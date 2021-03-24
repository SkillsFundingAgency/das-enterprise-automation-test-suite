using OpenQA.Selenium;
using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.RAA.DataGenerator;
using SFA.DAS.RAA.DataGenerator.Project;
using SFA.DAS.RAA_V2.Service.Project.Tests.Pages;
using SFA.DAS.UI.FrameworkHelpers;
using System;
using System.Linq;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V2.Service.Project.Helpers
{
    public class SearchVacancyProviderPageHelper
    {
        #region Helpers and Context
        private readonly ScenarioContext _context;
        private readonly ObjectContext _objectContext;
        private readonly RAAV2DataHelper _dataHelper;
        private readonly PageInteractionHelper _pageInteractionHelper;
        private readonly FormCompletionHelper _formCompletionHelper;
        #endregion
        private By SearchInput => By.CssSelector("#search-input");

        private By SearchButton => By.CssSelector("#search-submit-button");

        private By ActionLink => By.CssSelector("table tbody tr .govuk-link");

        public SearchVacancyProviderPageHelper(ScenarioContext context)
        {
            _context = context;
            _objectContext = context.Get<ObjectContext>();
            _pageInteractionHelper = context.Get<PageInteractionHelper>();
            _formCompletionHelper = context.Get<FormCompletionHelper>();
            _dataHelper = context.Get<RAAV2DataHelper>();
        }

        public string ClickEditAndSubmit(string vacancyStatus, bool previewReady = true)
        {
            ClickActionLink(vacancyStatus);

            // get all the edit and submit links which are for a vacancies which are in the requested preview state
            // using Employer Name which is Not selected as a proxy for those vacancies for which the wizard has 
            // not yet been completed
            By EmployerName = By.XPath(".//ancestor::tr/td[2]");
            var actionLinks = _pageInteractionHelper
                .FindElements(ActionLink)
                .Where(p => (p.FindElement(EmployerName).Text == "Not selected" ? false : true) == previewReady);

            var editAndSubmitLink = _dataHelper.GetRandomElementFromListOfElements(actionLinks.ToList());
            var vacancyTitle = editAndSubmitLink.FindElement(By.XPath(".//ancestor::tr/td[1]/div")).Text;

            _formCompletionHelper.ClickElement(editAndSubmitLink);

            return vacancyTitle;
        }

        public string ClickManageVacancy(string vacancyStatus, int minimumApplications = 0)
        {
            ClickActionLink(vacancyStatus);

            // get all the manage links for a vacancies with at least the minimum number of applications
            By Applications = By.XPath(".//ancestor::tr/td[3]");
            var actionLinksWithApplications = _pageInteractionHelper.FindElements(ActionLink)
                .Where(p => minimumApplications == 0 
                    || int.Parse(string.Concat(p.FindElement(Applications).Text.TakeWhile(char.IsDigit))) >= minimumApplications);

            if (actionLinksWithApplications.Count() == 0)
            {
                throw new Exception($"There are no vacancaies with at least {minimumApplications} application(s).");
            }

            var manageLink = _dataHelper.GetRandomElementFromListOfElements(actionLinksWithApplications.ToList());
            var vacancyTitle = manageLink.FindElement(By.XPath(".//ancestor::tr/td[1]/div")).Text;

            _formCompletionHelper.ClickElement(manageLink);

            return vacancyTitle;
        }

        private void ClickActionLink(string vacancyStatus)
        {
            IWebElement link;
            string filter;

            switch (vacancyStatus)
            {
                case "Draft":
                    link = _pageInteractionHelper.FindElement(By.PartialLinkText($"Draft"));
                    filter = "Draft";
                    break;

                case "PendingReview":
                    link = _pageInteractionHelper.FindElement(By.LinkText($"Pending review"));
                    filter = "Submitted";
                    break;

                case "Rejected":
                    link = _pageInteractionHelper.FindElement(By.PartialLinkText($"Rejected"));
                    filter = "Referred";
                    break;

                case "Live":
                    link = _pageInteractionHelper.FindElement(By.PartialLinkText($"Live"));
                    filter = "Live";
                    break;

                case "Closed":
                    link = _pageInteractionHelper.FindElement(By.PartialLinkText($"Closed"));
                    filter = "Closed";
                    break;

                default:
                    throw new ArgumentOutOfRangeException("vacancyStatus");
            }

            _formCompletionHelper.ClickElement(link);
            _pageInteractionHelper.WaitforURLToChange($"filter={filter}");
        }

        public ManageRecruitPage SearchVacancyByVacancyReference()
        {
            SearchVacancy();
            return new ManageRecruitPage(_context);
        }

        public ReferVacancyPage SearchReferVacancy()
        {
            SearchVacancy();
            return new ReferVacancyPage(_context);
        }

        private void SearchVacancy()
        {
            var vacRef = _objectContext.GetVacancyReference();
            _formCompletionHelper.EnterText(SearchInput, vacRef); 
            _formCompletionHelper.Click(SearchButton);
            _pageInteractionHelper.WaitforURLToChange($"searchTerm={vacRef}");
            _formCompletionHelper.ClickElement(_pageInteractionHelper.FindElement(ActionLink));
        }
    }
}
