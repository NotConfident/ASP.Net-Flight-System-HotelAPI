#pragma checksum "/Users/yongtenggg/Desktop/Poly/Year 2/Web Application Development/Assignment/Group 3/Source Code/web2020apr_p01_t3/web2020apr_p01_t3/Views/AdminActions/Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "cc8856c166a4674639a37d3dcb2ebe76b41c11c9"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_AdminActions_Index), @"mvc.1.0.view", @"/Views/AdminActions/Index.cshtml")]
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
#line 1 "/Users/yongtenggg/Desktop/Poly/Year 2/Web Application Development/Assignment/Group 3/Source Code/web2020apr_p01_t3/web2020apr_p01_t3/Views/AdminActions/Index.cshtml"
using Microsoft.AspNetCore.Http;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"cc8856c166a4674639a37d3dcb2ebe76b41c11c9", @"/Views/AdminActions/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"afe0a8bbc8ad1bbb4fddb5a2d3ea1a9aab4a0990", @"/Views/_ViewImports.cshtml")]
    public class Views_AdminActions_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/css/material-dashboard.css?v=2.1.2"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/css/table.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/css/demo.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", "~/Views/Shared/_AdminNavBar.cshtml", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", "~/Views/Home/Index.cshtml", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n<!DOCTYPE html>\r\n<html lang=\"en\">\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "cc8856c166a4674639a37d3dcb2ebe76b41c11c95967", async() => {
                WriteLiteral(@"
    <meta charset=""utf-8"" />
    <link rel=""apple-touch-icon"" sizes=""76x76"" href=""../assets/img/apple-icon.png"">
    <link rel=""icon"" type=""image/png"" href=""../assets/img/favicon.png"">
    <meta http-equiv=""X-UA-Compatible"" content=""IE=edge,chrome=1"" />

    <meta content='width=device-width, initial-scale=1.0, shrink-to-fit=no' name='viewport' />
    <!--     Fonts and icons     -->
    <link rel=""stylesheet"" type=""text/css"" href=""https://fonts.googleapis.com/css?family=Roboto:300,400,500,700|Roboto+Slab:400,700|Material+Icons"" />
    <link rel=""stylesheet"" href=""https://maxcdn.bootstrapcdn.com/font-awesome/latest/css/font-awesome.min.css"">
    <!-- CSS Files -->
    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "cc8856c166a4674639a37d3dcb2ebe76b41c11c96937", async() => {
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
                WriteLiteral("\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "cc8856c166a4674639a37d3dcb2ebe76b41c11c98100", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n\r\n    <!-- CSS Just for demo purpose, don\'t include it in your project -->\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "cc8856c166a4674639a37d3dcb2ebe76b41c11c99344", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n\r\n</html>\r\n");
#nullable restore
#line 25 "/Users/yongtenggg/Desktop/Poly/Year 2/Web Application Development/Assignment/Group 3/Source Code/web2020apr_p01_t3/web2020apr_p01_t3/Views/AdminActions/Index.cshtml"
 if (Context.Session.GetString("Role") != null)
{
    

#line default
#line hidden
#nullable disable
#nullable restore
#line 27 "/Users/yongtenggg/Desktop/Poly/Year 2/Web Application Development/Assignment/Group 3/Source Code/web2020apr_p01_t3/web2020apr_p01_t3/Views/AdminActions/Index.cshtml"
     if (TempData["Login"] != null)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <div class=\"alert alert-success alert-dismissable\">\r\n            <strong>");
#nullable restore
#line 30 "/Users/yongtenggg/Desktop/Poly/Year 2/Web Application Development/Assignment/Group 3/Source Code/web2020apr_p01_t3/web2020apr_p01_t3/Views/AdminActions/Index.cshtml"
               Write(TempData["Login"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</strong>\r\n        </div>\r\n");
#nullable restore
#line 32 "/Users/yongtenggg/Desktop/Poly/Year 2/Web Application Development/Assignment/Group 3/Source Code/web2020apr_p01_t3/web2020apr_p01_t3/Views/AdminActions/Index.cshtml"
    }

#line default
#line hidden
#nullable disable
#nullable restore
#line 32 "/Users/yongtenggg/Desktop/Poly/Year 2/Web Application Development/Assignment/Group 3/Source Code/web2020apr_p01_t3/web2020apr_p01_t3/Views/AdminActions/Index.cshtml"
     
    if (Context.Session.GetString("Role") == "Administrator")
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("partial", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "cc8856c166a4674639a37d3dcb2ebe76b41c11c912857", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Name = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
#nullable restore
#line 35 "/Users/yongtenggg/Desktop/Poly/Year 2/Web Application Development/Assignment/Group 3/Source Code/web2020apr_p01_t3/web2020apr_p01_t3/Views/AdminActions/Index.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Model = Model;

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext.AddTagHelperAttribute("model", __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Model, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 36 "/Users/yongtenggg/Desktop/Poly/Year 2/Web Application Development/Assignment/Group 3/Source Code/web2020apr_p01_t3/web2020apr_p01_t3/Views/AdminActions/Index.cshtml"
    }
}
else
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("partial", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "cc8856c166a4674639a37d3dcb2ebe76b41c11c914780", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Name = (string)__tagHelperAttribute_5.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
#nullable restore
#line 40 "/Users/yongtenggg/Desktop/Poly/Year 2/Web Application Development/Assignment/Group 3/Source Code/web2020apr_p01_t3/web2020apr_p01_t3/Views/AdminActions/Index.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Model = Model;

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext.AddTagHelperAttribute("model", __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Model, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 41 "/Users/yongtenggg/Desktop/Poly/Year 2/Web Application Development/Assignment/Group 3/Source Code/web2020apr_p01_t3/web2020apr_p01_t3/Views/AdminActions/Index.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<!-- End Navbar -->
<div class=""content"" style=""padding-top:10%;"">
    <div class=""container-fluid"">
        <div class=""row"">
            <div class=""col-lg-3 col-md-6 col-sm-6"">
                <div class=""card card-stats"">
                    <div class=""card-header card-header-warning card-header-icon"">
                        <div class=""card-icon"">
                            <i class=""material-icons"">content_copy</i>
                        </div>
                        <p class=""card-category"">Used Space</p>
                        <h3 class=""card-title"">
                            49/50
                            <small>GB</small>
                        </h3>
                    </div>
                    <div class=""card-footer"">
                        <div class=""stats"">
                            <i class=""material-icons text-danger"">warning</i>
                            <a href=""javascript:;"">Get More Space...</a>
                        </div>
                    </d");
            WriteLiteral(@"iv>
                </div>
            </div>
            <div class=""col-lg-3 col-md-6 col-sm-6"">
                <div class=""card card-stats"">
                    <div class=""card-header card-header-success card-header-icon"">
                        <div class=""card-icon"">
                            <i class=""material-icons"">store</i>
                        </div>
                        <p class=""card-category"">Revenue</p>
                        <h3 class=""card-title"">$34,245</h3>
                    </div>
                    <div class=""card-footer"">
                        <div class=""stats"">
                            <i class=""material-icons"">date_range</i> Last 24 Hours
                        </div>
                    </div>
                </div>
            </div>
            <div class=""col-lg-3 col-md-6 col-sm-6"">
                <div class=""card card-stats"">
                    <div class=""card-header card-header-danger card-header-icon"">
                        <div ");
            WriteLiteral(@"class=""card-icon"">
                            <i class=""material-icons"">info_outline</i>
                        </div>
                        <p class=""card-category"">Fixed Issues</p>
                        <h3 class=""card-title"">75</h3>
                    </div>
                    <div class=""card-footer"">
                        <div class=""stats"">
                            <i class=""material-icons"">local_offer</i> Tracked from Github
                        </div>
                    </div>
                </div>
            </div>
            <div class=""col-lg-3 col-md-6 col-sm-6"">
                <div class=""card card-stats"">
                    <div class=""card-header card-header-info card-header-icon"">
                        <div class=""card-icon"">
                            <i class=""fa fa-twitter""></i>
                        </div>
                        <p class=""card-category"">Followers</p>
                        <h3 class=""card-title"">+245</h3>
                  ");
            WriteLiteral(@"  </div>
                    <div class=""card-footer"">
                        <div class=""stats"">
                            <i class=""material-icons"">update</i> Just Updated
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class=""row"">
            <div class=""col-md-4"">
                <div class=""card card-chart"">
                    <div class=""card-header card-header-success"">
                        <div class=""ct-chart"" id=""dailySalesChart""></div>
                    </div>
                    <div class=""card-body"">
                        <h4 class=""card-title"">Daily Sales</h4>
                        <p class=""card-category"">
                            <span class=""text-success""><i class=""fa fa-long-arrow-up""></i> 55% </span> increase in today sales.
                        </p>
                    </div>
                    <div class=""card-footer"">
                        <div class=""stats"">
   ");
            WriteLiteral(@"                         <i class=""material-icons"">access_time</i> updated 4 minutes ago
                        </div>
                    </div>
                </div>
            </div>
            <div class=""col-md-4"">
                <div class=""card card-chart"">
                    <div class=""card-header card-header-warning"">
                        <div class=""ct-chart"" id=""websiteViewsChart""></div>
                    </div>
                    <div class=""card-body"">
                        <h4 class=""card-title"">Email Subscriptions</h4>
                        <p class=""card-category"">Last Campaign Performance</p>
                    </div>
                    <div class=""card-footer"">
                        <div class=""stats"">
                            <i class=""material-icons"">access_time</i> campaign sent 2 days ago
                        </div>
                    </div>
                </div>
            </div>
            <div class=""col-md-4"">
                <div ");
            WriteLiteral(@"class=""card card-chart"">
                    <div class=""card-header card-header-danger"">
                        <div class=""ct-chart"" id=""completedTasksChart""></div>
                    </div>
                    <div class=""card-body"">
                        <h4 class=""card-title"">Completed Tasks</h4>
                        <p class=""card-category"">Last Campaign Performance</p>
                    </div>
                    <div class=""card-footer"">
                        <div class=""stats"">
                            <i class=""material-icons"">access_time</i> campaign sent 2 days ago
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>
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