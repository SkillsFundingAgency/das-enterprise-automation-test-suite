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

        private By AtOneOfYourTrainingLocationsRadio => By.Id("ProviderLocationOption");
        private By AtAnEmployersLocationRadio => By.Id("EmployerLocationOption");
        private By BothRadio => By.Id("BothLocationOption");

        public WhereWillThisStandardBeDeliveredPage(ScenarioContext context) : base(context) => VerifyPage();

        public TrainingLocation_ConfirmVenuePage ConfirmAtOneofYourTrainingLocations()
        {
            formCompletionHelper.SelectRadioOptionByLocator(AtOneOfYourTrainingLocationsRadio);
            Continue();
            return new TrainingLocation_ConfirmVenuePage(context);
        }

        public AnyWhereInEnglandPage ConfirmAtAnEmployersLocation()
        {
            formCompletionHelper.SelectRadioOptionByLocator(AtAnEmployersLocationRadio);
            Continue();
            return new AnyWhereInEnglandPage(context);
        }

        public TrainingLocation_ConfirmVenuePage ConfirmStandardWillDeliveredInBoth()
        {
            formCompletionHelper.SelectRadioOptionByLocator(BothRadio);
            Continue();
            return new TrainingLocation_ConfirmVenuePage(context);
        }
    }
}
