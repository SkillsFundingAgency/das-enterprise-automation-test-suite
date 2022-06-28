using SFA.DAS.RAA_V2.Service.Project.Tests.Pages;
using SFA.DAS.FrameworkHelpers;
using TechTalk.SpecFlow;
using OpenQA.Selenium;
using SFA.DAS.TestDataExport;
using System.Linq;
using SFA.DAS.RAA_V2.Service.Project.Helpers;
using System.Collections.Generic;

namespace SFA.DAS.RAT_Provider.UITests.Project.Tests.Pages
{
    public class SelectEmployersPage : Raav2BasePage
    {
        protected override string PageTitle => "Which employer is this vacancy for?";

        private By RadioItem(string value) => By.CssSelector($".govuk-radios__item input{value}");

        public SelectEmployersPage(ScenarioContext context) : base(context) { }

        public (CreateAnApprenticeshipAdvertOrVacancyPage, bool) SelectEmployer(string empHashedid)
        {
            List<string> employers = GetEmployers(empHashedid);

            var validemployers = context.Get<ProviderCreateVacancySqlDbHelper>().GetValidHashedId(employers);

            var hashedid = RandomDataGenerator.GetRandomElementFromListOfElements(validemployers);

            (string hashedidvalue, int noOfLegalEntity) = ((string)hashedid[0], (int)hashedid[1]);

            formCompletionHelper.ClickElement(() => pageInteractionHelper.FindElement(RadioItem($"[value='{hashedidvalue}']")));

            if (noOfLegalEntity > 1) noOfLegalEntity = context.Get<RAAV2ProviderPermissionsSqlDbHelper>().GetNoOfValidOrganisations(hashedidvalue);

            objectContext.SetDebugInformation($"Selected employer with hashed id '{hashedidvalue}' who has {noOfLegalEntity} legal entities with provider permission");

            Continue();

            return (new CreateAnApprenticeshipAdvertOrVacancyPage(context), noOfLegalEntity > 1);
        }

        private List<string> GetEmployers(string empHashedid)
        {
            return string.IsNullOrEmpty(empHashedid) ?

                pageInteractionHelper.FindElements(RadioItem(string.Empty)).ToList().Select(x => x.GetAttribute("value")).ToList() :

                new List<string>() { (empHashedid) };
        }
    }
}
