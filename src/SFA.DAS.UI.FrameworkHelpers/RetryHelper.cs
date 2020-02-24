using System;
using Polly;
using NUnit.Framework;
using OpenQA.Selenium;
using System.Drawing;
using OpenQA.Selenium.Interactions;

namespace SFA.DAS.UI.FrameworkHelpers
{
    public class RetryHelper
    {
        private readonly IWebDriver _webDriver;
        private readonly string _scenarioTitle;

        public RetryHelper(IWebDriver webDriver, string scenarioTitle)
        {
            _webDriver = webDriver;
            _scenarioTitle = scenarioTitle;
        }

        internal bool RetryOnException(Func<bool> func, Action beforeAction, Action retryAction = null)
        {
            return Policy
                 .Handle<Exception>((x) => x.Message.Contains("verification failed"))
                 .WaitAndRetry(TimeOut, (exception, timeSpan, retryCount, context) =>
                 {
                     Report(retryCount, exception);
                     retryAction?.Invoke();
                 })
                 .Execute(() =>
                 {
                     using (var testcontext = new NUnit.Framework.Internal.TestExecutionContext.IsolatedContext())
                     {
                         beforeAction?.Invoke();
                         return func();
                     }
                 });
        }

        internal void RetryClickOnException(Func<IWebElement> element)
        {
            Policy
                .Handle<Exception>()
                .WaitAndRetry(TimeOut, (exception, timeSpan, retryCount, context) =>
                {
                    Report(retryCount, exception);
                })
               .Execute(() =>
               {
                   using (var testcontext = new NUnit.Framework.Internal.TestExecutionContext.IsolatedContext())
                   {
                       ClickEvent(element()).Invoke();
                   }
               });
        }

        internal void RetryClickOnWebDriverException(Func<IWebElement> element, Action retryAction = null)
        {
            Policy
                .Handle<WebDriverException>()
                .WaitAndRetry(TimeOut, (exception, timeSpan, retryCount, context) =>
                {
                    Report(retryCount, exception);
                    retryAction?.Invoke();
                })
               .Execute(() =>
               {
                   using (var testcontext = new NUnit.Framework.Internal.TestExecutionContext.IsolatedContext())
                   {
                       ClickEvent(element()).Invoke();
                   }
               });
        }

        internal T RetryOnWebDriverException<T>(Func<T> element, Action retryAction = null)
        {
            T webElement = default(T);
            Policy
                .Handle<WebDriverException>()
                .WaitAndRetry(TimeOut, (exception, timeSpan, retryCount, context) =>
                {
                    Report(retryCount, exception);
                    retryAction?.Invoke();
                })
                .Execute(() =>
                {
                    using (var testcontext = new NUnit.Framework.Internal.TestExecutionContext.IsolatedContext())
                    {
                        webElement = element.Invoke();
                    }
                });

            return webElement;
        }

        internal void RetryOnElementClickInterceptedException(IWebElement element, bool useAction)
        {
            Action beforeAction = null, afterAction = null;
            Policy
                 .Handle<ElementClickInterceptedException>()
                 .Or<WebDriverException>()
                 .WaitAndRetry(TimeOut, (exception, timeSpan, retryCount, context) =>
                 {
                     Report(retryCount, exception);

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
                     using (var testcontext = new NUnit.Framework.Internal.TestExecutionContext.IsolatedContext())
                     {
                         beforeAction?.Invoke();
                         ClickEvent(element, useAction).Invoke();
                         afterAction?.Invoke();
                     }
                 });
        }

        private Action ClickEvent(IWebElement element, bool useAction) => useAction ? ClickEvent(element) : Click(element);

        private Action ClickEvent(IWebElement element) => () => new Actions(_webDriver).MoveToElement(element).Click(element).Perform();

        private Action Click(IWebElement element) => () => element.Click();

        private static TimeSpan[] TimeOut => new[]
        {
            TimeSpan.FromSeconds(1),
            TimeSpan.FromSeconds(3),
            TimeSpan.FromSeconds(5)
        };

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

        private void Report(int retryCount, Exception exception)
        {
            TestContext.Progress.WriteLine($"{Environment.NewLine}Retry Count : {retryCount}{Environment.NewLine}Scenario Title : {_scenarioTitle}{Environment.NewLine}Exception : {exception.Message}");
        }
    }
}