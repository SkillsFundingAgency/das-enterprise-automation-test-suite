using NUnit.Framework;
using TechTalk.SpecFlow;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.Assessor
{
    public abstract class AssessorBasePage(ScenarioContext context) : RoatpNewAdminBasePage(context)
    {
        public ApplicationAssessmentOverviewPage SelectPassAndContinue()
        {
            SelectPassAndContinueToSubSection();
            return new ApplicationAssessmentOverviewPage(context);
        }

        public ApplicationAssessmentOverviewPage VerifyStatus(string linkText, string expectedStatus)
        {
            StringAssert.AreEqualIgnoringCase(expectedStatus, pageInteractionHelper.GetText(StatusTextLocator(linkText)), $"Status of '{linkText}' is Incorrect");

            return new ApplicationAssessmentOverviewPage(context);
        }
    }
}
