
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoList.Services;

namespace TodoList.Project.Extensions
{
    /// <summary>
    /// 自定义TagHelper,关于taghelper可以参考http://www.cnblogs.com/TomXu/p/4496480.html
    /// 前端使用类似
    /// <code>
    ///     <country-list selected-value="@Model.Country"></country-list>
    /// </code>
    /// </summary>
    [HtmlTargetElement("country-lists")]
    public class CountryListTagHelper : TagHelper
    {
        private readonly ICountryService _countryService;

        public string SelectedValue { get; set; }
        public CountryListTagHelper(ICountryService countryService)
        {
            _countryService = countryService;
        }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "select";
            output.Content.Clear();

            foreach (var item in _countryService.GetAll())
            {
                var seleted = "";
                if (SelectedValue != null && SelectedValue.Equals(item.Code, StringComparison.CurrentCultureIgnoreCase))
                {
                    seleted = " selected=\"selected\"";
                }

                var listItem = $"<option value=\"{item.Code}\"{seleted}>{item.CnName}-{item.enName}</option>";
                output.Content.AppendHtml(listItem);

            }

            //base.Process(context, output);
        }
    }
}
