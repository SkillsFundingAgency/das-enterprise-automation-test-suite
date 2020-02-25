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

        public void VerifyUpdatedCandidateDetails(string changingField)
        {
            formCompletionHelper.Click(CandidateSummary);
            if (changingField == "EmailId")
            {
                string changedEmailId = (faaDataHelper.ChangedEmailId).ToLower();
                pageInteractionHelper.VerifyText(CandidateDetails, faaDataHelper.NewPostCode);
                pageInteractionHelper.VerifyText(CandidateDetails, changedEmailId);
            }
            else
            {
                pageInteractionHelper.VerifyText(CandidateDetails, faaDataHelper.NewPhoneNumber);
            }
        }
    }
}
