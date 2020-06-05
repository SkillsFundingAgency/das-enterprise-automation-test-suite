using OpenQA.Selenium;
using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.RAA.DataGenerator.Project;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V1.UITests.Project.Tests.Pages.RAA
{
    public class RAA_EmployerInformationPage : RAA_HeaderSectionBasePage
    {
        protected override string PageTitle => "Check employer information";

        #region Helpers and Context
        private readonly PageInteractionHelper _pageInteractionHelper;
        private readonly ObjectContext _objectContext;
        #endregion

        private By NumberOfVacancy => By.Id("NumberOfPositions");

        private By NationwideNumberOfVacancy => By.Id("NumberOfPositionsNationwide");

        private By EmployerDescription => By.Id("AnonymousEmployerDescription");
        
        private By EmployerReason => By.Id("AnonymousEmployerReason");

        private By AboutTheEmployerBody => By.XPath("//body");

        private By EmployerWebsiteUrlOptional => By.Id("EmployerWebsiteUrl");

        private By VacancyLocationHeading => By.ClassName("heading-xlarge");

        private By VacancyLocationPageSaveAndContinue => By.CssSelector("button[type='submit']");

        private By EmployerName => By.CssSelector(".sfa-no-top-margin+p");

        public RAA_EmployerInformationPage(ScenarioContext context) : base(context)
        {
            _pageInteractionHelper = context.Get<PageInteractionHelper>();
            _objectContext = context.Get<ObjectContext>();
        }

        public RAA_EmployerInformationPage UseTheMainEmployerAddress(string position)
        {
            SetEmployerName();
            formCompletionHelper.SelectRadioOptionByText("Use the main employer address");
            formCompletionHelper.EnterText(NumberOfVacancy, position);
            return this;
        }

        public RAA_EmployerInformationPage AddDifferentLocation()
        {
            SetEmployerName();
            formCompletionHelper.SelectRadioOptionByText("Add different location(s)");
            return this;
        }

        public RAA_EmployerInformationPage SetAsANationWideVacancy(string position)
        {
            SetEmployerName();
            formCompletionHelper.SelectRadioOptionByText("Set as a nationwide vacancy");
            formCompletionHelper.EnterText(NationwideNumberOfVacancy, position);
            return this;
        }

        public void EmployerWishesToBeAnonymous()
        {
            formCompletionHelper.SelectRadioOptionByText("No, the employer wants to remain anonymous");
            formCompletionHelper.EnterText(EmployerDescription, rAAV1DataHelper.EmployerDescription);
            formCompletionHelper.EnterText(EmployerReason, rAAV1DataHelper.EmployerReason);
            SaveAndContinue();
        }

        public void EmployerDoesNotWantToBeAnonymous()
        {
            formCompletionHelper.SelectRadioOptionByText("Yes");
            formCompletionHelper.EnterText(EmployerWebsiteUrlOptional, rAAV1DataHelper.EmployerWebsiteUrl);
            SaveAndContinue();
        }

        private void SaveAndContinue()
        {
            EnterAboutTheEmployerInformation();
            formCompletionHelper.ClickButtonByText("Save and continue");
        }

        private RAA_EmployerInformationPage EnterAboutTheEmployerInformation()
        {
            tabHelper.SwitchToFrame();
            formCompletionHelper.SendKeys(AboutTheEmployerBody, (Keys.Tab + Keys.Control + "a" + Keys.Delete));
            formCompletionHelper.SendKeys(AboutTheEmployerBody,rAAV1DataHelper.EmployerBody);
            formCompletionHelper.SendKeys(AboutTheEmployerBody, Keys.Delete);
            tabHelper.SwitchToDefaultContent();
            return this;
        }

        public void ClickOnSaveAndContinueButton()
        {
            formCompletionHelper.ClickButtonByText("Save and continue");
            pageInteractionHelper.WaitforURLToChange("create?");
            var heading = _pageInteractionHelper.GetText(VacancyLocationHeading);
            if (heading.Contains("Vacancy location(s)"))
            {
                formCompletionHelper.Click(VacancyLocationPageSaveAndContinue);
            }
        }

        private void SetEmployerName() => _objectContext.SetEmployerName(pageInteractionHelper.GetText(EmployerName));
    }
}
