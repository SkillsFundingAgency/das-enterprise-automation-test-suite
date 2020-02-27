using OpenQA.Selenium;
using SFA.DAS.RAA.DataGenerator;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace SFA.DAS.FAA.UITests.Project.Tests.Pages
{
    public class FAA_MyApplicationsHomePage : BasePage
    {
        protected override string PageTitle => "My applications";

        #region Helpers and Context        
        private readonly FormCompletionHelper _formCompletionHelper;
        private readonly PageInteractionHelper _PageIntercationHelper;
        private readonly ScenarioContext _context;
        private readonly VacancyTitleDatahelper _dataHelper;
        #endregion
        
        private By FindAnApprenticeshipLink => By.LinkText("Find an apprenticeship");

        private By FindTraineeshipLink => By.Id("find-traineeship-link");

        private By SignOutCss => By.XPath("//a[contains(.,'Sign out')]");

        private By NotificationText => By.ClassName("info-summary");

        private By DismissNotification => By.LinkText("Dismiss this message");

        private By ReadFeedbackLink => By.LinkText("Read feedback");

        private By Settings => By.LinkText("Settings");

        private By SavedSection => By.Id("dashDrafts");

        private By SavedVacanciesTable => By.CssSelector(".table-font-xsmall");

        private By DeleteDraftButton => By.CssSelector("[title='Remove from my applications']");

        private By DraftVacancyDeletionInfoText => By.Id("VacancyDeletedInfoMessageText");

        private By VacancyDeletedLink => By.Id("vacancyDeletedLink");

        public FAA_MyApplicationsHomePage(ScenarioContext context) : base(context)
        {
            _context = context;            
            _formCompletionHelper = context.Get<FormCompletionHelper>();
            _PageIntercationHelper = context.Get<PageInteractionHelper>();
            _dataHelper = context.Get<VacancyTitleDatahelper>();
            VerifyPage();
        }

        public FAA_ApprenticeSearchPage FindAnApprenticeship()
        {
            _formCompletionHelper.Click(FindAnApprenticeshipLink);
            return new FAA_ApprenticeSearchPage(_context);
        }

        public FAA_TraineeshipSearchPage FindATraineeship()
        {
            _formCompletionHelper.Click(FindTraineeshipLink);
            return new FAA_TraineeshipSearchPage(_context);
        }

        public FAA_SettingsPage GoToSettings()
        {
            _formCompletionHelper.Click(Settings);
            return new FAA_SettingsPage(_context);
        }
        public void ClickSignOut()
        {
            _formCompletionHelper.Click(SignOutCss);
        }
        private void VerifyVacancySuccessfulNotification()
        {
            _PageIntercationHelper.VerifyText(NotificationText, "Your application for "+_dataHelper.VacancyTitle+" has been successful."); 
        }

        private void VerifyVacancyUnsuccessfulNotification()
        {
            _PageIntercationHelper.VerifyText(NotificationText, "Your application for "+_dataHelper.VacancyTitle+" has been unsuccessful.");
        }

        public void DismissSuccessfulNotification()
        {
            VerifyVacancySuccessfulNotification();
            _formCompletionHelper.Click(DismissNotification);
        }

        public  FAA_MyApplicationsHomePage DismissUnsuccessfulNotification()
        {
            VerifyVacancyUnsuccessfulNotification();
            _formCompletionHelper.Click(DismissNotification);
            return this;
        }

        public FAA_YourFeedbackPage ReadFeedback()
        {
            _formCompletionHelper.Click(ReadFeedbackLink);
            return new FAA_YourFeedbackPage(_context);
        }

        public void CheckDraftApplication()
        {
            _PageIntercationHelper.VerifyText(SavedSection, _dataHelper.VacancyTitle);
        }

        private void DeleteDraftApplication()
        {
            List<IWebElement> rows = _PageIntercationHelper.FindElements(SavedVacanciesTable);
            for(int i=0; i<rows.Count; i++)
            {
                if (rows[i].Text.Contains(_dataHelper.VacancyTitle))
                {
                    rows[i].FindElement(DeleteDraftButton).Click();
                    break;
                }
                else
                {
                    continue;
                } 
            }
        }

        public FAA_ApprenticeSummaryPage ConfirmVacancyDeletion()
        {
            DeleteDraftApplication();
            _PageIntercationHelper.VerifyText(DraftVacancyDeletionInfoText, "You've successfully removed the " + _dataHelper.VacancyTitle + " apprenticeship");
            _formCompletionHelper.Click(VacancyDeletedLink);
            return new FAA_ApprenticeSummaryPage(_context);
        }
    }
}
