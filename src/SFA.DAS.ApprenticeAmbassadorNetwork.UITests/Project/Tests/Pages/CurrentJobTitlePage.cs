using System;
using OpenQA.Selenium;
using SFA.DAS.UI.Framework.TestSupport;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace SFA.DAS.ApprenticeAmbassadorNetwork.UITests.Project.Tests.Pages
{
    public class CurrentJobTitlePage : AanBasePage
    {
        protected override string PageTitle => "What is your current job title?";


        private By CurrentJobTitle = By.Id("JobTitle");

        public CurrentJobTitlePage(ScenarioContext context) : base(context) => VerifyPage();

        public ApprenticeshipRegionPage ConfirmJobtitleAndContinue()
        {
            formCompletionHelper.EnterText(CurrentJobTitle, aanDataHelpers.JobTitle);
            Continue();
            return new ApprenticeshipRegionPage(context);
        }
        public CheckYourAnswersPage ChangeJobtitleAndContinue()
        {
            formCompletionHelper.EnterText(CurrentJobTitle, aanDataHelpers.NewJobTitle);
            Continue();
            return new CheckYourAnswersPage(context);
        }
    }
}

        

