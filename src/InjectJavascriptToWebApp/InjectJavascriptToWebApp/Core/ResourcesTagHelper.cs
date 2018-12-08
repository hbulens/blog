using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.Extensions.Localization;
using InjectJavascriptToWebApp.Resources;

namespace InjectJavascriptToWebApp
{
    [HtmlTargetElement("script", Attributes = "prepend-resources")]
    public class ResourcesTagHelper : TagHelper
    {
        private readonly ResourcesHelper _helper;

        public ResourcesTagHelper(IStringLocalizerFactory stringLocalizerFactory)
        {
            _helper = new ResourcesHelper(stringLocalizerFactory);
        }

        /// <summary>
        /// Execute script only once document is loaded.
        /// </summary>
        public bool OnContentLoaded { get; set; } = false;

        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            if (OnContentLoaded)
                await base.ProcessAsync(context, output);
            else
            {
                ResourceGroup labels = new ResourceGroup { Name = "Labels", Entries = _helper.GetResources(nameof(Labels)) };

                StringBuilder sb = new StringBuilder();
                ResourceJavaScriptService service = new ResourceJavaScriptService();
                sb.Append(service.ToJavascript(new List<ResourceGroup> { labels, /* Add as many resource files as you need to */ }));

                TagHelperContent content = await output.GetChildContentAsync();
                string javascript = content.GetContent();
                sb.Append(javascript);
                sb.Append(";");

                output.Content.AppendHtml(sb.ToString());
            }
        }
    }
}
