using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace MyTestMVC.DataAccess
{
    public class RegionsRepository
    {
        public IEnumerable<SelectListItem> GetRegions(string state)
        {
            var regions = new List<SelectListItem>
            {
                new SelectListItem
                {
                    Value = "NJ",
                    Text = "New Jersey region"
                },
                new SelectListItem
                {
                    Value = "NY",
                    Text = "New York region 1"
                },
                new SelectListItem
                {
                    Value = "NY",
                    Text = "New York region 2"
                },
                new SelectListItem
                {
                    Value = "NH",
                    Text = "New Hampshire region"
                }
            };
            return new SelectList(regions.Where(i => i.Value.Equals(state)), "Value", "Text");
        }

        public IEnumerable<SelectListItem> GetRegions()
        {
            return new List<SelectListItem>
            {
                new SelectListItem
                {
                    Value = null,
                    Text = " "
                }
            };
        }
    }
}