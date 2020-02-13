using SFA.DAS.Roatp.UITests.Project.Helpers;
using SFA.DAS.Roatp.UITests.Project.Tests.Pages;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class Section1Steps
    {
        private readonly ScenarioContext _context;
        private ApplicationOverviewPage _overviewPage;
        private readonly YourOrganisation_Section1_Helper _yourOrganisationSectionHelper;

        public Section1Steps(ScenarioContext context)
        {
            _context = context;
            _yourOrganisationSectionHelper = new YourOrganisation_Section1_Helper();
        }

        [Then(@"the provider completes Introduction and what you'll need section for main and employer route")]
        public void ThenTheProviderCompletesIntroductionAndWhatYoullNeedSectionForMainAndEmployerRoute() => _overviewPage = _yourOrganisationSectionHelper.CompleteYourOrganisationSection_1(new ApplicationOverviewPage(_context));

        [Then(@"the provider completes Introduction and what you'll need content for supporting route")]
        public void ThenTheProviderCompletesIntroductionAndWhatYoullNeedContentForSupportingRoute() => _overviewPage = _yourOrganisationSectionHelper.CompleteYourOrganisationSection_1_SupportRoute(new ApplicationOverviewPage(_context));

        [Then(@"the provider completes Organisation Information section for company")]
        public void ThenTheProviderCompletesOrganisationInformationSectionForCompany() => _overviewPage = _yourOrganisationSectionHelper.CompleteYourOrganisationSection_2(_overviewPage);

        [Then(@"the provider completes Organisation Information section for charity")]
        public void ThenTheProviderCompletesOrganisationInformationSectionForCharity() => _overviewPage = _yourOrganisationSectionHelper.CompleteYourOrganisationSection_2_NotACompany(_overviewPage);

        [Then(@"the provider completes Tell us who's in control section for charity")]
        public void ThenTheProviderCompletesTellUsWhosInControlSectionForCharity() => _overviewPage = _yourOrganisationSectionHelper.CompleteYourOrganisationSection_3_Charity(_overviewPage);

        [Then(@"the provider completes Tell us who's in control section")]
        public void ThenTheProviderCompletesTellUsWhosInControlSection() => _overviewPage = _yourOrganisationSectionHelper.CompleteYourOrganisationSection_3(_overviewPage);

        [Then(@"the provider completes Tell us who's in control section for sole trader")]
        public void ThenTheProviderCompletesTellUsWhosInControlSectionForSoleTrader() => _overviewPage = _yourOrganisationSectionHelper.CompleteYourOrganisationSection_3_Support(_overviewPage);

        [Then(@"the provider completes Tell us who's in control section for charity and company")]
        public void ThenTheProviderCompletesTellUsWhosInControlSectionForCharityAndCompany() => _overviewPage = _yourOrganisationSectionHelper.CompleteYourOrganisationSection_3_CharityAndCompany(_overviewPage);

        [Then(@"the provider completes Tell us who's in control section for Government Statue")]
        public void ThenTheProviderCompletesTellUsWhosInControlSectionForGovernmentStatue() => _overviewPage = _yourOrganisationSectionHelper.CompleteYourOrganisationSection_3_GovernmentStatue(_overviewPage);

        [Then(@"the provider completes Describe your organisation section as OrgTypeNoneOfTheAbove")]
        public void ThenTheProviderCompletesDescribeYourOrganisationSectionAsOrgTypeNoneOfTheAbove() => _overviewPage = _yourOrganisationSectionHelper.CompleteYourOrganisationSection_4_OrgTypeNoneOfTheAbove(_overviewPage);

        [Then(@"the provider completes Describe your organisation section as OrgTypeITP")]
        public void ThenTheProviderCompletesDescribeYourOrganisationSectionAsOrgTypeITP() => _overviewPage = _yourOrganisationSectionHelper.CompleteYourOrganisationSection_4(_overviewPage);

        [Then(@"the provider completes Describe your organisation section as OrgTypeGTA")]
        public void ThenTheProviderCompletesDescribeYourOrganisationSectionAsOrgTypeGTA() => _overviewPage = _yourOrganisationSectionHelper.CompleteYourOrganisationSection_4_OrgTypeGTA(_overviewPage);

        [Then(@"the provider completes Describe your organisation section as OrgTypeAEI")]
        public void ThenTheProviderCompletesDescribeYourOrganisationSectionAsOrgTypeAEI() => _overviewPage = _yourOrganisationSectionHelper.CompleteYourOrganisationSection_4_OrgTypeAEI(_overviewPage);

        [Then(@"the provider completes Describe your organisation section")]
        public void ThenTheProviderCompletesDescribeYourOrganisationSection() => _overviewPage = _yourOrganisationSectionHelper.CompleteYourOrganisationSection_4_OrgTypeAcadamy(_overviewPage);

        [Then(@"the provider completes Describe your organisation section as OrgTypeATP")]
        public void ThenTheProviderCompletesDescribeYourOrganisationSectionAsOrgTypeATP() => _overviewPage = _yourOrganisationSectionHelper.CompleteYourOrganisationSection_4_OrgTypeATP(_overviewPage);

        [Then(@"the provider completes Describe your organisation section as OrgTypePublicBody")]
        public void ThenTheProviderCompletesDescribeYourOrganisationSectionAsOrgTypePublicBody() => _overviewPage = _yourOrganisationSectionHelper.CompleteYourOrganisationSection_4_OrgTypePublicBody(_overviewPage);

        [Then(@"the provider completes Experience and Accreditations section by selecting No to all")]
        public void ThenTheProviderCompletesExperienceAndAccreditationsSectionBySelectingNoToAll() => _overviewPage = _yourOrganisationSectionHelper.CompleteYourOrganisationSection_5_NoToAll(_overviewPage);

        [Then(@"the provider completes Experience and Accreditations section by selecting Yes to Subcontractor training")]
        public void ThenTheProviderCompletesExperienceAndAccreditationsSectionBySelectingYesToSubcontractorTraining() => _overviewPage = _yourOrganisationSectionHelper.CompleteYourOrganisationSection_5_Support(_overviewPage);

        [Then(@"the provider completes Experience and Accreditations section by selecting GradeTypeRequiresImprovement")]
        public void ThenTheProviderCompletesExperienceAndAccreditationsSectionBySelectingGradeTypeRequiresImprovement() => _overviewPage = _yourOrganisationSectionHelper.CompleteYourOrganisationSection_5_GradeTypeRequiresImprovement(_overviewPage);

        [Then(@"the provider completes Experience and Accreditations section by selecting GradeOutstanding")]
        public void ThenTheProviderCompletesExperienceAndAccreditationsSectionBySelectingGradeOutstanding() => _overviewPage = _yourOrganisationSectionHelper.CompleteYourOrganisationSection_5_GradeOutstanding(_overviewPage);

        [Then(@"the provider completes Experience and Accreditations section by selecting Yes to PGTA")]
        public void ThenTheProviderCompletesExperienceAndAccreditationsSectionBySelectingYesToPGTA() => _overviewPage = _yourOrganisationSectionHelper.CompleteYourOrganisationSection_5_YesToPGTA(_overviewPage);

    }
}
