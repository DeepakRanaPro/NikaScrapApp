using Microsoft.AspNetCore.Mvc.Rendering;
using NikaScrapApp.Web.Models.Response;

namespace NikaScrapApp.Web.Utility
{
    public static class DropdownInitializer
    {
        public static List<SelectListItem> Initialize(List<SelectListItem> dropdownList, List<MasterData> dataSource, string dropdownType)
        {
            dropdownList = new List<SelectListItem>
                        {
                            new SelectListItem { Text = $"All {dropdownType}", Value = "0", Selected = true }
                        };

            foreach (var item in dataSource.Where(x => x.Type == dropdownType))
            {
                dropdownList.Add(new SelectListItem { Text = item.Name, Value = item.Id });
            }

            return dropdownList;
        }
    }
}
