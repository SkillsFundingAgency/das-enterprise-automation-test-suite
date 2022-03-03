using OpenQA.Selenium;
using SFA.DAS.RAA_V2.Service.Project.Tests.Pages.CreateAdvert;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V2.Service.Project.Tests.Pages
{
    public class SummaryOftheapprenticeshipPage : RAAV2CSSBasePage
    {
        protected override string PageTitle => "Summary of the apprenticeship";

        private By ShortDescSelector => By.CssSelector("textarea#ShortDescription");

        protected override By ContinueButton => By.CssSelector(".govuk-button.save-button");

        public SummaryOftheapprenticeshipPage(ScenarioContext context) : base(context) {  }

        public void EnterShortDescription()
        {
            formCompletionHelper.EnterText(ShortDescSelector, rAAV2DataHelper.RandomAlphabeticString(60));
        }

    }


    public partial class CreateAnApprenticeshipAdvertPage : RAAV2CSSBasePage
    {
        protected override string PageTitle => "Create an apprenticeship advert";

        public CreateAnApprenticeshipAdvertPage(ScenarioContext context) : base(context) { }

        
        public WhatDoYouWantToCallThisAdvertPage EnterAdvertTitle()
        {
            NavigateToTask(Advertsummary, Advertsummary_1);
            return new WhatDoYouWantToCallThisAdvertPage(context);
        }

        public SelectOrganisationPage EnterAdvertOrganisaition()
        {
            NavigateToTask(Advertsummary, Advertsummary_2);
            return new SelectOrganisationPage(context);
        }
        public ApprenticeshipTrainingPage EnterAdvertTrainingCourse()
        {
            NavigateToTask(Advertsummary, Advertsummary_3);
            return new ApprenticeshipTrainingPage(context);
        }
        public WhatDoYouWantToCallThisAdvertPage EnterAdvertTrainingProvider()
        {
            NavigateToTask(Advertsummary, Advertsummary_4);
            return new WhatDoYouWantToCallThisAdvertPage(context);
        }
        public WhatDoYouWantToCallThisAdvertPage EnterAdvertSummary()
        {
            NavigateToTask(Advertsummary, Advertsummary_5);
            return new WhatDoYouWantToCallThisAdvertPage(context);
        }
        public WhatDoYouWantToCallThisAdvertPage EnterAdvertAbout()
        {
            NavigateToTask(Advertsummary, Advertsummary_6);
            return new WhatDoYouWantToCallThisAdvertPage(context);
        }

        private void NavigateToTask(string sectionName, string taskName, int index = 0) => NavigateToTask(sectionName, taskName, index, null);
    }
}
