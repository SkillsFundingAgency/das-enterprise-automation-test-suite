using NUnit.Framework;
using TechTalk.SpecFlow;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.Assessor
{
    public abstract class AssessorBasePage : RoatpNewAdminBasePage
    {
        protected AssessorBasePage(ScenarioContext context) : base(context) { }

        public ApplicationAssessmentOverviewPage SelectPassAndContinue()
        {
            SelectPassAndContinueToSubSection();
            return new ApplicationAssessmentOverviewPage(context);
        }

        public ApplicationAssessmentOverviewPage VerifyStatus(string linkText, string expectedStatus)
        {
            Assert.AreEqual(expectedStatus, pageInteractionHelper.GetText(StatusTextLocator(linkText)), $"Status of '{linkText}' is Incorrect");
            return new ApplicationAssessmentOverviewPage(context);
        }
    }
}
