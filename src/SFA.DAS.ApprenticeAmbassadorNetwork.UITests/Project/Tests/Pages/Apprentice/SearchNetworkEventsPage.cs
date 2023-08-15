using System;

namespace SFA.DAS.ApprenticeAmbassadorNetwork.UITests.Project.Tests.Pages.Apprentice
{
    public class SearchNetworkEventsPage : AanBasePage
    {
        protected override string PageTitle => "Search network events";

        private static By FromDateField => By.Id("fromDate");
        private static By ToDateField => By.Id("toDate");
        private static By ApplyFilterButton => By.Id("filters-submit");
        private static By FirstEventLink => By.CssSelector("li.das-search-results__list-item a");
        private static By InpersonCheckBox => By.XPath("//input[contains(@value,'InPerson')]");
        private static By OnlineCheckBox => By.XPath("//input[contains(@value,'Online')]");
        private static By HybridCheckBox => By.XPath("//input[contains(@value,'Hybrid')]");
        private static By InpersonSelectedFilter => By.XPath("//a[contains(@title,'In person')]");
        private static By TrainingEventSelectedFilter => By.XPath("//a[contains(@title,'Training event')]");
        private static By HybridSelectedFilter => By.XPath("//a[contains(@title,'Hybrid')]");
        private static By OnlineSelectedFilter => By.XPath("//a[contains(@title,'Online')]");
        private static By TrainingEventCheckbox => By.XPath("//input[contains(@value,'6')]");

        private static string DateFormat => Configurator.IsVstsExecution ? "MM-dd-yyyy" : "dd-MM-yyyy";

        public SearchNetworkEventsPage(ScenarioContext context) : base(context) => VerifyPage();

        public SearchNetworkEventsPage FilterEventByTomorrow()
        {
            DateTime tomorrow = DateTime.Now.AddDays(1);
            string formattedDate = tomorrow.ToString(DateFormat);
            formCompletionHelper.EnterText(FromDateField, formattedDate);
            formCompletionHelper.ClickElement(ApplyFilterButton);
            return this;
        }

        public SearchNetworkEventsPage FilterEventByOneMonth()
        {
            string formattedDate = DateTime.Now.AddDays(1).ToString(DateFormat);

            string formattedEndDate = DateTime.Now.AddDays(30).ToString(DateFormat);

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