#pragma checksum "C:\Users\Again\Desktop\Chess\MultiplayerChess\Web\Chess.Web\Views\Chess\_BlackPlayerChessBoardPartial.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "4186ecb6902ca37fec0b9958045e2819b54e030f"
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
#nullable restore
#line 8 "C:\Users\Again\Desktop\Chess\MultiplayerChess\Web\Chess.Web\Views\_ViewImports.cshtml"
using Chess.Services.Paging;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4186ecb6902ca37fec0b9958045e2819b54e030f", @"/Views/Chess/_BlackPlayerChessBoardPartial.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"20f8531668fcea0551deeb825923c4b0b61bb53e", @"/Views/_ViewImports.cshtml")]
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
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "4186ecb6902ca37fec0b9958045e2819b54e030f5496", async() => {
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
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "4186ecb6902ca37fec0b9958045e2819b54e030f6608", async() => {
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
#line 6 "C:\Users\Again\Desktop\Chess\MultiplayerChess\Web\Chess.Web\Views\Chess\_BlackPlayerChessBoardPartial.cshtml"
     for (int row = 1; row <= 8; row++)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <tr>\n");
#nullable restore
#line 9 "C:\Users\Again\Desktop\Chess\MultiplayerChess\Web\Chess.Web\Views\Chess\_BlackPlayerChessBoardPartial.cshtml"
             for (int col = 'a'; col <= 'h'; col++) //
            {
                var boardCellColor = ((row + col) % 2 != 0) ? "white" : "black";//
                var figure = string.Empty;
                var figureSize = "fa-3x";
                var figureColor = string.Empty;
                var whiteFigureBorder = string.Empty;
                var cellId = (char)col + "" + row; //
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

                if ((row == 1 && (col == 'a' || col == 'h')) || (row == 8 && (col == 'a' || col == 'h')))
                {
                    figure = "fas fa-chess-rook";
                }

                if ((row == 1 && (col == 'b' || col == 'g')) || (row == 8 && (col == 'b' || col == 'g')))
                {
                    figure = "fas fa-chess-knight";
                }

                if ((row == 1 && (col == 'c' || col == 'f')) || (row == 8 && (col == 'c' || col == 'f')))
                {
                    figure = "fas fa-chess-bishop";
                }

                if ((row == 1 && col == 'd') || (row == 8 && col == 'd'))
                {
                    figure = "fas fa-chess-queen";
                }

                if ((row == 1 && col == 'e') || (row == 8 && col == 'e'))
                {
                    figure = "fas fa-chess-king";
                }


#line default
#line hidden
#nullable disable
            WriteLiteral("                <td");
            BeginWriteAttribute("id", " id=\"", 2132, "\"", 2144, 1);
#nullable restore
#line 63 "C:\Users\Again\Desktop\Chess\MultiplayerChess\Web\Chess.Web\Views\Chess\_BlackPlayerChessBoardPartial.cshtml"
WriteAttributeValue("", 2137, cellId, 2137, 7, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" style=\"text-align: center;\"");
            BeginWriteAttribute("class", " class=\"", 2173, "\"", 2196, 1);
#nullable restore
#line 63 "C:\Users\Again\Desktop\Chess\MultiplayerChess\Web\Chess.Web\Views\Chess\_BlackPlayerChessBoardPartial.cshtml"
WriteAttributeValue("", 2181, boardCellColor, 2181, 15, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" ondrop=\"drop(event)\" ondragover=\"allowDrop(event)\">\n\n");
#nullable restore
#line 65 "C:\Users\Again\Desktop\Chess\MultiplayerChess\Web\Chess.Web\Views\Chess\_BlackPlayerChessBoardPartial.cshtml"
                     if (row == 1 || row == 2)
                    {


#line default
#line hidden
#nullable disable
            WriteLiteral("                        <i");
            BeginWriteAttribute("id", " id=\"", 2347, "\"", 2361, 1);
#nullable restore
#line 68 "C:\Users\Again\Desktop\Chess\MultiplayerChess\Web\Chess.Web\Views\Chess\_BlackPlayerChessBoardPartial.cshtml"
WriteAttributeValue("", 2352, figureId, 2352, 9, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("class", " class=\"", 2362, "\"", 2421, 4);
#nullable restore
#line 68 "C:\Users\Again\Desktop\Chess\MultiplayerChess\Web\Chess.Web\Views\Chess\_BlackPlayerChessBoardPartial.cshtml"
WriteAttributeValue("", 2370, figure, 2370, 7, false);

#line default
#line hidden
#nullable disable
#nullable restore
#line 68 "C:\Users\Again\Desktop\Chess\MultiplayerChess\Web\Chess.Web\Views\Chess\_BlackPlayerChessBoardPartial.cshtml"
WriteAttributeValue(" ", 2377, figureSize, 2378, 11, false);

#line default
#line hidden
#nullable disable
#nullable restore
#line 68 "C:\Users\Again\Desktop\Chess\MultiplayerChess\Web\Chess.Web\Views\Chess\_BlackPlayerChessBoardPartial.cshtml"
WriteAttributeValue(" ", 2389, figureColor, 2390, 12, false);

#line default
#line hidden
#nullable disable
#nullable restore
#line 68 "C:\Users\Again\Desktop\Chess\MultiplayerChess\Web\Chess.Web\Views\Chess\_BlackPlayerChessBoardPartial.cshtml"
WriteAttributeValue(" ", 2402, whiteFigureBorder, 2403, 18, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" ");
            WriteLiteral(" ");
            WriteLiteral("></i>\n");
#nullable restore
#line 69 "C:\Users\Again\Desktop\Chess\MultiplayerChess\Web\Chess.Web\Views\Chess\_BlackPlayerChessBoardPartial.cshtml"
                    }
                    else if (row == 7 || row == 8)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <i");
            BeginWriteAttribute("id", " id=\"", 2600, "\"", 2614, 1);
#nullable restore
#line 72 "C:\Users\Again\Desktop\Chess\MultiplayerChess\Web\Chess.Web\Views\Chess\_BlackPlayerChessBoardPartial.cshtml"
WriteAttributeValue("", 2605, figureId, 2605, 9, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("class", " class=\"", 2615, "\"", 2674, 4);
#nullable restore
#line 72 "C:\Users\Again\Desktop\Chess\MultiplayerChess\Web\Chess.Web\Views\Chess\_BlackPlayerChessBoardPartial.cshtml"
WriteAttributeValue("", 2623, figure, 2623, 7, false);

#line default
#line hidden
#nullable disable
#nullable restore
#line 72 "C:\Users\Again\Desktop\Chess\MultiplayerChess\Web\Chess.Web\Views\Chess\_BlackPlayerChessBoardPartial.cshtml"
WriteAttributeValue(" ", 2630, figureSize, 2631, 11, false);

#line default
#line hidden
#nullable disable
#nullable restore
#line 72 "C:\Users\Again\Desktop\Chess\MultiplayerChess\Web\Chess.Web\Views\Chess\_BlackPlayerChessBoardPartial.cshtml"
WriteAttributeValue(" ", 2642, figureColor, 2643, 12, false);

#line default
#line hidden
#nullable disable
#nullable restore
#line 72 "C:\Users\Again\Desktop\Chess\MultiplayerChess\Web\Chess.Web\Views\Chess\_BlackPlayerChessBoardPartial.cshtml"
WriteAttributeValue(" ", 2655, whiteFigureBorder, 2656, 18, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" draggable=\"true\" ondragstart=\"drag(event)\"></i>\n");
#nullable restore
#line 73 "C:\Users\Again\Desktop\Chess\MultiplayerChess\Web\Chess.Web\Views\Chess\_BlackPlayerChessBoardPartial.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                </td>\n");
#nullable restore
#line 75 "C:\Users\Again\Desktop\Chess\MultiplayerChess\Web\Chess.Web\Views\Chess\_BlackPlayerChessBoardPartial.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </tr>\n");
#nullable restore
#line 77 "C:\Users\Again\Desktop\Chess\MultiplayerChess\Web\Chess.Web\Views\Chess\_BlackPlayerChessBoardPartial.cshtml"
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
