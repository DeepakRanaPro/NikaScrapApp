using Microsoft.AspNetCore.Mvc.Rendering;
using NikaScrapApp.Web.Models.Response;

namespace NikaScrapApp.Web.Utility.Extensions
{
    public static class DropdownExtensions
    {
        public static List<SelectListItem> InitializeDropdown(this List<SelectListItem> dropdownList, List<MasterData> dataSource, string dropdownType)
        {
            dropdownList = new List<SelectListItem>
        {
            new SelectListItem { Text = $"All {dropdownType}", Value = "0", Selected = true }
        };

            dropdownList.AddRange(dataSource
                .Where(x => x.Type == dropdownType)
                .Select(item => new SelectListItem { Text = item.Name, Value = item.Id.ToString() })
            );

            return dropdownList;
        }

        public static List<SelectListItem> InitializeDropdownWithDefaultValue(List<MasterData> dataSource, string dropdownType) 
        {
           var dropdownList = new List<SelectListItem>
        {
            new SelectListItem { Text = $"All {dropdownType}", Value = "0"}
        };

            dropdownList.AddRange(dataSource
                .Where(x => x.Type == dropdownType)
                .Select(item => new SelectListItem { Text = item.Name, Value = item.Id.ToString() })
            );

            return dropdownList;
        }

        public static List<SelectListItem> InitializeDropdown(List<MasterData> dataSource, string dropdownType)
        {
            var dropdownList = new List<SelectListItem>
        {
            new SelectListItem { Text = $"Select {dropdownType}", Value = string.Empty}
        };

            dropdownList.AddRange(dataSource
                .Where(x => x.Type == dropdownType)
                .Select(item => new SelectListItem { Text = item.Name, Value = item.Id.ToString() })
            );

            return dropdownList;
        }

        public static List<SelectListItem> InitializeDropdownWithOutDefaultValue(List<MasterData> dataSource, string dropdownType)
        {
            var dropdownList = new List<SelectListItem>();

            dropdownList.AddRange(dataSource
                .Where(x => x.Type == dropdownType)
                .Select(item => new SelectListItem { Text = item.Name, Value = item.Id.ToString() })
            );

            return dropdownList;
        }
    }
}
