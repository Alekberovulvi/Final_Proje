#pragma checksum "C:\Users\elekb\OneDrive\Desktop\Final Layihe\Final Layihe\Views\Classic\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "4428a010dba61bdcb53b2ca7edf6ccc0c1177d92"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Classic_Index), @"mvc.1.0.view", @"/Views/Classic/Index.cshtml")]
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
#nullable restore
#line 4 "C:\Users\elekb\OneDrive\Desktop\Final Layihe\Final Layihe\Views\_ViewImports.cshtml"
using Final_Layihe.ViewModels.Account;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\elekb\OneDrive\Desktop\Final Layihe\Final Layihe\Views\_ViewImports.cshtml"
using Final_Layihe.Services;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4428a010dba61bdcb53b2ca7edf6ccc0c1177d92", @"/Views/Classic/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"69d1ae78150e26dd0c02b0a4020e9ecd7cf53bb9", @"/Views/_ViewImports.cshtml")]
    public class Views_Classic_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<CampaignDetailVM>
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
            WriteLiteral("\r\n<section>\r\n    <div class=\"container\">\r\n        <div class=\"row\">\r\n");
#nullable restore
#line 6 "C:\Users\elekb\OneDrive\Desktop\Final Layihe\Final Layihe\Views\Classic\Index.cshtml"
             foreach (Classic classic in Model.Classics)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <div class=\"col-lg-5\">\r\n                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "4428a010dba61bdcb53b2ca7edf6ccc0c1177d924284", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 237, "~/images/", 237, 9, true);
#nullable restore
#line 9 "C:\Users\elekb\OneDrive\Desktop\Final Layihe\Final Layihe\Views\Classic\Index.cshtml"
AddHtmlAttributeValue("", 246, classic.Image, 246, 14, false);

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
#line 13 "C:\Users\elekb\OneDrive\Desktop\Final Layihe\Final Layihe\Views\Classic\Index.cshtml"
                   Write(classic.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </h1>\r\n                    <p>\r\n                        ");
#nullable restore
#line 16 "C:\Users\elekb\OneDrive\Desktop\Final Layihe\Final Layihe\Views\Classic\Index.cshtml"
                   Write(classic.Desc);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                    </p>

                    <a class=""fb-xfbml-parse-ignore"" target=""_blank""
                       href=""https://www.facebook.com/sharer/sharer.php?u=https://www.papajohns.az/az/stocks/stocks/description?slug=birthday-discount.&amp;src=sdkpreparse"">Payla??</a>
                </div>
");
#nullable restore
#line 22 "C:\Users\elekb\OneDrive\Desktop\Final Layihe\Final Layihe\Views\Classic\Index.cshtml"
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
