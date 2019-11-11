using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PluralSightCoreProject_CityInfo.Entities;
using PluralSightCoreProject_CityInfo.Models;
using PluralSightCoreProject_CityInfo.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PluralSightCoreProject_CityInfo.Controllers
{
    [Route("api/cities")]
    [ApiController]
    public class PointsOfInterestController : Controller
    {
        private readonly ILogger<PointsOfInterestController> _logger;
        private readonly IMailService _mailService;
        private readonly ICityInfoRepository _cityInfoRepository;
        private readonly IMapper _mapper;

        public PointsOfInterestController(ILogger<PointsOfInterestController> logger, IMailService mailService, ICityInfoRepository cityInfoRepository, IMapper mapper)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(ILogger<PointsOfInterestController>));
            _mailService = mailService ?? throw new ArgumentNullException(nameof(IMailService));
            _cityInfoRepository = cityInfoRepository ?? throw new ArgumentNullException(nameof(ICityInfoRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(IMapper));

            _logger.LogInformation($"Creating a controller: '{nameof(PointsOfInterestController)}");
        }

        #region Actions

        [HttpGet("{cityId}/pointsofinterest")]
        public IActionResult GetPointsOfInterest(int cityId)
        {
            #region Dummy

            // dummy statements to check exception handling
            if (cityId > 10)
            {
                try
                {
                    throw new ArgumentOutOfRangeException($"CityId is greater than 10. It is:{cityId}");
                }
                catch (Exception ex)
                {
                    _logger.LogCritical($"{ex.Message}");
                    _mailService.Sent();
                    return StatusCode(500, "Manually triggered exception.");
                }
            }

            #endregion Dummy

            if (!_cityInfoRepository.CityExists(cityId))
            {
                _logger.LogInformation($"City with id '{cityId}' wasn't found in the repository.");
                return NotFound();
            }

            var pointsOfInterestForCity = _cityInfoRepository.GetPointOfInterestForCity(cityId);
            var results = _mapper.Map<IEnumerable<PointOfInterestsDto>>(pointsOfInterestForCity);

            return Ok(results);
        }

        [HttpGet("{cityId}/pointsofinterest/{id}", Name = "GetPointOfInterest")]
        public IActionResult GetPointOfInterest(int cityId, int id)
        {
            if (!_cityInfoRepository.CityExists(cityId))
            {
                return NotFound();
            }

            var pointOfInterest = _cityInfoRepository.GetPointOfInterestForCity(cityId, id);
            if (pointOfInterest == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<PointOfInterestsDto>(pointOfInterest));
        }

        [HttpPost("{cityId}/pointsofinterest")]
        public async Task<IActionResult> CreatePointOfInterest(int cityId, [FromBody] PointOfInterestForCreationDto dto)
        {
            if (dto == null)
            {
                return BadRequest();
            }

            if (!_cityInfoRepository.CityExists(cityId))
            {
                return NotFound();
            }

            var newPointOfInterest = _mapper.Map<PointOfInterest>(dto);
            _cityInfoRepository.AddPointOfInterestForCity(cityId, newPointOfInterest);

            if (!(await _cityInfoRepository.Save()))
            {
                return StatusCode(500, "Request wasn't saved.");
            }

            var createdPointOfInterest = _mapper.Map<PointOfInterestsDto>(newPointOfInterest);

            return CreatedAtRoute("GetPointOfInterest", new { cityId = cityId, id = newPointOfInterest.Id }, createdPointOfInterest);
        }

        [HttpPut("{cityId}/pointsofinterest/{id}")]
        public async Task<IActionResult> UpdatePointOfInterest(int cityId, int id, [FromBody] PointOfInterestUpdateDto pointOfInterestUpdateDto)
        {
            if (pointOfInterestUpdateDto == null)
            {
                return BadRequest();
            }

            if (pointOfInterestUpdateDto.Description == pointOfInterestUpdateDto.Name)
            {
                ModelState.AddModelError("Description", "The provided description should be different from name.");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!_cityInfoRepository.CityExists(cityId))
            {
                return NotFound();
            }

            var pointOfInterestEntity = _cityInfoRepository.GetPointOfInterestForCity(cityId, id);

            if (pointOfInterestEntity == null)
            {
                return NotFound();
            }

            _mapper.Map(pointOfInterestUpdateDto, pointOfInterestEntity);
            if (!await _cityInfoRepository.Save())
            {
                return StatusCode(500, "Some error occured upon saving updated DTO.");
            }

            return NoContent();
        }

        [HttpPatch("{cityId}/pointsofinterest/{id}")]
        public async Task<IActionResult> PartiallyUpdatePointOfInterest(int cityId, int id, [FromBody] JsonPatchDocument<PointOfInterestUpdateDto> patchDoc)
        {
            if (patchDoc == null)
            {
                return BadRequest();
            }

            if (!_cityInfoRepository.CityExists(cityId))
            {
                return NotFound();
            }

            var pointOfInterest = _cityInfoRepository.GetPointOfInterestForCity(cityId, id);

            if (pointOfInterest == null)
            {
                return NotFound();
            }

            var pointOfInterestToPatch = _mapper.Map<PointOfInterestUpdateDto>(pointOfInterest);

            patchDoc.ApplyTo(pointOfInterestToPatch, ModelState);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (pointOfInterestToPatch.Description == pointOfInterestToPatch.Name)
            {
                ModelState.AddModelError("Description", "The provided description should be different from name.");
            }

            TryValidateModel(pointOfInterestToPatch);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _mapper.Map(pointOfInterestToPatch, pointOfInterest);

            if (!await _cityInfoRepository.Save())
            {
                return StatusCode(500, "Some error occured upon saving patched DTO.");
            }

            return NoContent();
        }

        [HttpDelete("{cityId}/pointsofinterest/{id}")]
        public async Task<IActionResult> DeletePointOfInterest(int cityId, int id)
        {
            if (!_cityInfoRepository.CityExists(cityId))
            {
                return NotFound();
            }

            var pointOfInterest = _cityInfoRepository.GetPointOfInterestForCity(cityId, id);

            if (pointOfInterest == null)
            {
                return NotFound();
            }

            _cityInfoRepository.DeletePointOfInterest(pointOfInterest);

            if (!await _cityInfoRepository.Save())
            {
                return StatusCode(500, "Some error occured upon saving patched DTO.");
            }


            return NoContent();
        }

        #endregion Actions
    }
}