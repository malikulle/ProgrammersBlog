#pragma checksum "C:\Users\malik\source\repos\ProgrammersBlog\ProgrammersBlog.Mvc\Areas\Admin\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "2a1925eebf99d6b02f01cfbb8b48a4922e7232df"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_Home_Index), @"mvc.1.0.view", @"/Areas/Admin/Views/Home/Index.cshtml")]
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
#line 1 "C:\Users\malik\source\repos\ProgrammersBlog\ProgrammersBlog.Mvc\Areas\Admin\Views\_ViewImports.cshtml"
using ProgrammersBlog.Entities.Dtos;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2a1925eebf99d6b02f01cfbb8b48a4922e7232df", @"/Areas/Admin/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2871f7cce4040b47836bdcbf2c121fb2692d24d5", @"/Areas/Admin/Views/_ViewImports.cshtml")]
    public class Areas_Admin_Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ProgrammersBlog.WebMvc.Areas.Admin.Models.DashboardViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-area", "Admin", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Home", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("small text-white stretched-link"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Categories", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Articles", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Comments", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "User", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_8 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("my-image-table"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            WriteLiteral("<ol class=\"breadcrumb mb-3 mt-2\">\n    <li class=\"breadcrumb-item\">");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "2a1925eebf99d6b02f01cfbb8b48a4922e7232df6128", async() => {
                WriteLiteral("Admin");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Area = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("</li>\n    <li class=\"breadcrumb-item active\">");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "2a1925eebf99d6b02f01cfbb8b48a4922e7232df7732", async() => {
                WriteLiteral("Y??netim Paneli");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Area = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("</li>\n</ol>\n<div class=\"row\">\n    <div class=\"col-xl-3 col-md-6\">\n        <div class=\"card bg-primary text-white mb-4\">\n            <div class=\"card-body\">Kategoriler (");
#nullable restore
#line 9 "C:\Users\malik\source\repos\ProgrammersBlog\ProgrammersBlog.Mvc\Areas\Admin\Views\Home\Index.cshtml"
                                           Write(Model.CategoriesCount);

#line default
#line hidden
#nullable disable
            WriteLiteral(")</div>\n            <div class=\"card-footer d-flex align-items-center justify-content-between\">\n                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "2a1925eebf99d6b02f01cfbb8b48a4922e7232df9879", async() => {
                WriteLiteral("Detaylar");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Area = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
                <div class=""small text-white""><i class=""fas fa-angle-right""></i></div>
            </div>
        </div>
    </div>
    <div class=""col-xl-3 col-md-6"">
        <div class=""card bg-warning text-white mb-4"">
            <div class=""card-body"">Makaleler (");
#nullable restore
#line 18 "C:\Users\malik\source\repos\ProgrammersBlog\ProgrammersBlog.Mvc\Areas\Admin\Views\Home\Index.cshtml"
                                         Write(Model.ArticlesCount);

#line default
#line hidden
#nullable disable
            WriteLiteral(")</div>\n            <div class=\"card-footer d-flex align-items-center justify-content-between\">\n                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "2a1925eebf99d6b02f01cfbb8b48a4922e7232df12199", async() => {
                WriteLiteral("Detaylar");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Area = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_5.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
                <div class=""small text-white""><i class=""fas fa-angle-right""></i></div>
            </div>
        </div>
    </div>
    <div class=""col-xl-3 col-md-6"">
        <div class=""card bg-success text-white mb-4"">
            <div class=""card-body"">Yorumlar (");
#nullable restore
#line 27 "C:\Users\malik\source\repos\ProgrammersBlog\ProgrammersBlog.Mvc\Areas\Admin\Views\Home\Index.cshtml"
                                        Write(Model.CommentsCount);

#line default
#line hidden
#nullable disable
            WriteLiteral(")</div>\n            <div class=\"card-footer d-flex align-items-center justify-content-between\">\n                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "2a1925eebf99d6b02f01cfbb8b48a4922e7232df14518", async() => {
                WriteLiteral("Detaylar");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Area = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_6.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_6);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
                <div class=""small text-white""><i class=""fas fa-angle-right""></i></div>
            </div>
        </div>
    </div>
    <div class=""col-xl-3 col-md-6"">
        <div class=""card bg-danger text-white mb-4"">
            <div class=""card-body"">Kullan??c??lar (");
#nullable restore
#line 36 "C:\Users\malik\source\repos\ProgrammersBlog\ProgrammersBlog.Mvc\Areas\Admin\Views\Home\Index.cshtml"
                                            Write(Model.UsersCount);

#line default
#line hidden
#nullable disable
            WriteLiteral(")</div>\n            <div class=\"card-footer d-flex align-items-center justify-content-between\">\n                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "2a1925eebf99d6b02f01cfbb8b48a4922e7232df16841", async() => {
                WriteLiteral("Detaylar");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Area = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_7.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_7);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
                <div class=""small text-white""><i class=""fas fa-angle-right""></i></div>
            </div>
        </div>
    </div>
</div>

<div class=""row"">
    <div class=""col-xl-12"">
        <div class=""card mb-4"">
            <div class=""card-header"">
                <i class=""fas fa-chart-area mr-1""></i>
                En ??ok Okunan Makaleler Grafi??i
            </div>
            <div class=""card-body""><canvas id=""viewCountChart"" width=""100%"" height=""30""></canvas></div>
        </div>
    </div>
");
            WriteLiteral(@"</div>
<div class=""card mb-4"">
    <div class=""card-header"">
        <i class=""fas fa-table mr-1""></i>
        Son Payla????lan Makaleler
    </div>
    <div class=""card-body"">
        <div class=""table-responsive"">
            <table class=""table table-bordered"" id=""dataTable"" width=""100%"" cellspacing=""0"">
                <thead>
                    <tr>
                        <th>#</th>
                        <th>Kategori</th>
                        <th>Ba??l??k</th>
                        <th>K??????k Resim</th>
                        <th>Tarih</th>
                        <th>Okunma Say??s??</th>
                        <th>Yorum Say??s??</th>
                        <th>Aktif Mi?</th>
                    </tr>
                </thead>
                <tfoot>
                    <tr>
                        <th>#</th>
                        <th>Kategori</th>
                        <th>Ba??l??k</th>
                        <th>K??????k Resim</th>
                        <th>Tarih</th>
                        <th>Ok");
            WriteLiteral("unma Say??s??</th>\n                        <th>Yorum Say??s??</th>\n                        <th>Aktif Mi?</th>\n                    </tr>\n                </tfoot>\n                <tbody>\n");
#nullable restore
#line 98 "C:\Users\malik\source\repos\ProgrammersBlog\ProgrammersBlog.Mvc\Areas\Admin\Views\Home\Index.cshtml"
                     foreach (var item in Model.Articles.Articles)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <tr>\n            <td>");
#nullable restore
#line 101 "C:\Users\malik\source\repos\ProgrammersBlog\ProgrammersBlog.Mvc\Areas\Admin\Views\Home\Index.cshtml"
           Write(item.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n            <td>");
#nullable restore
#line 102 "C:\Users\malik\source\repos\ProgrammersBlog\ProgrammersBlog.Mvc\Areas\Admin\Views\Home\Index.cshtml"
           Write(item.Category.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n            <td>");
#nullable restore
#line 103 "C:\Users\malik\source\repos\ProgrammersBlog\ProgrammersBlog.Mvc\Areas\Admin\Views\Home\Index.cshtml"
           Write(item.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n            <td>\n                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "2a1925eebf99d6b02f01cfbb8b48a4922e7232df21463", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 4593, "~/img/", 4593, 6, true);
#nullable restore
#line 105 "C:\Users\malik\source\repos\ProgrammersBlog\ProgrammersBlog.Mvc\Areas\Admin\Views\Home\Index.cshtml"
AddHtmlAttributeValue("", 4599, item.Thumbnail, 4599, 15, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_8);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\n            </td>\n            <td>");
#nullable restore
#line 107 "C:\Users\malik\source\repos\ProgrammersBlog\ProgrammersBlog.Mvc\Areas\Admin\Views\Home\Index.cshtml"
           Write(item.Date.Value.ToShortDateString());

#line default
#line hidden
#nullable disable
            WriteLiteral(" </td>\n            <td>");
#nullable restore
#line 108 "C:\Users\malik\source\repos\ProgrammersBlog\ProgrammersBlog.Mvc\Areas\Admin\Views\Home\Index.cshtml"
           Write(item.ViewsCount);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n            <td>");
#nullable restore
#line 109 "C:\Users\malik\source\repos\ProgrammersBlog\ProgrammersBlog.Mvc\Areas\Admin\Views\Home\Index.cshtml"
           Write(item.CommentsCount);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n            <td>");
#nullable restore
#line 110 "C:\Users\malik\source\repos\ProgrammersBlog\ProgrammersBlog.Mvc\Areas\Admin\Views\Home\Index.cshtml"
            Write(item.IsActive ? "Evet" : "Hay??r");

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n        </tr>");
#nullable restore
#line 111 "C:\Users\malik\source\repos\ProgrammersBlog\ProgrammersBlog.Mvc\Areas\Admin\Views\Home\Index.cshtml"
             }

#line default
#line hidden
#nullable disable
            WriteLiteral("\n\n                </tbody>\n            </table>\n        </div>\n    </div>\n</div>\n");
            DefineSection("Scripts", async() => {
                WriteLiteral(@"
    <script>
        $.get('/Admin/Article/GetAllByViewCount/?isAscending=false&takeSize=10', function (data) {

            let viewCountContext = $(""#viewCountChart"");
            const articleResult = jQuery.parseJSON(data);
            let viewCountChart = new Chart(viewCountContext, {
                type: 'bar',
                data: {
                    labels: articleResult.$values.map(x => x.Title),
                    datasets: [
                        {
                            label: 'Okunma Say??s??', data: articleResult.$values.map(x => x.ViewsCount), hoverBorderWith: 4, hoverBorderColor: 'black', backgroundColor: '#fb3640'
                        },
                        {
                            label: 'Yorum Say??s??', data: articleResult.$values.map(x => x.CommentsCount), hoverBorderWith: 4, hoverBorderColor: 'black', backgroundColor: '#fdca40'
                        },
                    ]
                },
                options: {
                    plugins: {
             ");
                WriteLiteral(@"           legend: {
                            labels: {
                                fond: {
                                    size: 18
                                }
                            }
                        }
                    }
                }
            });
        })
    </script>

");
            }
            );
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ProgrammersBlog.WebMvc.Areas.Admin.Models.DashboardViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
