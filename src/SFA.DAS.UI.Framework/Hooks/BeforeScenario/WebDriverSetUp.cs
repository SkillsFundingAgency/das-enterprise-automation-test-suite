using Desktop.Robot;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using System;
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


    public void StartPlaywrightCrx(IWebDriver driver)
    {
        driver.Navigate().GoToUrl("chrome://extensions/");

        var element = context.GetWebDriver().FindElement(By.CssSelector("body"));

        Actions actions = new(driver);

        actions.ContextClick(element).Build().Perform();

        actions.Pause(TimeSpan.FromMilliseconds(500)).Build().Perform();

        var robot = new Robot
        {
            AutoDelay = 500
        };
        robot.KeyPress(Key.Down);
        robot.KeyPress(Key.Down);
        robot.KeyPress(Key.Down);
        robot.KeyPress(Key.Down);
        robot.KeyPress(Key.Down);
        robot.KeyPress(Key.Down);
        robot.KeyPress(Key.Down);
        robot.KeyPress(Key.Down);
        robot.KeyPress(Key.Down);
        robot.KeyPress(Key.Enter);
    }
}
