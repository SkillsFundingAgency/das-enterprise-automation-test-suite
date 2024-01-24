using System.Collections.Generic;

namespace SFA.DAS.UI.Framework.TestSupport.AnalyzeHelpers;

public static class AccessibilityPageTitleChecker
{
    private static readonly List<string> pageTitles;

    static AccessibilityPageTitleChecker()
    {
        pageTitles = [];
    }

    public static bool Contains(string title)
    {
        var x = pageTitles.Contains(title);

        if (x == false) pageTitles.Add(title);

        return x;
    }
}
