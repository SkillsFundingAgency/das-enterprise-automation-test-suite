
using OpenQA.Selenium;
using SFA.DAS.UI.Framework.TestSupport;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace SFA.DAS.ManagingStandards.UITests.Project.Tests.Pages
{
    public class ReviewYourDetailsPage : VerifyBasePage
    {
        protected override string PageTitle => "Review your details";

        private By TrainingLocationsLink = By.LinkText("/10001259/traininglocations");

        private By StandardsLink = By.LinkText("/10001259/standards");

        public ReviewYourDetailsPage(ScenarioContext context) : base(context) => VerifyPage();

        public void ClickTrainingLocations()
        {
            formCompletionHelper.Click(TrainingLocationsLink);
        }

        public void ClickStandards()
        {
            formCompletionHelper.Click(StandardsLink);
        }

    }
 
}
