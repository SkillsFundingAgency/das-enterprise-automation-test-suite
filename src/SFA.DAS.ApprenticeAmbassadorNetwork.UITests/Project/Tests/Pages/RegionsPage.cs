using System;
using OpenQA.Selenium;
using SFA.DAS.UI.Framework.TestSupport;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace SFA.DAS.ApprenticeAmbassadorNetwork.UITests.Project.Tests.Pages;

public class RegionsPage : AanBasePage
{
    protected override string PageTitle => "This is a regulated standard";

    public RegionsPage(ScenarioContext context) : base(context) => VerifyPage();


    public WhyDoYouWantToJoinNetworkPage ClickConfirmAndContinueButton()
    {
        formCompletionHelper.SelectRadioOptionByText("London");
        Continue();
        return new WhyDoYouWantToJoinNetworkPage(context);
    }      
}

    

