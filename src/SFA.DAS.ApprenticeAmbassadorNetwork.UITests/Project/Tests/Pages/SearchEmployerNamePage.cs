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
    public class SearchEmployerNamePage : RequireLineManagerApprovalPage
    {
        protected override string PageTitle => "Search for your employer's name or address";

        private static By PostCodeField = By.Id("SearchTerm");
        public SearchEmployerPage(ScenarioContext context) : base(context) { }

        public EmployerDetailsPage EnterPostcodeAndContinue()
        {
            formCompletionHelper.EnterText(PostCodeField, AANDataHelpers.PostCode);
            Continue();
            return new EmployerDetailsPage(context);
        }
    }
}

        

