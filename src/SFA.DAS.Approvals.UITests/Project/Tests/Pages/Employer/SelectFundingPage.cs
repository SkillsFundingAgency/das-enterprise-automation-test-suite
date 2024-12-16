using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer
{
    public class SelectFundingPage(ScenarioContext context) : ApprovalsApprenticeBasePage(context)
    {
        protected override string PageTitle => "Select funding";
        protected override By PageHeader => By.ClassName("govuk-heading-l");
        protected override By ContinueButton => By.Id("submit-funding-type");

        public AddTrainingProviderDetailsPage SelectCurrentLevyFundsAsFundingType()
        {
            SelectRadioOptionByForAttribute("FundingType-4");
            Continue();
            return new AddTrainingProviderDetailsPage(context);
        }


    }
}
