#pragma checksum "/Users/sarahkastama/Documents/C#/Assignments_C#/weddingPlanner/Views/Home/Dashboard.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "e2892f9a063d7260840bf4d8385d226178a50a2e"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(MyApp.Namespace.Home.Views_Home_Dashboard), @"mvc.1.0.view", @"/Views/Home/Dashboard.cshtml")]
namespace MyApp.Namespace.Home
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
#line 2 "/Users/sarahkastama/Documents/C#/Assignments_C#/weddingPlanner/Views/Home/Dashboard.cshtml"
using weddingPlanner.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e2892f9a063d7260840bf4d8385d226178a50a2e", @"/Views/Home/Dashboard.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"fc1d1eb37dc6f0d82250bf784d7ea6a0b75ca51c", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Dashboard : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<Wedding>>
    {
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("<!DOCTYPE html>\n<html lang=\"en\">\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "e2892f9a063d7260840bf4d8385d226178a50a2e3082", async() => {
                WriteLiteral("\n    <meta charset=\"UTF-8\">\n    <meta http-equiv=\"X-UA-Compatible\" content=\"IE=edge\">\n    <meta name=\"viewport\" content=\"width=device-width, initial-scale=1.0\">\n    <title>Wedding Planner</title>\n");
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
            WriteLiteral("\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "e2892f9a063d7260840bf4d8385d226178a50a2e4239", async() => {
                WriteLiteral("\n    <h1>Welcome to Wedding Planner</h1>\n    <a href=\"/logout\">Log out</a>\n    <table>\n        <tr>\n            <th>Wedding</th>\n            <th>Date</th>\n            <th>Guest</th>\n            <th>Action</th>\n        </tr>\n");
#nullable restore
#line 23 "/Users/sarahkastama/Documents/C#/Assignments_C#/weddingPlanner/Views/Home/Dashboard.cshtml"
         foreach(Wedding wed in Model)
        {

#line default
#line hidden
#nullable disable
                WriteLiteral("            <tr>\n                <td><a");
                BeginWriteAttribute("href", " href=\"", 625, "\"", 654, 2);
                WriteAttributeValue("", 632, "wedding/", 632, 8, true);
#nullable restore
#line 26 "/Users/sarahkastama/Documents/C#/Assignments_C#/weddingPlanner/Views/Home/Dashboard.cshtml"
WriteAttributeValue("", 640, wed.WeddingId, 640, 14, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(">");
#nullable restore
#line 26 "/Users/sarahkastama/Documents/C#/Assignments_C#/weddingPlanner/Views/Home/Dashboard.cshtml"
                                                Write(wed.WedderOne);

#line default
#line hidden
#nullable disable
                WriteLiteral(" & ");
#nullable restore
#line 26 "/Users/sarahkastama/Documents/C#/Assignments_C#/weddingPlanner/Views/Home/Dashboard.cshtml"
                                                                 Write(wed.WedderTwo);

#line default
#line hidden
#nullable disable
                WriteLiteral("</a></td>\n");
#nullable restore
#line 27 "/Users/sarahkastama/Documents/C#/Assignments_C#/weddingPlanner/Views/Home/Dashboard.cshtml"
                  
                    var formatDate = wed.Date.ToString("MMMM dd, yyyy");
                

#line default
#line hidden
#nullable disable
                WriteLiteral("                <td>");
#nullable restore
#line 30 "/Users/sarahkastama/Documents/C#/Assignments_C#/weddingPlanner/Views/Home/Dashboard.cshtml"
               Write(formatDate);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\n                <td>");
#nullable restore
#line 31 "/Users/sarahkastama/Documents/C#/Assignments_C#/weddingPlanner/Views/Home/Dashboard.cshtml"
               Write(wed.Reservations.Count);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\n");
#nullable restore
#line 32 "/Users/sarahkastama/Documents/C#/Assignments_C#/weddingPlanner/Views/Home/Dashboard.cshtml"
                  
                    if (wed.UserId == (int)ViewBag.UserLoggedIn) 
                    {

#line default
#line hidden
#nullable disable
                WriteLiteral("                        <td><a");
                BeginWriteAttribute("href", " href=\"", 1030, "\"", 1058, 2);
                WriteAttributeValue("", 1037, "delete/", 1037, 7, true);
#nullable restore
#line 35 "/Users/sarahkastama/Documents/C#/Assignments_C#/weddingPlanner/Views/Home/Dashboard.cshtml"
WriteAttributeValue("", 1044, wed.WeddingId, 1044, 14, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(">Delete</a></td>\n");
#nullable restore
#line 36 "/Users/sarahkastama/Documents/C#/Assignments_C#/weddingPlanner/Views/Home/Dashboard.cshtml"
                    }
                    else 
                    {
                        if (wed.Reservations.Count == 0)
                        {

#line default
#line hidden
#nullable disable
                WriteLiteral("                            <td><a");
                BeginWriteAttribute("href", " href=\"", 1263, "\"", 1289, 2);
                WriteAttributeValue("", 1270, "rsvp/", 1270, 5, true);
#nullable restore
#line 41 "/Users/sarahkastama/Documents/C#/Assignments_C#/weddingPlanner/Views/Home/Dashboard.cshtml"
WriteAttributeValue("", 1275, wed.WeddingId, 1275, 14, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(">RSVP</a></td>\n");
#nullable restore
#line 42 "/Users/sarahkastama/Documents/C#/Assignments_C#/weddingPlanner/Views/Home/Dashboard.cshtml"
                        }
                        foreach (Reservation res in wed.Reservations)
                        {
                            if (res.UserId == (int)ViewBag.UserLoggedIn)
                            {

#line default
#line hidden
#nullable disable
                WriteLiteral("                                <td><a");
                BeginWriteAttribute("href", " href=\"", 1568, "\"", 1600, 2);
                WriteAttributeValue("", 1575, "unrsvp/", 1575, 7, true);
#nullable restore
#line 47 "/Users/sarahkastama/Documents/C#/Assignments_C#/weddingPlanner/Views/Home/Dashboard.cshtml"
WriteAttributeValue("", 1582, res.ReservationId, 1582, 18, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(">Un-RSVP</a></td>\n");
#nullable restore
#line 48 "/Users/sarahkastama/Documents/C#/Assignments_C#/weddingPlanner/Views/Home/Dashboard.cshtml"
                            }
                            else 
                            {

#line default
#line hidden
#nullable disable
                WriteLiteral("                                <td><a");
                BeginWriteAttribute("href", " href=\"", 1751, "\"", 1777, 2);
                WriteAttributeValue("", 1758, "rsvp/", 1758, 5, true);
#nullable restore
#line 51 "/Users/sarahkastama/Documents/C#/Assignments_C#/weddingPlanner/Views/Home/Dashboard.cshtml"
WriteAttributeValue("", 1763, wed.WeddingId, 1763, 14, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(">RSVP</a></td>\n");
#nullable restore
#line 52 "/Users/sarahkastama/Documents/C#/Assignments_C#/weddingPlanner/Views/Home/Dashboard.cshtml"
                            }
                        }
                    }
                

#line default
#line hidden
#nullable disable
                WriteLiteral("            </tr>\n");
#nullable restore
#line 57 "/Users/sarahkastama/Documents/C#/Assignments_C#/weddingPlanner/Views/Home/Dashboard.cshtml"
        }

#line default
#line hidden
#nullable disable
                WriteLiteral("    </table>\n    <br/>\n    <a href=\"/plan/wedding\">New Wedding</a>\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\n</html>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<Wedding>> Html { get; private set; }
    }
}
#pragma warning restore 1591
