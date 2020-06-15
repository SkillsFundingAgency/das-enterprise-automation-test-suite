using NUnit.Framework;
using OpenQA.Selenium;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.Assessor
{
    public partial class ApplicationAssessmentOverviewPage : AssessorBasePage
    {
        private By StatusText (string linkText) => By.XPath($"//a[text()='{linkText}']/../following-sibling::strong");

        public ApplicationAssessmentOverviewPage VerifyStatus(string linkText, string status)
        {
            Assert.AreEqual(status, pageInteractionHelper.GetText(StatusText(linkText)), $"Status of {linkText} is Incorrect");
            return new ApplicationAssessmentOverviewPage(_context);
        }

        #region Section1
        public ApplicationAssessmentOverviewPage VerifySection1Link1Status(string status) => VerifyStatus(Section1_Link1, status);
        #endregion
    }
}
