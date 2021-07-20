using SFA.DAS.ApprenticeCommitments.APITests.Project;
using SFA.DAS.ApprenticeCommitments.UITests.Project.Tests.Page;
using SFA.DAS.Approvals.UITests.Project.Helpers.DataHelpers;
using SFA.DAS.Approvals.UITests.Project.Helpers.StepsHelper;
using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.Login.Service;
using SFA.DAS.Registration.UITests.Project.Helpers;
using SFA.DAS.UI.Framework;
using TechTalk.SpecFlow;

namespace SFA.DAS.ApprenticeCommitments.UITests.Project.Tests.StepDefinition
{
    [Binding]
    public class CocSteps : BaseSteps
    {
        private readonly ScenarioContext _context;
        private readonly ObjectContext _objectContext;
        private readonly EmployerPortalLoginHelper _employerPortalLoginHelper;
        private readonly ApprenticeDataHelper _apprenticeDataHelper;
        private readonly EditedApprenticeDataHelper _editedApprenticeDataHelper;
        private readonly EditedApprenticeCourseDataHelper _editedApprenticeCourseDataHelper;

        private readonly EmployerStepsHelper _employerStepsHelper;
        private readonly ProviderStepsHelper _providerStepsHelper;
        private readonly ASCoCEmployerUser _user;


        public CocSteps(ScenarioContext context) : base(context)
        {
            _context = context;
            _objectContext = context.Get<ObjectContext>();
            _employerPortalLoginHelper = new EmployerPortalLoginHelper(context);
            _employerStepsHelper = new EmployerStepsHelper(context);
            _providerStepsHelper = new ProviderStepsHelper(context);
            _apprenticeDataHelper = context.Get<ApprenticeDataHelper>();
            _editedApprenticeDataHelper = context.Get<EditedApprenticeDataHelper>();
            _editedApprenticeCourseDataHelper = context.Get<EditedApprenticeCourseDataHelper>();
            _user = _context.GetUser<ASCoCEmployerUser>();
        }

        [Given(@"a Course date CoC occurs on an apprenticeship on Employer side")]
        public void GivenACourseDateCoCOccursOnAnApprenticeshipOnEmployerSide()
        {
            _employerPortalLoginHelper.Login(_user, true);

            _apprenticeDataHelper.UpdateCurrentApprenticeName(_user.CocApprenticeUser.ApprenticeFirstName, _user.CocApprenticeUser.ApprenticeLastName);

            var editAppPage = _employerStepsHelper.EditApprenticeDetailsPagePostApproval(false);

            _editedApprenticeCourseDataHelper.SelectAnyStandardCourse(editAppPage.GetSelectedCourse());

            new ApprenticeCommitmentsEditApprenticePage(_context).EditCourseAndDate().AcceptChangesAndSubmit();

            _editedApprenticeDataHelper.UpdateCurrentApprenticeName(_user.CocApprenticeUser.ApprenticeFirstName, _user.CocApprenticeUser.ApprenticeLastName);

            _providerStepsHelper.ApproveChangesAndSubmit();
        }

        [When(@"the apprentice logs into the Apprentice portal")]
        public void WhenTheApprenticeLogsIntoTheApprenticePortal()
        {
            tabHelper.OpenInNewTab(UrlConfig.Apprentice_BaseUrl());

            _objectContext.UpdateApprenticeEmail(_user.CocApprenticeUser.ApprenticeUsername);

            new SignIntoApprenticeshipPortalPage(_context).SignInToApprenticePortal();

        }


    }
}