#pragma checksum "C:\Users\yahia\Desktop\SupPlayer\SupPlayer\Views\Home\Delete.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "2f52b646009e8241012795d03e0853b78db6176d"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Delete), @"mvc.1.0.view", @"/Views/Home/Delete.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Home/Delete.cshtml", typeof(AspNetCore.Views_Home_Delete))]
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
#line 1 "C:\Users\yahia\Desktop\SupPlayer\SupPlayer\Views\_ViewImports.cshtml"
using SupPlayer;

#line default
#line hidden
#line 2 "C:\Users\yahia\Desktop\SupPlayer\SupPlayer\Views\_ViewImports.cshtml"
using SupPlayer.Models;

#line default
#line hidden
#line 1 "C:\Users\yahia\Desktop\SupPlayer\SupPlayer\Views\Home\Delete.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#line 3 "C:\Users\yahia\Desktop\SupPlayer\SupPlayer\Views\Home\Delete.cshtml"
using SupPlayer.ViewModel;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2f52b646009e8241012795d03e0853b78db6176d", @"/Views/Home/Delete.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3f5b97fc85c6a5cde039172932163f0e3fa0ba18", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Delete : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<PlaylistViewModel>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(38, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(100, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(200, 54, true);
            WriteLiteral("\r\n<div class=\"contentsite\" style=\"margin-top:20px;\">\r\n");
            EndContext();
#line 10 "C:\Users\yahia\Desktop\SupPlayer\SupPlayer\Views\Home\Delete.cshtml"
     if (SignInManager.IsSignedIn(User))
    {

#line default
#line hidden
            BeginContext(303, 12, true);
            WriteLiteral("        <h2>");
            EndContext();
            BeginContext(316, 19, false);
#line 12 "C:\Users\yahia\Desktop\SupPlayer\SupPlayer\Views\Home\Delete.cshtml"
       Write(ViewData["message"]);

#line default
#line hidden
            EndContext();
            BeginContext(335, 7, true);
            WriteLiteral("</h2>\r\n");
            EndContext();
#line 13 "C:\Users\yahia\Desktop\SupPlayer\SupPlayer\Views\Home\Delete.cshtml"
    }
    else
    {

#line default
#line hidden
            BeginContext(366, 64, true);
            WriteLiteral("        <h2>You must be logged in to access this section.</h2>\r\n");
            EndContext();
#line 17 "C:\Users\yahia\Desktop\SupPlayer\SupPlayer\Views\Home\Delete.cshtml"
    }

#line default
#line hidden
            BeginContext(437, 10, true);
            WriteLiteral("</div>\r\n\r\n");
            EndContext();
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public UserManager<IdentityUser> UserManager { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public SignInManager<IdentityUser> SignInManager { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<PlaylistViewModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591