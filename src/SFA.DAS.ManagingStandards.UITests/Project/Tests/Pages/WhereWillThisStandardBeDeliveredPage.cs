using OpenQA.Selenium;
using SFA.DAS.UI.Framework.TestSupport;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace SFA.DAS.ManagingStandards.UITests.Project.Tests.Pages
{
    public class WhereWillThisStandardBeDeliveredPage : VerifyBasePage
    {
        protected override string PageTitle => "Where will this standard be delivered";

        private By AtOneOfYourTrainingLocationsButton => By.Id("ProviderLocationOption");
        private By AtAnEmployersLocationButton => By.Id("EmployerLocationOption");
        private By BothButton => By.Id("BothLocationOption");
        private By SaveAndContinueButton => By.Id("submit");
        private By CancelLink = By.LinkText("/10001259/standards/240");

        public WhereWillThisStandardBeDeliveredPage(ScenarioContext context) : base(context) => VerifyPage();

        public WhereWillThisStandardBeDeliveredPage ClickSaveAndContinueButton()
        {
            formCompletionHelper.Click(SaveAndContinueButton);
            return new WhereWillThisStandardBeDeliveredPage(context);
        }
        public void ClickCancel()
        {
            formCompletionHelper.Click(CancelLink);
        }
    }
}
