#pragma checksum "E:\Website\whatsrank\Website\Areas\Co\Pages\VtyStar\Option.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "5840458f6a6d3ca9ad963e76bbe93501c0751100"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(Website.Areas.Co.Pages.VtyStar.Areas_Co_Pages_VtyStar_Option), @"mvc.1.0.razor-page", @"/Areas/Co/Pages/VtyStar/Option.cshtml")]
namespace Website.Areas.Co.Pages.VtyStar
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5840458f6a6d3ca9ad963e76bbe93501c0751100", @"/Areas/Co/Pages/VtyStar/Option.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"952ea22fad557f5ba49f83df3a1dd48a13e1401f", @"/Areas/Co/Pages/_ViewImports.cshtml")]
    public class Areas_Co_Pages_VtyStar_Option : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
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
#line 3 "E:\Website\whatsrank\Website\Areas\Co\Pages\VtyStar\Option.cshtml"
  
    ViewBag.Title = "options";
    var createUrl = Url.Page("", "Create");

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("partial", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "5840458f6a6d3ca9ad963e76bbe93501c07511004480", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Name = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
#nullable restore
#line 7 "E:\Website\whatsrank\Website\Areas\Co\Pages\VtyStar\Option.cshtml"
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
            WriteLiteral("\r\n<div class=\"table-container\">\r\n    <div class=\"table-container-header\">\r\n        <button class=\"btn btn-outline-dark\" onclick=\'ajaxLoadPartialForm(this)\' data-title=\"???????????? ??????????\"\r\n            data-url=\'");
#nullable restore
#line 11 "E:\Website\whatsrank\Website\Areas\Co\Pages\VtyStar\Option.cshtml"
                 Write(createUrl);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"'>
            ????????????
        </button>
    </div>
    <div class=""table-responsive"" id=""dataList"">

        <table class=""table table-bordered table-striped"">
            <caption class=""table-caption""></caption>
            <thead>
                <tr>
                    <th scope=""col"">#</th>
                    <th scope=""col"">??????????</th>
                    <th scope=""col"">????????</th>
                    <th scope=""col"">????????????</th>
                </tr>
            </thead>
            <tbody>
");
#nullable restore
#line 28 "E:\Website\whatsrank\Website\Areas\Co\Pages\VtyStar\Option.cshtml"
                 if (Model.List.Any())
                {
                    

#line default
#line hidden
#nullable disable
#nullable restore
#line 30 "E:\Website\whatsrank\Website\Areas\Co\Pages\VtyStar\Option.cshtml"
                     foreach (var item in Model.List)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <tr>\r\n                            <td>");
#nullable restore
#line 33 "E:\Website\whatsrank\Website\Areas\Co\Pages\VtyStar\Option.cshtml"
                           Write(item.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            <td>");
#nullable restore
#line 34 "E:\Website\whatsrank\Website\Areas\Co\Pages\VtyStar\Option.cshtml"
                           Write(item.Option);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            <td>");
#nullable restore
#line 35 "E:\Website\whatsrank\Website\Areas\Co\Pages\VtyStar\Option.cshtml"
                           Write(item.VoteCount);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            <td data-change>\r\n                                <div>\r\n                                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "5840458f6a6d3ca9ad963e76bbe93501c07511008449", async() => {
                WriteLiteral("\r\n                                        <input type=\"hidden\" name=\"id\"");
                BeginWriteAttribute("value", " value=\"", 1572, "\"", 1588, 1);
#nullable restore
#line 40 "E:\Website\whatsrank\Website\Areas\Co\Pages\VtyStar\Option.cshtml"
WriteAttributeValue("", 1580, item.Id, 1580, 8, false);

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
            AddHtmlAttributeValue("", 1385, "return", 1385, 6, true);
            AddHtmlAttributeValue(" ", 1391, "confirm(\'??????", 1392, 13, true);
            AddHtmlAttributeValue(" ", 1404, "????", 1405, 3, true);
            AddHtmlAttributeValue(" ", 1407, "??????", 1408, 4, true);
#nullable restore
#line 38 "E:\Website\whatsrank\Website\Areas\Co\Pages\VtyStar\Option.cshtml"
AddHtmlAttributeValue(" ", 1411, item.Option, 1412, 12, false);

#line default
#line hidden
#nullable disable
            AddHtmlAttributeValue(" ", 1424, "??????????", 1425, 6, true);
            AddHtmlAttributeValue(" ", 1430, "????????????\')", 1431, 9, true);
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
#line 48 "E:\Website\whatsrank\Website\Areas\Co\Pages\VtyStar\Option.cshtml"
                    }

#line default
#line hidden
#nullable disable
#nullable restore
#line 48 "E:\Website\whatsrank\Website\Areas\Co\Pages\VtyStar\Option.cshtml"
                     
                }
                else
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <tr data-span></tr>\r\n");
#nullable restore
#line 53 "E:\Website\whatsrank\Website\Areas\Co\Pages\VtyStar\Option.cshtml"
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Website.Areas.Co.Pages.VtyStar.OptionModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<Website.Areas.Co.Pages.VtyStar.OptionModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<Website.Areas.Co.Pages.VtyStar.OptionModel>)PageContext?.ViewData;
        public Website.Areas.Co.Pages.VtyStar.OptionModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591
