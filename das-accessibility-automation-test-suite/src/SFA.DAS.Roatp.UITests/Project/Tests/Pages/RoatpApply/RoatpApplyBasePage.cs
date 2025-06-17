using OpenQA.Selenium;
using SFA.DAS.FrameworkHelpers;
using SFA.DAS.Roatp.UITests.Project.Helpers.DataHelpers;
using System.Linq;
using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply
{
    public abstract class RoatpApplyBasePage(ScenarioContext context) : RoatpBasePage(context)
    {
        #region Helpers and Context
        protected readonly RoatpApplyDataHelpers applydataHelpers = context.GetValue<RoatpApplyDataHelpers>();
        protected readonly RoatpApplyCreateUserDataHelper applyCreateUserDataHelpers = context.GetValue<RoatpApplyCreateUserDataHelper>();
        #endregion

        private static By Dob => By.CssSelector("#dob");

        protected static By Month => By.CssSelector("input[id*='Month']");

        protected static By Year => By.CssSelector("input[id*='Year']");

        protected virtual By LongTextArea => By.CssSelector(".govuk-fieldset .govuk-textarea, .govuk-textarea");

        protected void UploadMultipleFiles(int noOfFiles)
        {
            for (int i = 0; i < noOfFiles; i++)
            {
                ChooseFile();
                formCompletionHelper.ClickButtonByText(ContinueButton, "Upload file");
            }

            formCompletionHelper.ClickButtonByText(ContinueButton, "Save and continue");
        }

        protected void UploadFile()
        {
            ChooseFile();
            Continue();
        }

        protected void SelectYesAndContinue()
        {
            SelectRadioOptionByText("Yes");
            Continue();
        }

        protected void SelectNoAndContinue()
        {
            SelectRadioOptionByText("No");
            Continue();
        }

        protected void EnterLongTextAreaAndContinue(string text)
        {
            formCompletionHelper.EnterText(LongTextArea, text);
            Continue();
        }

        public ApplicationOverviewPage ReturnToApplicationOverview()
        {
            formCompletionHelper.ClickLinkByText("Application overview");
            return new ApplicationOverviewPage(context);
        }

        public ApplicationOverviewPage EnterDateOfBirth()
        {
            var dobs = pageInteractionHelper.FindElements(Dob).ToList();

            int count = 0;

            foreach (var dob in dobs)
            {
                var dobcalc = RoatpApplyDataHelpers.Dob(count++);
                var month = dob.FindElement(Month);
                formCompletionHelper.EnterText(month, dobcalc.Month);

                var year = dob.FindElement(Year);
                formCompletionHelper.EnterText(year, dobcalc.Year);
            }

            Continue();
            return new ApplicationOverviewPage(context);
        }
    }
}
