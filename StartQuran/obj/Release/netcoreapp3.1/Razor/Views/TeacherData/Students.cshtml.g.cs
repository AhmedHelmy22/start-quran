#pragma checksum "D:\Job\FreeLance\Start-Quran\Start-Quran\StartQuran\Views\TeacherData\Students.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "932ddecbca7fab84c442d5ef97871b7752108db5"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_TeacherData_Students), @"mvc.1.0.view", @"/Views/TeacherData/Students.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"932ddecbca7fab84c442d5ef97871b7752108db5", @"/Views/TeacherData/Students.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"85f3c6811bb0d0dbcb904e2eae52fe1f2785c317", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_TeacherData_Students : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<StartQuran.Models.DataBase.Student>>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "D:\Job\FreeLance\Start-Quran\Start-Quran\StartQuran\Views\TeacherData\Students.cshtml"
  
    ViewData["Title"] = "الطلاب";
    Layout = "~/Views/Shared/_Layout.cshtml";



#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<div class=""card"">
    <div class=""card-header"" style=""text-align:center"">

        <h3 class=""card-title"">الطلاب</h3>
    </div>
    <!-- /.card-header -->
    <div class=""card-body"">
        <table id=""example1"" class=""table table-bordered table-striped"" data-page-length='100'>
            <thead>
                <tr style=""text-align:center"">
                    <th>الاسم</th>
                    <th>العائلة</th>
                    <th>العمر</th>
                    <th>النوع</th>
                    <th>تاريخ الانضمام</th>
               


                </tr>
            </thead>
            <tbody>
");
#nullable restore
#line 31 "D:\Job\FreeLance\Start-Quran\Start-Quran\StartQuran\Views\TeacherData\Students.cshtml"
                 foreach (var item in Model)
                {


#line default
#line hidden
#nullable disable
            WriteLiteral("                    <tr style=\"text-align:center\">\r\n\r\n                        <td>");
#nullable restore
#line 36 "D:\Job\FreeLance\Start-Quran\Start-Quran\StartQuran\Views\TeacherData\Students.cshtml"
                       Write(item.FullName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n");
#nullable restore
#line 37 "D:\Job\FreeLance\Start-Quran\Start-Quran\StartQuran\Views\TeacherData\Students.cshtml"
                         if (item.Family != null)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <td>");
#nullable restore
#line 39 "D:\Job\FreeLance\Start-Quran\Start-Quran\StartQuran\Views\TeacherData\Students.cshtml"
                           Write(item.Family.FullName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n");
#nullable restore
#line 40 "D:\Job\FreeLance\Start-Quran\Start-Quran\StartQuran\Views\TeacherData\Students.cshtml"
                        }
                        else
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <td></td>\r\n");
#nullable restore
#line 44 "D:\Job\FreeLance\Start-Quran\Start-Quran\StartQuran\Views\TeacherData\Students.cshtml"

                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <td>");
#nullable restore
#line 46 "D:\Job\FreeLance\Start-Quran\Start-Quran\StartQuran\Views\TeacherData\Students.cshtml"
                       Write(item.Age);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td>");
#nullable restore
#line 47 "D:\Job\FreeLance\Start-Quran\Start-Quran\StartQuran\Views\TeacherData\Students.cshtml"
                       Write(item.Gender);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td>");
#nullable restore
#line 48 "D:\Job\FreeLance\Start-Quran\Start-Quran\StartQuran\Views\TeacherData\Students.cshtml"
                       Write(item.JoiningDate);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    \r\n\r\n             \r\n\r\n                    </tr>\r\n");
#nullable restore
#line 54 "D:\Job\FreeLance\Start-Quran\Start-Quran\StartQuran\Views\TeacherData\Students.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("            </tbody>\r\n\r\n        </table>\r\n    </div>\r\n    <!-- /.card-body -->\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<StartQuran.Models.DataBase.Student>> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
