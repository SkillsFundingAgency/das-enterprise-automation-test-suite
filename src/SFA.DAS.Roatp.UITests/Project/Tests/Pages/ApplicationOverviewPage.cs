using OpenQA.Selenium;
using SFA.DAS.UI.FrameworkHelpers;
using System;
using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages
{
    public class ApplicationOverviewPage : RoatpBasePage
    {
        protected override string PageTitle => "Application overview";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        #region Questions
        private string Yourorganisation => "Your organisation";
        private string YourOrganisation_1 => "Introduction and what you'll need";
        private string YourOrganisation_2 => "Organisation information";
        private string YourOrganisation_3 => "Tell us who's in control";
        private string YourOrganisation_4 => "Describe your organisation";
        private string YourOrganisation_5 => "Experience and accreditation";

        private string FinancialEvidence_1 => "Introduction and what you'll need";
        private string FinancialEvidence_2 => "Your organisation's financial evidence";
        private string FinancialEvidence_3 => "Your UK ultimate parent company's financial evidence";
        #endregion

        private By TaskLists => By.CssSelector(".app-task-list > li");

        private By TaskSection => By.CssSelector(".app-task-list__section");

        private By TaskItems => By.CssSelector(".app-task-list__items");

        private By TaskItem => By.CssSelector(".app-task-list__item");

        private By TaskName => By.CssSelector(".app-task-list__task_name");

        private By TaskStatus => By.CssSelector(".govuk-tag");

        public ApplicationOverviewPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        #region Seciton1
        public ApplicationOverviewPage VerifyIntroductionStatus(string status)
        {
            VerifyElement(GetTaskStatusElement(Yourorganisation, YourOrganisation_1), status);
            return this;
        }

        public ApplicationOverviewPage VerifyOrganisationInformation(string status)
        {
            VerifyElement(GetTaskStatusElement(Yourorganisation, YourOrganisation_2), status);
            return this;
        }

        public ApplicationOverviewPage VerifyTellUsWhosInControlStatus(string status)
        {
            VerifyElement(GetTaskStatusElement(Yourorganisation, YourOrganisation_3), status);
            return this;
        }

        public ApplicationOverviewPage VerifyDescribeYourOrganisationStatus(string status)
        {
            VerifyElement(GetTaskStatusElement(Yourorganisation, YourOrganisation_4), status);
            return this;
        }

        public ApplicationOverviewPage VerifyExperienceAndAccreditationsStatus(string status)
        {
            VerifyElement(GetTaskStatusElement(Yourorganisation, YourOrganisation_5), status);
            return this;
        }

        public YourOrganisationPage AccessIntroductionWhatYouWillNeedSection()
        {
            formCompletionHelper.ClickElement(GetTaskLinkElement(Yourorganisation, YourOrganisation_1));
            return new YourOrganisationPage(_context);
        }

        public UltimateParentCompanyPage AccessYourOrganisationSectionForOrgTypeCompany()
        {
            formCompletionHelper.ClickElement(GetTaskLinkElement(Yourorganisation, YourOrganisation_2));
            return new UltimateParentCompanyPage(_context);
        }
        public ConfrimWhosInControlPage AccessTellUSWhosInControlSection()
        {
            formCompletionHelper.ClickElement(GetTaskLinkElement(Yourorganisation, YourOrganisation_3));
            return new ConfrimWhosInControlPage(_context);
        }
        public WhatIsYourOrganisationPage AccessDescribeYourOrganisationsForOrgTypeCharity()
        {
            formCompletionHelper.ClickElement(GetTaskLinkElement(Yourorganisation, YourOrganisation_4));
            return new WhatIsYourOrganisationPage(_context);
        }
        public FundedByTheOfficeForStudentsPage AccessExperienceAndAccreditationsSection()
        {
            formCompletionHelper.ClickElement(GetTaskLinkElement(Yourorganisation, YourOrganisation_5));
            return new FundedByTheOfficeForStudentsPage(_context);
        }

        #endregion

        private Func<IWebElement> GetTaskLinkElement(string sectionName, string taskName) => GetTaskElement(sectionName, taskName, TaskName);

        private Func<IWebElement> GetTaskStatusElement(string sectionName, string taskName) => GetTaskElement(sectionName, taskName, TaskStatus);

        private Func<IWebElement> GetTaskElement(string sectionName, string taskName, By childelement)
        {
            return () =>
            {
                var taskLists = pageInteractionHelper.FindElements(TaskLists);
                foreach(var tasklist in taskLists)
                {
                    if (tasklist.FindElement(TaskSection).Text.ContainsCompareCaseInsensitive(sectionName))
                    {
                        var tasks = tasklist.FindElements(TaskItem);
                        foreach (var task in tasks)
                        {
                            if (task.Text.ContainsCompareCaseInsensitive(taskName))
                            {
                                return task.FindElement(childelement);
                            }
                        }
                    }
                }
                throw new NotFoundException($"can not find task element inside '{sectionName}' with text '{taskName}'");
            };
        }
    }
}
