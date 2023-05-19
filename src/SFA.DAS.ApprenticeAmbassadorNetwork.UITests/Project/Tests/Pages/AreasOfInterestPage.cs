using System;
using OpenQA.Selenium;
using SFA.DAS.UI.Framework.TestSupport;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace SFA.DAS.ApprenticeAmbassadorNetwork.UITests.Project.Tests.Pages;

public class AreasOfInterestPage : AanBasePage
{
    protected override string PageTitle => "Are you joining because you have engaged with an ambassador in the network?";

    private readonly string pageTitle;

    public AreasOfInterestPage(ScenarioContext context) : base(context) => VerifyPage();

    public PreviousEngagementPage EnterInformationToJoinNetwork()
    {
        formCompletionHelper.Click(ContinueButton);
        Continue();
        return new PreviousEngagementPage(context);
    }
}

    

