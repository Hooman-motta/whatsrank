#pragma checksum "E:\Website\whatsrank\Website\Areas\Co\Pages\Province\City.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "9a2e387ca925c3e0a06363abba0e8b6d5957a3dd"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(Website.Areas.Co.Pages.Province.Areas_Co_Pages_Province_City), @"mvc.1.0.razor-page", @"/Areas/Co/Pages/Province/City.cshtml")]
namespace Website.Areas.Co.Pages.Province
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 4 "E:\Website\whatsrank\Website\Areas\Co\Pages\_ViewImports.cshtml"
using Website.Helper.Utils;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "E:\Website\whatsrank\Website\Areas\Co\Pages\_ViewImports.cshtml"
using DbLayer.Enums;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "E:\Website\whatsrank\Website\Areas\Co\Pages\_ViewImports.cshtml"
using HpLayer.Extensions;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemMetadataAttribute("RouteTemplate", "{id}")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9a2e387ca925c3e0a06363abba0e8b6d5957a3dd", @"/Areas/Co/Pages/Province/City.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"952ea22fad557f5ba49f83df3a1dd48a13e1401f", @"/Areas/Co/Pages/_ViewImports.cshtml")]
    public class Areas_Co_Pages_Province_City : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", "_Alert", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-page-handler", "remove", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 3 "E:\Website\whatsrank\Website\Areas\Co\Pages\Province\City.cshtml"
  
    ViewBag.Title = "city";
    var createUrl = Url.Page("", "Create");

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("partial", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "9a2e387ca925c3e0a06363abba0e8b6d5957a3dd4473", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Name = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
#nullable restore
#line 7 "E:\Website\whatsrank\Website\Areas\Co\Pages\Province\City.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Model = Model.Alert;

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext.AddTagHelperAttribute("model", __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Model, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n<div class=\"table-container\">\r\n    <div class=\"table-container-header\">\r\n        <button class=\"btn btn-outline-dark\" onclick=\'ajaxLoadPartialForm(this)\' data-title=\"افزودن شهر\"\r\n            data-url=\'");
#nullable restore
#line 11 "E:\Website\whatsrank\Website\Areas\Co\Pages\Province\City.cshtml"
                 Write(createUrl);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"'>
            افزودن
        </button>
    </div>
    <div class=""table-responsive"" id=""dataList"">
        <table class=""table table-bordered table-striped"">
            <caption class=""table-caption""></caption>
            <thead>
                <tr>
                    <th>#</th>
                    <th>شهر</th>
                    <th>عملیات</th>
                </tr>
            </thead>
            <tbody>
");
#nullable restore
#line 26 "E:\Website\whatsrank\Website\Areas\Co\Pages\Province\City.cshtml"
                 if (Model.List.Any())
                {
                    foreach (var item in Model.List)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <tr>\r\n                            <td>");
#nullable restore
#line 31 "E:\Website\whatsrank\Website\Areas\Co\Pages\Province\City.cshtml"
                           Write(item.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            <td>");
#nullable restore
#line 32 "E:\Website\whatsrank\Website\Areas\Co\Pages\Province\City.cshtml"
                           Write(item.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            <td data-change>\r\n                                <div>\r\n                                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "9a2e387ca925c3e0a06363abba0e8b6d5957a3dd7899", async() => {
                WriteLiteral("\r\n                                        <input type=\"hidden\" name=\"id\"");
                BeginWriteAttribute("value", " value=\"", 1422, "\"", 1438, 1);
#nullable restore
#line 37 "E:\Website\whatsrank\Website\Areas\Co\Pages\Province\City.cshtml"
WriteAttributeValue("", 1430, item.Id, 1430, 8, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(">\r\n                                        <button type=\"submit\" data-trash>\r\n                                            <i class=\"las\"></i>\r\n                                        </button>\r\n                                    ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "onsubmit", 7, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 1236, "return", 1236, 6, true);
            AddHtmlAttributeValue(" ", 1242, "confirm(\'آیا", 1243, 13, true);
            AddHtmlAttributeValue(" ", 1255, "از", 1256, 3, true);
            AddHtmlAttributeValue(" ", 1258, "حذف", 1259, 4, true);
#nullable restore
#line 35 "E:\Website\whatsrank\Website\Areas\Co\Pages\Province\City.cshtml"
AddHtmlAttributeValue(" ", 1262, item.Title, 1263, 11, false);

#line default
#line hidden
#nullable disable
            AddHtmlAttributeValue(" ", 1274, "مطمئن", 1275, 6, true);
            AddHtmlAttributeValue(" ", 1280, "هستید؟\')", 1281, 9, true);
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.PageHandler = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                                </div>\r\n                            </td>\r\n                        </tr>\r\n");
#nullable restore
#line 45 "E:\Website\whatsrank\Website\Areas\Co\Pages\Province\City.cshtml"
                    }
                }
                else
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <tr data-span></tr>\r\n");
#nullable restore
#line 50 "E:\Website\whatsrank\Website\Areas\Co\Pages\Province\City.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("            </tbody>\r\n        </table>\r\n    </div>\r\n</div>");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Website.Areas.Co.Pages.Province.CityModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<Website.Areas.Co.Pages.Province.CityModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<Website.Areas.Co.Pages.Province.CityModel>)PageContext?.ViewData;
        public Website.Areas.Co.Pages.Province.CityModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591
