using Desktop.Robot;
using OpenQA.Selenium;
using SFA.DAS.UI.Framework.TestSupport;
using TechTalk.SpecFlow;

namespace SFA.DAS.UI.Framework.Hooks.BeforeScenario;

[Binding]
public class WebDriverSetup(ScenarioContext context) : WebDriverSetupBase(context)
{
    [BeforeScenario(Order = 3)]
    public void SetupWebDriver()
    {
        SetDriverLocation();

        var driver = webDriverSetupHelper.SetupWebDriver();

        StartPlaywrightCrx(driver);
    }

    public static void StartPlaywrightCrx(IWebDriver driver)
    {
        driver.Navigate().GoToUrl("about:blank");

        var robot = new Robot
        {
            AutoDelay = 500
        };

        robot.KeyDown(Key.Alt);
        robot.KeyDown(Key.Shift);
        robot.KeyPress(Key.R);
        robot.KeyUp(Key.Alt);
        robot.KeyUp(Key.Shift);
    }
}
