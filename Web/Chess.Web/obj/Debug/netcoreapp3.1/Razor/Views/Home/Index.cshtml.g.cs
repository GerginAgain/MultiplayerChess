#pragma checksum "C:\Users\Again\Desktop\Chess\MultiplayerChess\Web\Chess.Web\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ecd2718566c5fd4e95813375ca6fb4cd633b12e6"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Index), @"mvc.1.0.view", @"/Views/Home/Index.cshtml")]
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
#line 1 "C:\Users\Again\Desktop\Chess\MultiplayerChess\Web\Chess.Web\Views\_ViewImports.cshtml"
using Chess.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Again\Desktop\Chess\MultiplayerChess\Web\Chess.Web\Views\_ViewImports.cshtml"
using Chess.Web.ViewModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\Again\Desktop\Chess\MultiplayerChess\Web\Chess.Web\Views\_ViewImports.cshtml"
using Chess.Web.ViewModels.InputModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\Again\Desktop\Chess\MultiplayerChess\Web\Chess.Web\Views\_ViewImports.cshtml"
using Chess.Web.ViewModels.ViewModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\Again\Desktop\Chess\MultiplayerChess\Web\Chess.Web\Views\_ViewImports.cshtml"
using Chess.Web.ViewModels.InputModels.Videos;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\Again\Desktop\Chess\MultiplayerChess\Web\Chess.Web\Views\_ViewImports.cshtml"
using Chess.Web.ViewModels.ViewModels.Videos;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\Users\Again\Desktop\Chess\MultiplayerChess\Web\Chess.Web\Views\_ViewImports.cshtml"
using Chess.Services.Paging;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Again\Desktop\Chess\MultiplayerChess\Web\Chess.Web\Views\Home\Index.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\Again\Desktop\Chess\MultiplayerChess\Web\Chess.Web\Views\Home\Index.cshtml"
using Chess.Data.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ecd2718566c5fd4e95813375ca6fb4cd633b12e6", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"20f8531668fcea0551deeb825923c4b0b61bb53e", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<LatestThreeAddedVideosViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/css/picture.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", "_AddToFavoritesModalPartial", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", "_RemoveFromFavoritesModalPartial", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/add-to-favorites-index.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "ecd2718566c5fd4e95813375ca6fb4cd633b12e66402", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\n<div class=\"row justify-content-center\">\n    <h1 class=\"text-primary\">Wellcome to Multiplayer Chess</h1>\n</div>\n<h3 class=\"mt-5 text-primary\">Latest Added Videos:</h3>\n<hr class=\"hr-chess\" />\n<div class=\"row\">\n");
#nullable restore
#line 13 "C:\Users\Again\Desktop\Chess\MultiplayerChess\Web\Chess.Web\Views\Home\Index.cshtml"
     for (int i = 0; i < Model.Videos.Count; i++)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <div class=\"col-lg-4 col-md-12 mb-4\">\n            <div class=\"row justify-content-center\">\n            <h3 class=\"text-primary\">");
#nullable restore
#line 17 "C:\Users\Again\Desktop\Chess\MultiplayerChess\Web\Chess.Web\Views\Home\Index.cshtml"
                                Write(Model.Videos[i].Title);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h3>\n            </div>\n");
#nullable restore
#line 19 "C:\Users\Again\Desktop\Chess\MultiplayerChess\Web\Chess.Web\Views\Home\Index.cshtml"
               
                var id = "modal" + i;
                var target = "#modal" + i; 
             

#line default
#line hidden
#nullable disable
            WriteLiteral("            <div class=\"modal fade\"");
            BeginWriteAttribute("id", " id=", 855, "", 862, 1);
#nullable restore
#line 23 "C:\Users\Again\Desktop\Chess\MultiplayerChess\Web\Chess.Web\Views\Home\Index.cshtml"
WriteAttributeValue("", 859, id, 859, 3, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@" tabindex=""-1"" role=""dialog"" aria-labelledby=""myModalLabel"" aria-hidden=""true"">
                <div class=""modal-dialog modal-lg"" role=""document"">
                    <div class=""modal-content"">
                        <div class=""modal-body mb-0 p-0"">
                            <div class=""embed-responsive embed-responsive-16by9 z-depth-1-half"">
                                <iframe class=""embed-responsive-item""");
            BeginWriteAttribute("src", " src=", 1282, "", 1308, 1);
#nullable restore
#line 28 "C:\Users\Again\Desktop\Chess\MultiplayerChess\Web\Chess.Web\Views\Home\Index.cshtml"
WriteAttributeValue("", 1287, Model.Videos[i].Link, 1287, 21, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@" allowfullscreen></iframe>
                            </div>
                        </div>
                        <div class=""modal-footer justify-content-center"">
                            <button type=""button"" class=""btn btn-outline-primary btn-rounded btn-md ml-4"" data-dismiss=""modal"">Close</button>
                        </div>
                    </div>
                </div>
            </div>
            <a>
                <img id=""video"" class=""getHover offset-2 z-depth-1""");
            BeginWriteAttribute("src", " src=\"", 1800, "\"", 1834, 1);
#nullable restore
#line 38 "C:\Users\Again\Desktop\Chess\MultiplayerChess\Web\Chess.Web\Views\Home\Index.cshtml"
WriteAttributeValue("", 1806, Model.Videos[i].PictureLink, 1806, 28, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("alt", " alt=\"", 1835, "\"", 1869, 1);
#nullable restore
#line 38 "C:\Users\Again\Desktop\Chess\MultiplayerChess\Web\Chess.Web\Views\Home\Index.cshtml"
WriteAttributeValue("", 1841, Model.Videos[i].PictureName, 1841, 28, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" data-toggle=\"modal\" data-target=");
#nullable restore
#line 38 "C:\Users\Again\Desktop\Chess\MultiplayerChess\Web\Chess.Web\Views\Home\Index.cshtml"
                                                                                                                                                                     Write(target);

#line default
#line hidden
#nullable disable
            WriteLiteral(">\n            </a>\n");
#nullable restore
#line 40 "C:\Users\Again\Desktop\Chess\MultiplayerChess\Web\Chess.Web\Views\Home\Index.cshtml"
             if (SignInManager.IsSignedIn(User))
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <div class=\"mt-2 offset-2\">\n");
#nullable restore
#line 43 "C:\Users\Again\Desktop\Chess\MultiplayerChess\Web\Chess.Web\Views\Home\Index.cshtml"
                 if (!(Model.Videos[i].IsInFavourites))
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <i");
            BeginWriteAttribute("id", " id=\"", 2132, "\"", 2156, 1);
#nullable restore
#line 45 "C:\Users\Again\Desktop\Chess\MultiplayerChess\Web\Chess.Web\Views\Home\Index.cshtml"
WriteAttributeValue("", 2137, Model.Videos[i].Id, 2137, 19, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"far fa-star fa-3x text-warning getHover\"></i> \n");
#nullable restore
#line 46 "C:\Users\Again\Desktop\Chess\MultiplayerChess\Web\Chess.Web\Views\Home\Index.cshtml"
                }
                else
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <i");
            BeginWriteAttribute("id", " id=\"", 2291, "\"", 2315, 1);
#nullable restore
#line 49 "C:\Users\Again\Desktop\Chess\MultiplayerChess\Web\Chess.Web\Views\Home\Index.cshtml"
WriteAttributeValue("", 2296, Model.Videos[i].Id, 2296, 19, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"fas fa-star fa-3x text-warning getHover\"></i>\n");
#nullable restore
#line 50 "C:\Users\Again\Desktop\Chess\MultiplayerChess\Web\Chess.Web\Views\Home\Index.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("                </div>\n");
#nullable restore
#line 52 "C:\Users\Again\Desktop\Chess\MultiplayerChess\Web\Chess.Web\Views\Home\Index.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </div>\n");
#nullable restore
#line 54 "C:\Users\Again\Desktop\Chess\MultiplayerChess\Web\Chess.Web\Views\Home\Index.cshtml"
     }

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\n\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("partial", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "ecd2718566c5fd4e95813375ca6fb4cd633b12e613998", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Name = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("partial", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "ecd2718566c5fd4e95813375ca6fb4cd633b12e615113", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Name = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\n\n");
            DefineSection("Scripts", async() => {
                WriteLiteral("\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "ecd2718566c5fd4e95813375ca6fb4cd633b12e616326", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\n");
            }
            );
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public UserManager<ApplicationUser> UserManager { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public SignInManager<ApplicationUser> SignInManager { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<LatestThreeAddedVideosViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
