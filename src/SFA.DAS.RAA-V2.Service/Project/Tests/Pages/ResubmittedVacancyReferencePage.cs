using OpenQA.Selenium;
using SFA.DAS.RAA.DataGenerator;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V2.Service.Project.Tests.Pages
{
    public class ResubmittedVacancyReferencePage : BasePage
    {
        #region Helpers and Context
        private readonly ScenarioContext _context;
        private readonly VacancyTitleDatahelper _vacancyTitleDataHelper;  
        private readonly FormCompletionHelper _formCompletionHelper;
        private readonly PageInteractionHelper _pageInteractionHelper;
        #endregion

        protected override string PageTitle => _vacancyTitleDataHelper.VacancyTitle;

        protected By ReturnToDashboard => By.LinkText("Return to dashboard");
        protected By VacancyResubmissionText => By.ClassName("govuk-panel__title");

        public ResubmittedVacancyReferencePage(ScenarioContext context) : base(context)
        {
            _context = context;
            _vacancyTitleDataHelper = context.Get<VacancyTitleDatahelper>();
            _formCompletionHelper = context.Get<FormCompletionHelper>();
            _pageInteractionHelper = context.Get<PageInteractionHelper>();
            VerifyPage();
        }

        public void ConfirmVacancyResubmission()
        {
            _pageInteractionHelper.VerifyText(VacancyResubmissionText, "Vacancy resubmitted for approval");
            NavigateHome();
        }
    }
}
