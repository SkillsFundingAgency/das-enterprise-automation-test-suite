using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.FrameworkHelpers;
using SFA.DAS.Login.Service;
using SFA.DAS.Login.Service.Project.Helpers;
using SFA.DAS.Registration.UITests.Project.Helpers;
using SFA.DAS.Registration.UITests.Project.Tests.Pages.AuthPages;
using SFA.DAS.UI.Framework;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using TechTalk.SpecFlow;

namespace SFA.DAS.Registration.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class AuthSteps(ScenarioContext context)
    {
        private readonly ObjectContext _objectContext = context.Get<ObjectContext>();

        [Then(@"a valid user can not access different account")]
        public void ThenAValidUserCanNotAccessDifferentAccount() => VerifyAuthUrls(true);

        [Then(@"an unauthorised user can not access the service")]
        public void AnUnauthorisedUserCanNotAccessTheService() => VerifyAuthUrls(false);

        private void VerifyAuthUrls(bool login)
        {
            HashSet<string> skippedurls = [];

            HashSet<string> verifiedurls = [];

            HashSet<string> authurls = [.. _objectContext.GetAuthUrl()];

            string VerifiedUrlsToString() => ToString("Verified Urls", verifiedurls);

            string SkippedUrlsToString() => ToString("Skipped Urls", skippedurls);

            var webDriver = new RestartWebDriverHelper(context).RestartWebDriver();

            if (login)
            {
                context.Get<TabHelper>().GoToUrl(UrlConfig.EmployerApprenticeshipService_BaseUrl);

                new EmployerPortalLoginHelper(context).Login(context.GetUser<AuthTestUser>(), true);
            }

            List<string> exceptions = [];

            string scenarioTitle = string.Empty;

            foreach (var url in authurls)
            {
                int x = context.Get<ScreenShotTitleGenerator>().GetNextCounter();

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

                    scenarioTitle = login ? new UnauthorisedUserWithLoginPage(context, url).ScenarioTitle() : new UnauthorisedUserWithoutLoginPage(context, url).ScenarioTitle();
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

        private static string ToString(string message, HashSet<string> x) => $"{message} : {Environment.NewLine}{x.ToList().ToString(Environment.NewLine)}{Environment.NewLine}";

        private static List<string> ExcludeUrlContains() =>
            new()
            {
                $"https://{EnvName}-login.apprenticeships.education.gov.uk/account/register?clientId=easacc",
                $"{EnvName}-pas.apprenticeships.education.gov.uk/"
            };

        private static List<string> ExcludeUrlEquals() =>
            new()
            {
                $"https://accounts.{EnvName}-eas.apprenticeships.education.gov.uk/service/index?",
                $"{UrlConfig.EmployerApprenticeshipService_BaseUrl}",
            };

        private static List<string> ExcludeUrlEqualsForLogedInUser() =>
            new()
            {
                $"https://accounts.{EnvName}-eas.apprenticeships.education.gov.uk/accounts/getApprenticeshipFunding",
                $"https://accounts.{EnvName}-eas.apprenticeships.education.gov.uk/accounts/gatewayInform",
                $"https://accounts.{EnvName}-eas.apprenticeships.education.gov.uk/accounts/organisations/search",
                $"https://accounts.{EnvName}-eas.apprenticeships.education.gov.uk/accounts/summary",
                $"https://accounts.{EnvName}-eas.apprenticeships.education.gov.uk/settings/notifications",
                $"https://accounts.{EnvName}-eas.apprenticeships.education.gov.uk/service/accounts"
            };

        private static List<string> ExcludeUrlContainsForLogedInUser() =>
            new()
            {
                $"https://accounts.{EnvName}-eas.apprenticeships.education.gov.uk/accounts/organisations/search/results?searchTerm=",
                $"https://{EnvName}-login.apprenticeships.education.gov.uk/account/changepassword?clientId=easacc{EnvName}" +
                $"&returnurl=https%3A%2F%2Faccounts.{EnvName}-eas.apprenticeships.education.gov.uk",
                $"https://{EnvName}-login.apprenticeships.education.gov.uk/account/changeemail?clientId=easacc{EnvName}" +
                $"&returnurl=https%3A%2F%2Faccounts.{EnvName}-eas.apprenticeships.education.gov.uk"
            };

        private static bool UrlException(string url) => (ExcludeUrlContains().Any(x => url.ContainsCompareCaseInsensitive(x)) || ExcludeUrlEquals().Any(x => x.CompareToIgnoreCase(url)));

        private static bool UrlExceptionForLogedInUser(string url) => (ExcludeUrlContainsForLogedInUser().Any(x => url.ContainsCompareCaseInsensitive(x)) || ExcludeUrlEqualsForLogedInUser().Any(x => x.CompareToIgnoreCase(url)));

        private static string EnvName => EnvironmentConfig.EnvironmentName;
    }
}