#pragma checksum "/Users/tessa/Documents/Epicodus/02 C#/Week02/ToDoList.Solution/ToDoList/Views/Categories/index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "24d6280c1d467f1288b7f24e0cb9cedcd6e7b2ba"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Categories_index), @"mvc.1.0.view", @"/Views/Categories/index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Categories/index.cshtml", typeof(AspNetCore.Views_Categories_index))]
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
#line 1 "/Users/tessa/Documents/Epicodus/02 C#/Week02/ToDoList.Solution/ToDoList/Views/Categories/index.cshtml"
using ToDoList.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"24d6280c1d467f1288b7f24e0cb9cedcd6e7b2ba", @"/Views/Categories/index.cshtml")]
    public class Views_Categories_index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(24, 27, true);
            WriteLiteral("\n<h1>To Do List</h1>\n<ul>\n\n");
            EndContext();
#line 6 "/Users/tessa/Documents/Epicodus/02 C#/Week02/ToDoList.Solution/ToDoList/Views/Categories/index.cshtml"
 if (Model.Count == 0)
{

#line default
#line hidden
            BeginContext(76, 43, true);
            WriteLiteral("  <p>No categories have been added yet</p>\n");
            EndContext();
#line 9 "/Users/tessa/Documents/Epicodus/02 C#/Week02/ToDoList.Solution/ToDoList/Views/Categories/index.cshtml"
}

#line default
#line hidden
#line 10 "/Users/tessa/Documents/Epicodus/02 C#/Week02/ToDoList.Solution/ToDoList/Views/Categories/index.cshtml"
 if(Model.Count != 0)
{
  

#line default
#line hidden
#line 12 "/Users/tessa/Documents/Epicodus/02 C#/Week02/ToDoList.Solution/ToDoList/Views/Categories/index.cshtml"
   foreach (Category category in Model)
  {

#line default
#line hidden
            BeginContext(189, 10, true);
            WriteLiteral("    <li><a");
            EndContext();
            BeginWriteAttribute("href", " href=\'", 199, "\'", 235, 2);
            WriteAttributeValue("", 206, "/categories/", 206, 12, true);
#line 14 "/Users/tessa/Documents/Epicodus/02 C#/Week02/ToDoList.Solution/ToDoList/Views/Categories/index.cshtml"
WriteAttributeValue("", 218, category.GetId(), 218, 17, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(236, 1, true);
            WriteLiteral(">");
            EndContext();
            BeginContext(238, 18, false);
#line 14 "/Users/tessa/Documents/Epicodus/02 C#/Week02/ToDoList.Solution/ToDoList/Views/Categories/index.cshtml"
                                           Write(category.GetName());

#line default
#line hidden
            EndContext();
            BeginContext(256, 10, true);
            WriteLiteral("</a></li>\n");
            EndContext();
#line 15 "/Users/tessa/Documents/Epicodus/02 C#/Week02/ToDoList.Solution/ToDoList/Views/Categories/index.cshtml"
  }

#line default
#line hidden
#line 15 "/Users/tessa/Documents/Epicodus/02 C#/Week02/ToDoList.Solution/ToDoList/Views/Categories/index.cshtml"
   
}

#line default
#line hidden
            BeginContext(272, 222, true);
            WriteLiteral("\n</ul>\n<p><a href=\'/\'>Back home</a></p>\n<p><a href=\"/categories/new\">Add a new category.</a></p>\n<form action=\"/categories/delete\" method=\"post\">\n  <button type=\"submit\" name=\"button\">Delete all categories</button>\n</form>");
            EndContext();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
