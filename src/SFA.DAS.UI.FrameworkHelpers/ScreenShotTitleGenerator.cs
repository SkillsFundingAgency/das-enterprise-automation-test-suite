using System;

namespace SFA.DAS.UI.FrameworkHelpers;

public class ScreenShotTitleGenerator(int start)
{
    public int GetCounter() => start;

    public int GetNextCounter() => start + 1;

    public string GetTitle() => $"{++start:D2}_{DateTime.Now:fffff}";
}
