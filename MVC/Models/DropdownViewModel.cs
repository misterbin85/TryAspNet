using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace MyTestMVC.Models
{
    public class DropdownViewModel
    {
        [Required]
        [Display(Name = "Country")]
        public string SelectedCountry { get; set; }

        public IEnumerable<SelectListItem> Countries { get; set; }

        [Required]
        [Display(Name = "State / Region")]
        public string SelectedRegionCode { get; set; }

        public IEnumerable<SelectListItem> Regions { get; set; }
    }
}