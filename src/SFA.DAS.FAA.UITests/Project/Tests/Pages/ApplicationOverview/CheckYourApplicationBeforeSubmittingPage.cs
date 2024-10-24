using SFA.DAS.FAA.UITests.Project.Tests.Pages;
using SFA.DAS.FAA.UITests.Project.Tests.Pages.ApplicationOverview;

namespace SFA.DAS.FAA.UITests.Project.Pages.ApplicationOverview;

public class CheckYourApplicationBeforeSubmittingPage(ScenarioContext context) : FAABasePage(context)
{
    protected override string PageTitle => "Check your application before submitting";

    public ApplicationSubmittedPage SubmitApplication()
    {
        SelectCheckBoxByText("I understand that I won't be able to make any changes after I submit my application");

        Continue();

        return new(context);
    }
}

