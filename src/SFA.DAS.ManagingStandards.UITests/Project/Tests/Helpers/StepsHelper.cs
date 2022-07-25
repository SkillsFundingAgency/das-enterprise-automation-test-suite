using OpenQA.Selenium;
using SFA.DAS.IdamsLogin.Service.Project.Tests.Pages;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace SFA.DAS.ManagingStandards.UITests.Project.Helpers.Pages
{
    public class StepsHelper 
    {
        private readonly ScenarioContext _context;
        private readonly TabHelper _tabHelper;
        private readonly FormCompletionHelper formCompletionHelper;

        private By PireanPreprod => By.XPath("//span[contains(text(),'Pirean Preprod')]");

        public StepsHelper(ScenarioContext context)
        {
            _context = context;
            _tabHelper = _context.Get<TabHelper>();
            formCompletionHelper = _context.Get<FormCompletionHelper>();
        }

        public void NavigateToReviewYourDetails()
        {
            //This is the only way we can naviagate to Managing standards for now,
            //This will change when Dashboard link will be implemented

            _tabHelper.GoToUrl("https://roatp.pp-pas.apprenticeships.education.gov.uk/10001259/review-your-details");
            formCompletionHelper.ClickElement(PireanPreprod);
        }

    }
}
