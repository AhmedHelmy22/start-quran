#pragma checksum "D:\Job\FreeLance\Start-Quran\Start-Quran\StartQuran\Views\Invoice\Student.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d124650abecbb111b81d0de391cc5a86eb330a53"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Invoice_Student), @"mvc.1.0.view", @"/Views/Invoice/Student.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d124650abecbb111b81d0de391cc5a86eb330a53", @"/Views/Invoice/Student.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"85f3c6811bb0d0dbcb904e2eae52fe1f2785c317", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Invoice_Student : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<StartQuran.Service.InvoiceService.Model.InvoiceStudent>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("width: 70px;"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/assets/img/StartQuran.PNG"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("width: 230px;margin-bottom: 65px;"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString(" float-right"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("margin-right: 5px;width: 100px;height: 38px;"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/Design/dist/img/credit/paypal2.png"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("alt", new global::Microsoft.AspNetCore.Html.HtmlString("Paypal"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#nullable restore
#line 2 "D:\Job\FreeLance\Start-Quran\Start-Quran\StartQuran\Views\Invoice\Student.cshtml"
  
    ViewData["Title"] = "الفاتورة";
     if (User.IsInRole("ADMIN"))
    {
        Layout = "~/Views/Shared/_Layout.cshtml";
    }
    var messageTemp = TempData["AlertMessage"] ?? string.Empty;

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<script src=""https://cdnjs.cloudflare.com/ajax/libs/jquery/3.3.1/jquery.min.js""></script>
<script src=""//cdn.jsdelivr.net/npm/sweetalert2@11""></script>
<div style=""background-color: white;direction:ltr;"" class=""invoice p-3 mb-3"">
    <!-- title row -->
    <div class=""row"">
        <div class=""col-12"">
            
        </div>
        <!-- /.col -->
    </div>
    <!-- info row -->
    <div class=""row invoice-info"">
        <div class=""col-sm-4 invoice-col"">
            From
            <address>
                Helwan, Cairo<br>
                EGYPT<br>
                Phone: +201061384005<br>
                Email: contact@start-quran.com
            </address>
        </div>
           <div class=""col-sm-4 invoice-col"" style="" justify-content: center; display: flex; "">
           ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "d124650abecbb111b81d0de391cc5a86eb330a536946", async() => {
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
            WriteLiteral("\r\n           </div>\r\n        <!-- /.col -->\r\n        <div class=\"col-sm-4 invoice-col\">\r\n            \r\n            <address>\r\n                <strong>");
#nullable restore
#line 38 "D:\Job\FreeLance\Start-Quran\Start-Quran\StartQuran\Views\Invoice\Student.cshtml"
                   Write(Model.Student.FullName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</strong><br>\r\n                <small >Date: ");
#nullable restore
#line 39 "D:\Job\FreeLance\Start-Quran\Start-Quran\StartQuran\Views\Invoice\Student.cshtml"
                         Write(String.Format("{0: MMMM , yyyy}", @Model.date));

#line default
#line hidden
#nullable disable
            WriteLiteral("</small>\r\n                <br>            \r\n                <b>Payment Due:</b> <input type=\"date\"");
            BeginWriteAttribute("value", " value=\"", 1515, "\"", 1534, 1);
#nullable restore
#line 41 "D:\Job\FreeLance\Start-Quran\Start-Quran\StartQuran\Views\Invoice\Student.cshtml"
WriteAttributeValue("", 1523, Model.date, 1523, 11, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" id=\"DateStudentInvoice\" /><br>\r\n                <input hidden type=\"text\"");
            BeginWriteAttribute("value", " value=\"", 1609, "\"", 1634, 1);
#nullable restore
#line 42 "D:\Job\FreeLance\Start-Quran\Start-Quran\StartQuran\Views\Invoice\Student.cshtml"
WriteAttributeValue("", 1617, Model.Student.ID, 1617, 17, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@" id=""StudentId"" />
            </address>
        </div>
        <!-- /.col -->
       
        <!-- /.col -->
    </div>
    <!-- /.row -->
    <!-- Table row -->
    <div class=""row"">
        <div class=""col-12 table-responsive"">
             <table id=""example2"" class=""table table-bordered table-striped"" data-page-length='100'>
                <thead>
                    <tr>
                        <th>Student</th>
                        <th>Teacher</th>
                        <th>Hour</th>
                        <th>Date</th>
                        <th>Comment</th>
                    </tr>
                </thead>
                <tbody>
");
#nullable restore
#line 64 "D:\Job\FreeLance\Start-Quran\Start-Quran\StartQuran\Views\Invoice\Student.cshtml"
                     foreach(var item in Model.Sections.OrderBy(c=>c.SectionDate).ToList())
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                         <tr>\r\n                            <td>");
#nullable restore
#line 67 "D:\Job\FreeLance\Start-Quran\Start-Quran\StartQuran\Views\Invoice\Student.cshtml"
                           Write(item.Student.FullName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            <td>");
#nullable restore
#line 68 "D:\Job\FreeLance\Start-Quran\Start-Quran\StartQuran\Views\Invoice\Student.cshtml"
                           Write(item.Teacher.FullName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            <td>");
#nullable restore
#line 69 "D:\Job\FreeLance\Start-Quran\Start-Quran\StartQuran\Views\Invoice\Student.cshtml"
                           Write(item.NumberOfHours);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            <td>");
#nullable restore
#line 70 "D:\Job\FreeLance\Start-Quran\Start-Quran\StartQuran\Views\Invoice\Student.cshtml"
                           Write(item.SectionDate.ToShortDateString());

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            <td>");
#nullable restore
#line 71 "D:\Job\FreeLance\Start-Quran\Start-Quran\StartQuran\Views\Invoice\Student.cshtml"
                           Write(item.Comment);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                         </tr>\r\n");
#nullable restore
#line 73 "D:\Job\FreeLance\Start-Quran\Start-Quran\StartQuran\Views\Invoice\Student.cshtml"
                 
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                </tbody>\r\n            </table>\r\n        </div>\r\n        <!-- /.col -->\r\n    </div>\r\n    <!-- /.row -->\r\n\r\n    <div class=\"row\">\r\n        <!-- accepted payments column -->\r\n        <div class=\"col-md-6 col-12\">\r\n            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "d124650abecbb111b81d0de391cc5a86eb330a5312730", async() => {
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
            WriteLiteral("\r\n\r\n        </div>\r\n        <!-- /.col -->\r\n        <div class=\"col-6\">\r\n              <p class=\"lead\">Amount Due :   ");
#nullable restore
#line 90 "D:\Job\FreeLance\Start-Quran\Start-Quran\StartQuran\Views\Invoice\Student.cshtml"
                                        Write(String.Format("{0: MMMM , yyyy}", @Model.date));

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n\r\n            <div class=\"table-responsive\">\r\n                <table class=\"table\">\r\n                     <tr>\r\n                        <th style=\"width:50%\">Total Hour:</th>\r\n                        <td>");
#nullable restore
#line 96 "D:\Job\FreeLance\Start-Quran\Start-Quran\StartQuran\Views\Invoice\Student.cshtml"
                       Write(Model.NumOfHour);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    </tr>\r\n                    <tr>\r\n                        <th style=\"width:50%\">Price per Hour :</th>\r\n                        <td>");
#nullable restore
#line 100 "D:\Job\FreeLance\Start-Quran\Start-Quran\StartQuran\Views\Invoice\Student.cshtml"
                       Write(Model.Student.PriceOfHour);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    </tr>\r\n                    <tr>\r\n                        <th style=\"width:50%\">Cash:</th>\r\n                        <td>$");
#nullable restore
#line 104 "D:\Job\FreeLance\Start-Quran\Start-Quran\StartQuran\Views\Invoice\Student.cshtml"
                        Write(Model.Cach);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    </tr>\r\n                    <tr>\r\n                        <th>Tax (");
#nullable restore
#line 107 "D:\Job\FreeLance\Start-Quran\Start-Quran\StartQuran\Views\Invoice\Student.cshtml"
                            Write(Model.Tax);

#line default
#line hidden
#nullable disable
            WriteLiteral("%)</th>\r\n                        <td>$");
#nullable restore
#line 108 "D:\Job\FreeLance\Start-Quran\Start-Quran\StartQuran\Views\Invoice\Student.cshtml"
                        Write(Model.TotalTax);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    </tr>\r\n                    <tr>\r\n                        <th>Total:</th>\r\n                        <td>$");
#nullable restore
#line 112 "D:\Job\FreeLance\Start-Quran\Start-Quran\StartQuran\Views\Invoice\Student.cshtml"
                        Write(Model.TotalPayMent);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</td>
                    </tr>
                   
                </table>
            </div>
        </div>
        <!-- /.col -->
    </div>
    <!-- /.row -->
    <!-- this row will not appear when printing -->
    <div class=""row no-print"">
        <div class=""col-12"">
            <a  onclick=""PrintPage()"" rel=""noopener"" target=""_blank"" class=""btn btn-default""><i class=""fas fa-print""></i> Print</a>
");
            WriteLiteral("                     <a");
            BeginWriteAttribute("href", " href=\"", 4827, "\"", 4855, 1);
#nullable restore
#line 129 "D:\Job\FreeLance\Start-Quran\Start-Quran\StartQuran\Views\Invoice\Student.cshtml"
WriteAttributeValue("", 4834, Model.Student.Paypal, 4834, 21, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                          ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "d124650abecbb111b81d0de391cc5a86eb330a5317445", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_6);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                     </a>\r\n\r\n        </div>\r\n    </div>\r\n</div>\r\n\r\n<script type=\"text/javascript\">\r\n      var message = \'");
#nullable restore
#line 138 "D:\Job\FreeLance\Start-Quran\Start-Quran\StartQuran\Views\Invoice\Student.cshtml"
                Write(messageTemp);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"';
    if (message) {
        if (message == ""Done"") {

        }
        else {
            Swal.fire({
                icon: 'error',
                title: 'هناك مشكله',
                text: 'لم يتم السماح لك لمشاهده هذه الفاتوره'
            })
        }
    }

    
   
</script>

 <script>
     function PrintPage(){
          window.addEventListener(window.print());
     }
        $(function () {

            $('#DateStudentInvoice').on('change', function () {
                
                var StuId = $('#StudentId').val();
                var date = $('#DateStudentInvoice').val();
              var url = ""/Invoice/StudentDate?"" + ""Id="" + StuId + ""&Date="" + date;

              window.location.assign(url);

            });
        });
 </script>
");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<StartQuran.Service.InvoiceService.Model.InvoiceStudent> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
