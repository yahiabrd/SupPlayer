#pragma checksum "C:\Users\yahia\Desktop\SupPlayer\SupPlayer\Views\Home\ErrorSongName.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "84cb387678a55909456ffb79af1163cfc6e21506"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_ErrorSongName), @"mvc.1.0.view", @"/Views/Home/ErrorSongName.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Home/ErrorSongName.cshtml", typeof(AspNetCore.Views_Home_ErrorSongName))]
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
#line 1 "C:\Users\yahia\Desktop\SupPlayer\SupPlayer\Views\Home\ErrorSongName.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#line 3 "C:\Users\yahia\Desktop\SupPlayer\SupPlayer\Views\Home\ErrorSongName.cshtml"
using SupPlayer.ViewModel;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"84cb387678a55909456ffb79af1163cfc6e21506", @"/Views/Home/ErrorSongName.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3f5b97fc85c6a5cde039172932163f0e3fa0ba18", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_ErrorSongName : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<PlaylistViewModel>>
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
            BeginContext(200, 56, true);
            WriteLiteral("\r\n\r\n<div class=\"contentsite\" style=\"margin-top:20px;\">\r\n");
            EndContext();
#line 11 "C:\Users\yahia\Desktop\SupPlayer\SupPlayer\Views\Home\ErrorSongName.cshtml"
     if (SignInManager.IsSignedIn(User))
    {

#line default
#line hidden
            BeginContext(305, 26, true);
            WriteLiteral("        <h2>\r\n            ");
            EndContext();
            BeginContext(332, 19, false);
#line 14 "C:\Users\yahia\Desktop\SupPlayer\SupPlayer\Views\Home\ErrorSongName.cshtml"
       Write(ViewData["message"]);

#line default
#line hidden
            EndContext();
            BeginContext(351, 54, true);
            WriteLiteral("<br />\r\n            Please, try again\r\n        </h2>\r\n");
            EndContext();
#line 17 "C:\Users\yahia\Desktop\SupPlayer\SupPlayer\Views\Home\ErrorSongName.cshtml"
    }
    else
    {

#line default
#line hidden
            BeginContext(429, 64, true);
            WriteLiteral("        <h2>You must be logged in to access this section.</h2>\r\n");
            EndContext();
#line 21 "C:\Users\yahia\Desktop\SupPlayer\SupPlayer\Views\Home\ErrorSongName.cshtml"
    }

#line default
#line hidden
            BeginContext(500, 10, true);
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