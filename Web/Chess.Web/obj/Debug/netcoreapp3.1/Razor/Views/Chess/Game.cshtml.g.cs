#pragma checksum "C:\Users\Again\Desktop\Chess\MultiplayerChess\Web\Chess.Web\Views\Chess\Game.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "35b1caca027013f34ecdf1c817a219ee6a7405a4"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Chess_Game), @"mvc.1.0.view", @"/Views/Chess/Game.cshtml")]
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
#nullable restore
#line 1 "C:\Users\Again\Desktop\Chess\MultiplayerChess\Web\Chess.Web\Views\Chess\Game.cshtml"
using Chess.Web.ViewModels.ViewModels.Games;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Again\Desktop\Chess\MultiplayerChess\Web\Chess.Web\Views\Chess\Game.cshtml"
using Chess.Common;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"35b1caca027013f34ecdf1c817a219ee6a7405a4", @"/Views/Chess/Game.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"20f8531668fcea0551deeb825923c4b0b61bb53e", @"/Views/_ViewImports.cshtml")]
    public class Views_Chess_Game : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<GameViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/css/chess.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/lib/font-awesome/css/all.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/lib/microsoft/signalr/dist/browser/signalr.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", "_ChatPartial", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", "_WhitePlayerChessBoardPartial", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", "_BlackPlayerChessBoardPartial", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", "~/js/add-move-to-dashboard.js", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_8 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", "~/js/chat.js", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.ScriptTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "35b1caca027013f34ecdf1c817a219ee6a7405a48010", async() => {
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
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "35b1caca027013f34ecdf1c817a219ee6a7405a49122", async() => {
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
            WriteLiteral("\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "35b1caca027013f34ecdf1c817a219ee6a7405a410234", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\n\n<script type=\"text/javascript\">\n    var element = document.getElementById(\"bodyPart\");\n    element.classList.remove(\"container\");\n</script>\n\n<div class=\"row\">\n    <div class=\"col-md-3 ml-5 mr-4 blueborder\">\n        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("partial", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "35b1caca027013f34ecdf1c817a219ee6a7405a411506", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Name = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\n    </div>\n    <div class=\"ml-4\">\n");
#nullable restore
#line 19 "C:\Users\Again\Desktop\Chess\MultiplayerChess\Web\Chess.Web\Views\Chess\Game.cshtml"
         if (Model.Color == "White")
        {

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("partial", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "35b1caca027013f34ecdf1c817a219ee6a7405a412871", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Name = (string)__tagHelperAttribute_5.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(" ");
#nullable restore
#line 21 "C:\Users\Again\Desktop\Chess\MultiplayerChess\Web\Chess.Web\Views\Chess\Game.cshtml"
                                                 }
            else
            {

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("partial", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "35b1caca027013f34ecdf1c817a219ee6a7405a414232", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Name = (string)__tagHelperAttribute_6.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_6);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
#nullable restore
#line 24 "C:\Users\Again\Desktop\Chess\MultiplayerChess\Web\Chess.Web\Views\Chess\Game.cshtml"
                                                }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"    </div>
    <div class=""col-md-3 ml-5 blueborder"">
        <div>
            <h3 id=""guestName"" class=""text-danger"">Waiting for opponent</h3>
        </div>
        <div>
            <h3 style=""visibility: hidden"">guest on move</h3>
        </div>
        <div id=""moveDashboard"" class=""blueborder"" style=""font-size: 16px; overflow-y: scroll; height: 360px;"">

        </div>
        <div>
            <h3 style=""visibility: hidden"">host on move</h3>
        </div>
        <div>
            <h3 class=""text-primary"">");
#nullable restore
#line 40 "C:\Users\Again\Desktop\Chess\MultiplayerChess\Web\Chess.Web\Views\Chess\Game.cshtml"
                                Write(Model.HostName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h3>\n        </div>\n    </div>\n</div>\n\n<script type=\"text/javascript\">\n    let gameId = \"");
#nullable restore
#line 46 "C:\Users\Again\Desktop\Chess\MultiplayerChess\Web\Chess.Web\Views\Chess\Game.cshtml"
             Write(Model.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral(@""";

    var connection = new signalR.HubConnectionBuilder().withUrl(""/chessHub"").build();
    connection.start().then(() => {
        connection.invoke(""AddHostConnectionIdToGame"", gameId);
    });

    connection.on(""RedirectToDeletedGame"", function () {
        window.location.href = `/Chess/DeletedGame`;
    });

    connection.on(""AddGuestToDashboard"", function (guestName) {
        $(""#guestName"").html(guestName);
    });

    connection.on(""ReceiveNewMove"", function (startId, targetId) {
        let figuretoMove = document.getElementById(startId);
        let targetCell = document.getElementById(targetId);

        if (targetId.startsWith(""i"")) {
            let targetElementParent = targetCell.parentElement;
            let firstChildElement = targetElementParent.firstElementChild;
            targetElementParent.removeChild(firstChildElement);
            targetElementParent.appendChild(figuretoMove);
        }
        else {
            targetCell.appendChild(figuretoMove);
        }
    });

    let");
            WriteLiteral(@" targetId = """";
    let startId = """";

    let figureClasses = """";
    let newAddressFigure = """";
    let parentElementFigure = """";
    let oldAddressFigure = """";

    function allowDrop(ev) {
        ev.preventDefault();
    }

    function drag(ev) {
        ev.dataTransfer.setData(""text"", ev.target.id);
        startId = ev.target.id;
        parentElementFigure = ev.target.parentElement;
        oldAddressFigure = parentElementFigure.id;
    }

    function drop(ev) {
        ev.preventDefault();
        let data = ev.dataTransfer.getData(""text"");
        let currentFigure = document.getElementById(data);
        figureClasses = currentFigure.classList.item(1);
        let targetElementId = ev.target.id;

        if (targetElementId.startsWith(""i"")) {
            let targetFigure = ev.target;
            let targetFigureColor = targetFigure.classList.item(3);
            let figureColor = targetFigureColor.substring(0, 5);

            if (figureColor !== """);
#nullable restore
#line 107 "C:\Users\Again\Desktop\Chess\MultiplayerChess\Web\Chess.Web\Views\Chess\Game.cshtml"
                            Write(Model.Color.ToLower());

#line default
#line hidden
#nullable disable
            WriteLiteral(@""") {
                let targetElementParent = ev.target.parentElement;
                let firstChildElement = targetElementParent.firstElementChild;
                targetElementParent.removeChild(firstChildElement);
                targetElementParent.appendChild(currentFigure);

                newAddressFigure = targetElementParent.id;
            }
            else {
                return;
            }
        }
        else {
            let targetCell = ev.target;
            if (targetCell.childElementCount > 0) {
                let figrueChildElement = targetCell.firstElementChild;
                let figrueChildElementColor = figrueChildElement.classList.item(3);
                let figureColor = figrueChildElementColor.substring(0, 5);
                if (figureColor === """);
#nullable restore
#line 125 "C:\Users\Again\Desktop\Chess\MultiplayerChess\Web\Chess.Web\Views\Chess\Game.cshtml"
                                Write(Model.Color.ToLower());

#line default
#line hidden
#nullable disable
            WriteLiteral(@""") {
                    return;
                }
            }
            targetCell.appendChild(currentFigure);
            newAddressFigure = targetCell.id;
        }

        targetId = targetElementId;
        connection.invoke(""SendNewMoveToBoard"", startId, targetId, gameId);
        connection.invoke(""SendNewMoveToDashboard"", gameId, figureClasses, oldAddressFigure, newAddressFigure);
    }
</script>

");
            DefineSection("Scripts", async() => {
                WriteLiteral("\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "35b1caca027013f34ecdf1c817a219ee6a7405a420578", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.ScriptTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper.Src = (string)__tagHelperAttribute_7.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_7);
#nullable restore
#line 141 "C:\Users\Again\Desktop\Chess\MultiplayerChess\Web\Chess.Web\Views\Chess\Game.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper.AppendVersion = true;

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-append-version", __Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper.AppendVersion, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "35b1caca027013f34ecdf1c817a219ee6a7405a422540", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.ScriptTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper.Src = (string)__tagHelperAttribute_8.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_8);
#nullable restore
#line 142 "C:\Users\Again\Desktop\Chess\MultiplayerChess\Web\Chess.Web\Views\Chess\Game.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper.AppendVersion = true;

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-append-version", __Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper.AppendVersion, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<GameViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
