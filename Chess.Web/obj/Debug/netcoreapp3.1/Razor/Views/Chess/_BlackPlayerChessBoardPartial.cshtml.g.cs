#pragma checksum "C:\Users\Again\Desktop\Chess\MultiplayerChess\Chess.Web\Views\Chess\_BlackPlayerChessBoardPartial.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "df2bf2ba947879b240c3c01a4573a2478b79a488"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Chess__BlackPlayerChessBoardPartial), @"mvc.1.0.view", @"/Views/Chess/_BlackPlayerChessBoardPartial.cshtml")]
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
#line 1 "C:\Users\Again\Desktop\Chess\MultiplayerChess\Chess.Web\Views\_ViewImports.cshtml"
using Chess.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Again\Desktop\Chess\MultiplayerChess\Chess.Web\Views\_ViewImports.cshtml"
using Chess.Web.ViewModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\Again\Desktop\Chess\MultiplayerChess\Chess.Web\Views\_ViewImports.cshtml"
using Chess.Web.ViewModels.InputModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\Again\Desktop\Chess\MultiplayerChess\Chess.Web\Views\_ViewImports.cshtml"
using Chess.Web.ViewModels.ViewModels;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"df2bf2ba947879b240c3c01a4573a2478b79a488", @"/Views/Chess/_BlackPlayerChessBoardPartial.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b8184c5baf9691d2f7189f11c7d348909e771177", @"/Views/_ViewImports.cshtml")]
    public class Views_Chess__BlackPlayerChessBoardPartial : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/css/chess.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/lib/font-awesome/css/all.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "df2bf2ba947879b240c3c01a4573a2478b79a4884661", async() => {
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
            WriteLiteral("\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "df2bf2ba947879b240c3c01a4573a2478b79a4885773", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\n\n\n<table id=\"chessBoard\" class=\"center\">\n");
#nullable restore
#line 6 "C:\Users\Again\Desktop\Chess\MultiplayerChess\Chess.Web\Views\Chess\_BlackPlayerChessBoardPartial.cshtml"
     for (int row = 1; row <= 8; row++)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <tr>\n");
#nullable restore
#line 9 "C:\Users\Again\Desktop\Chess\MultiplayerChess\Chess.Web\Views\Chess\_BlackPlayerChessBoardPartial.cshtml"
             for (int col = 1; col <= 8; col++)
            {
                var boardCellColor = ((row + col) % 2 == 0) ? "white" : "black";
                var figure = string.Empty;
                var figureSize = "fa-3x";
                var figureColor = string.Empty;
                var whiteFigureBorder = string.Empty;
                var cellId = row + "" + col;
                var figureId = "i" + row + col;

                if (row == 1 || row == 2)
                {
                    whiteFigureBorder = "figureBorder";
                }

                if (row == 7 || row == 8)
                {
                    figureColor = "blackFigure";
                   }
                else if (row == 1 || row == 2)
                {
                    figureColor = "whiteFigure";
                }

                if (row == 2 || row == 7)
                {
                    figure = "fas fa-chess-pawn";
                }

                if ((row == 1 && (col == 1 || col == 8)) || (row == 8 && (col == 1 || col == 8)))
                {
                    figure = "fas fa-chess-rook";
                }

                if ((row == 1 && (col == 2 || col == 7)) || (row == 8 && (col == 2 || col == 7)))
                {
                    figure = "fas fa-chess-knight";
                }

                if ((row == 1 && (col == 3 || col == 6)) || (row == 8 && (col == 3 || col == 6)))
                {
                    figure = "fas fa-chess-bishop";
                }

                if ((row == 1 && col == 4) || (row == 8 && col == 4))
                {
                    figure = "fas fa-chess-queen";
                }

                if ((row == 1 && col == 5) || (row == 8 && col == 5))
                {
                    figure = "fas fa-chess-king";
                }


#line default
#line hidden
#nullable disable
            WriteLiteral("                <td");
            BeginWriteAttribute("id", " id=\"", 2057, "\"", 2069, 1);
#nullable restore
#line 63 "C:\Users\Again\Desktop\Chess\MultiplayerChess\Chess.Web\Views\Chess\_BlackPlayerChessBoardPartial.cshtml"
WriteAttributeValue("", 2062, cellId, 2062, 7, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("class", " class=\"", 2070, "\"", 2093, 1);
#nullable restore
#line 63 "C:\Users\Again\Desktop\Chess\MultiplayerChess\Chess.Web\Views\Chess\_BlackPlayerChessBoardPartial.cshtml"
WriteAttributeValue("", 2078, boardCellColor, 2078, 15, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" ondrop=\"drop(event)\" ondragover=\"allowDrop(event)\">\n\n");
#nullable restore
#line 65 "C:\Users\Again\Desktop\Chess\MultiplayerChess\Chess.Web\Views\Chess\_BlackPlayerChessBoardPartial.cshtml"
                     if (row == 1 || row == 2)
                    {


#line default
#line hidden
#nullable disable
            WriteLiteral("                        <i");
            BeginWriteAttribute("id", " id=\"", 2244, "\"", 2258, 1);
#nullable restore
#line 68 "C:\Users\Again\Desktop\Chess\MultiplayerChess\Chess.Web\Views\Chess\_BlackPlayerChessBoardPartial.cshtml"
WriteAttributeValue("", 2249, figureId, 2249, 9, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("class", " class=\"", 2259, "\"", 2318, 4);
#nullable restore
#line 68 "C:\Users\Again\Desktop\Chess\MultiplayerChess\Chess.Web\Views\Chess\_BlackPlayerChessBoardPartial.cshtml"
WriteAttributeValue("", 2267, figure, 2267, 7, false);

#line default
#line hidden
#nullable disable
#nullable restore
#line 68 "C:\Users\Again\Desktop\Chess\MultiplayerChess\Chess.Web\Views\Chess\_BlackPlayerChessBoardPartial.cshtml"
WriteAttributeValue(" ", 2274, figureSize, 2275, 11, false);

#line default
#line hidden
#nullable disable
#nullable restore
#line 68 "C:\Users\Again\Desktop\Chess\MultiplayerChess\Chess.Web\Views\Chess\_BlackPlayerChessBoardPartial.cshtml"
WriteAttributeValue(" ", 2286, figureColor, 2287, 12, false);

#line default
#line hidden
#nullable disable
#nullable restore
#line 68 "C:\Users\Again\Desktop\Chess\MultiplayerChess\Chess.Web\Views\Chess\_BlackPlayerChessBoardPartial.cshtml"
WriteAttributeValue(" ", 2299, whiteFigureBorder, 2300, 18, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" ");
            WriteLiteral(" ");
            WriteLiteral("></i>\n");
#nullable restore
#line 69 "C:\Users\Again\Desktop\Chess\MultiplayerChess\Chess.Web\Views\Chess\_BlackPlayerChessBoardPartial.cshtml"
                    }
                    else if (row == 7 || row == 8)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <i");
            BeginWriteAttribute("id", " id=\"", 2497, "\"", 2511, 1);
#nullable restore
#line 72 "C:\Users\Again\Desktop\Chess\MultiplayerChess\Chess.Web\Views\Chess\_BlackPlayerChessBoardPartial.cshtml"
WriteAttributeValue("", 2502, figureId, 2502, 9, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("class", " class=\"", 2512, "\"", 2571, 4);
#nullable restore
#line 72 "C:\Users\Again\Desktop\Chess\MultiplayerChess\Chess.Web\Views\Chess\_BlackPlayerChessBoardPartial.cshtml"
WriteAttributeValue("", 2520, figure, 2520, 7, false);

#line default
#line hidden
#nullable disable
#nullable restore
#line 72 "C:\Users\Again\Desktop\Chess\MultiplayerChess\Chess.Web\Views\Chess\_BlackPlayerChessBoardPartial.cshtml"
WriteAttributeValue(" ", 2527, figureSize, 2528, 11, false);

#line default
#line hidden
#nullable disable
#nullable restore
#line 72 "C:\Users\Again\Desktop\Chess\MultiplayerChess\Chess.Web\Views\Chess\_BlackPlayerChessBoardPartial.cshtml"
WriteAttributeValue(" ", 2539, figureColor, 2540, 12, false);

#line default
#line hidden
#nullable disable
#nullable restore
#line 72 "C:\Users\Again\Desktop\Chess\MultiplayerChess\Chess.Web\Views\Chess\_BlackPlayerChessBoardPartial.cshtml"
WriteAttributeValue(" ", 2552, whiteFigureBorder, 2553, 18, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" draggable=\"true\" ondragstart=\"drag(event)\"></i>\n");
#nullable restore
#line 73 "C:\Users\Again\Desktop\Chess\MultiplayerChess\Chess.Web\Views\Chess\_BlackPlayerChessBoardPartial.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                </td>\n");
#nullable restore
#line 75 "C:\Users\Again\Desktop\Chess\MultiplayerChess\Chess.Web\Views\Chess\_BlackPlayerChessBoardPartial.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </tr>\n");
#nullable restore
#line 77 "C:\Users\Again\Desktop\Chess\MultiplayerChess\Chess.Web\Views\Chess\_BlackPlayerChessBoardPartial.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</table>

<script type=""text/javascript"">
    //let whiteFigures = document.getElementsByClassName('whiteFigure');
    //for (var i = 0; i < whiteFigures.length; i++) {
    //    whiteFigures[i].setAttribute('draggable', true);
    //}

    //let blackFigures = document.getElementsByClassName('blackFigure');
    //for (var i = 0; i < blackFigures.length; i++) {
    //    blackFigures[i].setAttribute('draggable', true);
    //}
</script>
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
