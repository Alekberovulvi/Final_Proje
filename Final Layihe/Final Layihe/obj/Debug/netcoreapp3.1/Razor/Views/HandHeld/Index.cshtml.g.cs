#pragma checksum "C:\Users\elekb\OneDrive\Desktop\Final Layihe\Final Layihe\Views\HandHeld\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3b0693bebe74ce6e4c9a2218571042cafa169bb7"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_HandHeld_Index), @"mvc.1.0.view", @"/Views/HandHeld/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3b0693bebe74ce6e4c9a2218571042cafa169bb7", @"/Views/HandHeld/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4dfc60d3cb967e6c75116f5b6f592824a34e1abd", @"/Views/_ViewImports.cshtml")]
    public class Views_HandHeld_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<CampaignDetailVM>
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
            WriteLiteral("\r\n\r\n<section>\r\n    <div class=\"container\">\r\n        <div class=\"row\">\r\n");
#nullable restore
#line 7 "C:\Users\elekb\OneDrive\Desktop\Final Layihe\Final Layihe\Views\HandHeld\Index.cshtml"
             foreach (HandHeld handHeld in Model.HandHelds)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <div class=\"col-lg-5\">\r\n                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "3b0693bebe74ce6e4c9a2218571042cafa169bb73899", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 242, "~/images/", 242, 9, true);
#nullable restore
#line 10 "C:\Users\elekb\OneDrive\Desktop\Final Layihe\Final Layihe\Views\HandHeld\Index.cshtml"
AddHtmlAttributeValue("", 251, handHeld.Image, 251, 15, false);

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
            WriteLiteral("\r\n                </div>\r\n                <div class=\"col-lg-7\">\r\n                    <h1>\r\n                        ");
#nullable restore
#line 14 "C:\Users\elekb\OneDrive\Desktop\Final Layihe\Final Layihe\Views\HandHeld\Index.cshtml"
                   Write(handHeld.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </h1>\r\n                    <h3>\r\n                        ");
#nullable restore
#line 17 "C:\Users\elekb\OneDrive\Desktop\Final Layihe\Final Layihe\Views\HandHeld\Index.cshtml"
                   Write(handHeld.SubTitle);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </h3>\r\n                    <p>\r\n                        ");
#nullable restore
#line 20 "C:\Users\elekb\OneDrive\Desktop\Final Layihe\Final Layihe\Views\HandHeld\Index.cshtml"
                   Write(handHeld.Desc);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                    </p>
                   

                    <a class=""fb-xfbml-parse-ignore"" target=""_blank""
                       href=""https://www.facebook.com/sharer/sharer.php?u=https://www.papajohns.az/az/stocks/stocks/description?slug=birthday-discount.&amp;src=sdkpreparse"">Paylaş</a>
                </div>
");
#nullable restore
#line 27 "C:\Users\elekb\OneDrive\Desktop\Final Layihe\Final Layihe\Views\HandHeld\Index.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </div>\r\n    </div>\r\n</section>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<CampaignDetailVM> Html { get; private set; }
    }
}
#pragma warning restore 1591
