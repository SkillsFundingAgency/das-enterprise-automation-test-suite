namespace SFA.DAS.IdamsLogin.Service.Project.Helpers;

public static class IdamsPageSelector
{
    public static By StartNowButton => By.CssSelector(".govuk-button--start");

    public static By PireanPreprod => By.XPath("//span[contains(text(),'Pirean Preprod')]");

    public static By Access1Staff => By.XPath("//span[contains(text(),'Access1 Staff')]");
}
