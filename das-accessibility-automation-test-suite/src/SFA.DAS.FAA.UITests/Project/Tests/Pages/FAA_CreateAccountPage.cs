using SFA.DAS.FAA.UITests.Project.Tests.Pages.SignUp;

namespace SFA.DAS.FAA.UITests.Project.Tests.Pages;

public class FAA_CreateAccountPage(ScenarioContext context) : FAABasePage(context)
{
    protected override string PageTitle => "Create an account for Find an apprenticeship";

    public WhatIsYourNamePage CreateAnAccount()
    {
        Continue();

        return new(context);
    }
}
