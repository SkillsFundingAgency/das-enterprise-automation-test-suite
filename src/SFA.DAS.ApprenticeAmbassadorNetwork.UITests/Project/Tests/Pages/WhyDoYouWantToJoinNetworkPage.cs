using System;
using OpenQA.Selenium;
using SFA.DAS.UI.Framework.TestSupport;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace SFA.DAS.ApprenticeAmbassadorNetwork.UITests.Project.Tests.Pages;

public class WhyDoYouWantToJoinNetworkPage : AanBasePage
{
    protected override string PageTitle => "Why do you want to join the network?";

    private static By ReasonForJoining => By.Id("ReasonForJoiningTheNetwork");

    public WhyDoYouWantToJoinNetworkPage(ScenarioContext context) : base(context) => VerifyPage();

    public AreasOfInterestPage EnterInformationToJoinNetwork()
    {
        formCompletionHelper.EnterText(ReasonForJoining,aanDataHelpers.UpdateProviderDescriptionText);
        Continue();
        return new AreasOfInterestPage(context);
    }
}

    

