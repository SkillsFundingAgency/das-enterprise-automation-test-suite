using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V1.UITests.Project.Tests.Pages.RAA
{
    public class RAA_CandidateApplicationPage : RAA_HeaderSectionBasePage
    {
        protected override string PageTitle => "Applications";

        private By CandidateDetails => By.Id("details-content-0");

        private By CandidateSummary => By.CssSelector(".summary");


        public RAA_CandidateApplicationPage(ScenarioContext context) : base(context)
        {
            VerifyPage();
        }

        public void VerifyUpdatedCandidateDetails()
        {
            formCompletionHelper.Click(CandidateSummary);
            pageInteractionHelper.VerifyText(CandidateDetails, faaDataHelper.NewAddress);
            pageInteractionHelper.VerifyText(CandidateDetails, faaDataHelper.PhoneNumber);
            pageInteractionHelper.VerifyText(CandidateDetails, faaDataHelper.ChangedEmailId);
        }
    }
}
