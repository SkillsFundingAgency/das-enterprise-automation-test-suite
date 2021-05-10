using System;
using System.Text.RegularExpressions;

namespace SFA.DAS.Roatp.UITests.Project.Helpers
{
    public static class ApplicationRouteHelper
    {
        private static readonly string Routes = @"main|supporting|support|employer";

        public static ApplicationRoute GetApplicationRoute(string applicationroute)
        {
            var match = Regex.Match(applicationroute, Routes, RegexOptions.IgnoreCase);

            var value = Regex.Replace(match.Value, Routes, match.Value.ToLower() == "support" ? $"{match.Value}ing" : match.Value, RegexOptions.IgnoreCase);

            return Enum.Parse<ApplicationRoute>($"{value}ProviderRoute", true);
        }
    }
}
