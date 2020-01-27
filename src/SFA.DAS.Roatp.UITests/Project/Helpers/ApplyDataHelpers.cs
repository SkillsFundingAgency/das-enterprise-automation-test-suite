using SFA.DAS.UI.FrameworkHelpers;

namespace SFA.DAS.Roatp.UITests.Project.Helpers
{
    public class ApplyDataHelpers
    {
        private readonly RandomDataGenerator _randomDataGenerator;
        public ApplyDataHelpers(RandomDataGenerator randomDataGenerator)
        {
            _randomDataGenerator = randomDataGenerator;
            CompanyNumber = randomDataGenerator.GenerateRandomNumber(8);
            CompanyName = $"{CompanyNumber}EnterpriseTestDemo";
            IocNumber = randomDataGenerator.GenerateRandomAlphanumericString(8);
            Website = $"www.company.co.uk";
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
        }

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
        public string GenerateRandomNumber(int length) => _randomDataGenerator.GenerateRandomNumber(length);
        

    }
}
