#pragma checksum "C:\Users\elekb\OneDrive\Desktop\Final Layihe\Final Layihe\Views\Shared\_PapadiasDetailPatial.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "93e6be521d66383dcdd2f6f0e1b8f8b353733369"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__PapadiasDetailPatial), @"mvc.1.0.view", @"/Views/Shared/_PapadiasDetailPatial.cshtml")]
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
#line 2 "C:\Users\elekb\OneDrive\Desktop\Final Layihe\Final Layihe\Views\_ViewImports.cshtml"
using Final_Layihe.ViewModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\elekb\OneDrive\Desktop\Final Layihe\Final Layihe\Views\_ViewImports.cshtml"
using Final_Layihe.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"93e6be521d66383dcdd2f6f0e1b8f8b353733369", @"/Views/Shared/_PapadiasDetailPatial.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4dfc60d3cb967e6c75116f5b6f592824a34e1abd", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared__PapadiasDetailPatial : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Papadias>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("alt", new global::Microsoft.AspNetCore.Html.HtmlString(""), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            WriteLiteral("\r\n    <div class=\"modal-content\">\r\n\r\n\r\n        <div class=\"close\">\r\n            <h6>Bağla</h6>\r\n            <button>\r\n                <i class=\"fas fa-times\"></i>\r\n            </button>\r\n        </div>\r\n        <div class=\"image\">\r\n            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "93e6be521d66383dcdd2f6f0e1b8f8b3537333693813", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 271, "~/images/", 271, 9, true);
#nullable restore
#line 13 "C:\Users\elekb\OneDrive\Desktop\Final Layihe\Final Layihe\Views\Shared\_PapadiasDetailPatial.cshtml"
AddHtmlAttributeValue("", 280, Model.Img, 280, 10, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n        </div>\r\n        <div class=\"modal-body\">\r\n            <h2>");
#nullable restore
#line 16 "C:\Users\elekb\OneDrive\Desktop\Final Layihe\Final Layihe\Views\Shared\_PapadiasDetailPatial.cshtml"
           Write(Model.Basliq);

#line default
#line hidden
#nullable disable
            WriteLiteral(@" </h2>
        </div>
        <div class=""controls"">
            <div class=""plus""><i class=""fas fa-plus""></i></div>
            <div class=""count"">1</div>
            <div class=""minus""><i class=""fas fa-minus""></i></div>
            <div class=""price"">");
#nullable restore
#line 22 "C:\Users\elekb\OneDrive\Desktop\Final Layihe\Final Layihe\Views\Shared\_PapadiasDetailPatial.cshtml"
                          Write(Model.Price);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"₼ </div>
        </div>
        <div class=""modal-footer"">
            <div class=""basket"">
                <sup>0</sup>
                <i class=""fas fa-shopping-basket""></i>
            </div>
            <button class=""add-basket"">Səbətə at</button>
        </div>
    </div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Papadias> Html { get; private set; }
    }
}
#pragma warning restore 1591
