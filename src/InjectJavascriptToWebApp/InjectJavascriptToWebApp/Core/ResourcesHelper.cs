using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Microsoft.Extensions.Localization;

namespace InjectJavascriptToWebApp
{
    public class ResourcesHelper
    {
        private readonly IStringLocalizerFactory _stringLocalizerFactory;

        public ResourcesHelper(IStringLocalizerFactory stringLocalizerFactory)
        {
            _stringLocalizerFactory = stringLocalizerFactory;
        }

        public IEnumerable<LocalizedString> GetResources(string name)
        {
            IStringLocalizer localizer = _stringLocalizerFactory.Create(name, Assembly.GetEntryAssembly().FullName);
            return localizer.GetAllStrings(true).ToList();
        }
    }
}