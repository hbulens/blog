using System.Collections.Generic;
using Microsoft.Extensions.Localization;

namespace InjectJavascriptToWebApp
{
    internal class ResourceGroup
    {
        public string Name { get; set; }
        public IEnumerable<LocalizedString> Entries { get; set; }
    }
}