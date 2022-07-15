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
    public class TrainingLocationPage : VerifyBasePage
    {
        protected override string PageTitle => "Training locations";

        public TrainingLocationPage(ScenarioContext context) : base(context) => VerifyPage();

    }
}
