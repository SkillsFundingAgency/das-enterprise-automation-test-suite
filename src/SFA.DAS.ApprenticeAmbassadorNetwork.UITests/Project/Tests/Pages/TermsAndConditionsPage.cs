using System;
using OpenQA.Selenium;
using SFA.DAS.UI.Framework.TestSupport;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace SFA.DAS.ApprenticeAmbassadorNetwork.UITests.Project.Tests.Pages;

public class TermsAndConditionsPage : AanBasePage
{
    protected override string PageTitle => "Terms and Conditions";

    private By ConfirmAndContinueButton => By.Id("confirm-and-continue");

    public TermsAndConditionsPage(ScenarioContext context) : base(context) => VerifyPage();

    public RequiresLineManagerApprovalPage AcceptTermsAndConditions()
    {
        formCompletionHelper.Click(ConfirmAndContinueButton);
        return new RequiresLineManagerApprovalPage(context);
    }
}

    

