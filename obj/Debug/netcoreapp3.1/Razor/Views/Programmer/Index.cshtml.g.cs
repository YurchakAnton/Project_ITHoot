#pragma checksum "D:\ASP.NET Project\Project_ITHoot\Project_ITHoot\Views\Programmer\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f0d51b033269eda761738d577ece1ac0efb47857"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Programmer_Index), @"mvc.1.0.view", @"/Views/Programmer/Index.cshtml")]
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
#line 1 "D:\ASP.NET Project\Project_ITHoot\Project_ITHoot\Views\_ViewImports.cshtml"
using Project_ITHoot;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\ASP.NET Project\Project_ITHoot\Project_ITHoot\Views\_ViewImports.cshtml"
using Project_ITHoot.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f0d51b033269eda761738d577ece1ac0efb47857", @"/Views/Programmer/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0a1874460ea4c6d08249706d62a746616e8ab84f", @"/Views/_ViewImports.cshtml")]
    public class Views_Programmer_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Project_ITHoot.Models.ProgrammerModel>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "D:\ASP.NET Project\Project_ITHoot\Project_ITHoot\Views\Programmer\Index.cshtml"
  
    ViewData["Title"] = "Programmers";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>Programmers</h1>\r\n\r\n<div id=\"view-all\">\r\n    ");
#nullable restore
#line 10 "D:\ASP.NET Project\Project_ITHoot\Project_ITHoot\Views\Programmer\Index.cshtml"
Write(await Html.PartialAsync("_ViewAll", Model));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n</div>\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Project_ITHoot.Models.ProgrammerModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
