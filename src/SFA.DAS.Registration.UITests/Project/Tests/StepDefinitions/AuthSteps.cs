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

        [Then(@"an unauthorised user can not access the service")]
        public void AnUnauthorisedUserCanNotAccessTheService()
        {
            HashSet<string> authurls = new HashSet<string>();

            var webDriver = new RestartWebDriverHelper(_context).RestartWebDriver();

            authurls = _objectContext.GetAuthUrl().Select(x => x.url).ToList().ToHashSet();

            List<string> exceptions = new List<string>();

            foreach (var url in authurls)
            {
                try
                {
                    if ((UrlExceptionListContains().Any(x => url.ContainsCompareCaseInsensitive(x)))
                       || (UrlExceptionListEquals().Any(x => x.CompareToIgnoreCase(url)))) continue;

                    webDriver.Navigate().GoToUrl(url);

                    new UnauthorisedAccessPage(_context);
                }
                catch (Exception ex)
                {
                    exceptions.Add($"{ex.Message}{Environment.NewLine}URL: {url}");
                }
            }

            if (exceptions.Count > 0) throw new Exception(exceptions.ToString(Environment.NewLine));
        }

        private List<string> UrlExceptionListContains() => 
            new List<string> { 
                $"https://{EnvironmentConfig.EnvironmentName}-login.apprenticeships.education.gov.uk/account/register?clientId=easacc"
            };

        private List<string> UrlExceptionListEquals() =>
            new List<string> {
                $"https://accounts.{EnvironmentConfig.EnvironmentName}-eas.apprenticeships.education.gov.uk/service/index?",
                $"https://accounts.{EnvironmentConfig.EnvironmentName}-eas.apprenticeships.education.gov.uk/"
            };
    }
}