using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.Registration.UITests.Project.Tests.Pages;
using SFA.DAS.UI.Framework.TestSupport;
using System;
using System.Linq;
using System.Collections.Generic;
using TechTalk.SpecFlow;
using SFA.DAS.UI.FrameworkHelpers;

namespace SFA.DAS.Registration.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class AuthSteps
    {
        private readonly ScenarioContext _context;
        private readonly ObjectContext _objectContext;

        public AuthSteps(ScenarioContext context)
        {
            _context = context;
            _objectContext = context.Get<ObjectContext>();
        }

        [Then(@"UnAuthorised users can not access the service")]
        public void ThenUnAuthorisedUsersCanNotAccessTheService()
        {
            List<string> authurls = new List<string>();

            var webDriver = new RestartWebDriverHelper(_context).RestartWebDriver();

            authurls = _objectContext.GetAuthUrl().Select(x=> x.url).ToList();

            List<string> exceptions = new List<string>();

            foreach (var url in authurls)
            {
                try
                {
                    if (UrlExceptionList().Any(x=>x.ContainsCompareCaseInsensitive(url))) continue;

                    webDriver.Navigate().GoToUrl(url);

                    new SignInPage(_context);
                }
                catch (Exception ex)
                {
                    exceptions.Add($"{ex.Message}{Environment.NewLine}URL: {url}");
                }
            }

            if (exceptions.Count > 0) throw new Exception(exceptions.ToString(Environment.NewLine));
        }

        private List<string> UrlExceptionList() => new List<string> { $"https://accounts.{EnvironmentConfig.EnvironmentName}-eas.apprenticeships.education.gov.uk/service/index?" };
    }
}