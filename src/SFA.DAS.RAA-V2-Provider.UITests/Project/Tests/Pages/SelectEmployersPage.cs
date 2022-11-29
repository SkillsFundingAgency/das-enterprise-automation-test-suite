using SFA.DAS.RAA_V2.Service.Project.Tests.Pages;
using SFA.DAS.FrameworkHelpers;
using TechTalk.SpecFlow;
using OpenQA.Selenium;
using SFA.DAS.TestDataExport;
using System.Linq;
using SFA.DAS.RAA_V2.Service.Project.Helpers;
using System.Collections.Generic;

namespace SFA.DAS.RAA_V2_Provider.UITests.Project.Tests.Pages
{
    public class SelectEmployersPage : Raav2BasePage
    {
        protected override string PageTitle => "Which employer do you want to create a vacancy for?";
        private By SelectItemList => By.CssSelector(".govuk-table .das-button--inline-link");

        private By ListItem(string value) => By.CssSelector($"#select-{value}");

        public SelectEmployersPage(ScenarioContext context) : base(context) { }

        public (CreateAnApprenticeshipAdvertOrVacancyPage, bool) SelectEmployer(string empHashedid)
        {
            List<string> employers = GetEmployers(empHashedid);

            var validemployers = context.Get<ProviderCreateVacancySqlDbHelper>().GetValidHashedId(employers);

            var publichashedid = RandomDataGenerator.GetRandomElementFromListOfElements(validemployers);

            (string hashedidvalue, int noOfLegalEntity) = ((string)publichashedid[0], (int)publichashedid[1]);

            formCompletionHelper.ClickElement(() => pageInteractionHelper.FindElement(ListItem($"[value='{hashedidvalue}']")));

            if (noOfLegalEntity > 1) noOfLegalEntity = context.Get<RAAV2ProviderPermissionsSqlDbHelper>().GetNoOfValidOrganisations(hashedidvalue);

            objectContext.SetDebugInformation($"Selected employer with hashed id '{hashedidvalue}' who has {noOfLegalEntity} legal entities with provider permission");

            Continue();

            return (new CreateAnApprenticeshipAdvertOrVacancyPage(context), noOfLegalEntity > 1);
        }

        private List<string> GetEmployers(string empHashedid)
        {
            if (string.IsNullOrEmpty(empHashedid))
            {
                var items = pageInteractionHelper.FindElements(SelectItemList).ToList();
                return items.Select(x => x.GetAttribute("value")?.Split('|')[1]).ToList();
            }


            return new List<string>() { (empHashedid) };
        }
    }
}
