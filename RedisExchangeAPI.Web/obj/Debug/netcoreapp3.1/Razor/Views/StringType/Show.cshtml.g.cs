#pragma checksum "/Users/mehmetyilmaz/Projects/redis/RedisExchangeAPI.Web/Views/StringType/Show.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "6f8399935af3e24d76653d7c22bef0da50049e73"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_StringType_Show), @"mvc.1.0.view", @"/Views/StringType/Show.cshtml")]
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
#line 1 "/Users/mehmetyilmaz/Projects/redis/RedisExchangeAPI.Web/Views/_ViewImports.cshtml"
using RedisExchangeAPI.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "/Users/mehmetyilmaz/Projects/redis/RedisExchangeAPI.Web/Views/_ViewImports.cshtml"
using RedisExchangeAPI.Web.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6f8399935af3e24d76653d7c22bef0da50049e73", @"/Views/StringType/Show.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d89c0624d3a6c310a4f8abbcbeac07298d56cd06", @"/Views/_ViewImports.cshtml")]
    public class Views_StringType_Show : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "/Users/mehmetyilmaz/Projects/redis/RedisExchangeAPI.Web/Views/StringType/Show.cshtml"
  
    ViewData["Title"] = "String Type Page";

#line default
#line hidden
#nullable disable
            WriteLiteral("\n    <div class=\"text-center\">\n        <h1 class=\"display-4\">");
#nullable restore
#line 6 "/Users/mehmetyilmaz/Projects/redis/RedisExchangeAPI.Web/Views/StringType/Show.cshtml"
                         Write(ViewBag.valueName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h1>\n        <h1 class=\"display-4\">");
#nullable restore
#line 7 "/Users/mehmetyilmaz/Projects/redis/RedisExchangeAPI.Web/Views/StringType/Show.cshtml"
                         Write(ViewBag.valueZiyaretci);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h1>\n    </div>\n");
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
