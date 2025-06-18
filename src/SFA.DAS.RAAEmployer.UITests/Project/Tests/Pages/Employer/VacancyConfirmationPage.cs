using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using SFA.DAS.RAA.Service.Project.Tests.Pages;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAAEmployer.UITests.Project.Tests.Pages.Employer
{
    public class VacancyConfirmationPage(ScenarioContext context) : RaaBasePage(context)
    {
        protected override string PageTitle => "Advert submitted for approval";
        public static By ReturnToDashboardLink => By.LinkText("Return to dashboard");

        public YourApprenticeshipAdvertsHomePage ClickReturnToDashboard()
        {
            formCompletionHelper.Click(ReturnToDashboardLink);
            return new YourApprenticeshipAdvertsHomePage(context);
        }

    }
}
