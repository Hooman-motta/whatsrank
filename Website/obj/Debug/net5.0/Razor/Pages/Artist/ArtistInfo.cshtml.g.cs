#pragma checksum "E:\Website\whatsrank\Website\Pages\Artist\ArtistInfo.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "41a251b9a53b4c7a6e03e41cbdde48ef6d78aeb2"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Pages_Artist_ArtistInfo), @"mvc.1.0.razor-page", @"/Pages/Artist/ArtistInfo.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"41a251b9a53b4c7a6e03e41cbdde48ef6d78aeb2", @"/Pages/Artist/ArtistInfo.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0465593bec2ec7cb4f945f38a3d60667992e4ecc", @"/Pages/_ViewImports.cshtml")]
    public class Pages_Artist_ArtistInfo : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("name-link"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-page", "/Movie/MovieInfo", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", "_VoteSelect", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("more"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-page", "/Artist/ArtistInfo", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/libs/swiper/swiper.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 3 "E:\Website\whatsrank\Website\Pages\Artist\ArtistInfo.cshtml"
  
    ViewBag.Title = Model.ViewResult.FullName;
    ViewBag.MetaKeywords = Model.ViewResult.KeyWord;

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<section class=\"page-info artist-info\">\r\n    <div class=\"row top-page\">\r\n        <div class=\"col-12 col-md-3 right\">\r\n            <img");
            BeginWriteAttribute("src", " src=\"", 304, "\"", 339, 1);
#nullable restore
#line 11 "E:\Website\whatsrank\Website\Pages\Artist\ArtistInfo.cshtml"
WriteAttributeValue("", 310, Model.ViewResult.FriendlyUrl, 310, 29, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("alt", " alt=\"", 340, "\"", 372, 1);
#nullable restore
#line 11 "E:\Website\whatsrank\Website\Pages\Artist\ArtistInfo.cshtml"
WriteAttributeValue("", 346, Model.ViewResult.FullName, 346, 26, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n        </div>\r\n\r\n        <article class=\"col-12 col-md-8 left\">\r\n            <header class=\"left-top\">\r\n                <div class=\"caption\">\r\n                    <h4 class=\"caption-title\">\r\n                        ");
#nullable restore
#line 18 "E:\Website\whatsrank\Website\Pages\Artist\ArtistInfo.cshtml"
                   Write(Model.ViewResult.FullName);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </h4>\r\n                    <div class=\"caption-detail\">\r\n                        <span>\r\n                            ");
#nullable restore
#line 22 "E:\Website\whatsrank\Website\Pages\Artist\ArtistInfo.cshtml"
                       Write(Model.ViewResult.CinemaRoles);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </span>\r\n                        <span>\r\n                            ?????????? :\r\n                            ");
#nullable restore
#line 26 "E:\Website\whatsrank\Website\Pages\Artist\ArtistInfo.cshtml"
                       Write(Model.ViewResult.BirthDate);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </span>\r\n                    </div>\r\n                </div>\r\n                <div class=\"vote\">\r\n                    <i class=\"las la-star\"></i>\r\n                    <small>\r\n                        <b>");
#nullable restore
#line 33 "E:\Website\whatsrank\Website\Pages\Artist\ArtistInfo.cshtml"
                      Write(Model.Vote.DisplayVoteAverage);

#line default
#line hidden
#nullable disable
            WriteLiteral("</b>\r\n                        <b>");
#nullable restore
#line 34 "E:\Website\whatsrank\Website\Pages\Artist\ArtistInfo.cshtml"
                      Write(Model.Vote.VoteCount);

#line default
#line hidden
#nullable disable
            WriteLiteral(@" ??????</b>
                    </small>
                </div>
            </header>

            <div class=""left-summary"">
                <h6 class=""title"">
                    ???????????????? :
                </h6>
                <p class=""bio"">
                    ");
#nullable restore
#line 44 "E:\Website\whatsrank\Website\Pages\Artist\ArtistInfo.cshtml"
               Write(Model.ViewResult.Bio);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </p>\r\n            </div>\r\n        </article>\r\n    </div>\r\n\r\n    <div class=\"middle-page\">\r\n        <!-- ???????????????? -->\r\n        <div class=\"section-title\">\r\n            <i class=\"las\"></i>\r\n            <span>???????? ");
#nullable restore
#line 54 "E:\Website\whatsrank\Website\Pages\Artist\ArtistInfo.cshtml"
                  Write(Model.ViewResult.FullName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n        </div>\r\n\r\n        <div class=\"middle-content\">\r\n");
#nullable restore
#line 58 "E:\Website\whatsrank\Website\Pages\Artist\ArtistInfo.cshtml"
             foreach (var item in Model.ViewResult.Movie.ToList())
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <div class=\"box small-box\">\r\n                    <div class=\"top-box\">\r\n                        <img");
            BeginWriteAttribute("src", " src=\"", 2070, "\"", 2093, 1);
#nullable restore
#line 62 "E:\Website\whatsrank\Website\Pages\Artist\ArtistInfo.cshtml"
WriteAttributeValue("", 2076, item.FriendlyUrl, 2076, 17, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("alt", " alt=\"", 2094, "\"", 2116, 1);
#nullable restore
#line 62 "E:\Website\whatsrank\Website\Pages\Artist\ArtistInfo.cshtml"
WriteAttributeValue("", 2100, item.MovieTitle, 2100, 16, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@">
                    </div>
                    <div class=""bottom-box"">
                        <div class=""vote"">
                            <small class=""avg"">
                                <i class=""las la-star""></i>
                                <b>");
#nullable restore
#line 68 "E:\Website\whatsrank\Website\Pages\Artist\ArtistInfo.cshtml"
                              Write(item.DisplayVoteAverage);

#line default
#line hidden
#nullable disable
            WriteLiteral("</b>\r\n                            </small>\r\n                        </div>\r\n                        <div class=\"caption\">\r\n                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "41a251b9a53b4c7a6e03e41cbdde48ef6d78aeb212677", async() => {
                WriteLiteral("\r\n                                <b class=\"name\">");
#nullable restore
#line 74 "E:\Website\whatsrank\Website\Pages\Artist\ArtistInfo.cshtml"
                                           Write(item.MovieTitle);

#line default
#line hidden
#nullable disable
                WriteLiteral("</b>\r\n                            ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Page = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 72 "E:\Website\whatsrank\Website\Pages\Artist\ArtistInfo.cshtml"
                                                                               WriteLiteral(item.MovieId);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            BeginWriteTagHelperAttribute();
#nullable restore
#line 73 "E:\Website\whatsrank\Website\Pages\Artist\ArtistInfo.cshtml"
                                 WriteLiteral(item.MovieTitle.ToFriendlyRoute());

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["title"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-title", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["title"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                            <b class=\"role\">");
#nullable restore
#line 76 "E:\Website\whatsrank\Website\Pages\Artist\ArtistInfo.cshtml"
                                       Write(item.RoleInMovie);

#line default
#line hidden
#nullable disable
            WriteLiteral("</b>\r\n                        </div>\r\n                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("partial", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "41a251b9a53b4c7a6e03e41cbdde48ef6d78aeb216316", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Name = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
#nullable restore
#line 78 "E:\Website\whatsrank\Website\Pages\Artist\ArtistInfo.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Model = new VoteSelectVm{
                            ItemId=item.AMRId,
                            MarkValue=item.UserMark,
                            RouteId=item.MovieId,
                            HandlerUrl="ArtistVote",
                            PageUrl="/Movie/MovieInfo",
                            UqId="amr"
                        };

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext.AddTagHelperAttribute("model", __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Model, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.SingleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                    </div>\r\n                </div>\r\n");
#nullable restore
#line 88 "E:\Website\whatsrank\Website\Pages\Artist\ArtistInfo.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"        </div>
    </div>

    <!-- ???????????? ?????? ?????????? -->
    <div class=""similar-page"">
        <div class=""section-title"">
            <i class=""las""></i>
            <span>???????????? ?????? ??????????</span>
        </div>

        <div class=""swiper-container mySwiper"">
            <div class=""swiper-wrapper"">
");
#nullable restore
#line 101 "E:\Website\whatsrank\Website\Pages\Artist\ArtistInfo.cshtml"
                 foreach (var item in Model.ViewResult.SimilarArtist)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <div class=\"swiper-slide\">\r\n                        <div class=\"box\">\r\n                            <div class=\"top-box\">\r\n                                <img");
            BeginWriteAttribute("src", " src=\"", 3986, "\"", 4009, 1);
#nullable restore
#line 106 "E:\Website\whatsrank\Website\Pages\Artist\ArtistInfo.cshtml"
WriteAttributeValue("", 3992, item.FriendlyUrl, 3992, 17, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("alt", " alt=\"", 4010, "\"", 4030, 1);
#nullable restore
#line 106 "E:\Website\whatsrank\Website\Pages\Artist\ArtistInfo.cshtml"
WriteAttributeValue("", 4016, item.FullName, 4016, 14, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                            </div>\r\n                            <div class=\"bottom-box\">\r\n                                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "41a251b9a53b4c7a6e03e41cbdde48ef6d78aeb220022", async() => {
                WriteLiteral("\r\n                                    <b class=\"name\">");
#nullable restore
#line 111 "E:\Website\whatsrank\Website\Pages\Artist\ArtistInfo.cshtml"
                                               Write(item.FullName);

#line default
#line hidden
#nullable disable
                WriteLiteral("</b>\r\n                                ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Page = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 109 "E:\Website\whatsrank\Website\Pages\Artist\ArtistInfo.cshtml"
                                                                                WriteLiteral(item.ArtistId);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            BeginWriteTagHelperAttribute();
#nullable restore
#line 110 "E:\Website\whatsrank\Website\Pages\Artist\ArtistInfo.cshtml"
                                     WriteLiteral(item.FullName.ToFriendlyRoute());

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["title"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-title", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["title"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                            </div>\r\n                        </div>\r\n                    </div>\r\n");
#nullable restore
#line 116 "E:\Website\whatsrank\Website\Pages\Artist\ArtistInfo.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("            </div>\r\n        </div>\r\n    </div>\r\n</section>\r\n\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral("\r\n");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "41a251b9a53b4c7a6e03e41cbdde48ef6d78aeb223789", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n<script>\r\n    const count = swipperCount();\r\n    new Swiper(\".mySwiper\", {\r\n        spaceBetween: 30,\r\n        slidesPerView: count\r\n    });\r\n</script>\r\n");
            }
            );
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Website.Pages.Artist.ArtistInfoModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<Website.Pages.Artist.ArtistInfoModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<Website.Pages.Artist.ArtistInfoModel>)PageContext?.ViewData;
        public Website.Pages.Artist.ArtistInfoModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591
