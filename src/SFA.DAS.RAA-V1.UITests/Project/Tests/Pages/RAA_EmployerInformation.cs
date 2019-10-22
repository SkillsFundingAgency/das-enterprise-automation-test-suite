using OpenQA.Selenium;
using SFA.DAS.RAA_V1.UITests.Project.Helpers;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V1.UITests.Project.Tests.Pages
{
    public class RAA_EmployerInformation : BasePage
    {
        protected override string PageTitle => "Check employer information";

        #region Helpers and Context
        private readonly FormCompletionHelper _formCompletionHelper;
        private readonly ScenarioContext _context;
        private readonly RAAV1DataHelper _dataHelper;
        private readonly IWebDriver _webDriver;
        #endregion

        private By NumberOfVacancy => By.Id("NumberOfPositions");

        private By EmployerDescription => By.Id("AnonymousEmployerDescription");
        
        private By EmployerReason => By.Id("AnonymousEmployerReason");

        private By AboutTheEmployerBody => By.XPath("//body");

        private By IFrame => By.CssSelector("iframe");

        private By EmployerWebsiteUrlOptional => By.Id("EmployerWebsiteUrl");

        public RAA_EmployerInformation(ScenarioContext context) : base(context)
        {
            _context = context;
            _dataHelper = context.Get<RAAV1DataHelper>();
            _formCompletionHelper = context.Get<FormCompletionHelper>();
            _webDriver = context.GetWebDriver();
            VerifyPage();
        }

        public RAA_EmployerInformation UseTheMainEmployerAddress(string position)
        {
            _formCompletionHelper.SelectRadioOptionByText("Use the main employer address");
            SetNoOfVacancy(position);
            return this;
        }

        public RAA_EmployerInformation AddDifferentLocation()
        {
            _formCompletionHelper.SelectRadioOptionByText("Add different location(s)");
            return this;
        }

        public RAA_EmployerInformation SetAsANationWideVacancy(string position)
        {
            _formCompletionHelper.SelectRadioOptionByText("Set as a nationwide vacancy");
            SetNoOfVacancy(position);
            return this;
        }

        public RAA_BasicVacancyDetails EmployerWishesToBeAnonymous()
        {
            _formCompletionHelper.SelectRadioOptionByText("No, the employer wants to remain anonymous");
            _formCompletionHelper.EnterText(EmployerDescription, _dataHelper.EmployerDescription);
            _formCompletionHelper.EnterText(EmployerReason, _dataHelper.EmployerReason);
            return SaveAndContinue();
        }

        public RAA_BasicVacancyDetails EmployerDoesNotWantToBeAnonymous()
        {
            _formCompletionHelper.SelectRadioOptionByText("Yes");
            _formCompletionHelper.EnterText(EmployerWebsiteUrlOptional, _dataHelper.EmployerWebsiteUrl);
            return SaveAndContinue();
        }

        private RAA_EmployerInformation SetNoOfVacancy(string position)
        {
            _formCompletionHelper.EnterText(NumberOfVacancy, position);
            return this;
        }

        private RAA_BasicVacancyDetails SaveAndContinue()
        {
            EnterAboutTheEmployerInformation();
            _formCompletionHelper.ClickButtonByText("Save and continue");
            return new RAA_BasicVacancyDetails(_context);
        }

        private RAA_EmployerInformation EnterAboutTheEmployerInformation()
        {
            _webDriver.SwitchTo().Frame(_webDriver.FindElement(IFrame));
            _webDriver.FindElement(AboutTheEmployerBody).SendKeys(Keys.Tab + Keys.Control + "a" + Keys.Delete);
            _webDriver.FindElement(AboutTheEmployerBody).SendKeys(_dataHelper.EmployerBody);
            _webDriver.FindElement(AboutTheEmployerBody).SendKeys(Keys.Delete);
            _webDriver.SwitchTo().DefaultContent();
            return this;
        }
    }
}
