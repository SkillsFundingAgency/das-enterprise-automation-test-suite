using NUnit.Framework;
using OpenQA.Selenium;
using SFA.DAS.Approvals.UITests.Project.Helpers.DataHelpers;
using SFA.DAS.FrameworkHelpers;
using SFA.DAS.TransferMatching.UITests.Project.Helpers;
using SFA.DAS.UI.Framework.TestSupport;
using System.Linq;
using TechTalk.SpecFlow;

namespace SFA.DAS.TransferMatching.UITests.Project.Tests.Pages
{
    public abstract class TransferMatchingBasePage : VerifyBasePage
    {
        #region Helpers and Context
        protected readonly TMDataHelper tMDataHelper;
        protected readonly ApprenticeDataHelper datahelper;
        #endregion

        protected static By NonDefaulCheckboxSelector => By.CssSelector(".govuk-checkboxes .govuk-checkboxes__input");

        protected static By ErrorMessageSelector => By.CssSelector(".govuk-error-summary");

        private static By ApplicaitonStatusSelector => By.CssSelector("div.govuk-body");      //By.XPath("//strong[contains(@class,'govuk-tag')]");

        protected TransferMatchingBasePage(ScenarioContext context, bool verifyPage = true) : base(context)
        {
            tMDataHelper = context.GetValue<TMDataHelper>();
            datahelper = context.GetValue<ApprenticeDataHelper>();
            if (verifyPage) VerifyPage();
        }

        public string GetErrorMessage() => pageInteractionHelper.GetText(ErrorMessageSelector);

        protected void VerifyApplicationStatus(string expectedStatus)
        {

            var actualStatus = pageInteractionHelper.GetText(ApplicaitonStatusSelector);
            actualStatus = actualStatus.Remove(0, 20).Trim().ToUpper();
            Assert.AreEqual(expectedStatus, actualStatus); 
        }          

        protected Pledge GetPledgeDetail() => objectContext.GetPledgeDetail();

        protected string GetPledgeId() => GetPledgeDetail().PledgeId;

        protected CreateATransferPledgePage SelectAndContinue()
        {
            SelectRandomCheckbox();

            Continue();

            return new CreateATransferPledgePage(context);
        }

        protected void SelectRandomCheckbox()
        {
            var NonDefaultList = pageInteractionHelper.FindElements(NonDefaulCheckboxSelector);

            int randomvalue = TMDataHelper.GenerateRandomNumberLessThanMaxAmount(NonDefaultList.Count);

            formCompletionHelper.ClickElement(NonDefaultList.ElementAt(randomvalue));
        }
    }
}