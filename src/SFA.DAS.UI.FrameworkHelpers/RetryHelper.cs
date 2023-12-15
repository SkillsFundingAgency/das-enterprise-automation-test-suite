using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using Polly;
using SFA.DAS.FrameworkHelpers;
using System;
using System.Drawing;
using TechTalk.SpecFlow;

namespace SFA.DAS.UI.FrameworkHelpers;

public class RetryHelper
{
    private readonly IWebDriver _webDriver;
    private readonly string _title;
    private readonly TimeSpan[] TimeOut;
    private readonly ObjectContext objectContext;

    public RetryHelper(IWebDriver webDriver, ScenarioInfo scenarioInfo, ObjectContext objectContext) : this(webDriver, scenarioInfo, objectContext, RetryTimeOut.DefaultTimeout())
    {

    }

    internal RetryHelper(IWebDriver webDriver, ScenarioInfo scenarioInfo, ObjectContext objectContext, TimeSpan[] timeSpans)
    {
        _webDriver = webDriver;
        _title = scenarioInfo.Title;
        TimeOut = timeSpans;
        this.objectContext = objectContext;
    }

    internal bool RetryOnException(Func<bool> func, Action beforeAction, Action retryAction = null)
    {
        var logging = GetRetryLogging();

        return Policy
             .Handle<Exception>((x) => x.Message.Contains("verification failed"))
             .WaitAndRetry(TimeOut, (exception, timeSpan, retryCount, context) =>
             {
                 logging.Report(retryCount, timeSpan, exception, _title, retryAction);
                 retryAction?.Invoke();
             })
             .Execute(() =>
             {
                 using var testcontext = new NUnit.Framework.Internal.TestExecutionContext.IsolatedContext();
                 beforeAction?.Invoke();
                 return func();
             });
    }

    internal void RetryClickOnException(Func<IWebElement> element)
    {
        var logging = GetRetryLogging();

        Policy
            .Handle<Exception>()
            .WaitAndRetry(TimeOut, (exception, timeSpan, retryCount, context) =>
            {
                logging.Report(retryCount, timeSpan, exception, _title);
            })
           .Execute(() =>
           {
               using var testcontext = new NUnit.Framework.Internal.TestExecutionContext.IsolatedContext();
               ClickEvent(element()).Invoke();
           });
    }

    internal void RetryClickOnWebDriverException(Func<IWebElement> element, Action retryAction = null)
    {
        var logging = GetRetryLogging();

        Policy
            .Handle<WebDriverException>((ex) => !ex.Message.ContainsCompareCaseInsensitive("The HTTP request to the remote WebDriver server for URL"))
            .WaitAndRetry(TimeOut, (exception, timeSpan, retryCount, context) =>
            {
                logging.Report(retryCount, timeSpan, exception, _title, retryAction);
                retryAction?.Invoke();
            })
           .Execute(() =>
           {
               using var testcontext = new NUnit.Framework.Internal.TestExecutionContext.IsolatedContext();
               ClickEvent(element()).Invoke();
           });
    }

    internal void RetryOnWebDriverException(Action action, Action retryAction = null)
    {
        var logging = GetRetryLogging();

        Policy
            .Handle<WebDriverException>()
            .WaitAndRetry(TimeOut, (exception, timeSpan, retryCount, context) =>
            {
                logging.Report(retryCount, timeSpan, exception, _title, retryAction);
                retryAction?.Invoke();
            })
            .Execute(() =>
            {
                using var testcontext = new NUnit.Framework.Internal.TestExecutionContext.IsolatedContext();
                {
                    action.Invoke();
                }
            });
    }

    internal T RetryOnWebDriverException<T>(Func<T> func, Action retryAction = null)
    {
        var logging = GetRetryLogging();

        T result = default;
        Policy
            .Handle<WebDriverException>()
            .WaitAndRetry(TimeOut, (exception, timeSpan, retryCount, context) =>
            {
                logging.Report(retryCount, timeSpan, exception, _title, retryAction);
                retryAction?.Invoke();
            })
            .Execute(() =>
            {
                using var testcontext = new NUnit.Framework.Internal.TestExecutionContext.IsolatedContext();
                result = func.Invoke();
            });

        return result;
    }

    internal void RetryOnElementClickInterceptedException(IWebElement element, bool useAction = true)
    {
        var logging = GetRetryLogging();

        Action beforeAction = null, afterAction = null;
        Policy
             .Handle<ElementClickInterceptedException>()
             .Or<WebDriverException>()
             .WaitAndRetry(TimeOut, (exception, timeSpan, retryCount, context) =>
             {
                 logging.Report(retryCount, timeSpan, exception, _title, beforeAction);

                 switch (true)
                 {
                     case bool _ when retryCount == 1:
                         var x = ResizeWindow();
                         beforeAction = x.beforeAction;
                         afterAction = x.afterAction;
                         break;
                     case bool _ when retryCount >= 2:
                         var y = ScrollIntoView(element);
                         beforeAction = y.beforeAction;
                         afterAction = y.afterAction;
                         break;
                 }
             })
             .Execute(() =>
             {
                 using var testcontext = new NUnit.Framework.Internal.TestExecutionContext.IsolatedContext();
                 beforeAction?.Invoke();
                 ClickEvent(element, useAction).Invoke();
                 afterAction?.Invoke();
             });
    }

    private Action ClickEvent(IWebElement element, bool useAction) => useAction ? ClickEvent(element) : Click(element);

    private Action ClickEvent(IWebElement element) => () => new Actions(_webDriver).MoveToElement(element).Click(element).Perform();

    private static Action Click(IWebElement element) => () => element.Click();

    private (Action beforeAction, Action afterAction) ResizeWindow()
    {
        void beforeAction() => _webDriver.Manage().Window.Size = new Size(1920, 1080);
        void afterAction() => _webDriver.Manage().Window.Maximize();
        return (beforeAction, afterAction);
    }

    private (Action beforeAction, Action afterAction) ScrollIntoView(IWebElement element)
    {
        void beforeAction() => ((IJavaScriptExecutor)_webDriver).ExecuteScript("arguments[0].scrollIntoView(true);", element);
        return (beforeAction, null);
    }

    private RetryLogging GetRetryLogging() => new(objectContext, RandomDataGenerator.GenerateRandomWholeNumber(4));
}
