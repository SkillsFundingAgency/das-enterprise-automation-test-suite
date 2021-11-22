using SFA.DAS.UI.FrameworkHelpers;
using System;

namespace SFA.DAS.Roatp.UITests.Project.Helpers.DataHelpers
{
    public class RoatpApplyDataHelpers : RandomElementHelper
    {
        public RoatpApplyDataHelpers() : base()
        {
            CompanyNumber = RandomDataGenerator.GenerateRandomNumber(8);
            CompanyName = $"{CompanyNumber}EnterpriseTestDemo";
            IocNumber = RandomDataGenerator.GenerateRandomAlphanumericString(8);
            Website = $"www.company.co.uk";
            BuildingAndStreet = RandomDataGenerator.GenerateRandomNumber(3);
            TownOrCity = RandomDataGenerator.GenerateRandomAlphabeticString(10);
            County = RandomDataGenerator.GenerateRandomAlphabeticString(5);
            CompositionWithCreditots = RandomDataGenerator.GenerateRandomAlphabeticString(20);
            PayBackFundsLastThreeYears = RandomDataGenerator.GenerateRandomAlphabeticString(20);
            ContractTerminatedByPublicBody = RandomDataGenerator.GenerateRandomAlphabeticString(20);
            WithdrawnFromAContractWithPublicBody = RandomDataGenerator.GenerateRandomAlphabeticString(20);
            FundingRemovedFromEducationBodies = RandomDataGenerator.GenerateRandomAlphabeticString(20);
            RemovedFromProfessionalOrTradeRegisters = RandomDataGenerator.GenerateRandomAlphabeticString(20);
            InvoluntaryWithdrawlFromITTAccreditation = RandomDataGenerator.GenerateRandomAlphabeticString(20);
            NamesOfAllOrganisations = RandomDataGenerator.GenerateRandomAlphabeticString(20);
            RemovedFromCharityRegister = RandomDataGenerator.GenerateRandomAlphabeticString(20);
            InvestigatedDueToSafeGuardingIssues = RandomDataGenerator.GenerateRandomAlphabeticString(20);
            InvestigatedDueToWhistleBlowingIssues = RandomDataGenerator.GenerateRandomAlphabeticString(20);
            InsolvencyOrWindingUpProceedings = RandomDataGenerator.GenerateRandomAlphabeticString(20);
            UnspentCriminalConvictions = RandomDataGenerator.GenerateRandomAlphabeticString(20);
            WhosInControlFailedToPayBackFunds = RandomDataGenerator.GenerateRandomAlphabeticString(20);
            WhosInControlInvestigatedForFraudorIrregularities = RandomDataGenerator.GenerateRandomAlphabeticString(20);
            WhosInControlOngoingInvestigationsForFraud = RandomDataGenerator.GenerateRandomAlphabeticString(20);
            WhosInControlContractTerminatedByPublicBody = RandomDataGenerator.GenerateRandomAlphabeticString(20);
            WhosInControlContractWithdrawnWithPublicBody = RandomDataGenerator.GenerateRandomAlphabeticString(20);
            WhosInControlBreachTaxSocialSecurity = RandomDataGenerator.GenerateRandomAlphabeticString(20);
            WhosInControlBankruptInLastThreeYears = RandomDataGenerator.GenerateRandomAlphabeticString(20);
            ManagingRelationshipWithEmployers = RandomDataGenerator.GenerateRandomAlphabeticString(20);
            OrganisationPromoteApprenticeships = RandomDataGenerator.GenerateRandomAlphabeticString(20);
            OrganisationProcessForInitialTraning = RandomDataGenerator.GenerateRandomAlphabeticString(20);
            ProcessToAssessEnglishAndMaths = RandomDataGenerator.GenerateRandomAlphabeticString(20);
            ReadytoDeliverTraining = RandomDataGenerator.GenerateRandomAlphabeticString(20);
            EngageWithEPAO = RandomDataGenerator.GenerateRandomAlphabeticString(20);
            EngageWithAwardingBodies = RandomDataGenerator.GenerateRandomAlphabeticString(20);
            OffTheJobTraining = RandomDataGenerator.GenerateRandomAlphabeticString(20);
            EvaluatingQualityOfTrainingDelivered = RandomDataGenerator.GenerateRandomAlphabeticString(20);
            ImprovementsUsingProcessForEvaluating = RandomDataGenerator.GenerateRandomAlphabeticString(20);
            ReviewProcessForEvaluatingTheQualityOfTraining = RandomDataGenerator.GenerateRandomAlphabeticString(20);
            TransitionFromFrameWorksToStandardsForEmployerRoute = RandomDataGenerator.GenerateRandomAlphabeticString(20);
            TransitionFromFrameWorksToStandards = RandomDataGenerator.GenerateRandomAlphabeticString(20);
            HowApprenticesAreSupported = RandomDataGenerator.GenerateRandomAlphabeticString(20);
            OtherWaysToSupportApprentices = RandomDataGenerator.GenerateRandomAlphabeticString(20);
            HowExpectationsAreMonitored = RandomDataGenerator.GenerateRandomAlphabeticString(20);
            HowAreTheyCommunicatedToEmployees = RandomDataGenerator.GenerateRandomAlphabeticString(20);
            ExampleToImproveEmployees = RandomDataGenerator.GenerateRandomAlphabeticString(20);
            ExampleToMaintainEmployees = RandomDataGenerator.GenerateRandomAlphabeticString(20);
            HowHasTheTeamOrPersonWorked = RandomDataGenerator.GenerateRandomAlphabeticString(20);
            WhatLevelOfSupportProvided = RandomDataGenerator.GenerateRandomAlphabeticString(20);
            NumberBetween1And23 = RandomDataGenerator.GenerateRandomNumberBetweenTwoValues(1, 23);
            SignificantEventText = RandomDataGenerator.GenerateRandomAlphabeticString(20);
            StandardIntendToDeliver = RandomDataGenerator.GenerateRandomAlphabeticString(20);
            ProhibitionOrderFromTeachingRegulationAgency = RandomDataGenerator.GenerateRandomAlphabeticString(100);
            RandomMonth = RandomDataGenerator.GenerateRandomMonth();
            RandomYear = RandomDataGenerator.GenerateRandomDobYear();
        }

        public DateTime Dob(int x) => DateTime.Now.AddYears(-20 + x);
        public string FullName => "George Smith";
        public string LastName => "George";
        public string FirstName => "Smith";
        public string JobRole => "Employee";
        public string Email => "test.demo@digital.education.gov.uk";
        public string ContactNumber => "1234567890";
        public string BuildingAndStreet { get; }
        public string TownOrCity { get; }
        public string County { get; }
        public string Postcode => "CV22 4NX";
        public string CompanyNumber { get; }
        public string CompanyName { get; }
        public string IocNumber { get; }
        public string Website { get; }
        public string CompositionWithCreditots { get; }
        public string PayBackFundsLastThreeYears { get; }
        public string ContractTerminatedByPublicBody { get; }
        public string WithdrawnFromAContractWithPublicBody { get; }
        public string FundingRemovedFromEducationBodies { get; }
        public string RemovedFromProfessionalOrTradeRegisters { get; }
        public string InvoluntaryWithdrawlFromITTAccreditation { get; }
        public string RemovedFromCharityRegister { get; }
        public string InvestigatedDueToSafeGuardingIssues { get; }
        public string InvestigatedDueToWhistleBlowingIssues { get; }
        public string InsolvencyOrWindingUpProceedings { get; }
        public string UnspentCriminalConvictions { get; }
        public string WhosInControlFailedToPayBackFunds { get; }
        public string WhosInControlInvestigatedForFraudorIrregularities { get; }
        public string WhosInControlOngoingInvestigationsForFraud { get; }
        public string WhosInControlContractTerminatedByPublicBody { get; }
        public string WhosInControlContractWithdrawnWithPublicBody { get; }
        public string WhosInControlBreachTaxSocialSecurity { get; }
        public string WhosInControlBankruptInLastThreeYears { get; }
        public string ProhibitionOrderFromTeachingRegulationAgency { get; }
        public string ManagingRelationshipWithEmployers { get; }
        public string OrganisationPromoteApprenticeships { get; }
        public string OrganisationProcessForInitialTraning { get; }
        public string ProcessToAssessEnglishAndMaths { get; }
        public string ReadytoDeliverTraining { get; }
        public string EngageWithEPAO { get; }
        public string StandardIntendToDeliver { get; }
        public string EngageWithAwardingBodies { get; }
        public string OffTheJobTraining { get; }
        public string EvaluatingQualityOfTrainingDelivered { get; }
        public string ImprovementsUsingProcessForEvaluating { get; }
        public string ReviewProcessForEvaluatingTheQualityOfTraining { get; }
        public string TransitionFromFrameWorksToStandardsForEmployerRoute { get; }
        public string TransitionFromFrameWorksToStandards { get; }
        public string HowApprenticesAreSupported { get; }
        public string OtherWaysToSupportApprentices { get; }
        public string HowExpectationsAreMonitored { get; }
        public string HowAreTheyCommunicatedToEmployees { get; }
        public string ExampleToImproveEmployees { get; }
        public string ExampleToMaintainEmployees { get; }
        public string HowHasTheTeamOrPersonWorked { get; }
        public string NamesOfAllOrganisations { get; }
        public string WhatLevelOfSupportProvided { get; }
        public string SignificantEventText { get; }
        public string GenerateRandomWholeNumber(int length) => RandomDataGenerator.GenerateRandomWholeNumber(length);
        public int NumberBetween1And23 { get; }
        public int RandomMonth { get; }
        public int RandomYear { get; }
    }
}
