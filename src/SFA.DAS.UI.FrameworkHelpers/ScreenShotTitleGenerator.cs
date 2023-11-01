using System;

namespace SFA.DAS.UI.FrameworkHelpers;

public class ScreenShotTitleGenerator
{
    private int _count;

    public ScreenShotTitleGenerator(int start) => _count = start;

    public int GetCounter() => _count;

    public int GetNextCounter() => _count + 1;

    public string GetTitle() => $"{++_count:D2}_{DateTime.Now:fffff}";
}
