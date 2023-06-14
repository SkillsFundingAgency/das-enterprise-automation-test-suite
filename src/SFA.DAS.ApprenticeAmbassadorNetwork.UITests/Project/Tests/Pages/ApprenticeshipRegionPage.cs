using System;
using OpenQA.Selenium;
using SFA.DAS.UI.Framework.TestSupport;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using OpenQA.Selenium.DevTools.V111.Audits;

namespace SFA.DAS.ApprenticeAmbassadorNetwork.UITests.Project.Tests.Pages
{
    public class ApprenticeshipRegionPage : AanBasePage
    {
        protected override string PageTitle => "Tell us what area of the country you work in as an apprentice";
        private static By LondonRadio => By.CssSelector("#SelectedRegionId[value='3']");
        private static By NorthEasstRadio => By.CssSelector("#SelectedRegionId[value='4']");

        public ApprenticeshipRegionPage(ScenarioContext context) : base(context) => VerifyPage();


        public WhyDoYouWantToJoinNetworkPage ConfirmRegionAndContinue()
        {
            formCompletionHelper.SelectRadioOptionByLocator(LondonRadio);
            Continue();
            return new WhyDoYouWantToJoinNetworkPage(context);
        }
        public CheckYourAnswersPage AddOneMoreRegionAndContinue()
        {
            formCompletionHelper.SelectRadioOptionByLocator(NorthEasstRadio);
            Continue();
            return new CheckYourAnswersPage(context);
        }
    }
}

        

