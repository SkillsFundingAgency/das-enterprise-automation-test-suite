using OpenQA.Selenium;

namespace SFA.DAS.UI.FrameworkHelpers;

public static class AttributeHelper
{
    public static string InnerText => "innerText";

    public static string AriaExpanded => "aria-expanded";

    public static string Placeholder => "placeholder";

    public static string Value => "value";

    public static string Id => "id";

    public static string DataCount => "data-count";

    public static string Disabled => "disabled";

    public static string GetValueAttribute(this IWebElement webElement) => webElement.GetDomProperty(Value);

    public static string GetInnerTextAttribute(this IWebElement webElement) => webElement.GetDomProperty(InnerText);
}