using OpenQA.Selenium;
using SFA.DAS.Approvals.UITests.Project.Helpers.DataHelpers;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Common;
using System;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer
{
    public class StoppedApprenticeDetailsPage : ConfirmApprenticeStatus
    {
        protected override string PageTitle => "Apprenticeship stopped";        
        protected override By PageHeader => By.CssSelector("h1.heading-large");
        private By EditLink => By.PartialLinkText("Edit");
        private By StopDateTextBox => By.Id("stopDate");
        private By MadeRedundantTextBox => By.Id("madeRedundant");
        

        private readonly ApprenticeDataHelper _dataHelper;

        public StoppedApprenticeDetailsPage(ScenarioContext context) : base(context) 
        {
            _dataHelper = context.Get<ApprenticeDataHelper>();
        }

        public StoppedApprenticeDetailsPage ValidateEditLinkIsNoLongerVisible()
        {
            if (!pageInteractionHelper.IsElementDisplayed(EditLink))
                throw new Exception("Link is still available to edit apprentice record");
            else
                return this;
        }

        public StoppedApprenticeDetailsPage ValidateRedundancyStatusAndStopDate()
        {
            string expectedStopDate = DateTime.Now.ToString("MMMM") + " " + DateTime.Now.Year;
            pageInteractionHelper.VerifyText(StopDateTextBox, expectedStopDate);
            pageInteractionHelper.VerifyText(MadeRedundantTextBox, _dataHelper.MadeRedundant);
            return this;
        }
    }
}