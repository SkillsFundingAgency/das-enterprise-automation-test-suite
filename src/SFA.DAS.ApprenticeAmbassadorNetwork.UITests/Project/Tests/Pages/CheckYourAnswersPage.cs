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

public class CheckYourAnswersPage : AanBasePage
{
    protected override string PageTitle => "Check the information you have provided before submitting your application";

    private readonly string pageTitle;

    public CheckYourAnswersPage(ScenarioContext context) : base(context) => VerifyPage();

    
}

    

