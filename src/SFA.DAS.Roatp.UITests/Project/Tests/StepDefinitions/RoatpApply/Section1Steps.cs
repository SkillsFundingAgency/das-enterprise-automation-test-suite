using SFA.DAS.Roatp.UITests.Project.Helpers.StepsHelper;
using SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply;
using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.StepDefinitions.RoatpApply
{
    [Binding]
    public class Section1Steps(ScenarioContext context)
    {
        private ApplicationOverviewPage _overviewPage;

        [When(@"the provider completes Your organisation section using an ukprn")]
        public void WhenTheProviderCompletesYourOrganisationSectionUsingAnUkprn()
        {
            _overviewPage = new ApplicationOverviewPage(context);
            _overviewPage = YourOrganisation_Section1_Helper.CompleteYourOrganisationSection_1(_overviewPage);
            _overviewPage = YourOrganisation_Section1_Helper.CompleteYourOrganisationSection_2_NotACompany(_overviewPage);
            _overviewPage = YourOrganisation_Section1_Helper.CompleteYourOrganisationSection_3_GovernmentStatue(_overviewPage);
            _overviewPage = YourOrganisation_Section1_Helper.CompleteYourOrganisationSection_4_OrgTypeHEIEmplopyerRoute(_overviewPage);
            _overviewPage = YourOrganisation_Section1_Helper.CompleteYourOrganisationSection_5_NoToAllForEmployerRoute(_overviewPage);
            YourOrganisation_Section1_Helper.VerifySection1Status(_overviewPage);
        }

        [Then(@"the provider completes Introduction and what you'll need section for main and employer route")]
        public void ThenTheProviderCompletesIntroductionAndWhatYoullNeedSectionForMainAndEmployerRoute() => _overviewPage = YourOrganisation_Section1_Helper.CompleteYourOrganisationSection_1(new ApplicationOverviewPage(context));

        [Then(@"the provider completes Introduction and what you'll need content for supporting route")]
        public void ThenTheProviderCompletesIntroductionAndWhatYoullNeedContentForSupportingRoute() => _overviewPage = YourOrganisation_Section1_Helper.CompleteYourOrganisationSection_1_SupportRoute(new ApplicationOverviewPage(context));

        [Then(@"the provider completes Organisation Information section for company")]
        public void ThenTheProviderCompletesOrganisationInformationSectionForCompany() => _overviewPage = YourOrganisation_Section1_Helper.CompleteYourOrganisationSection_2(_overviewPage);

        [Then(@"the provider completes Organisation Information section for charity")]
        public void ThenTheProviderCompletesOrganisationInformationSectionForCharity() => _overviewPage = YourOrganisation_Section1_Helper.CompleteYourOrganisationSection_2_NotACompany(_overviewPage);

        [Then(@"the provider completes Tell us who's in control section for charity")]
        public void ThenTheProviderCompletesTellUsWhosInControlSectionForCharity() => _overviewPage = YourOrganisation_Section1_Helper.CompleteYourOrganisationSection_3_Charity(_overviewPage);

        [Then(@"the provider completes Tell us who's in control section")]
        public void ThenTheProviderCompletesTellUsWhosInControlSection() => _overviewPage = YourOrganisation_Section1_Helper.CompleteYourOrganisationSection_3(_overviewPage);

        [Then(@"the provider completes Tell us who's in control section for sole trader")]
        public void ThenTheProviderCompletesTellUsWhosInControlSectionForSoleTrader() => _overviewPage = YourOrganisation_Section1_Helper.CompleteYourOrganisationSection_3_Support(_overviewPage);

        [Then(@"the provider completes Tell us who's in control section for sole trader and partnership")]
        public void ThenTheProviderCompletesTellUsWhoSInControlSectionForSoleTraderAndPartnership() => _overviewPage = YourOrganisation_Section1_Helper.CompleteYourOrganisationSection_3_Supporting_Partnership(_overviewPage);

        [Then(@"the provider completes Tell us who's in control section for charity and company")]
        public void ThenTheProviderCompletesTellUsWhosInControlSectionForCharityAndCompany() => _overviewPage = YourOrganisation_Section1_Helper.CompleteYourOrganisationSection_3_CharityAndCompany(_overviewPage);

        [Then(@"the provider completes Tell us who's in control section for Government Statue")]
        public void ThenTheProviderCompletesTellUsWhosInControlSectionForGovernmentStatue() => _overviewPage = YourOrganisation_Section1_Helper.CompleteYourOrganisationSection_3_GovernmentStatue(_overviewPage);

        [Then(@"the provider completes Describe your organisation section as OrgTypeNoneOfTheAbove")]
        public void ThenTheProviderCompletesDescribeYourOrganisationSectionAsOrgTypeNoneOfTheAbove() => _overviewPage = YourOrganisation_Section1_Helper.CompleteYourOrganisationSection_4_OrgTypeNoneOfTheAbove(_overviewPage);

        [Then(@"the provider completes Describe your organisation section as OrgTypeITP")]
        public void ThenTheProviderCompletesDescribeYourOrganisationSectionAsOrgTypeITP() => _overviewPage = YourOrganisation_Section1_Helper.CompleteYourOrganisationSection_4(_overviewPage);

        [Then(@"the provider completes Describe your organisation section as OrgTypeGTA")]
        public void ThenTheProviderCompletesDescribeYourOrganisationSectionAsOrgTypeGTA() => _overviewPage = YourOrganisation_Section1_Helper.CompleteYourOrganisationSection_4_OrgTypeGTA(_overviewPage);

        [Then(@"the provider completes Describe your organisation section as OrgTypeAEI")]
        public void ThenTheProviderCompletesDescribeYourOrganisationSectionAsOrgTypeAEI() => _overviewPage = YourOrganisation_Section1_Helper.CompleteYourOrganisationSection_4_OrgTypeAEI(_overviewPage);

        [Then(@"the provider completes Describe your organisation section as OrgTypeAEI Employer Route")]
        public void ThenTheProviderCompletesDescribeYourOrganisationSectionAsOrgTypeAEIEmployerRoute() => _overviewPage = YourOrganisation_Section1_Helper.CompleteYourOrganisationSection_4_OrgTypeHEIEmplopyerRoute(_overviewPage);

        [Then(@"the provider completes Describe your organisation section")]
        public void ThenTheProviderCompletesDescribeYourOrganisationSection() => _overviewPage = YourOrganisation_Section1_Helper.CompleteYourOrganisationSection_4_OrgTypeAcadamy(_overviewPage);
        [Then(@"the provider completes Describe your organisation section as OrgTYpe Rail franchise")]
        public void ThenTheProviderCompletesDescribeYourOrganisationSectionAsOrgTYpeRailFranchise() => _overviewPage = YourOrganisation_Section1_Helper.CompleteYourOrganisationSection_4_OrgTypeRailFranchise(_overviewPage);

        [Then(@"the provider completes Describe your organisation section as OrgTypeATP")]
        public void ThenTheProviderCompletesDescribeYourOrganisationSectionAsOrgTypeATP() => _overviewPage = YourOrganisation_Section1_Helper.CompleteYourOrganisationSection_4_OrgTypeATP(_overviewPage);

        [Then(@"the provider completes Describe your organisation section as OrgTypePublicBody")]
        public void ThenTheProviderCompletesDescribeYourOrganisationSectionAsOrgTypePublicBody() => _overviewPage = YourOrganisation_Section1_Helper.CompleteYourOrganisationSection_4_OrgTypePublicBody(_overviewPage);

        [Then(@"the provider completes Experience and Accreditations section by selecting No to all")]
        public void ThenTheProviderCompletesExperienceAndAccreditationsSectionBySelectingNoToAll() => _overviewPage = YourOrganisation_Section1_Helper.CompleteYourOrganisationSection_5_NoToAllMainRoute(_overviewPage);

        [Then(@"the provider completes Experience and Accreditations section by selecting No to all Employer Route")]
        public void ThenTheProviderCompletesExperienceAndAccreditationsSectionBySelectingNoToAllEmployerRoute() => _overviewPage = YourOrganisation_Section1_Helper.CompleteYourOrganisationSection_5_NoToAllForEmployerRoute(_overviewPage);

        [Then(@"the provider completes Experience and Accreditations section by selecting Yes to Subcontractor training")]
        public void ThenTheProviderCompletesExperienceAndAccreditationsSectionBySelectingYesToSubcontractorTraining() => _overviewPage = YourOrganisation_Section1_Helper.CompleteYourOrganisationSection_5_Support(_overviewPage);

        [Then(@"the provider completes Experience and Accreditations section by selecting GradeTypeRequiresImprovement")]
        public void ThenTheProviderCompletesExperienceAndAccreditationsSectionBySelectingGradeTypeRequiresImprovement() => _overviewPage = YourOrganisation_Section1_Helper.CompleteYourOrganisationSection_5_GradeTypeRequiresImprovement(_overviewPage);
        [Then(@"the provider completes Experience and Accreditations section by selecting Yes had monitoring visit for apprenticeships")]
        public void ThenTheProviderCompletesExperienceAndAccreditationsSectionBySelectingYesHadMonitoringVisitForApprenticeships() => _overviewPage = YourOrganisation_Section1_Helper.CompleteYourOrganisationSection_5_InsufficientProgressInMonitoringVisits(_overviewPage);

        [Then(@"the provider completes Experience and Accreditations section by selecting GradeTypeRequiresImprovement for Main Route")]
        public void ThenTheProviderCompletesExperienceAndAccreditationsSectionBySelectingGradeTypeRequiresImprovementForMainRoute() => _overviewPage = YourOrganisation_Section1_Helper.CompleteYourOrganisationSection_5_GradeTypeRequiresImprovement_MainRoute(_overviewPage);

        [Then(@"the provider completes Experience and Accreditations section by selecting GradeOutstanding")]
        public void ThenTheProviderCompletesExperienceAndAccreditationsSectionBySelectingGradeOutstanding() => _overviewPage = YourOrganisation_Section1_Helper.CompleteYourOrganisationSection_5_GradeOutstanding(_overviewPage);

        [Then(@"the provider completes Experience and Accreditations section by selecting Yes to PGTA")]
        public void ThenTheProviderCompletesExperienceAndAccreditationsSectionBySelectingYesToPGTA() => _overviewPage = YourOrganisation_Section1_Helper.CompleteYourOrganisationSection_5_YesToPGTA(_overviewPage);

        [Then(@"the provider completes Experience and Accreditations section by meeting all Ofsted Requirements")]
        public void ThenTheProviderCompletesExperienceAndAccreditationsSectionByMeetingAllOfstedRequirements() => _overviewPage = YourOrganisation_Section1_Helper.CompleteYourOrganisationSection_5_Ofsted(_overviewPage);

        [Then(@"the provider verifies section exemptions")]
        public void ThenTheProviderVerifiesSectionExemptions() => _overviewPage = YourOrganisation_Section1_Helper.CompleteAndVerifySectionExemptions_MainRoute(_overviewPage);

        [Then(@"the provider verifies section exemptions for employer route")]
        public void ThenTheProviderVerifiesSectionExemptionsForEmployerRoute() => _overviewPage = YourOrganisation_Section1_Helper.CompleteAndVerifySectionExemptions_EmployerRoute(_overviewPage);

        [Then(@"the provider verifies Financial Section Status as not required")]
        public void ThenTheProviderVerifiesFinancialSectionStatusAsNotRequired() => _overviewPage = FinancialEvidence_Section2_Helper.VerifyFinancialEvidenceSectionExempted(_overviewPage);

    }
}