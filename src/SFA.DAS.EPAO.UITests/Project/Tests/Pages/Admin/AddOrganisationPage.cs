using SFA.DAS.UI.Framework;
using SFA.DAS.UI.FrameworkHelpers;
using System;
using TechTalk.SpecFlow;

namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.Admin
{
    public class AddOrganisationPage : AddOrEditOrganisationPage
    {
        protected override string PageTitle => "Add an organisation";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        private readonly TabHelper _tabHelper;
        #endregion

        public AddOrganisationPage(ScenarioContext context) : base(context)
        {
            _context = context;
            _tabHelper = context.Get<TabHelper>();
            // this is temp work aound as the redirection is not working correctly.
            VerifyPage(() => 
            {
                var uri = new Uri(new Uri(UrlConfig.Admin_BaseUrl), $"register/add-organisation");
                _tabHelper.GoToUrl(uri.AbsoluteUri);
                return pageInteractionHelper.FindElements(PageHeader);
            }, PageTitle);
        }

        public OrganisationDetailsPage EnterDetails()
        {
            formCompletionHelper.EnterText(OrganisationNameField, ePAOAdminDataHelper.NewOrganisationName);
            formCompletionHelper.EnterText(LegalNameField, ePAOAdminDataHelper.NewOrganisationLegalName);
            formCompletionHelper.EnterText(CompanyNumberField, ePAOAdminDataHelper.CompanyNumber);
            formCompletionHelper.EnterText(CharityNumberField, ePAOAdminDataHelper.CharityNumber);
            formCompletionHelper.EnterText(UkprnNameField, ePAOAdminDataHelper.NewOrganisationUkprn);
            ClickRandomElement(OrganisationTypeId);
            formCompletionHelper.EnterText(Email, ePAOAdminDataHelper.RandomEmail);
            formCompletionHelper.EnterText(PhoneNumber, ePAOAdminDataHelper.PhoneNumber);
            formCompletionHelper.EnterText(WebsiteField, ePAOAdminDataHelper.RandomWebsiteAddress);          
            formCompletionHelper.EnterText(StreetAddress1Field, ePAOAdminDataHelper.StreetAddress1);
            formCompletionHelper.EnterText(StreetAddress2Field, ePAOAdminDataHelper.StreetAddress2);
            formCompletionHelper.EnterText(StreetAddress3Field, ePAOAdminDataHelper.StreetAddress3);
            formCompletionHelper.EnterText(TownOrCityField, ePAOAdminDataHelper.TownName);
            formCompletionHelper.EnterText(PostCodeField, ePAOAdminDataHelper.PostCode);
            Continue();
            return new OrganisationDetailsPage(_context);
        }
    }
}

