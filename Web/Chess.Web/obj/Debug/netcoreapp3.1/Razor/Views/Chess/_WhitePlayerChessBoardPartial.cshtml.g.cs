#pragma checksum "C:\Users\Again\Desktop\Chess\MultiplayerChess\Web\Chess.Web\Views\Chess\_WhitePlayerChessBoardPartial.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "7257e512990054c9e17d4f37c681a3c8c7dd5c5d"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Chess__WhitePlayerChessBoardPartial), @"mvc.1.0.view", @"/Views/Chess/_WhitePlayerChessBoardPartial.cshtml")]
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
#line 6 "C:\Users\Again\Desktop\Chess\MultiplayerChess\Web\Chess.Web\Views\_ViewImports.cshtml"
using Chess.Data.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\Again\Desktop\Chess\MultiplayerChess\Web\Chess.Web\Views\_ViewImports.cshtml"
using Chess.Web.ViewModels.ViewModels.Videos;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7257e512990054c9e17d4f37c681a3c8c7dd5c5d", @"/Views/Chess/_WhitePlayerChessBoardPartial.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d76ca1dace8dcdd5260d567abce421006ca1785e", @"/Views/_ViewImports.cshtml")]
    public class Views_Chess__WhitePlayerChessBoardPartial : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
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
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "7257e512990054c9e17d4f37c681a3c8c7dd5c5d5300", async() => {
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
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "7257e512990054c9e17d4f37c681a3c8c7dd5c5d6412", async() => {
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
#line 6 "C:\Users\Again\Desktop\Chess\MultiplayerChess\Web\Chess.Web\Views\Chess\_WhitePlayerChessBoardPartial.cshtml"
     for (int row = 8; row > 0; row--)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <tr>\n");
#nullable restore
#line 9 "C:\Users\Again\Desktop\Chess\MultiplayerChess\Web\Chess.Web\Views\Chess\_WhitePlayerChessBoardPartial.cshtml"
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
            BeginWriteAttribute("id", " id=\"", 2053, "\"", 2065, 1);
#nullable restore
#line 63 "C:\Users\Again\Desktop\Chess\MultiplayerChess\Web\Chess.Web\Views\Chess\_WhitePlayerChessBoardPartial.cshtml"
WriteAttributeValue("", 2058, cellId, 2058, 7, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("class", " class=\"", 2066, "\"", 2089, 1);
#nullable restore
#line 63 "C:\Users\Again\Desktop\Chess\MultiplayerChess\Web\Chess.Web\Views\Chess\_WhitePlayerChessBoardPartial.cshtml"
WriteAttributeValue("", 2074, boardCellColor, 2074, 15, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" ondrop=\"drop(event)\" ondragover=\"allowDrop(event)\">\n");
#nullable restore
#line 64 "C:\Users\Again\Desktop\Chess\MultiplayerChess\Web\Chess.Web\Views\Chess\_WhitePlayerChessBoardPartial.cshtml"
                     if (row == 1 || row == 2)
                    {


#line default
#line hidden
#nullable disable
            WriteLiteral("                        <i");
            BeginWriteAttribute("id", " id=\"", 2239, "\"", 2253, 1);
#nullable restore
#line 67 "C:\Users\Again\Desktop\Chess\MultiplayerChess\Web\Chess.Web\Views\Chess\_WhitePlayerChessBoardPartial.cshtml"
WriteAttributeValue("", 2244, figureId, 2244, 9, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("class", " class=\"", 2254, "\"", 2313, 4);
#nullable restore
#line 67 "C:\Users\Again\Desktop\Chess\MultiplayerChess\Web\Chess.Web\Views\Chess\_WhitePlayerChessBoardPartial.cshtml"
WriteAttributeValue("", 2262, figure, 2262, 7, false);

#line default
#line hidden
#nullable disable
#nullable restore
#line 67 "C:\Users\Again\Desktop\Chess\MultiplayerChess\Web\Chess.Web\Views\Chess\_WhitePlayerChessBoardPartial.cshtml"
WriteAttributeValue(" ", 2269, figureSize, 2270, 11, false);

#line default
#line hidden
#nullable disable
#nullable restore
#line 67 "C:\Users\Again\Desktop\Chess\MultiplayerChess\Web\Chess.Web\Views\Chess\_WhitePlayerChessBoardPartial.cshtml"
WriteAttributeValue(" ", 2281, figureColor, 2282, 12, false);

#line default
#line hidden
#nullable disable
#nullable restore
#line 67 "C:\Users\Again\Desktop\Chess\MultiplayerChess\Web\Chess.Web\Views\Chess\_WhitePlayerChessBoardPartial.cshtml"
WriteAttributeValue(" ", 2294, whiteFigureBorder, 2295, 18, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" draggable=\"true\" ondragstart=\"drag(event)\"></i>\n");
#nullable restore
#line 68 "C:\Users\Again\Desktop\Chess\MultiplayerChess\Web\Chess.Web\Views\Chess\_WhitePlayerChessBoardPartial.cshtml"
                    }
                    else if (row == 7 || row == 8)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <i");
            BeginWriteAttribute("id", " id=\"", 2484, "\"", 2498, 1);
#nullable restore
#line 71 "C:\Users\Again\Desktop\Chess\MultiplayerChess\Web\Chess.Web\Views\Chess\_WhitePlayerChessBoardPartial.cshtml"
WriteAttributeValue("", 2489, figureId, 2489, 9, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("class", " class=\"", 2499, "\"", 2558, 4);
#nullable restore
#line 71 "C:\Users\Again\Desktop\Chess\MultiplayerChess\Web\Chess.Web\Views\Chess\_WhitePlayerChessBoardPartial.cshtml"
WriteAttributeValue("", 2507, figure, 2507, 7, false);

#line default
#line hidden
#nullable disable
#nullable restore
#line 71 "C:\Users\Again\Desktop\Chess\MultiplayerChess\Web\Chess.Web\Views\Chess\_WhitePlayerChessBoardPartial.cshtml"
WriteAttributeValue(" ", 2514, figureSize, 2515, 11, false);

#line default
#line hidden
#nullable disable
#nullable restore
#line 71 "C:\Users\Again\Desktop\Chess\MultiplayerChess\Web\Chess.Web\Views\Chess\_WhitePlayerChessBoardPartial.cshtml"
WriteAttributeValue(" ", 2526, figureColor, 2527, 12, false);

#line default
#line hidden
#nullable disable
#nullable restore
#line 71 "C:\Users\Again\Desktop\Chess\MultiplayerChess\Web\Chess.Web\Views\Chess\_WhitePlayerChessBoardPartial.cshtml"
WriteAttributeValue(" ", 2539, whiteFigureBorder, 2540, 18, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("></i>\n");
#nullable restore
#line 72 "C:\Users\Again\Desktop\Chess\MultiplayerChess\Web\Chess.Web\Views\Chess\_WhitePlayerChessBoardPartial.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                </td>\n");
#nullable restore
#line 74 "C:\Users\Again\Desktop\Chess\MultiplayerChess\Web\Chess.Web\Views\Chess\_WhitePlayerChessBoardPartial.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </tr>\n");
#nullable restore
#line 76 "C:\Users\Again\Desktop\Chess\MultiplayerChess\Web\Chess.Web\Views\Chess\_WhitePlayerChessBoardPartial.cshtml"
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
    //    blackFigures[i].setAttribute('draggable', false);
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
