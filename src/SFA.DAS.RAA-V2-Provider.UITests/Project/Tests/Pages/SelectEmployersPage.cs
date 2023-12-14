using OpenQA.Selenium;
using SFA.DAS.FrameworkHelpers;
using SFA.DAS.RAA_V2.Service.Project.Helpers;
using SFA.DAS.RAA_V2.Service.Project.Tests.Pages;
using System.Collections.Generic;
using System.Linq;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V2_Provider.UITests.Project.Tests.Pages
{
    public class SelectEmployersPage(ScenarioContext context) : Raav2BasePage(context)
    {

        private List<(string hashedid, string value)> values = [];

        protected override string PageTitle => "Which employer do you want to create a vacancy for?";

        private static By SelectItemList => By.CssSelector(".govuk-table .das-button--inline-link");

        private static By ListItem(string value) => By.CssSelector($".govuk-table .das-button--inline-link[value='{value}']");

        private static By SelectedEmployerYes => By.Id("confirm-yes");

        public (CreateAnApprenticeshipAdvertOrVacancyPage, bool) SelectEmployer(string empHashedid)
        {
            List<string> employers = GetEmployers(empHashedid);

            var validemployers = context.Get<ProviderCreateVacancySqlDbHelper>().GetValidHashedId(employers);

            var hashedid = GetRandomElementFromListOfElements(validemployers);

            (string hashedidvalue, int noOfLegalEntity) = ((string)hashedid[0], (int)hashedid[1]);

            objectContext.SetDebugInformation($"Employer with hashed id '{hashedidvalue}' has {noOfLegalEntity} legal entities");

            var legalEntity = values.Where(x => x.hashedid == hashedidvalue).ToList();

            objectContext.SetDebugInformation($"Employer with hashed id '{hashedidvalue}' has {legalEntity.Count} legal entities with provider permission");

            var value = GetRandomElementFromListOfElements(legalEntity).value;

            formCompletionHelper.ClickElement(() => pageInteractionHelper.FindElement(ListItem(value)));

            if (noOfLegalEntity > 1) noOfLegalEntity = legalEntity.Count;

            objectContext.SetDebugInformation($"Selected employer with hashed id '{value}' who has {noOfLegalEntity} legal entities with provider permission");

            formCompletionHelper.SelectRadioOptionByLocator(SelectedEmployerYes);

            SaveAndContinue();

            return (new CreateAnApprenticeshipAdvertOrVacancyPage(context), noOfLegalEntity > 1);
        }

        private static T GetRandomElementFromListOfElements<T>(List<T> elements) => RandomDataGenerator.GetRandomElementFromListOfElements(elements);

        private List<string> GetEmployers(string empHashedid)
        {
            values = GetEmpDetails();

            if (string.IsNullOrEmpty(empHashedid)) return values.Select(x => x.hashedid).ToList();

            return [(empHashedid)];
        }

        private List<(string hashedid, string value)> GetEmpDetails()
        {
            var value = pageInteractionHelper.FindElements(SelectItemList).Select(x => x.GetAttribute("value")).ToList();

            return value.Select(x => (x?.Split('|')[1], x)).ToList();
        }
    }
}
