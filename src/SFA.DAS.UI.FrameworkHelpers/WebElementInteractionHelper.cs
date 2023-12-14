using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SFA.DAS.UI.FrameworkHelpers;

public abstract class WebElementInteractionHelper
{
    protected readonly IWebDriver webDriver;

    protected static By LinkCssSelector => By.CssSelector("a");

    protected static By InputCssSelector => By.CssSelector(".govuk-input");

    protected static By ButtonCssSelector => By.CssSelector(".button");

    protected static By RadioButtonInputCssSelector => By.CssSelector("input.govuk-radios__input");

    protected static By RadioButtonLabelCssSelector => By.CssSelector("label.selection-button-radio, label.govuk-radios__label");

    protected static By CheckBoxCssSelector => By.CssSelector("label.selection-button-checkbox");

    protected WebElementInteractionHelper(IWebDriver webDriver) => this.webDriver = webDriver;

    public List<IWebElement> GetElementsByText(By locator, string expectedvalue) => GetElementsByAttribute(locator, expectedvalue, (IWebElement e) => e.Text ?? e.GetAttribute(AttributeHelper.InnerText));

    public IWebElement GetElementByText(By locator, string expectedvalue) => GetElementsByText(locator, expectedvalue).FirstOrDefault();

    protected IWebElement GetElementByAttribute(By locator, string attribute, string expectedvalue) => GetElementsByAttribute(locator, expectedvalue, (IWebElement e) => e.GetAttribute(attribute)).FirstOrDefault();

    private List<IWebElement> GetElementsByAttribute(By locator, string expectedvalue, Func<IWebElement, string> actualValue)
    {
        List<IWebElement> elements = [];

        foreach (var e in webDriver.FindElements(locator))
        {
            if (actualValue(e).Contains(expectedvalue)) elements.Add(e);
        }

        return elements;
    }


    protected static SelectElement SelectElement(IWebElement element) => new(element);

    protected SelectElement SelectElement(By by) => SelectElement(webDriver.FindElement(by));
}