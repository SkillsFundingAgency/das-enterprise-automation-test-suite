using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.Registration.UITests.Project.Tests.Pages;
using SFA.DAS.UI.Framework.TestSupport;
using System;
using System.Linq;
using System.Collections.Generic;
using TechTalk.SpecFlow;
using SFA.DAS.UI.FrameworkHelpers;
using SFA.DAS.Login.Service;
using SFA.DAS.Login.Service.Helpers;
using SFA.DAS.Registration.UITests.Project.Helpers;
using SFA.DAS.UI.Framework;

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

        [Then(@"a valid user can not access different account")]
        public void ThenAValidUserCanNotAccessDifferentAccount() => VerifyAuthUrls(true);

        [Then(@"an unauthorised user can not access the service")]
        public void AnUnauthorisedUserCanNotAccessTheService() => VerifyAuthUrls(false);

        private void VerifyAuthUrls(bool login)
        {
            HashSet<string> authurls = new HashSet<string>();

            authurls = _objectContext.GetAuthUrl().ToHashSet();

            var webDriver = new RestartWebDriverHelper(_context).RestartWebDriver();

            if (login)
            {
                webDriver.Navigate().GoToUrl(UrlConfig.EmployerApprenticeshipService_BaseUrl);

                new EmployerPortalLoginHelper(_context).Login(_context.GetUser<AuthTestUser>(), true);
            }

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
                    exceptions.Add($"{ex.Message}" +
                        $"{Environment.NewLine}AuthUrl: {url}" +
                        $"{Environment.NewLine}ActualUrl: {webDriver.Url}");
                }
            }

            if (exceptions.Count > 0) throw new Exception($"{ exceptions.ToString(Environment.NewLine)}{Environment.NewLine}{authurls.ToList().ToString(Environment.NewLine)}");
        }

        private List<string> UrlExceptionListContains() => 
            new List<string> { 
                $"https://{EnvironmentConfig.EnvironmentName}-login.apprenticeships.education.gov.uk/account/register?clientId=easacc"
            };

        private List<string> UrlExceptionListEquals() =>
            new List<string> {
                $"{UriHelper.GetAbsoluteUri(UrlConfig.EmployerApprenticeshipService_BaseUrl,"service/index?")}",
                $"{UrlConfig.EmployerApprenticeshipService_BaseUrl}",
                $"{UriHelper.GetAbsoluteUri(UrlConfig.EmployerApprenticeshipService_BaseUrl, "service/accounts")}",
                $"https://{EnvironmentConfig.EnvironmentName}-login.apprenticeships.education.gov.uk/account/changepassword?clientId=easacc{EnvironmentConfig.EnvironmentName}" +
                $"&returnurl=https%3A%2F%2Faccounts.{EnvironmentConfig.EnvironmentName}-eas.apprenticeships.education.gov.uk%2F%2Fservice%2Fpassword%2Fchange",
                $"https://{EnvironmentConfig.EnvironmentName}-login.apprenticeships.education.gov.uk/account/changeemail?clientId=easacc{EnvironmentConfig.EnvironmentName}" +
                $"&returnurl=https%3A%2F%2Faccounts.{EnvironmentConfig.EnvironmentName}-eas.apprenticeships.education.gov.uk%2F%2Fservice%2Femail%2Fchange",
                $"https://accounts.{EnvironmentConfig.EnvironmentName}-eas.apprenticeships.education.gov.uk/settings/notifications"
            };
    }
}