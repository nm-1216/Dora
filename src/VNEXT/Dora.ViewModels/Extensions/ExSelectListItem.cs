namespace Dora.ViewModels.Extensions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc.Rendering;

    public static class ExSelectListItem
    {
        public static List<SelectListItem> ToSelectListItem(this Enum valueEnum)
        {
            return (from int value in Enum.GetValues(valueEnum.GetType())
                    select new SelectListItem
                    {
                        Text = Enum.GetName(valueEnum.GetType(), value),
                        Value = value.ToString()
                    }).ToList();
        }

        public static List<SelectListItem> ToSelectListItem(this Enum valueEnum, string selectName)
        {
            return (from int value in Enum.GetValues(valueEnum.GetType())
                    select new SelectListItem
                    {
                        Text = Enum.GetName(valueEnum.GetType(), value),
                        Value = value.ToString(),
                        Selected = Enum.GetName(valueEnum.GetType(), value) == selectName ? true : false
                    }).ToList();
        }
    }
}
