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
    public class AreasOfInterestPagePage : AanBasePage
    {
        protected override string PageTitle => "Please tell us which areas interest you most in your role as an ambassador";

        private static By NetworkingCheckBox => By.Id("Events_0__IsSelected");
        private static By WritingCaseStudies => By.Id("Promotions_0__IsSelected");
        private static By OnlineEventsCheckBox => By.Id("Events_3__IsSelected");
        private static By DistrubtingCommunicationCheckBox => By.Id("Promotions_2__IsSelected");

        public AreasOfInterestPagePage(ScenarioContext context) : base(context) => VerifyPage();
        public EngagedWithAmbassadorPage SelectEventsAndPromotions()
        {
            formCompletionHelper.SelectRadioOptionByLocator(NetworkingCheckBox);
            formCompletionHelper.SelectRadioOptionByLocator(WritingCaseStudies);
            Continue();
            return new EngagedWithAmbassadorPage(context);
        }

        public CheckYourAnswersPage AddMoreEventsAndPromotions()
        {
            formCompletionHelper.SelectRadioOptionByLocator(OnlineEventsCheckBox);
            formCompletionHelper.SelectRadioOptionByLocator(DistrubtingCommunicationCheckBox);
            Continue();
            return new CheckYourAnswersPage(context);
        }

    }
}

        

