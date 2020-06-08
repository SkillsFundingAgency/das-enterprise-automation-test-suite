using SFA.DAS.UI.FrameworkHelpers;
using System;

namespace SFA.DAS.Roatp.UITests.Project.Helpers.RoatpApply
{
    public class RoatpApplyDataHelpers : RandomDataGeneratorHelper
    {
        public RoatpApplyDataHelpers(RandomDataGenerator randomDataGenerator) : base(randomDataGenerator)
        {
            CompanyNumber = randomDataGenerator.GenerateRandomNumber(8);
            CompanyName = $"{CompanyNumber}EnterpriseTestDemo";
            IocNumber = randomDataGenerator.GenerateRandomAlphanumericString(8);
            Website = $"www.company.co.uk";
            BuildingAndStreet = randomDataGenerator.GenerateRandomNumber(3);
            TownOrCity = randomDataGenerator.GenerateRandomAlphabeticString(10);
            County = randomDataGenerator.GenerateRandomAlphabeticString(5);
            CompositionWithCreditots = randomDataGenerator.GenerateRandomAlphabeticString(20);
            PayBackFundsLastThreeYears = randomDataGenerator.GenerateRandomAlphabeticString(20);
            ContractTerminatedByPublicBody = randomDataGenerator.GenerateRandomAlphabeticString(20);
            WithdrawnFromAContractWithPublicBody = randomDataGenerator.GenerateRandomAlphabeticString(20);
            FundingRemovedFromEducationBodies = randomDataGenerator.GenerateRandomAlphabeticString(20);
            RemovedFromProfessionalOrTradeRegisters = randomDataGenerator.GenerateRandomAlphabeticString(20);
            InvoluntaryWithdrawlFromITTAccreditation = randomDataGenerator.GenerateRandomAlphabeticString(20);
            RemovedFromCharityRegister = randomDataGenerator.GenerateRandomAlphabeticString(20);
            InvestigatedDueToSafeGuardingIssues = randomDataGenerator.GenerateRandomAlphabeticString(20);
            InvestigatedDueToWhistleBlowingIssues = randomDataGenerator.GenerateRandomAlphabeticString(20);
            InsolvencyOrWindingUpProceedings = randomDataGenerator.GenerateRandomAlphabeticString(20);
            UnspentCriminalConvictions = randomDataGenerator.GenerateRandomAlphabeticString(20);
            WhosInControlFailedToPayBackFunds = randomDataGenerator.GenerateRandomAlphabeticString(20);
            WhosInControlInvestigatedForFraudorIrregularities = randomDataGenerator.GenerateRandomAlphabeticString(20);
            WhosInControlOngoingInvestigationsForFraud = randomDataGenerator.GenerateRandomAlphabeticString(20);
            WhosInControlContractTerminatedByPublicBody = randomDataGenerator.GenerateRandomAlphabeticString(20);
            WhosInControlContractWithdrawnWithPublicBody = randomDataGenerator.GenerateRandomAlphabeticString(20);
            WhosInControlBreachTaxSocialSecurity = randomDataGenerator.GenerateRandomAlphabeticString(20);
            WhosInControlBankruptInLastThreeYears = randomDataGenerator.GenerateRandomAlphabeticString(20);
            ManagingRelationshipWithEmployers = randomDataGenerator.GenerateRandomAlphabeticString(20);
            OrganisationPromoteApprenticeships = randomDataGenerator.GenerateRandomAlphabeticString(20);
            OrganisationProcessForInitialTraning = randomDataGenerator.GenerateRandomAlphabeticString(20);
            ProcessToAssessEnglishAndMaths = randomDataGenerator.GenerateRandomAlphabeticString(20);
            ReadytoDeliverTraining = randomDataGenerator.GenerateRandomAlphabeticString(20);
            EngageWithEPAO = randomDataGenerator.GenerateRandomAlphabeticString(20);
            EngageWithAwardingBodies = randomDataGenerator.GenerateRandomAlphabeticString(20);
            OffTheJobTraining = randomDataGenerator.GenerateRandomAlphabeticString(20);
            EvaluatingQualityOfTrainingDelivered = randomDataGenerator.GenerateRandomAlphabeticString(20);
            ImprovementsUsingProcessForEvaluating = randomDataGenerator.GenerateRandomAlphabeticString(20);
            ReviewProcessForEvaluatingTheQualityOfTraining = randomDataGenerator.GenerateRandomAlphabeticString(20);
            TransitionFromFrameWorksToStandardsForEmployerRoute = randomDataGenerator.GenerateRandomAlphabeticString(20);
            TransitionFromFrameWorksToStandards = randomDataGenerator.GenerateRandomAlphabeticString(20);
            HowApprenticesAreSupported = randomDataGenerator.GenerateRandomAlphabeticString(20);
            OtherWaysToSupportApprentices = randomDataGenerator.GenerateRandomAlphabeticString(20);
            HowExpectationsAreMonitored = randomDataGenerator.GenerateRandomAlphabeticString(20);
            HowAreTheyCommunicatedToEmployees = randomDataGenerator.GenerateRandomAlphabeticString(20);
            ExampleToImproveEmployees = randomDataGenerator.GenerateRandomAlphabeticString(20);
            ExampleToMaintainEmployees = randomDataGenerator.GenerateRandomAlphabeticString(20);
            HowHasTheTeamOrPersonWorked = randomDataGenerator.GenerateRandomAlphabeticString(20);
        }

        public DateTime Dob(int x) => DateTime.Now.AddYears(-40 + x);
        public string FullName => "George Smith";
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
        public string ManagingRelationshipWithEmployers { get; }
        public string OrganisationPromoteApprenticeships { get; }
        public string OrganisationProcessForInitialTraning { get; }
        public string ProcessToAssessEnglishAndMaths { get; }
        public string ReadytoDeliverTraining { get; }
        public string EngageWithEPAO { get; }
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
        public string GenerateRandomWholeNumber(int length) => randomDataGenerator.GenerateRandomWholeNumber(length);
    }
}
