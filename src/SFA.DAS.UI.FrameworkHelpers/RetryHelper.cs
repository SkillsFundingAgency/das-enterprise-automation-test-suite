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

        public RetryHelper(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        internal bool RetryOnException(Func<bool> func, Action beforeAction)
        {
            return Policy
                 .Handle<Exception>((x) => x.Message.Contains("verification failed"))
                 .WaitAndRetry(TimeOut, (exception, timeSpan, retryCount, context) =>
                 {
                     TestContext.Progress.WriteLine($"Retry Count : {retryCount}, Exception : {exception.Message}");
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

        internal void RetryClickOnWebDriverException(Func<IWebElement> element)
        {
            Policy
                .Handle<WebDriverException>()
                .WaitAndRetry(TimeOut, (exception, timeSpan, retryCount, context) =>
                {
                    TestContext.Progress.WriteLine($"Retry Count : {retryCount}, Exception : {exception.Message}");
                })
               .Execute(() =>
               {
                   using (var testcontext = new NUnit.Framework.Internal.TestExecutionContext.IsolatedContext())
                   {
                       ClickEvent(element()).Invoke();
                   }
               });
        }

        internal T RetryOnWebDriverException<T>(Func<T> element)
        {
            T webElement = default(T);
            Policy
                .Handle<WebDriverException>()
                .WaitAndRetry(TimeOut, (exception, timeSpan, retryCount, context) =>
                {
                    TestContext.Progress.WriteLine($"Retry Count : {retryCount}, Exception : {exception.Message}");
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

        internal void RetryOnElementClickInterceptedException(IWebElement element)
        {

            Action beforeAction = null, afterAction = null;
            Policy
                 .Handle<ElementClickInterceptedException>()
                 .Or<WebDriverException>()
                 .WaitAndRetry(TimeOut, (exception, timeSpan, retryCount, context) =>
                 {
                     TestContext.Progress.WriteLine($"Retry Count : {retryCount}, Exception : {exception.Message}");

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
                         ClickEvent(element).Invoke();
                         afterAction?.Invoke();
                     }
                 });
        }

        private Action ClickEvent(IWebElement element)
        {
            return () => new Actions(_webDriver).MoveToElement(element).Click(element).Perform();
        }

        private static TimeSpan[] TimeOut => new[]
        {
            TimeSpan.FromSeconds(1),
            TimeSpan.FromSeconds(2),
            TimeSpan.FromSeconds(3)
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
    }
}