using OpenQA.Selenium;
using SFA.DAS.Approvals.UITests.Project.Helpers.DataHelpers;
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

        protected By NonDefaulCheckboxSelector => By.CssSelector(".govuk-checkboxes .govuk-checkboxes__input");

        protected By ErrorMessageSelector => By.CssSelector(".govuk-error-summary");

        private static By ApplicaitonStatusSelector => By.CssSelector("#main-content .application-status-one");

        protected TransferMatchingBasePage(ScenarioContext context, bool verifyPage = true) : base(context)
        {
            tMDataHelper = context.Get<TMDataHelper>();
            datahelper = context.Get<ApprenticeDataHelper>();
            if (verifyPage) VerifyPage();
        }

        public string GetErrorMessage() => pageInteractionHelper.GetText(ErrorMessageSelector);

        protected void VerifyApplicationStatus(string expectedStatus) => VerifyElement(ApplicaitonStatusSelector, expectedStatus);

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

            int randomvalue = tMDataHelper.GenerateRandomNumberLessThanMaxAmount(NonDefaultList.Count);

            formCompletionHelper.ClickElement(NonDefaultList.ElementAt(randomvalue));
        }
    }
}