using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.UI.Framework.TestSupport;
using System;
using System.Linq;
using System.Collections.Generic;
using TechTalk.SpecFlow;
using SFA.DAS.UI.FrameworkHelpers;
using SFA.DAS.Login.Service;
using SFA.DAS.Registration.UITests.Project.Helpers;
using SFA.DAS.UI.Framework;
using SFA.DAS.Registration.UITests.Project.Tests.Pages.AuthPages;
using SFA.DAS.Login.Service.Project.Helpers;
using SFA.DAS.FrameworkHelpers;

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
            HashSet<string> skippedurls = new HashSet<string>();

            HashSet<string> verifiedurls = new HashSet<string>();

            HashSet<string> authurls = _objectContext.GetAuthUrl().ToHashSet();

            string VerifiedUrlsToString() => ToString("Verified Urls", verifiedurls);

            string SkippedUrlsToString() => ToString("Skipped Urls", skippedurls);

            var webDriver = new RestartWebDriverHelper(_context).RestartWebDriver();

            if (login)
            {
                webDriver.Navigate().GoToUrl(UrlConfig.EmployerApprenticeshipService_BaseUrl);

                new EmployerPortalLoginHelper(_context).Login(_context.GetUser<AuthTestUser>(), true);
            }

            List<string> exceptions = new List<string>();

            string scenarioTitle = string.Empty;

            foreach (var url in authurls)
            {
                int x = _context.Get<ScreenShotTitleGenerator>().count + 1;

                string result = "Pass";

                bool skipped = false;

                try
                {
                    if (UrlException(url) || (login && UrlExceptionForLogedInUser(url))) 
                    {
                        skipped = true;
                        skippedurls.Add(url); 
                        continue; 
                    }

                    webDriver.Navigate().GoToUrl(url);

                    scenarioTitle = login ? new UnauthorisedUserWithLoginPage(_context).ScenarioTitle() : new UnauthorisedUserWithoutLoginPage(_context).ScenarioTitle();
                }
                catch (Exception ex)
                {
                    result = "FAIL";

                    exceptions.Add($"{ex.Message}{Environment.NewLine}Url: {scenarioTitle}_{x}_{result} - {url}");
                }
                finally
                {
                    if (!(skipped)) verifiedurls.Add($"{scenarioTitle}_{x}_{result} - {url}");
                }              
            }

            _objectContext.Replace($"{scenarioTitle}_Verified Urls", VerifiedUrlsToString());
            _objectContext.Replace($"{scenarioTitle}_Skipped Urls", SkippedUrlsToString());

            if (exceptions.Count > 0) throw new Exception($"{exceptions.ToString(Environment.NewLine)}{Environment.NewLine}" +
                $"{VerifiedUrlsToString()}{SkippedUrlsToString()}");
        }

        private string ToString(string message, HashSet<string> x) => $"{message} : {Environment.NewLine}{x.ToList().ToString(Environment.NewLine)}{Environment.NewLine}";

        private List<string> ExcludeUrlContains() =>
            new List<string> {
                $"https://{EnvName}-login.apprenticeships.education.gov.uk/account/register?clientId=easacc",
                $"{EnvName}-pas.apprenticeships.education.gov.uk/"
            };

        private List<string> ExcludeUrlEquals() =>
            new List<string>
            {
                $"https://accounts.{EnvName}-eas.apprenticeships.education.gov.uk/service/index?",
                $"{UrlConfig.EmployerApprenticeshipService_BaseUrl}",
            };

        private List<string> ExcludeUrlEqualsForLogedInUser() =>
            new List<string>
            {
                $"https://accounts.{EnvName}-eas.apprenticeships.education.gov.uk/accounts/getApprenticeshipFunding",
                $"https://accounts.{EnvName}-eas.apprenticeships.education.gov.uk/accounts/gatewayInform",
                $"https://accounts.{EnvName}-eas.apprenticeships.education.gov.uk/accounts/organisations/search",
                $"https://accounts.{EnvName}-eas.apprenticeships.education.gov.uk/accounts/summary",
                $"https://accounts.{EnvName}-eas.apprenticeships.education.gov.uk/settings/notifications",
                $"https://accounts.{EnvName}-eas.apprenticeships.education.gov.uk/service/accounts"
            };

        private List<string> ExcludeUrlContainsForLogedInUser() =>
            new List<string>
            {
                $"https://accounts.{EnvName}-eas.apprenticeships.education.gov.uk/accounts/organisations/search/results?searchTerm=",
                $"https://{EnvName}-login.apprenticeships.education.gov.uk/account/changepassword?clientId=easacc{EnvName}" +
                $"&returnurl=https%3A%2F%2Faccounts.{EnvName}-eas.apprenticeships.education.gov.uk",
                $"https://{EnvName}-login.apprenticeships.education.gov.uk/account/changeemail?clientId=easacc{EnvName}" +
                $"&returnurl=https%3A%2F%2Faccounts.{EnvName}-eas.apprenticeships.education.gov.uk"
            };

        private bool UrlException(string url) => (ExcludeUrlContains().Any(x => url.ContainsCompareCaseInsensitive(x)) || ExcludeUrlEquals().Any(x => x.CompareToIgnoreCase(url)));

        private bool UrlExceptionForLogedInUser(string url) => (ExcludeUrlContainsForLogedInUser().Any(x => url.ContainsCompareCaseInsensitive(x)) || ExcludeUrlEqualsForLogedInUser().Any(x => x.CompareToIgnoreCase(url)));

        private string EnvName => EnvironmentConfig.EnvironmentName;
    }
}