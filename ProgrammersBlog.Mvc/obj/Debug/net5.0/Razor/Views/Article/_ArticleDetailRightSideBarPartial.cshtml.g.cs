#pragma checksum "C:\Users\malik\source\repos\ProgrammersBlog\ProgrammersBlog.Mvc\Views\Article\_ArticleDetailRightSideBarPartial.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "5b8084c8d339256e91a946d9881340b3bc0f7fd6"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Article__ArticleDetailRightSideBarPartial), @"mvc.1.0.view", @"/Views/Article/_ArticleDetailRightSideBarPartial.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5b8084c8d339256e91a946d9881340b3bc0f7fd6", @"/Views/Article/_ArticleDetailRightSideBarPartial.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4ed1d286704faafb66f6c362a6279f19f91eff5f", @"/Views/_ViewImports.cshtml")]
    public class Views_Article__ArticleDetailRightSideBarPartial : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ProgrammersBlog.WebMvc.Models.ArticleRightSidebarViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("card-img-top text-center image-thumbnail mt-1 mb-1"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("alt", new global::Microsoft.AspNetCore.Html.HtmlString(""), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Article", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Detail", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            WriteLiteral("\n<div class=\"col-md-4\">\n\n\n    <!-- Categories Widget -->\n    <div class=\"card my-4\">\n        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "5b8084c8d339256e91a946d9881340b3bc0f7fd64504", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 169, "~/img/", 169, 6, true);
#nullable restore
#line 8 "C:\Users\malik\source\repos\ProgrammersBlog\ProgrammersBlog.Mvc\Views\Article\_ArticleDetailRightSideBarPartial.cshtml"
AddHtmlAttributeValue("", 175, Model.User.Picture, 175, 19, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\n        <h5 class=\"card-header text-center\">");
#nullable restore
#line 9 "C:\Users\malik\source\repos\ProgrammersBlog\ProgrammersBlog.Mvc\Views\Article\_ArticleDetailRightSideBarPartial.cshtml"
                                       Write(Model.User.UserName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h5>\n        <div class=\"card-body\">\n            <p class=\"card-text\">");
#nullable restore
#line 11 "C:\Users\malik\source\repos\ProgrammersBlog\ProgrammersBlog.Mvc\Views\Article\_ArticleDetailRightSideBarPartial.cshtml"
                            Write(Model.User.About);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\n        </div>\n        <div class=\"card-footer text-center\">\n            <p>Sosyal Medya Linkleri</p>\n");
#nullable restore
#line 15 "C:\Users\malik\source\repos\ProgrammersBlog\ProgrammersBlog.Mvc\Views\Article\_ArticleDetailRightSideBarPartial.cshtml"
             if (Model.User.LinkedInLink != null)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("<a");
            BeginWriteAttribute("href", " href=\"", 590, "\"", 621, 1);
#nullable restore
#line 17 "C:\Users\malik\source\repos\ProgrammersBlog\ProgrammersBlog.Mvc\Views\Article\_ArticleDetailRightSideBarPartial.cshtml"
WriteAttributeValue("", 597, Model.User.LinkedInLink, 597, 24, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("><span class=\"fab fa-linkedin\"></span></a>");
#nullable restore
#line 17 "C:\Users\malik\source\repos\ProgrammersBlog\ProgrammersBlog.Mvc\Views\Article\_ArticleDetailRightSideBarPartial.cshtml"
                                                                            }

#line default
#line hidden
#nullable disable
#nullable restore
#line 18 "C:\Users\malik\source\repos\ProgrammersBlog\ProgrammersBlog.Mvc\Views\Article\_ArticleDetailRightSideBarPartial.cshtml"
             if (Model.User.GitHubLink != null)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("<a");
            BeginWriteAttribute("href", " href=\"", 730, "\"", 759, 1);
#nullable restore
#line 20 "C:\Users\malik\source\repos\ProgrammersBlog\ProgrammersBlog.Mvc\Views\Article\_ArticleDetailRightSideBarPartial.cshtml"
WriteAttributeValue("", 737, Model.User.GitHubLink, 737, 22, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("><span class=\"fab fa-github-square\"></span></a>");
#nullable restore
#line 20 "C:\Users\malik\source\repos\ProgrammersBlog\ProgrammersBlog.Mvc\Views\Article\_ArticleDetailRightSideBarPartial.cshtml"
                                                                               }

#line default
#line hidden
#nullable disable
#nullable restore
#line 21 "C:\Users\malik\source\repos\ProgrammersBlog\ProgrammersBlog.Mvc\Views\Article\_ArticleDetailRightSideBarPartial.cshtml"
             if (Model.User.TwitterLink != null)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("<a");
            BeginWriteAttribute("href", " href=\"", 874, "\"", 904, 1);
#nullable restore
#line 23 "C:\Users\malik\source\repos\ProgrammersBlog\ProgrammersBlog.Mvc\Views\Article\_ArticleDetailRightSideBarPartial.cshtml"
WriteAttributeValue("", 881, Model.User.TwitterLink, 881, 23, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("><span class=\"fab fa-twitter-square\"></span></a>");
#nullable restore
#line 23 "C:\Users\malik\source\repos\ProgrammersBlog\ProgrammersBlog.Mvc\Views\Article\_ArticleDetailRightSideBarPartial.cshtml"
                                                                                 }

#line default
#line hidden
#nullable disable
#nullable restore
#line 24 "C:\Users\malik\source\repos\ProgrammersBlog\ProgrammersBlog.Mvc\Views\Article\_ArticleDetailRightSideBarPartial.cshtml"
             if (Model.User.FacebookLink != null)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("<a");
            BeginWriteAttribute("href", " href=\"", 1021, "\"", 1052, 1);
#nullable restore
#line 26 "C:\Users\malik\source\repos\ProgrammersBlog\ProgrammersBlog.Mvc\Views\Article\_ArticleDetailRightSideBarPartial.cshtml"
WriteAttributeValue("", 1028, Model.User.FacebookLink, 1028, 24, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("><span class=\"fab fa-facebook-square\"></span></a>");
#nullable restore
#line 26 "C:\Users\malik\source\repos\ProgrammersBlog\ProgrammersBlog.Mvc\Views\Article\_ArticleDetailRightSideBarPartial.cshtml"
                                                                                   }

#line default
#line hidden
#nullable disable
#nullable restore
#line 27 "C:\Users\malik\source\repos\ProgrammersBlog\ProgrammersBlog.Mvc\Views\Article\_ArticleDetailRightSideBarPartial.cshtml"
             if (Model.User.InstagramLink != null)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("<a");
            BeginWriteAttribute("href", " href=\"", 1171, "\"", 1203, 1);
#nullable restore
#line 29 "C:\Users\malik\source\repos\ProgrammersBlog\ProgrammersBlog.Mvc\Views\Article\_ArticleDetailRightSideBarPartial.cshtml"
WriteAttributeValue("", 1178, Model.User.InstagramLink, 1178, 25, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("><span class=\"fab fa-instagram-square\"></span></a>");
#nullable restore
#line 29 "C:\Users\malik\source\repos\ProgrammersBlog\ProgrammersBlog.Mvc\Views\Article\_ArticleDetailRightSideBarPartial.cshtml"
                                                                                     }

#line default
#line hidden
#nullable disable
#nullable restore
#line 30 "C:\Users\malik\source\repos\ProgrammersBlog\ProgrammersBlog.Mvc\Views\Article\_ArticleDetailRightSideBarPartial.cshtml"
             if (Model.User.YoutubeLink != null)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("<a");
            BeginWriteAttribute("href", " href=\"", 1321, "\"", 1351, 1);
#nullable restore
#line 32 "C:\Users\malik\source\repos\ProgrammersBlog\ProgrammersBlog.Mvc\Views\Article\_ArticleDetailRightSideBarPartial.cshtml"
WriteAttributeValue("", 1328, Model.User.YoutubeLink, 1328, 23, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("><span class=\"fab fa-youtube-square\"></span></a>");
#nullable restore
#line 32 "C:\Users\malik\source\repos\ProgrammersBlog\ProgrammersBlog.Mvc\Views\Article\_ArticleDetailRightSideBarPartial.cshtml"
                                                                                 }

#line default
#line hidden
#nullable disable
#nullable restore
#line 33 "C:\Users\malik\source\repos\ProgrammersBlog\ProgrammersBlog.Mvc\Views\Article\_ArticleDetailRightSideBarPartial.cshtml"
             if (Model.User.WebsiteLink != null)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("<a");
            BeginWriteAttribute("href", " href=\"", 1467, "\"", 1497, 1);
#nullable restore
#line 35 "C:\Users\malik\source\repos\ProgrammersBlog\ProgrammersBlog.Mvc\Views\Article\_ArticleDetailRightSideBarPartial.cshtml"
WriteAttributeValue("", 1474, Model.User.WebsiteLink, 1474, 23, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("><span class=\"fas fa-home\"></span></a>");
#nullable restore
#line 35 "C:\Users\malik\source\repos\ProgrammersBlog\ProgrammersBlog.Mvc\Views\Article\_ArticleDetailRightSideBarPartial.cshtml"
                                                                       }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </div>\n    </div>\n\n    <!-- Side Widget -->\n    <!-- Side Widget -->\n    <div class=\"card my-4\">\n        <h5 class=\"card-header\">");
#nullable restore
#line 42 "C:\Users\malik\source\repos\ProgrammersBlog\ProgrammersBlog.Mvc\Views\Article\_ArticleDetailRightSideBarPartial.cshtml"
                           Write(Model.Header);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h5>\n        <div class=\"card-body\">\n            <ul class=\"list-group\">\n");
#nullable restore
#line 45 "C:\Users\malik\source\repos\ProgrammersBlog\ProgrammersBlog.Mvc\Views\Article\_ArticleDetailRightSideBarPartial.cshtml"
                 for (int i = 0; i < Model.ArticleListDto.Articles.Count; i++)
                {
                    if (i % 2 == 0)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("    <li class=\"list-group-item list-group-item-primary\">\n        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "5b8084c8d339256e91a946d9881340b3bc0f7fd615261", async() => {
#nullable restore
#line 50 "C:\Users\malik\source\repos\ProgrammersBlog\ProgrammersBlog.Mvc\Views\Article\_ArticleDetailRightSideBarPartial.cshtml"
                                                                                                              Write(Model.ArticleListDto.Articles[i].Title);

#line default
#line hidden
#nullable disable
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-articleId", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 50 "C:\Users\malik\source\repos\ProgrammersBlog\ProgrammersBlog.Mvc\Views\Article\_ArticleDetailRightSideBarPartial.cshtml"
                                                                 WriteLiteral(Model.ArticleListDto.Articles[i].Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["articleId"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-articleId", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["articleId"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\n    </li>\n");
#nullable restore
#line 52 "C:\Users\malik\source\repos\ProgrammersBlog\ProgrammersBlog.Mvc\Views\Article\_ArticleDetailRightSideBarPartial.cshtml"
 }
else
{

#line default
#line hidden
#nullable disable
            WriteLiteral("<li class=\"list-group-item list-group-item-danger\">\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "5b8084c8d339256e91a946d9881340b3bc0f7fd618364", async() => {
#nullable restore
#line 56 "C:\Users\malik\source\repos\ProgrammersBlog\ProgrammersBlog.Mvc\Views\Article\_ArticleDetailRightSideBarPartial.cshtml"
                                                                                                          Write(Model.ArticleListDto.Articles[i].Title);

#line default
#line hidden
#nullable disable
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-articleId", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 56 "C:\Users\malik\source\repos\ProgrammersBlog\ProgrammersBlog.Mvc\Views\Article\_ArticleDetailRightSideBarPartial.cshtml"
                                                             WriteLiteral(Model.ArticleListDto.Articles[i].Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["articleId"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-articleId", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["articleId"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\n</li>\n");
#nullable restore
#line 58 "C:\Users\malik\source\repos\ProgrammersBlog\ProgrammersBlog.Mvc\Views\Article\_ArticleDetailRightSideBarPartial.cshtml"
}
}

#line default
#line hidden
#nullable disable
            WriteLiteral("            </ul>\n        </div>\n    </div>\n\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ProgrammersBlog.WebMvc.Models.ArticleRightSidebarViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
