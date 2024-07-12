using NUnit.Framework;
using System;
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
            string actualStatus = pageInteractionHelper.GetText(StatusTextLocator(linkText));
            bool firstLetterMatch = actualStatus[0] == expectedStatus[0] && char.IsUpper(actualStatus[0]);
            bool restOfStringMatch = string.Equals(actualStatus.Substring(1), expectedStatus.Substring(1), StringComparison.OrdinalIgnoreCase);
            bool statusesMatch = firstLetterMatch && restOfStringMatch;

            Assert.IsTrue(statusesMatch, $"Status of '{linkText}' is Incorrect. Expected: '{expectedStatus}', Actual: '{actualStatus}'");
            return new ApplicationAssessmentOverviewPage(context);
        }

    }
}
