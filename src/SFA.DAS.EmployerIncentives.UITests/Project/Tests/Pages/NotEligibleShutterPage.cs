using System;
using System.Collections.Generic;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.EmployerIncentives.UITests.Project.Tests.Pages
{
    public class NotEligibleShutterPage : EIBasePage
    {
        protected override string PageTitle => $"Not eligible for the payment";

        #region Locators
        private readonly ScenarioContext _context;

        private By IneligibleApprenticesList => By.Name("ineligible-apprenticeship");
        private By EmploymentStartDateFields => By.Name("ineligible-apprenticeship-start-date");
        private By CancelApplicationButton => By.Id("cancelApplication");
        private By ContinueApplicationButton => By.Id("continueApplication");
        #endregion

        public NotEligibleShutterPage(ScenarioContext context, bool verifypage = true) : base(context, verifypage)
        {
            _context = context;
        }

        public int NumberOfIneligibleApprenticeships => pageInteractionHelper.FindElements(IneligibleApprenticesList).Count;
        public bool CancelApplicationButtonExists => pageInteractionHelper.ElementExists(CancelApplicationButton);
        public bool ContinueApplicationButtonExists => pageInteractionHelper.ElementExists(ContinueApplicationButton);

        public List<DateTime> EmploymentStartDates
        {
            get
            {
                var startDates = new List<DateTime>();
                var startDateElements = pageInteractionHelper.FindElements(EmploymentStartDateFields);
                foreach (var startDateElement in startDateElements)
                {
                    startDates.Add(DateTime.Parse(startDateElement.Text));
                }

                return startDates;
            }
        }
    }
}
