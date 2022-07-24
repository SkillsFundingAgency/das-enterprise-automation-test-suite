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
    public class WhereCanYouDeliverTrainingPage : VerifyBasePage
    {
        protected override string PageTitle => "Where can you deliver this training?";

        private By DerbyChekcBox = By.XPath("//input[@value='1']");
        private By RutlandChekcBox = By.XPath("//input[@value='9']");
        private By LutonChekcBox = By.XPath("//input[@value='15']");
        private By EssexChekcBox = By.XPath("//input[@value='13']");
        public WhereCanYouDeliverTrainingPage(ScenarioContext context) : base(context) => VerifyPage();
        
        public ManageAStandard_TeacherPage SelectDerbyRutlandRegionsAndConfirm()
        {
                formCompletionHelper.SelectCheckbox(DerbyChekcBox);
                formCompletionHelper.SelectCheckbox(RutlandChekcBox);
                Continue();
                return new ManageAStandard_TeacherPage(context);
        }
        public ManageAStandard_TeacherPage EditRegionsAddLutonEssexAndConfirm()
        {
            formCompletionHelper.SelectCheckbox(LutonChekcBox);
            formCompletionHelper.SelectCheckbox(EssexChekcBox);
            Continue();
            return new ManageAStandard_TeacherPage(context);
        }
    }
}
