using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SFA.DAS.ManagingStandards.UITests.Project.Tests.Pages
{
    public  class SorryThereIsAProblem(ScenarioContext context) : ManagingStandardsBasePage(context)
    {
        protected override string PageTitle => "Sorry, there is a problem with the service";
        private static By ReturnToTPDashboardLink => By.LinkText("training provider dashboard");
        public YourStandardsAndTrainingVenuesPage ClickReturnToDashboard()
        {
            formCompletionHelper.Click(ReturnToTPDashboardLink);
            return new YourStandardsAndTrainingVenuesPage(context);
        }

    }
}
