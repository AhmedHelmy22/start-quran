#pragma checksum "D:\Job\FreeLance\Start-Quran\Start-Quran\StartQuran\Views\WebSite\Home.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ff422ac4e8353a163dd5fc905a71c02ef339494d"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_WebSite_Home), @"mvc.1.0.view", @"/Views/WebSite/Home.cshtml")]
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
#line 1 "D:\Job\FreeLance\Start-Quran\Start-Quran\StartQuran\Views\_ViewImports.cshtml"
using StartQuran;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\Job\FreeLance\Start-Quran\Start-Quran\StartQuran\Views\_ViewImports.cshtml"
using StartQuran.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ff422ac4e8353a163dd5fc905a71c02ef339494d", @"/Views/WebSite/Home.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"85f3c6811bb0d0dbcb904e2eae52fe1f2785c317", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_WebSite_Home : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<StartQuran.Models.DataBase.RegistrationFamily>>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-sucsses"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "website", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "IsRead", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("onclick", new global::Microsoft.AspNetCore.Html.HtmlString("return confirm(\'هل انت متأكد انك تواصلت مع العميل ؟\');"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-danger"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Delete", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("onclick", new global::Microsoft.AspNetCore.Html.HtmlString("return confirm(\'هل انت متأكد انك تريد حذف هذا العنصر ؟\');"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/Site/js/main.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "D:\Job\FreeLance\Start-Quran\Start-Quran\StartQuran\Views\WebSite\Home.cshtml"
  
    
    Layout = "~/Views/Shared/_Layout.cshtml";
    var messageTemp = TempData["AlertMessage"] ?? string.Empty;


#line default
#line hidden
#nullable disable
            WriteLiteral(@"<script src=""https://cdnjs.cloudflare.com/ajax/libs/jquery/3.3.1/jquery.min.js""></script>
<script src=""//cdn.jsdelivr.net/npm/sweetalert2@11""></script>


<div class=""card"">
    
    <!-- /.card-header -->
    <div class=""card-body"">
        <table id=""example1"" class=""table table-bordered table-striped"" data-page-length='100'>
            <thead>
                <tr style=""text-align:center"">
                    <th>الاسم</th>
                    <th>واتس</th>
                    <th> تلفون - كود البلد</th>
                    <th>الرسالة</th>
                    <th>تاريخ التسجيل</th>
                    <th>العمليات</th>

                </tr>
            </thead>
            <tbody>
");
#nullable restore
#line 30 "D:\Job\FreeLance\Start-Quran\Start-Quran\StartQuran\Views\WebSite\Home.cshtml"
                 foreach (var item in Model)
                {
                    

#line default
#line hidden
#nullable disable
#nullable restore
#line 32 "D:\Job\FreeLance\Start-Quran\Start-Quran\StartQuran\Views\WebSite\Home.cshtml"
                     if (item.Read)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <tr style=\"text-align:center ; background-color:indianred\">\r\n                            <td>");
#nullable restore
#line 35 "D:\Job\FreeLance\Start-Quran\Start-Quran\StartQuran\Views\WebSite\Home.cshtml"
                           Write(item.FullName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            <td>");
#nullable restore
#line 36 "D:\Job\FreeLance\Start-Quran\Start-Quran\StartQuran\Views\WebSite\Home.cshtml"
                           Write(item.WhatsApp);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            \r\n                            <td>(");
#nullable restore
#line 38 "D:\Job\FreeLance\Start-Quran\Start-Quran\StartQuran\Views\WebSite\Home.cshtml"
                            Write(item.CountryCode);

#line default
#line hidden
#nullable disable
            WriteLiteral(")");
#nullable restore
#line 38 "D:\Job\FreeLance\Start-Quran\Start-Quran\StartQuran\Views\WebSite\Home.cshtml"
                                              Write(item.PhoneNumber);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            <td>");
#nullable restore
#line 39 "D:\Job\FreeLance\Start-Quran\Start-Quran\StartQuran\Views\WebSite\Home.cshtml"
                           Write(item.Message);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            <td>");
#nullable restore
#line 40 "D:\Job\FreeLance\Start-Quran\Start-Quran\StartQuran\Views\WebSite\Home.cshtml"
                           Write(String.Format("{0:dd, MMMM , yyyy}", @item.CreateDate));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            <td>\r\n                               <a class=\"btn btn-sucsses\"");
            BeginWriteAttribute("href", " href=\"", 1570, "\"", 1601, 2);
            WriteAttributeValue("", 1577, "/website/IsRead/", 1577, 16, true);
#nullable restore
#line 42 "D:\Job\FreeLance\Start-Quran\Start-Quran\StartQuran\Views\WebSite\Home.cshtml"
WriteAttributeValue("", 1593, item.ID, 1593, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" onclick = \"return confirm(\'هل انت متأكد انك تواصلت مع العميل ؟\');\"><i class=\"fa fa-eye\"></i></a>\r\n");
#nullable restore
#line 43 "D:\Job\FreeLance\Start-Quran\Start-Quran\StartQuran\Views\WebSite\Home.cshtml"
                                 if (User.IsInRole("ADMIN"))
                                {   

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <a class=\"btn btn-danger\"");
            BeginWriteAttribute("href", " href=\"", 1862, "\"", 1893, 2);
            WriteAttributeValue("", 1869, "/website/Delete/", 1869, 16, true);
#nullable restore
#line 45 "D:\Job\FreeLance\Start-Quran\Start-Quran\StartQuran\Views\WebSite\Home.cshtml"
WriteAttributeValue("", 1885, item.ID, 1885, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" onclick = \"return confirm(\'هل انت متأكد انك تريد حذف هذا العنصر ؟\');\"><i class=\"fa fa-trash\"></i></a>\r\n");
#nullable restore
#line 46 "D:\Job\FreeLance\Start-Quran\Start-Quran\StartQuran\Views\WebSite\Home.cshtml"
                                }

#line default
#line hidden
#nullable disable
            WriteLiteral("                          \r\n                            </td>\r\n                        </tr>\r\n");
#nullable restore
#line 50 "D:\Job\FreeLance\Start-Quran\Start-Quran\StartQuran\Views\WebSite\Home.cshtml"
                    }
                    else{

#line default
#line hidden
#nullable disable
            WriteLiteral("                         <tr style=\"text-align:center; background-color:lightgreen \">\r\n                            <td>");
#nullable restore
#line 53 "D:\Job\FreeLance\Start-Quran\Start-Quran\StartQuran\Views\WebSite\Home.cshtml"
                           Write(item.FullName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            <td>");
#nullable restore
#line 54 "D:\Job\FreeLance\Start-Quran\Start-Quran\StartQuran\Views\WebSite\Home.cshtml"
                           Write(item.WhatsApp);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            <td>(");
#nullable restore
#line 55 "D:\Job\FreeLance\Start-Quran\Start-Quran\StartQuran\Views\WebSite\Home.cshtml"
                            Write(item.CountryCode);

#line default
#line hidden
#nullable disable
            WriteLiteral(")");
#nullable restore
#line 55 "D:\Job\FreeLance\Start-Quran\Start-Quran\StartQuran\Views\WebSite\Home.cshtml"
                                              Write(item.PhoneNumber);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                             <td>");
#nullable restore
#line 56 "D:\Job\FreeLance\Start-Quran\Start-Quran\StartQuran\Views\WebSite\Home.cshtml"
                            Write(item.Message);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            <td>");
#nullable restore
#line 57 "D:\Job\FreeLance\Start-Quran\Start-Quran\StartQuran\Views\WebSite\Home.cshtml"
                           Write(String.Format("{0:dd, MMMM , yyyy}", @item.CreateDate));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            <td>\r\n                               ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "ff422ac4e8353a163dd5fc905a71c02ef339494d13442", async() => {
                WriteLiteral("<i class=\"fa fa-eye\"></i>");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 59 "D:\Job\FreeLance\Start-Quran\Start-Quran\StartQuran\Views\WebSite\Home.cshtml"
                                                                                                         WriteLiteral(item.ID);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n                                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "ff422ac4e8353a163dd5fc905a71c02ef339494d16085", async() => {
                WriteLiteral("<i class=\"fa fa-trash\"></i>");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_5.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 61 "D:\Job\FreeLance\Start-Quran\Start-Quran\StartQuran\Views\WebSite\Home.cshtml"
                                                                                                         WriteLiteral(item.ID);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_6);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                          \r\n                            </td>\r\n                        </tr>\r\n");
#nullable restore
#line 65 "D:\Job\FreeLance\Start-Quran\Start-Quran\StartQuran\Views\WebSite\Home.cshtml"
                    }

#line default
#line hidden
#nullable disable
#nullable restore
#line 65 "D:\Job\FreeLance\Start-Quran\Start-Quran\StartQuran\Views\WebSite\Home.cshtml"
                     
                    

                        
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("            </tbody>\r\n\r\n        </table>\r\n    </div>\r\n    <!-- /.card-body -->\r\n</div>\r\n<input type=\"hidden\" id=\"hiddenId\" />\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "ff422ac4e8353a163dd5fc905a71c02ef339494d19403", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_7);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n<script type=\"text/javascript\">\r\n       \r\n   \r\n    \r\n\r\n</script>");
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<StartQuran.Models.DataBase.RegistrationFamily>> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
