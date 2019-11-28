using OpenQA.Selenium;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V1.UITests.Project.Tests.Pages.Manage
{
    public class Manage_AdminFunctionsPage : BasePage
    {
        protected override string PageTitle => "Administrator functions";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        protected readonly FormCompletionHelper formCompletionHelper;
        #endregion

        private By ManageProvidersLink => By.LinkText("Manage Providers");
        private By ManageProviderSitesLink => By.LinkText("Manage Provider Sites");
        private By ManageApiUsersLink => By.LinkText("Manage API Users");
        private By ManageEmployersLink => By.LinkText("Manage Employers");
        private By SectorsLink => By.LinkText("Sectors");
        private By StandardsLink => By.LinkText("Standards");
        private By FrameworksLink => By.LinkText("Frameworks");

        public Manage_AdminFunctionsPage(ScenarioContext context) : base(context)
        {
            _context = context;
            formCompletionHelper = context.Get<FormCompletionHelper>();
            VerifyPage();
        }

        public Manage_AdminManageProvidersPage ClickManageProvidersLink()
        {
            formCompletionHelper.Click(ManageProvidersLink);
            return new Manage_AdminManageProvidersPage(_context);
        }

        public Manage_AdminManageProviderSitesPage ClickManageProviderSitesLink()
        {
            formCompletionHelper.Click(ManageProviderSitesLink);
            return new Manage_AdminManageProviderSitesPage(_context);
        }

        public Manage_AdminManageApiUsersPage ClickManageApiUsersLink()
        {
            formCompletionHelper.Click(ManageApiUsersLink);
            return new Manage_AdminManageApiUsersPage(_context);
        }

        public Manage_AdminManageEmployersPage ClickManageEmployersLink()
        {
            formCompletionHelper.Click(ManageEmployersLink);
            return new Manage_AdminManageEmployersPage(_context);
        }

        public Manage_AdminSectorsPage ClickSectorsLink()
        {
            formCompletionHelper.Click(SectorsLink);
            return new Manage_AdminSectorsPage(_context);
        }

        public Manage_AdminStandardsPage ClickStandardsLink()
        {
            formCompletionHelper.Click(StandardsLink);
            return new Manage_AdminStandardsPage(_context);
        }

        public Manage_AdminFrameworksPage ClickFrameworksLink()
        {
            formCompletionHelper.Click(FrameworksLink);
            return new Manage_AdminFrameworksPage(_context);
        }

        public class Manage_AdminManageProvidersPage : Manage_AdminFunctionsPage
        {
            protected override string PageTitle => "Providers";

            public Manage_AdminManageProvidersPage(ScenarioContext context) : base(context) { }
        }

        public class Manage_AdminManageProviderSitesPage : Manage_AdminFunctionsPage
        {
            protected override string PageTitle => "Provider Sites";

            public Manage_AdminManageProviderSitesPage(ScenarioContext context) : base(context) { }
        }

        public class Manage_AdminManageApiUsersPage : Manage_AdminFunctionsPage
        {
            protected override string PageTitle => "API Users";

            public Manage_AdminManageApiUsersPage(ScenarioContext context) : base(context) { }
        }

        public class Manage_AdminManageEmployersPage : Manage_AdminFunctionsPage
        {
            protected override string PageTitle => "Employers";

            public Manage_AdminManageEmployersPage(ScenarioContext context) : base(context) { }
        }

        public class Manage_AdminSectorsPage : Manage_AdminFunctionsPage
        {
            protected override string PageTitle => "Sectors";

            public Manage_AdminSectorsPage(ScenarioContext context) : base(context) { }
        }

        public class Manage_AdminStandardsPage : Manage_AdminFunctionsPage
        {
            protected override string PageTitle => "Standards";

            public Manage_AdminStandardsPage(ScenarioContext context) : base(context) { }
        }

        public class Manage_AdminFrameworksPage : Manage_AdminFunctionsPage
        {
            protected override string PageTitle => "Frameworks";

            public Manage_AdminFrameworksPage(ScenarioContext context) : base(context) { }
        }
    }
}