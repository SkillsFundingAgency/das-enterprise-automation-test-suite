using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace SFA.DAS.EarlyConnectForms.UITests.Project.Tests.Pages
{
    public class SchoolCollegePage(ScenarioContext context) : EarlyConnectBasePage(context)
    {
        protected override string PageTitle => "What is the name of your school or college?";
        private static By SchoolCollegeField => By.CssSelector("#schoolname");
        protected override By ContinueButton => By.CssSelector("button[type='submit']");
        public SchoolCollegePage EnterValidSchoolOrCollegeName()
        {
            formCompletionHelper.EnterText(SchoolCollegeField, "Testing College");
            formCompletionHelper.ClickElement(ContinueButton);
            return new SchoolCollegePage(context);
        }
    }
}
