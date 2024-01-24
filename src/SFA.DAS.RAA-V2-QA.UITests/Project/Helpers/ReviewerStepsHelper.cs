using SFA.DAS.DfeAdmin.Service.Project.Helpers.DfeSign;
using SFA.DAS.FrameworkHelpers;
using SFA.DAS.RAA_V2.Service.Project.Tests.Pages;
using SFA.DAS.RAA_V2_QA.UITests.Project.Tests.Pages.Reviewer;
using SFA.DAS.UI.Framework;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V2_QA.UITests.Project.Helpers;

public class ReviewerStepsHelper(ScenarioContext context)
{
    public Reviewer_HomePage GoToReviewerHomePage(bool restart)
    {
        var applicationName = "Reviewer";
        var raav2qaBaseUrl = UrlConfig.RAAV2QA_BaseUrl;

        if (restart)
        {
            new RestartWebDriverHelper(context).RestartWebDriver(raav2qaBaseUrl, applicationName);
        }
        else
        {
            context.Get<ObjectContext>().SetCurrentApplicationName(applicationName);

            context.Get<TabHelper>().OpenInNewTab(raav2qaBaseUrl);
        }

        new DfeAdminLoginStepsHelper(context).CheckAndLoginToASVacancyQa();

        return new Reviewer_HomePage(context);
    }

    public void VerifyEmployerNameAndApprove(bool restart) => RAAV2QASignOut(ReviewVacancy(restart).VerifyEmployerName().Approve());

    public void Refer(bool restart) => RAAV2QASignOut(ReviewVacancy(restart).ReferTitle());

    public void VerifyDisabilityConfidenceAndApprove(bool restart) => RAAV2QASignOut(ReviewVacancy(restart).VerifyDisabilityConfident().Approve());

    private Reviewer_VacancyPreviewPage ReviewVacancy(bool restart) => GoToReviewerHomePage(restart).ReviewVacancy();

    private static void RAAV2QASignOut(VerifyDetailsBasePage basePage) => basePage.RAAV2QASignOut();
}
