
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

        public ReviewYourDetailsPage(ScenarioContext context) : base(context) => VerifyPage();

        public TrainingLocationPage AccessTrainingLocations()
        {
            formCompletionHelper.ClickLinkByText("Training locations");
            return new TrainingLocationPage(context);
        }

        public ManageTheStandardsYouDeliverPage AccessStandards()
        {
            formCompletionHelper.ClickLinkByText("Standards");
            return new ManageTheStandardsYouDeliverPage(context);
        }

    }
 
}
