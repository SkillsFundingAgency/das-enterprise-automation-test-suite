using OpenQA.Selenium;
using SFA.DAS.UI.Framework;
using System;
using System.Linq;
using TechTalk.SpecFlow;

namespace SFA.DAS.ConsolidatedSupport.UITests.Project.Tests.Pages
{
    public abstract class UserOrgPage : ConsolidatedSupportBasePage
    {
        private readonly ScenarioContext _context;

        private By OptionsButton => By.CssSelector(".ember-view .object_options > .object_options_btn");

        private By ModelButtons => By.CssSelector(".modal-footer .btn");

        public UserOrgPage(ScenarioContext context) : base(context)
        {
            _context = context;
        }

        public HomePage DeleteUser()
        {
            NavigateToUser();

            return DeleteEntity();
        }

        public HomePage DeleteOrg() => DeleteEntity();

        protected HomePage InvokeAction(Action action, bool IsOrganisation = false)
        {
            if (IsOrganisation) { NavigateToOrganisation(); }
            else { NavigateToUser(); }
            action.Invoke();
            return CloseAllTickets();
        }

        protected void NavigateToUser() => tabHelper.GoToUrl(UrlConfig.ConsolidatedSupport_BaseUrl, $"agent/#/users/{objectContext.GetUserId()}/tickets");

        protected void NavigateToOrganisation() => tabHelper.GoToUrl(UrlConfig.ConsolidatedSupport_BaseUrl, $"agent/#/users/{objectContext.GetUserId()}/organization/tickets");

        private new HomePage CloseAllTickets()
        {
            base.CloseAllTickets();
            return new HomePage(_context, true);
        }

        private HomePage DeleteEntity()
        {
            var element = pageInteractionHelper.FindElements(OptionsButton).First(x => x.Displayed && x.Enabled);

            formCompletionHelper.ClickElement(element);

            formCompletionHelper.ClickLinkByText("Delete");

            formCompletionHelper.ClickElement(() => pageInteractionHelper.FindElements(ModelButtons).Single(x => x.Text == "OK"));

            return CloseAllTickets();
        }
    }
}
