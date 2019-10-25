using OpenQA.Selenium;
using SFA.DAS.UI.Framework.TestSupport;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V1.UITests.Project.Tests.Pages.RAA
{
    public class RAA_EmployerInformation : RAA_HeaderSectionBasePage
    {
        protected override string PageTitle => "Check employer information";

        #region Helpers and Context
        private readonly IWebDriver _webDriver;
        #endregion

        private By NumberOfVacancy => By.Id("NumberOfPositions");
        private By NationwideNumberOfVacancy => By.Id("NumberOfPositionsNationwide");

        private By EmployerDescription => By.Id("AnonymousEmployerDescription");
        
        private By EmployerReason => By.Id("AnonymousEmployerReason");

        private By AboutTheEmployerBody => By.XPath("//body");

        private By IFrame => By.CssSelector("iframe");

        private By EmployerWebsiteUrlOptional => By.Id("EmployerWebsiteUrl");

        public RAA_EmployerInformation(ScenarioContext context) : base(context)
        {
            _webDriver = context.GetWebDriver();
        }

        public RAA_EmployerInformation UseTheMainEmployerAddress(string position)
        {
            formCompletionHelper.SelectRadioOptionByText("Use the main employer address");
            formCompletionHelper.EnterText(NumberOfVacancy, position);
            return this;
        }

        public RAA_EmployerInformation AddDifferentLocation()
        {
            formCompletionHelper.SelectRadioOptionByText("Add different location(s)");
            return this;
        }

        public RAA_EmployerInformation SetAsANationWideVacancy(string position)
        {
            formCompletionHelper.SelectRadioOptionByText("Set as a nationwide vacancy");
            formCompletionHelper.EnterText(NationwideNumberOfVacancy, position);
            return this;
        }

        public void EmployerWishesToBeAnonymous()
        {
            formCompletionHelper.SelectRadioOptionByText("No, the employer wants to remain anonymous");
            formCompletionHelper.EnterText(EmployerDescription, dataHelper.EmployerDescription);
            formCompletionHelper.EnterText(EmployerReason, dataHelper.EmployerReason);
            SaveAndContinue();
        }

        public void EmployerDoesNotWantToBeAnonymous()
        {
            formCompletionHelper.SelectRadioOptionByText("Yes");
            formCompletionHelper.EnterText(EmployerWebsiteUrlOptional, dataHelper.EmployerWebsiteUrl);
            SaveAndContinue();
        }

        private void SaveAndContinue()
        {
            EnterAboutTheEmployerInformation();
            formCompletionHelper.ClickButtonByText("Save and continue");
        }

        private RAA_EmployerInformation EnterAboutTheEmployerInformation()
        {
            _webDriver.SwitchTo().Frame(_webDriver.FindElement(IFrame));
            _webDriver.FindElement(AboutTheEmployerBody).SendKeys(Keys.Tab + Keys.Control + "a" + Keys.Delete);
            _webDriver.FindElement(AboutTheEmployerBody).SendKeys(dataHelper.EmployerBody);
            _webDriver.FindElement(AboutTheEmployerBody).SendKeys(Keys.Delete);
            _webDriver.SwitchTo().DefaultContent();
            return this;
        }
    }
}
