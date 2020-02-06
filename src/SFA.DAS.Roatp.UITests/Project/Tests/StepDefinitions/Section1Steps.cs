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

        [Then(@"the provider completes Introduction and what you'll need sub section for main and employer route")]
        public void ThenTheProviderCompletesIntroductionAndWhatYoullNeedSubSectionForMainAndEmployerRoute()
        {
            _overviewPage = new ApplicationOverviewPage(_context);
            _yourOrganisationSectionHelper.CompleteYourOrganisationSection_1(_overviewPage);
        }

        [Then(@"the provider completes Organisation Information sub section for charity")]
        public void ThenTheProviderCompletesOrganisationInformationSubSectionForCharity()
        {
            _overviewPage = _yourOrganisationSectionHelper.CompleteYourOrganisationSection_2_NotACompany(_overviewPage);
        }

        [Then(@"the provider completes Tell us who's in control sub section for charity")]
        public void ThenTheProviderCompletesTellUsWhosInControlSubSectionForCharity()
        {
            _overviewPage = _yourOrganisationSectionHelper.CompleteYourOrganisationSection_3_Charity(_overviewPage);
        }

        [Then(@"the provider completes Describe your organisation sub section as OrgTypeNoneOfTheAbove")]
        public void ThenTheProviderCompletesDescribeYourOrganisationSubSectionAsOrgTypeNoneOfTheAbove()
        {
            _overviewPage = _yourOrganisationSectionHelper.CompleteYourOrganisationSection_4_OrgTypeNoneOfTheAbove(_overviewPage);
        }

        [Then(@"the provider completes Experience and Accreditations section by selecting No to all")]
        public void ThenTheProviderCompletesExperienceAndAccreditationsSectionBySelectingNoToAll()
        {
            _overviewPage = _yourOrganisationSectionHelper.CompleteYourOrganisationSection_5_NoToAll(_overviewPage);
        }

    }
}
