using System;

namespace SFA.DAS.UI.FrameworkHelpers
{
    public static class UriHelper
    {
        public static string GetAbsoluteUri(string uriString, string relativeUri) => new Uri(new Uri(uriString), relativeUri).AbsoluteUri;
    }
}
