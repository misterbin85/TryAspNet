using System.Collections.Generic;
using System.Web.Mvc;

namespace MyTestMVC.DataAccess
{
    public class CountriesRepository
    {
        public IEnumerable<SelectListItem> GetCountries()
        {
            return new List<SelectListItem>
            {
                new SelectListItem
                {
                    Value = null, Text = "--- select country ---"
                },
                new SelectListItem
                {
                    Value = "NY", Text = "New York"
                },
                new SelectListItem
                {
                    Value = "NJ", Text = "New Jersey"
                },
                new SelectListItem
                {
                    Value = "NH", Text = "New Hampshire"
                }
            };
        }
    }
}