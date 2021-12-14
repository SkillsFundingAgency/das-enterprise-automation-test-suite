using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace SFA.DAS.ConsolidatedSupport.UITests.Project.Tests.Pages
{
    public class AdminPage : ConsolidatedSupportBasePage
    {
        protected override By PageHeader => By.CssSelector(".admin .pane.left.section");

        protected override string PageTitle => "ADMIN HOME";

        private By SearchHeader => By.CssSelector("h2");

        private By PeopleLink => By.CssSelector("a[href='/agent/admin/people']");

        private By SearchOrganisationsLink => By.CssSelector("a[href='/organizations']");

        private By NewOrgLink => By.CssSelector("[id='search-result'] .item-info a[href*='organizations']");

        private By SearchInput => By.CssSelector("input[id='query']");

        private By SearchButton => By.CssSelector("input[id='buttonsubmit']");

        public AdminPage(ScenarioContext context) : base(context) => MultipleVerifyPage(new List<Func<bool>> { () => VerifyPage(), () => VerifyPage(PeopleLink) });

        public UserPage NavigateToUserPage()
        {
            formCompletionHelper.ClickElement(() => pageInteractionHelper.FindElement(PeopleLink));
            return new UserPage(context);
        }

        public int NoOfOrganisation()
        {
            formCompletionHelper.ClickElement(() => pageInteractionHelper.FindElement(PeopleLink));

            int count = 0; 
            
            frameHelper.SwitchFrameAndAction(() => 
            {
                InvokeAction(() => VerifyPage(SearchOrganisationsLink));

                InvokeAction(() => formCompletionHelper.ClickElement(() => pageInteractionHelper.FindElement(SearchOrganisationsLink)));
                VerifySearchHeaders();

                InvokeAction(() => formCompletionHelper.EnterText(SearchInput, dataHelper.NewOrgName));
                InvokeAction(() => formCompletionHelper.ClickElement(() => pageInteractionHelper.FindElement(SearchButton)));


                VerifySearchHeaders();
                count = InvokeAction(() => pageInteractionHelper.GetLinks(NewOrgLink, dataHelper.NewOrgName).Count);
            });

            return count;
        }

        public OrgPage NavigateToOrgPage()
        {
            frameHelper.SwitchFrameAndAction(() =>
            {
                InvokeAction(() => formCompletionHelper.ClickLinkByText(NewOrgLink, dataHelper.NewOrgName));
            });

            return new OrgPage(context);
        }

        private void VerifySearchHeaders()
        {
            InvokeAction(() => VerifyPage(() => pageInteractionHelper.FindElements(SearchHeader), "People"));
            InvokeAction(() => VerifyPage(() => pageInteractionHelper.FindElements(SearchHeader), "Organisations"));
        }
    }
}
