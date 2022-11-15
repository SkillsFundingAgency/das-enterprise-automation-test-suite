using OpenQA.Selenium;

namespace SFA.DAS.IdamsLogin.Service.Project.Helpers;

public static class Selectors
{
    public static By PireanPreprod => By.XPath("//span[contains(text(),'Pirean Preprod')]");
}
