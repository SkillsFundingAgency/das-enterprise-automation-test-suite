using System;

namespace SFA.DAS.ApprenticeAmbassadorNetwork.UITests.Project.Tests.Pages
{
    public class SearchNetworkEventsPage : SignInPage
    {
        protected override string PageTitle => "Search network events";

        private By FromDateField = By.Id("fromDate");
        private By ToDateField = By.Id("toDate");
        private By ApplyFilterButton = By.Id("filters-submit");
        private By FirstEventLink = By.CssSelector("li.das-search-results__list-item a");
        private By InpersonCheckBox = By.XPath("//input[contains(@value,'InPerson')]");
        private By OnlineCheckBox = By.XPath("//input[contains(@value,'Online')]");
        private By HybridCheckBox = By.XPath("//input[contains(@value,'Hybrid')]");
        private By InpersonSelectedFilter = By.XPath("//a[contains(@title,'In person')]");
        private By TrainingEventSelectedFilter = By.XPath("//a[contains(@title,'Training event')]");
        private By HybridSelectedFilter = By.XPath("//a[contains(@title,'Hybrid')]");
        private By OnlineSelectedFilter = By.XPath("//a[contains(@title,'Online')]");
        private By TrainingEventCheckbox = By.XPath("//input[contains(@value,'6')]");

        public SearchNetworkEventsPage(ScenarioContext context) : base(context) => VerifyPage();

        public SearchNetworkEventsPage FilterEventByTomorrow()
        {
            DateTime tomorrow = DateTime.Now.AddDays(1);
            string formattedDate = tomorrow.ToString("dd-MM-yyyy");
            formCompletionHelper.EnterText(FromDateField,formattedDate);
            formCompletionHelper.ClickElement(ApplyFilterButton);
            return this;
        }

        public SearchNetworkEventsPage FilterEventByOneMonth()
        {
            DateTime startDate = DateTime.Now.AddDays(1);
            string formattedDate = startDate.ToString("dd-MM-yyyy");

            DateTime endDate = DateTime.Now.AddDays(30);
            string formattedEndDate = endDate.ToString("dd-MM-yyyy");

            formCompletionHelper.EnterText(FromDateField, formattedDate);
            formCompletionHelper.EnterText(ToDateField, formattedEndDate);

            formCompletionHelper.ClickElement(ApplyFilterButton);

            return this;
        }

        public EventPage ClickOnFirstEventLink()
        {
            formCompletionHelper.ClickElement(FirstEventLink);
            return new EventPage(context);
        }

        public string GetTextOfFirstEventLink()
        {
            return pageInteractionHelper.GetText(FirstEventLink);
        }

        public SearchNetworkEventsPage FilterEventByEventType_InPerson()
        {
            formCompletionHelper.SelectCheckbox(InpersonCheckBox);  
            formCompletionHelper.ClickElement(ApplyFilterButton);
            return this;
        }
        public SearchNetworkEventsPage FilterEventByEventType_TrainingEvent()
        {
            formCompletionHelper.SelectCheckbox(TrainingEventCheckbox);
            formCompletionHelper.ClickElement(ApplyFilterButton);
            return this;
        }

        public SearchNetworkEventsPage FilterEventByEventType_Online()
        {
            formCompletionHelper.SelectCheckbox(OnlineCheckBox);
            formCompletionHelper.ClickElement(ApplyFilterButton);
            return this;
        }

        public SearchNetworkEventsPage FilterEventByEventType_Hybrid()
        {
            formCompletionHelper.SelectCheckbox(HybridCheckBox);
            formCompletionHelper.ClickElement(ApplyFilterButton);
            return this;
        }

        public SearchNetworkEventsPage ClearAllFilters()
        {
            formCompletionHelper.ClickLinkByText("Clear");
            return this;
        }

        public SearchNetworkEventsPage VerifyEventType_Inperson_Filter()
        {
            pageInteractionHelper.IsElementDisplayed(InpersonSelectedFilter);
            return this;
        }
        public SearchNetworkEventsPage VerifyEventType_TrainingEvent_Filter()
        {
            pageInteractionHelper.IsElementDisplayed(TrainingEventSelectedFilter);
            return this;
        }
        public SearchNetworkEventsPage VerifyEventType_Online_Filter()
        {
            pageInteractionHelper.IsElementDisplayed(OnlineSelectedFilter);
            return this;
        }
        public SearchNetworkEventsPage VerifyEventType_Hybrid_Filter()
        {
            pageInteractionHelper.IsElementDisplayed(HybridSelectedFilter);
            return this;
        }

    }
}