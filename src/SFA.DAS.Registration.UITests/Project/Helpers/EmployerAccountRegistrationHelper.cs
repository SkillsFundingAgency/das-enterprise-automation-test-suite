using SFA.DAS.FrameworkHelpers;
using SFA.DAS.Registration.UITests.Project.Tests.Pages;
using SFA.DAS.UI.Framework.TestSupport;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using static SFA.DAS.Registration.UITests.Project.Helpers.EnumHelper;

namespace SFA.DAS.Registration.UITests.Project.Helpers
{
    public class EmployerAccountRegistrationHelper : AccountCreationStepsHelper
    {
        CreateYourEmployerAccountPage _createYourEmployerAccountPage;

        public EmployerAccountRegistrationHelper(ScenarioContext context) : base(context)
        {
           
        }

        public void CreateNewEmployerAccount()
        {
            // Navigate to home page
            // click on register
            // enter first and last name
            // enter PAYE details & add org
            // confirm arg name
            // sign legal agreement
            // give provider permissions
        }

        public void AddAdditionalAccount()
        { 
        
        }


        internal CreateYourEmployerAccountPage RegisterStubUserAccount2(CreateAnAccountToManageApprenticeshipsPage indexPage, string email)
        {
            return _createYourEmployerAccountPage = indexPage
                .ClickOnCreateAccountLink()
                .RegisterUser()
                .ContinueToCreateYourEmployerAccountPage();
        }

        internal void AddPayeAndOrgDetails(int payeIndex, OrgType orgType = OrgType.Default)
        {
            _createYourEmployerAccountPage
                .GoToAddPayeLink()
                .SelectOptionLessThan3Million()
                .AddPaye()
                .ContinueToGGSignIn()
                .SignInTo(payeIndex)
                .SearchForAnOrganisation(orgType)
                .SelectYourOrganisation(orgType)
                .ClickYesContinueButton();
        }


            






    }
}
