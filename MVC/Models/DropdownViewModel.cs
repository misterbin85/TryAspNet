using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace MyTestMVC.Models
{
    public class DropdownViewModel
    {
        [Required]
        [Display(Name = "State")]
        public string SelectedState { get; set; }

        public IEnumerable<SelectListItem> States { get; set; }

        [Required]
        [Display(Name = "State / Region")]
        public string SelectedRegionCode { get; set; }

        public IEnumerable<SelectListItem> Regions { get; set; }
    }
}