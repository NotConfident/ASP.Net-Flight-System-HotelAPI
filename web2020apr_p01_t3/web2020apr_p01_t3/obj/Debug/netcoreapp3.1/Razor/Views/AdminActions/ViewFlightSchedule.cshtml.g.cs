#pragma checksum "/Users/yongtenggg/Desktop/Poly/Year 2/Web Application Development/Assignment/Group 3/Source Code/web2020apr_p01_t3/web2020apr_p01_t3/Views/AdminActions/ViewFlightSchedule.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "36771d7541262185865301ca28764f8e14ad40cc"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_AdminActions_ViewFlightSchedule), @"mvc.1.0.view", @"/Views/AdminActions/ViewFlightSchedule.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"36771d7541262185865301ca28764f8e14ad40cc", @"/Views/AdminActions/ViewFlightSchedule.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"afe0a8bbc8ad1bbb4fddb5a2d3ea1a9aab4a0990", @"/Views/_ViewImports.cshtml")]
    public class Views_AdminActions_ViewFlightSchedule : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<web2020apr_p01_t3.Models.FlightScheduleViewModel>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/css/table.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "ViewScheduleBooking", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "AdminActions", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "AssignPersonnel", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "36771d7541262185865301ca28764f8e14ad40cc5435", async() => {
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
            WriteLiteral("\r\n\r\n");
#nullable restore
#line 4 "/Users/yongtenggg/Desktop/Poly/Year 2/Web Application Development/Assignment/Group 3/Source Code/web2020apr_p01_t3/web2020apr_p01_t3/Views/AdminActions/ViewFlightSchedule.cshtml"
 if (TempData["CreateScheduleSuccess"] != null)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class=\"alert alert-success alert-dismissable\">\r\n        <strong>");
#nullable restore
#line 7 "/Users/yongtenggg/Desktop/Poly/Year 2/Web Application Development/Assignment/Group 3/Source Code/web2020apr_p01_t3/web2020apr_p01_t3/Views/AdminActions/ViewFlightSchedule.cshtml"
           Write(TempData["CreateScheduleSuccess"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</strong>\r\n    </div>\r\n");
#nullable restore
#line 9 "/Users/yongtenggg/Desktop/Poly/Year 2/Web Application Development/Assignment/Group 3/Source Code/web2020apr_p01_t3/web2020apr_p01_t3/Views/AdminActions/ViewFlightSchedule.cshtml"
}

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "/Users/yongtenggg/Desktop/Poly/Year 2/Web Application Development/Assignment/Group 3/Source Code/web2020apr_p01_t3/web2020apr_p01_t3/Views/AdminActions/ViewFlightSchedule.cshtml"
 if (TempData["EditScheduleSuccess"] != null)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class=\"alert alert-success alert-dismissable\">\r\n        <strong>");
#nullable restore
#line 13 "/Users/yongtenggg/Desktop/Poly/Year 2/Web Application Development/Assignment/Group 3/Source Code/web2020apr_p01_t3/web2020apr_p01_t3/Views/AdminActions/ViewFlightSchedule.cshtml"
           Write(TempData["EditScheduleSuccess"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</strong>\r\n    </div>\r\n");
#nullable restore
#line 15 "/Users/yongtenggg/Desktop/Poly/Year 2/Web Application Development/Assignment/Group 3/Source Code/web2020apr_p01_t3/web2020apr_p01_t3/Views/AdminActions/ViewFlightSchedule.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 17 "/Users/yongtenggg/Desktop/Poly/Year 2/Web Application Development/Assignment/Group 3/Source Code/web2020apr_p01_t3/web2020apr_p01_t3/Views/AdminActions/ViewFlightSchedule.cshtml"
 if (TempData["DeleteScheduleSuccess"] != null)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class=\"alert alert-success alert-dismissable\">\r\n        <strong>");
#nullable restore
#line 20 "/Users/yongtenggg/Desktop/Poly/Year 2/Web Application Development/Assignment/Group 3/Source Code/web2020apr_p01_t3/web2020apr_p01_t3/Views/AdminActions/ViewFlightSchedule.cshtml"
           Write(TempData["DeleteScheduleSuccess"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</strong>\r\n    </div>\r\n");
#nullable restore
#line 22 "/Users/yongtenggg/Desktop/Poly/Year 2/Web Application Development/Assignment/Group 3/Source Code/web2020apr_p01_t3/web2020apr_p01_t3/Views/AdminActions/ViewFlightSchedule.cshtml"
}

#line default
#line hidden
#nullable disable
#nullable restore
#line 23 "/Users/yongtenggg/Desktop/Poly/Year 2/Web Application Development/Assignment/Group 3/Source Code/web2020apr_p01_t3/web2020apr_p01_t3/Views/AdminActions/ViewFlightSchedule.cshtml"
 if (TempData["DeleteScheduleFail"] != null)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class=\"alert alert-danger alert-dismissable\">\r\n        <strong>");
#nullable restore
#line 26 "/Users/yongtenggg/Desktop/Poly/Year 2/Web Application Development/Assignment/Group 3/Source Code/web2020apr_p01_t3/web2020apr_p01_t3/Views/AdminActions/ViewFlightSchedule.cshtml"
           Write(TempData["DeleteScheduleFail"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</strong>\r\n    </div>\r\n");
#nullable restore
#line 28 "/Users/yongtenggg/Desktop/Poly/Year 2/Web Application Development/Assignment/Group 3/Source Code/web2020apr_p01_t3/web2020apr_p01_t3/Views/AdminActions/ViewFlightSchedule.cshtml"
}

#line default
#line hidden
#nullable disable
#nullable restore
#line 29 "/Users/yongtenggg/Desktop/Poly/Year 2/Web Application Development/Assignment/Group 3/Source Code/web2020apr_p01_t3/web2020apr_p01_t3/Views/AdminActions/ViewFlightSchedule.cshtml"
 if (TempData["UpdateScheduleBookingSuccess"] != null)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class=\"alert alert-success alert-dismissable\">\r\n        <strong>");
#nullable restore
#line 32 "/Users/yongtenggg/Desktop/Poly/Year 2/Web Application Development/Assignment/Group 3/Source Code/web2020apr_p01_t3/web2020apr_p01_t3/Views/AdminActions/ViewFlightSchedule.cshtml"
           Write(TempData["UpdateScheduleBookingSuccess"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</strong>\r\n    </div>\r\n");
#nullable restore
#line 34 "/Users/yongtenggg/Desktop/Poly/Year 2/Web Application Development/Assignment/Group 3/Source Code/web2020apr_p01_t3/web2020apr_p01_t3/Views/AdminActions/ViewFlightSchedule.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("<!--p><a asp-action=\"CreateFlightSchedule\">Create New Flight Schedule</a></p-->\r\n\r\n");
#nullable restore
#line 37 "/Users/yongtenggg/Desktop/Poly/Year 2/Web Application Development/Assignment/Group 3/Source Code/web2020apr_p01_t3/web2020apr_p01_t3/Views/AdminActions/ViewFlightSchedule.cshtml"
 if (Model.ToList().Count > 0)
{

#line default
#line hidden
#nullable disable
            WriteLiteral(@"    <div class=""table-responsive"" id=""table-padding"">
        <table id=""viewStaff"" class=""rwd-table table table-striped table-bordered"">
            <thead class=""thead-dark"">
                <tr>
                    <th>Schedule ID</th>
                    <th>Flight Number</th>
                    <th>Route ID</th>
                    <th>Departure / Arrival</th>
                    <th>Departure Date and Time</th>
                    <th>Arrival Date and Time</th>
                    <th>Price (Eco / Business)</th>
                    <th>Duration</th>
                    <th>Actions</th>
                </tr>
            </thead>
            <tbody>
");
#nullable restore
#line 55 "/Users/yongtenggg/Desktop/Poly/Year 2/Web Application Development/Assignment/Group 3/Source Code/web2020apr_p01_t3/web2020apr_p01_t3/Views/AdminActions/ViewFlightSchedule.cshtml"
                 foreach (var item in Model)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <tr>\r\n                        <td>");
#nullable restore
#line 58 "/Users/yongtenggg/Desktop/Poly/Year 2/Web Application Development/Assignment/Group 3/Source Code/web2020apr_p01_t3/web2020apr_p01_t3/Views/AdminActions/ViewFlightSchedule.cshtml"
                       Write(item.ScheduleID.ToString());

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td>");
#nullable restore
#line 59 "/Users/yongtenggg/Desktop/Poly/Year 2/Web Application Development/Assignment/Group 3/Source Code/web2020apr_p01_t3/web2020apr_p01_t3/Views/AdminActions/ViewFlightSchedule.cshtml"
                       Write(item.FlightNumber.ToString());

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td>");
#nullable restore
#line 60 "/Users/yongtenggg/Desktop/Poly/Year 2/Web Application Development/Assignment/Group 3/Source Code/web2020apr_p01_t3/web2020apr_p01_t3/Views/AdminActions/ViewFlightSchedule.cshtml"
                       Write(item.RouteID);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td>");
#nullable restore
#line 61 "/Users/yongtenggg/Desktop/Poly/Year 2/Web Application Development/Assignment/Group 3/Source Code/web2020apr_p01_t3/web2020apr_p01_t3/Views/AdminActions/ViewFlightSchedule.cshtml"
                       Write(item.DepartureCountry.ToString());

#line default
#line hidden
#nullable disable
            WriteLiteral(", ");
#nullable restore
#line 61 "/Users/yongtenggg/Desktop/Poly/Year 2/Web Application Development/Assignment/Group 3/Source Code/web2020apr_p01_t3/web2020apr_p01_t3/Views/AdminActions/ViewFlightSchedule.cshtml"
                                                          Write(item.DepartureCity.ToString());

#line default
#line hidden
#nullable disable
            WriteLiteral(" / ");
#nullable restore
#line 61 "/Users/yongtenggg/Desktop/Poly/Year 2/Web Application Development/Assignment/Group 3/Source Code/web2020apr_p01_t3/web2020apr_p01_t3/Views/AdminActions/ViewFlightSchedule.cshtml"
                                                                                           Write(item.ArrivalCountry.ToString());

#line default
#line hidden
#nullable disable
            WriteLiteral(", ");
#nullable restore
#line 61 "/Users/yongtenggg/Desktop/Poly/Year 2/Web Application Development/Assignment/Group 3/Source Code/web2020apr_p01_t3/web2020apr_p01_t3/Views/AdminActions/ViewFlightSchedule.cshtml"
                                                                                                                            Write(item.ArrivalCity.ToString());

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n");
#nullable restore
#line 62 "/Users/yongtenggg/Desktop/Poly/Year 2/Web Application Development/Assignment/Group 3/Source Code/web2020apr_p01_t3/web2020apr_p01_t3/Views/AdminActions/ViewFlightSchedule.cshtml"
                         if (item.DepartureDateTime == null)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <td><i>NULL</i></td>\r\n                            <td><i>NULL</i></td>\r\n");
#nullable restore
#line 66 "/Users/yongtenggg/Desktop/Poly/Year 2/Web Application Development/Assignment/Group 3/Source Code/web2020apr_p01_t3/web2020apr_p01_t3/Views/AdminActions/ViewFlightSchedule.cshtml"
                        }
                        else
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <td>");
#nullable restore
#line 69 "/Users/yongtenggg/Desktop/Poly/Year 2/Web Application Development/Assignment/Group 3/Source Code/web2020apr_p01_t3/web2020apr_p01_t3/Views/AdminActions/ViewFlightSchedule.cshtml"
                           Write(Html.DisplayFor(x => item.DepartureDateTime));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            <td>");
#nullable restore
#line 70 "/Users/yongtenggg/Desktop/Poly/Year 2/Web Application Development/Assignment/Group 3/Source Code/web2020apr_p01_t3/web2020apr_p01_t3/Views/AdminActions/ViewFlightSchedule.cshtml"
                           Write(Html.DisplayFor(x => item.ArrivalDateTime));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n");
#nullable restore
#line 71 "/Users/yongtenggg/Desktop/Poly/Year 2/Web Application Development/Assignment/Group 3/Source Code/web2020apr_p01_t3/web2020apr_p01_t3/Views/AdminActions/ViewFlightSchedule.cshtml"

                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <td>$");
#nullable restore
#line 73 "/Users/yongtenggg/Desktop/Poly/Year 2/Web Application Development/Assignment/Group 3/Source Code/web2020apr_p01_t3/web2020apr_p01_t3/Views/AdminActions/ViewFlightSchedule.cshtml"
                        Write(Html.DisplayFor(x => item.PriceEco));

#line default
#line hidden
#nullable disable
            WriteLiteral(" / $");
#nullable restore
#line 73 "/Users/yongtenggg/Desktop/Poly/Year 2/Web Application Development/Assignment/Group 3/Source Code/web2020apr_p01_t3/web2020apr_p01_t3/Views/AdminActions/ViewFlightSchedule.cshtml"
                                                                Write(Html.DisplayFor(x => item.PriceBusiness));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td>");
#nullable restore
#line 74 "/Users/yongtenggg/Desktop/Poly/Year 2/Web Application Development/Assignment/Group 3/Source Code/web2020apr_p01_t3/web2020apr_p01_t3/Views/AdminActions/ViewFlightSchedule.cshtml"
                       Write(item.FlightDuration);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </td>\r\n                        <td>\r\n                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "36771d7541262185865301ca28764f8e14ad40cc19160", async() => {
                WriteLiteral("View");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-scheduleID", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 76 "/Users/yongtenggg/Desktop/Poly/Year 2/Web Application Development/Assignment/Group 3/Source Code/web2020apr_p01_t3/web2020apr_p01_t3/Views/AdminActions/ViewFlightSchedule.cshtml"
                                                                                                        WriteLiteral(item.ScheduleID);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["scheduleID"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-scheduleID", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["scheduleID"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(" |\r\n                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "36771d7541262185865301ca28764f8e14ad40cc21714", async() => {
                WriteLiteral("Assign");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
                            <!--< a asp-action=""EditFlightSchedule"" asp-controller=""AdminActions"" asp-route-id=""item.ScheduleID"">Edit</a>
                            <a asp-action=""DeleteSchedule"" asp-controller=""AdminActions"" asp-route-id=""item.ScheduleID"">Delete</a>-->
                        </td>
                    </tr>
");
#nullable restore
#line 82 "/Users/yongtenggg/Desktop/Poly/Year 2/Web Application Development/Assignment/Group 3/Source Code/web2020apr_p01_t3/web2020apr_p01_t3/Views/AdminActions/ViewFlightSchedule.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("            </tbody>\r\n        </table>\r\n    </div>\r\n");
#nullable restore
#line 86 "/Users/yongtenggg/Desktop/Poly/Year 2/Web Application Development/Assignment/Group 3/Source Code/web2020apr_p01_t3/web2020apr_p01_t3/Views/AdminActions/ViewFlightSchedule.cshtml"
}
else
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class=\"alert alert-success alert-dismissable\">\r\n        <strong>No records found!</strong>\r\n    </div>\r\n");
#nullable restore
#line 92 "/Users/yongtenggg/Desktop/Poly/Year 2/Web Application Development/Assignment/Group 3/Source Code/web2020apr_p01_t3/web2020apr_p01_t3/Views/AdminActions/ViewFlightSchedule.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<web2020apr_p01_t3.Models.FlightScheduleViewModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591