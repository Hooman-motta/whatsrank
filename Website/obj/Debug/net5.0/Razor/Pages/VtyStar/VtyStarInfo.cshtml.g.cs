#pragma checksum "E:\Website\whatsrank\Website\Pages\VtyStar\VtyStarInfo.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "88276fb237b9f584b1d63596487d196e88cf5bce"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Pages_VtyStar_VtyStarInfo), @"mvc.1.0.razor-page", @"/Pages/VtyStar/VtyStarInfo.cshtml")]
namespace AspNetCore
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
#line 1 "E:\Website\whatsrank\Website\Pages\_ViewImports.cshtml"
using System.Net;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "E:\Website\whatsrank\Website\Pages\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "E:\Website\whatsrank\Website\Pages\_ViewImports.cshtml"
using Website;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "E:\Website\whatsrank\Website\Pages\_ViewImports.cshtml"
using Website.Helper.Utils;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "E:\Website\whatsrank\Website\Pages\_ViewImports.cshtml"
using Website.Helper.Vmodel;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "E:\Website\whatsrank\Website\Pages\_ViewImports.cshtml"
using Website.Service.SrcIdentity.Configure;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "E:\Website\whatsrank\Website\Pages\_ViewImports.cshtml"
using Website.Service.SrcIdentity.UserManager;

#line default
#line hidden
#nullable disable
#nullable restore
#line 12 "E:\Website\whatsrank\Website\Pages\_ViewImports.cshtml"
using DbLayer.Enums;

#line default
#line hidden
#nullable disable
#nullable restore
#line 13 "E:\Website\whatsrank\Website\Pages\_ViewImports.cshtml"
using DbLayer.Identity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 14 "E:\Website\whatsrank\Website\Pages\_ViewImports.cshtml"
using DbLayer.Helper;

#line default
#line hidden
#nullable disable
#nullable restore
#line 17 "E:\Website\whatsrank\Website\Pages\_ViewImports.cshtml"
using HpLayer.Extensions;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemMetadataAttribute("RouteTemplate", "{id}")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"88276fb237b9f584b1d63596487d196e88cf5bce", @"/Pages/VtyStar/VtyStarInfo.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0465593bec2ec7cb4f945f38a3d60667992e4ecc", @"/Pages/_ViewImports.cshtml")]
    public class Pages_VtyStar_VtyStarInfo : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", "_Options", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("m-auto my-2"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-page", "/VtyStar/VtyStarInfo", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-page-handler", "SetComment", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("data-ajax", new global::Microsoft.AspNetCore.Html.HtmlString("true"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("data-ajax-method", new global::Microsoft.AspNetCore.Html.HtmlString("post"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("data-ajax-begin", new global::Microsoft.AspNetCore.Html.HtmlString("ajaxBegin"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("data-ajax-complete", new global::Microsoft.AspNetCore.Html.HtmlString("ajaxCmpSetComment"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_8 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("data-ajax-failure", new global::Microsoft.AspNetCore.Html.HtmlString("ajaxFailure"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            WriteLiteral("\r\n");
#nullable restore
#line 4 "E:\Website\whatsrank\Website\Pages\VtyStar\VtyStarInfo.cshtml"
  
    ViewBag.Title = Model.List.Title;
    ViewBag.MetaKeywords = Model.List.KeyWord;

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h4 class=\"page-title\">\r\n    ");
#nullable restore
#line 10 "E:\Website\whatsrank\Website\Pages\VtyStar\VtyStarInfo.cshtml"
Write(Model.List.Question);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n</h4>\r\n\r\n<section class=\"page-info vtystar-info\">\r\n    <div class=\"row top-page\">\r\n        <div class=\"col-12 col-md-6 right\">\r\n            <div class=\"right-options\">\r\n                <img");
            BeginWriteAttribute("src", " src=\"", 399, "\"", 428, 1);
#nullable restore
#line 17 "E:\Website\whatsrank\Website\Pages\VtyStar\VtyStarInfo.cshtml"
WriteAttributeValue("", 405, Model.List.FriendlyUrl, 405, 23, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("alt", " alt=\"", 429, "\"", 452, 1);
#nullable restore
#line 17 "E:\Website\whatsrank\Website\Pages\VtyStar\VtyStarInfo.cshtml"
WriteAttributeValue("", 435, Model.List.Title, 435, 17, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                <h6 class=\"title\">");
#nullable restore
#line 18 "E:\Website\whatsrank\Website\Pages\VtyStar\VtyStarInfo.cshtml"
                             Write(Model.List.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h6>\r\n            </div>\r\n        </div>\r\n        <article class=\"col-12 col-md-6 left\">\r\n            <div class=\"left-options\">\r\n                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("partial", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "88276fb237b9f584b1d63596487d196e88cf5bce9797", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Name = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
#nullable restore
#line 23 "E:\Website\whatsrank\Website\Pages\VtyStar\VtyStarInfo.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Model = Model.List.Options;

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
            WriteLiteral("\r\n            </div>\r\n        </article>\r\n    </div>\r\n\r\n    <div class=\"middle-page\">\r\n        <div class=\"row\">\r\n            <div class=\"col-sm-12 col-md-6 px-4\" style=\"text-align: justify;line-height: 2;\">\r\n                ");
#nullable restore
#line 31 "E:\Website\whatsrank\Website\Pages\VtyStar\VtyStarInfo.cshtml"
           Write(Html.Raw(WebUtility.HtmlDecode(Model.List.Source)));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </div>\r\n            <div class=\"col-sm-12 col-md-6\">\r\n                <div class=\"h_iframe-aparat_embed_frame\">\r\n                    <span style=\"display: block;padding-top: 57%\"></span>\r\n                    <iframe");
            BeginWriteAttribute("src", " src=\"", 1214, "\"", 1240, 1);
#nullable restore
#line 36 "E:\Website\whatsrank\Website\Pages\VtyStar\VtyStarInfo.cshtml"
WriteAttributeValue("", 1220, Model.List.VideoUrl, 1220, 20, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("title", " title=\"", 1241, "\"", 1266, 1);
#nullable restore
#line 36 "E:\Website\whatsrank\Website\Pages\VtyStar\VtyStarInfo.cshtml"
WriteAttributeValue("", 1249, Model.List.Title, 1249, 17, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@" allowFullScreen=""true""
                        webkitallowfullscreen=""true"" mozallowfullscreen=""true"">
                    </iframe>
                </div>
            </div>
        </div>
    </div>

    <div class=""comment-page"">
        <div class=""section-title m-0"">
            <i class=""las""></i>
            <span>نظرات</span>
        </div>

");
#nullable restore
#line 50 "E:\Website\whatsrank\Website\Pages\VtyStar\VtyStarInfo.cshtml"
         if (!User.Identity.IsAuthenticated)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <div class=\"d-flex justify-content-start m-3\">\r\n                <b class=\"no-auth\">برای ثبت رای ابتدا وارد شوید.</b>\r\n            </div>\r\n");
#nullable restore
#line 55 "E:\Website\whatsrank\Website\Pages\VtyStar\VtyStarInfo.cshtml"
        }
        else
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "88276fb237b9f584b1d63596487d196e88cf5bce13759", async() => {
                WriteLiteral(@"
                <div class=""form-floating my-3"">
                    <textarea class=""w-100"" name=""extract"" placeholder=""شرح نظر..."" rows=""5"" cols=""30""></textarea>
                </div>
                <button type=""submit"" class=""btn-submit"">ثبت نظر</button>
            ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Page = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.PageHandler = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_6);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_7);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_8);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 66 "E:\Website\whatsrank\Website\Pages\VtyStar\VtyStarInfo.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("        <ul class=\"list-group\">\r\n");
#nullable restore
#line 68 "E:\Website\whatsrank\Website\Pages\VtyStar\VtyStarInfo.cshtml"
             foreach (var item in Model.List.Comments)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <li class=\"list-group-item\">\r\n                    <div class=\"user-info\">\r\n                        <b class=\"username\">");
#nullable restore
#line 72 "E:\Website\whatsrank\Website\Pages\VtyStar\VtyStarInfo.cshtml"
                                       Write(item.DisplayName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</b>\r\n                        <small class=\"date\">\r\n                            ");
#nullable restore
#line 74 "E:\Website\whatsrank\Website\Pages\VtyStar\VtyStarInfo.cshtml"
                       Write(item.PersianCreatedDate);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </small>\r\n                    </div>\r\n                    <p class=\"extract-info\">\r\n                        ");
#nullable restore
#line 78 "E:\Website\whatsrank\Website\Pages\VtyStar\VtyStarInfo.cshtml"
                   Write(item.Extract);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </p>\r\n                </li>\r\n");
#nullable restore
#line 81 "E:\Website\whatsrank\Website\Pages\VtyStar\VtyStarInfo.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </ul>\r\n    </div>\r\n</section>\r\n\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral("\r\n<script>\r\n</script>\r\n");
            }
            );
            WriteLiteral(@"
<style>
    .h_iframe-aparat_embed_frame {
        position: relative;
    }

    .h_iframe-aparat_embed_frame .ratio {
        display: block;
        width: 100%;
        height: auto;
    }

    .h_iframe-aparat_embed_frame iframe {
        position: absolute;
        top: 0;
        left: 0;
        width: 100%;
        height: 100%;
    }
</style>
");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Website.Pages.VtyStar.VtyStarInfoModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<Website.Pages.VtyStar.VtyStarInfoModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<Website.Pages.VtyStar.VtyStarInfoModel>)PageContext?.ViewData;
        public Website.Pages.VtyStar.VtyStarInfoModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591