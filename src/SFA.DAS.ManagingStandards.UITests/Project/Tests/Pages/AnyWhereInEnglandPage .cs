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
    public class AnyWhereInEnglandPage : VerifyBasePage
    {
        protected override string PageTitle => "Can you deliver this training anywhere in England?";

        private By YesRadio = By.Id("Yes");
        private By NoRadio = By.Id("No");
        public AnyWhereInEnglandPage(ScenarioContext context) : base(context) => VerifyPage();
        
        public ManageAStandard_TeacherPage YesDeliverAnyWhereInEngland()
        {
                formCompletionHelper.SelectRadioOptionByLocator(YesRadio);
                Continue();
                return new ManageAStandard_TeacherPage(context);
        }

        public WhereCanYouDeliverTrainingPage NoDeliverAnyWhereInEngland()
        {
            formCompletionHelper.SelectRadioOptionByLocator(NoRadio);
            Continue();
            return new WhereCanYouDeliverTrainingPage(context);
        }
    }
}
