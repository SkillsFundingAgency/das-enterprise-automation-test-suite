using System;
using OpenQA.Selenium;
using SFA.DAS.UI.Framework.TestSupport;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace SFA.DAS.ApprenticeAmbassadorNetwork.UITests.Project.Tests.Pages
{
    public class SearchEmployerNamePage : AanBasePage
    {
        protected override string PageTitle => "Search for your employer's name or address";
        private static By FirstAddress => By.Id("SearchTerm__option--0");

        private static By PostCodeField = By.Id("SearchTerm");
        public SearchEmployerNamePage(ScenarioContext context) : base(context) { }

        public EmployerDetailsPage EnterPostcodeAndContinue()
        {
            formCompletionHelper.EnterText(PostCodeField, aanDataHelpers.PostCode);
            formCompletionHelper.Click(FirstAddress);
            Continue();
            return new EmployerDetailsPage(context);
        }
    }
}

        

