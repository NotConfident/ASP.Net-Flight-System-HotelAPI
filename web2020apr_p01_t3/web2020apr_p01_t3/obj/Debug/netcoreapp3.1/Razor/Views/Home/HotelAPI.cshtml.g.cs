#pragma checksum "/Users/yongtenggg/Desktop/Poly/Year 2/Web Application Development/Assignment/Group 3/Source Code/web2020apr_p01_t3/web2020apr_p01_t3/Views/Home/HotelAPI.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "9d2bd5de070625a58e5993f32ff5c0d586c2ab54"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_HotelAPI), @"mvc.1.0.view", @"/Views/Home/HotelAPI.cshtml")]
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
#line 1 "/Users/yongtenggg/Desktop/Poly/Year 2/Web Application Development/Assignment/Group 3/Source Code/web2020apr_p01_t3/web2020apr_p01_t3/Views/_ViewImports.cshtml"
using web2020apr_p01_t3;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "/Users/yongtenggg/Desktop/Poly/Year 2/Web Application Development/Assignment/Group 3/Source Code/web2020apr_p01_t3/web2020apr_p01_t3/Views/_ViewImports.cshtml"
using web2020apr_p01_t3.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "/Users/yongtenggg/Desktop/Poly/Year 2/Web Application Development/Assignment/Group 3/Source Code/web2020apr_p01_t3/web2020apr_p01_t3/Views/_ViewImports.cshtml"
using Microsoft.AspNetCore.Http;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9d2bd5de070625a58e5993f32ff5c0d586c2ab54", @"/Views/Home/HotelAPI.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"afe0a8bbc8ad1bbb4fddb5a2d3ea1a9aab4a0990", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_HotelAPI : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<web2020apr_p01_t3.Models.Hotel>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", new global::Microsoft.AspNetCore.Html.HtmlString("text/css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/vendor/bootstrap/css/bootstrap.min.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/css/schedulebooking.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/css/schedulebookingmain.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/css/table.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            WriteLiteral("\r\n");
#nullable restore
#line 3 "/Users/yongtenggg/Desktop/Poly/Year 2/Web Application Development/Assignment/Group 3/Source Code/web2020apr_p01_t3/web2020apr_p01_t3/Views/Home/HotelAPI.cshtml"
 if (TempData["APIError"] != null)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class=\"alert alert-danger alert-dismissable\">\r\n        <strong>");
#nullable restore
#line 6 "/Users/yongtenggg/Desktop/Poly/Year 2/Web Application Development/Assignment/Group 3/Source Code/web2020apr_p01_t3/web2020apr_p01_t3/Views/Home/HotelAPI.cshtml"
           Write(TempData["APIError"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</strong>\r\n    </div>\r\n");
#nullable restore
#line 8 "/Users/yongtenggg/Desktop/Poly/Year 2/Web Application Development/Assignment/Group 3/Source Code/web2020apr_p01_t3/web2020apr_p01_t3/Views/Home/HotelAPI.cshtml"
}

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "9d2bd5de070625a58e5993f32ff5c0d586c2ab546699", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n<!--===============================================================================================-->\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "9d2bd5de070625a58e5993f32ff5c0d586c2ab547987", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "9d2bd5de070625a58e5993f32ff5c0d586c2ab549169", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "9d2bd5de070625a58e5993f32ff5c0d586c2ab5410351", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n");
#nullable restore
#line 15 "/Users/yongtenggg/Desktop/Poly/Year 2/Web Application Development/Assignment/Group 3/Source Code/web2020apr_p01_t3/web2020apr_p01_t3/Views/Home/HotelAPI.cshtml"
 if (Model.ToList().Count > 0)
{

#line default
#line hidden
#nullable disable
            WriteLiteral(@"    <br />
    <br>
    <div class=""wrap-contact100"">
        <div class=""table-responsive"">
            <table id=""viewBook"" class=""table table-striped table-bordered"">
                <thead class=""thead-dark"">
                    <tr>
                        <th>Hotel Name</th>
                        <th>Hotel ID</th>
                        <th>Price / Tax / Vendor</th>
                        <th>Price / Tax / Vendor</th>
                        <th>Price / Tax / Vendor</th>
                        <th>Price / Tax / Vendor</th>
                        <th>Price / Tax / Vendor</th>
                    </tr>
                </thead>
                <tbody>
");
#nullable restore
#line 34 "/Users/yongtenggg/Desktop/Poly/Year 2/Web Application Development/Assignment/Group 3/Source Code/web2020apr_p01_t3/web2020apr_p01_t3/Views/Home/HotelAPI.cshtml"
                     foreach (Hotel item in Model)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <tr>\r\n                            <td>");
#nullable restore
#line 37 "/Users/yongtenggg/Desktop/Poly/Year 2/Web Application Development/Assignment/Group 3/Source Code/web2020apr_p01_t3/web2020apr_p01_t3/Views/Home/HotelAPI.cshtml"
                           Write(item.hotelName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            <td>");
#nullable restore
#line 38 "/Users/yongtenggg/Desktop/Poly/Year 2/Web Application Development/Assignment/Group 3/Source Code/web2020apr_p01_t3/web2020apr_p01_t3/Views/Home/HotelAPI.cshtml"
                           Write(item.hotelId);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n\r\n");
#nullable restore
#line 40 "/Users/yongtenggg/Desktop/Poly/Year 2/Web Application Development/Assignment/Group 3/Source Code/web2020apr_p01_t3/web2020apr_p01_t3/Views/Home/HotelAPI.cshtml"
                             if (item.price1 != "")
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <td>$");
#nullable restore
#line 42 "/Users/yongtenggg/Desktop/Poly/Year 2/Web Application Development/Assignment/Group 3/Source Code/web2020apr_p01_t3/web2020apr_p01_t3/Views/Home/HotelAPI.cshtml"
                                Write(item.price1);

#line default
#line hidden
#nullable disable
            WriteLiteral(" / $");
#nullable restore
#line 42 "/Users/yongtenggg/Desktop/Poly/Year 2/Web Application Development/Assignment/Group 3/Source Code/web2020apr_p01_t3/web2020apr_p01_t3/Views/Home/HotelAPI.cshtml"
                                                Write(item.tax1);

#line default
#line hidden
#nullable disable
            WriteLiteral(" / <a");
            BeginWriteAttribute("href", " href=\"", 1695, "\"", 1727, 2);
            WriteAttributeValue("", 1702, "https://www.", 1702, 12, true);
#nullable restore
#line 42 "/Users/yongtenggg/Desktop/Poly/Year 2/Web Application Development/Assignment/Group 3/Source Code/web2020apr_p01_t3/web2020apr_p01_t3/Views/Home/HotelAPI.cshtml"
WriteAttributeValue("", 1714, item.vendor1, 1714, 13, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 42 "/Users/yongtenggg/Desktop/Poly/Year 2/Web Application Development/Assignment/Group 3/Source Code/web2020apr_p01_t3/web2020apr_p01_t3/Views/Home/HotelAPI.cshtml"
                                                                                                 Write(item.vendor1);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a> </td>\r\n");
#nullable restore
#line 43 "/Users/yongtenggg/Desktop/Poly/Year 2/Web Application Development/Assignment/Group 3/Source Code/web2020apr_p01_t3/web2020apr_p01_t3/Views/Home/HotelAPI.cshtml"

                            }
                            else
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <td><i>NULL</i></td>\r\n");
#nullable restore
#line 48 "/Users/yongtenggg/Desktop/Poly/Year 2/Web Application Development/Assignment/Group 3/Source Code/web2020apr_p01_t3/web2020apr_p01_t3/Views/Home/HotelAPI.cshtml"

                            }

#line default
#line hidden
#nullable disable
#nullable restore
#line 50 "/Users/yongtenggg/Desktop/Poly/Year 2/Web Application Development/Assignment/Group 3/Source Code/web2020apr_p01_t3/web2020apr_p01_t3/Views/Home/HotelAPI.cshtml"
                             if (item.price2 != "")
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <td>$");
#nullable restore
#line 52 "/Users/yongtenggg/Desktop/Poly/Year 2/Web Application Development/Assignment/Group 3/Source Code/web2020apr_p01_t3/web2020apr_p01_t3/Views/Home/HotelAPI.cshtml"
                                Write(item.price2);

#line default
#line hidden
#nullable disable
            WriteLiteral(" / $");
#nullable restore
#line 52 "/Users/yongtenggg/Desktop/Poly/Year 2/Web Application Development/Assignment/Group 3/Source Code/web2020apr_p01_t3/web2020apr_p01_t3/Views/Home/HotelAPI.cshtml"
                                                Write(item.tax2);

#line default
#line hidden
#nullable disable
            WriteLiteral(" / <a");
            BeginWriteAttribute("href", " href=\"", 2091, "\"", 2123, 2);
            WriteAttributeValue("", 2098, "https://www.", 2098, 12, true);
#nullable restore
#line 52 "/Users/yongtenggg/Desktop/Poly/Year 2/Web Application Development/Assignment/Group 3/Source Code/web2020apr_p01_t3/web2020apr_p01_t3/Views/Home/HotelAPI.cshtml"
WriteAttributeValue("", 2110, item.vendor2, 2110, 13, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 52 "/Users/yongtenggg/Desktop/Poly/Year 2/Web Application Development/Assignment/Group 3/Source Code/web2020apr_p01_t3/web2020apr_p01_t3/Views/Home/HotelAPI.cshtml"
                                                                                                 Write(item.vendor2);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a> </td>\r\n");
#nullable restore
#line 53 "/Users/yongtenggg/Desktop/Poly/Year 2/Web Application Development/Assignment/Group 3/Source Code/web2020apr_p01_t3/web2020apr_p01_t3/Views/Home/HotelAPI.cshtml"

                            }
                            else
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <td><i>NULL</i></td>\r\n");
#nullable restore
#line 58 "/Users/yongtenggg/Desktop/Poly/Year 2/Web Application Development/Assignment/Group 3/Source Code/web2020apr_p01_t3/web2020apr_p01_t3/Views/Home/HotelAPI.cshtml"

                            }

#line default
#line hidden
#nullable disable
#nullable restore
#line 60 "/Users/yongtenggg/Desktop/Poly/Year 2/Web Application Development/Assignment/Group 3/Source Code/web2020apr_p01_t3/web2020apr_p01_t3/Views/Home/HotelAPI.cshtml"
                             if (item.price3 != "")
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <td>$");
#nullable restore
#line 62 "/Users/yongtenggg/Desktop/Poly/Year 2/Web Application Development/Assignment/Group 3/Source Code/web2020apr_p01_t3/web2020apr_p01_t3/Views/Home/HotelAPI.cshtml"
                                Write(item.price3);

#line default
#line hidden
#nullable disable
            WriteLiteral(" / $");
#nullable restore
#line 62 "/Users/yongtenggg/Desktop/Poly/Year 2/Web Application Development/Assignment/Group 3/Source Code/web2020apr_p01_t3/web2020apr_p01_t3/Views/Home/HotelAPI.cshtml"
                                                Write(item.tax3);

#line default
#line hidden
#nullable disable
            WriteLiteral(" / <a");
            BeginWriteAttribute("href", " href=\"", 2487, "\"", 2519, 2);
            WriteAttributeValue("", 2494, "https://www.", 2494, 12, true);
#nullable restore
#line 62 "/Users/yongtenggg/Desktop/Poly/Year 2/Web Application Development/Assignment/Group 3/Source Code/web2020apr_p01_t3/web2020apr_p01_t3/Views/Home/HotelAPI.cshtml"
WriteAttributeValue("", 2506, item.vendor3, 2506, 13, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 62 "/Users/yongtenggg/Desktop/Poly/Year 2/Web Application Development/Assignment/Group 3/Source Code/web2020apr_p01_t3/web2020apr_p01_t3/Views/Home/HotelAPI.cshtml"
                                                                                                 Write(item.vendor3);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a> </td>\r\n");
#nullable restore
#line 63 "/Users/yongtenggg/Desktop/Poly/Year 2/Web Application Development/Assignment/Group 3/Source Code/web2020apr_p01_t3/web2020apr_p01_t3/Views/Home/HotelAPI.cshtml"

                            }
                            else
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <td><i>NULL</i></td>\r\n");
#nullable restore
#line 68 "/Users/yongtenggg/Desktop/Poly/Year 2/Web Application Development/Assignment/Group 3/Source Code/web2020apr_p01_t3/web2020apr_p01_t3/Views/Home/HotelAPI.cshtml"

                            }

#line default
#line hidden
#nullable disable
#nullable restore
#line 70 "/Users/yongtenggg/Desktop/Poly/Year 2/Web Application Development/Assignment/Group 3/Source Code/web2020apr_p01_t3/web2020apr_p01_t3/Views/Home/HotelAPI.cshtml"
                             if (item.price4 != "")
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <td>$");
#nullable restore
#line 72 "/Users/yongtenggg/Desktop/Poly/Year 2/Web Application Development/Assignment/Group 3/Source Code/web2020apr_p01_t3/web2020apr_p01_t3/Views/Home/HotelAPI.cshtml"
                                Write(item.price4);

#line default
#line hidden
#nullable disable
            WriteLiteral(" / $");
#nullable restore
#line 72 "/Users/yongtenggg/Desktop/Poly/Year 2/Web Application Development/Assignment/Group 3/Source Code/web2020apr_p01_t3/web2020apr_p01_t3/Views/Home/HotelAPI.cshtml"
                                                Write(item.tax4);

#line default
#line hidden
#nullable disable
            WriteLiteral(" / <a");
            BeginWriteAttribute("href", " href=\"", 2883, "\"", 2915, 2);
            WriteAttributeValue("", 2890, "https://www.", 2890, 12, true);
#nullable restore
#line 72 "/Users/yongtenggg/Desktop/Poly/Year 2/Web Application Development/Assignment/Group 3/Source Code/web2020apr_p01_t3/web2020apr_p01_t3/Views/Home/HotelAPI.cshtml"
WriteAttributeValue("", 2902, item.vendor4, 2902, 13, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 72 "/Users/yongtenggg/Desktop/Poly/Year 2/Web Application Development/Assignment/Group 3/Source Code/web2020apr_p01_t3/web2020apr_p01_t3/Views/Home/HotelAPI.cshtml"
                                                                                                 Write(item.vendor4);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a> </td>\r\n");
#nullable restore
#line 73 "/Users/yongtenggg/Desktop/Poly/Year 2/Web Application Development/Assignment/Group 3/Source Code/web2020apr_p01_t3/web2020apr_p01_t3/Views/Home/HotelAPI.cshtml"

                            }
                            else
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <td><i>NULL</i></td>\r\n");
#nullable restore
#line 78 "/Users/yongtenggg/Desktop/Poly/Year 2/Web Application Development/Assignment/Group 3/Source Code/web2020apr_p01_t3/web2020apr_p01_t3/Views/Home/HotelAPI.cshtml"

                            }

#line default
#line hidden
#nullable disable
#nullable restore
#line 80 "/Users/yongtenggg/Desktop/Poly/Year 2/Web Application Development/Assignment/Group 3/Source Code/web2020apr_p01_t3/web2020apr_p01_t3/Views/Home/HotelAPI.cshtml"
                             if (item.price5 != "")
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <td>$");
#nullable restore
#line 82 "/Users/yongtenggg/Desktop/Poly/Year 2/Web Application Development/Assignment/Group 3/Source Code/web2020apr_p01_t3/web2020apr_p01_t3/Views/Home/HotelAPI.cshtml"
                                Write(item.price5);

#line default
#line hidden
#nullable disable
            WriteLiteral(" / $");
#nullable restore
#line 82 "/Users/yongtenggg/Desktop/Poly/Year 2/Web Application Development/Assignment/Group 3/Source Code/web2020apr_p01_t3/web2020apr_p01_t3/Views/Home/HotelAPI.cshtml"
                                                Write(item.tax5);

#line default
#line hidden
#nullable disable
            WriteLiteral(" / <a");
            BeginWriteAttribute("href", " href=\"", 3279, "\"", 3311, 2);
            WriteAttributeValue("", 3286, "https://www.", 3286, 12, true);
#nullable restore
#line 82 "/Users/yongtenggg/Desktop/Poly/Year 2/Web Application Development/Assignment/Group 3/Source Code/web2020apr_p01_t3/web2020apr_p01_t3/Views/Home/HotelAPI.cshtml"
WriteAttributeValue("", 3298, item.vendor5, 3298, 13, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 82 "/Users/yongtenggg/Desktop/Poly/Year 2/Web Application Development/Assignment/Group 3/Source Code/web2020apr_p01_t3/web2020apr_p01_t3/Views/Home/HotelAPI.cshtml"
                                                                                                 Write(item.vendor5);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a> </td>\r\n");
#nullable restore
#line 83 "/Users/yongtenggg/Desktop/Poly/Year 2/Web Application Development/Assignment/Group 3/Source Code/web2020apr_p01_t3/web2020apr_p01_t3/Views/Home/HotelAPI.cshtml"

                            }
                            else
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <td><i>NULL</i></td>\r\n");
#nullable restore
#line 88 "/Users/yongtenggg/Desktop/Poly/Year 2/Web Application Development/Assignment/Group 3/Source Code/web2020apr_p01_t3/web2020apr_p01_t3/Views/Home/HotelAPI.cshtml"

                            }

#line default
#line hidden
#nullable disable
            WriteLiteral("                        </tr>\r\n");
#nullable restore
#line 91 "/Users/yongtenggg/Desktop/Poly/Year 2/Web Application Development/Assignment/Group 3/Source Code/web2020apr_p01_t3/web2020apr_p01_t3/Views/Home/HotelAPI.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                </tbody>\r\n            </table>\r\n        </div>\r\n    </div>\r\n");
#nullable restore
#line 96 "/Users/yongtenggg/Desktop/Poly/Year 2/Web Application Development/Assignment/Group 3/Source Code/web2020apr_p01_t3/web2020apr_p01_t3/Views/Home/HotelAPI.cshtml"
}

#line default
#line hidden
#nullable disable
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<web2020apr_p01_t3.Models.Hotel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
