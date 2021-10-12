namespace SFA.DAS.EPAO.UITests.Project.Helpers.DataHelpers
{
    public struct LeanerCriteria
    {
        public readonly bool IsActiveStandard;
        public readonly bool HasMultipleVersions;
        public readonly bool WithOptions;
        public readonly bool HasMultiStandards;

        //These latter options dictate data coming from Approvals
        public readonly bool VersionConfirmed;
        public readonly bool OptionIsSet;

        public LeanerCriteria(bool isActiveStandard, bool hasMultipleVersions, bool withOptions, bool hasMultiStandards, bool versionConfirmed, bool optionIsSet)
        {
            IsActiveStandard = isActiveStandard; HasMultipleVersions = hasMultipleVersions; WithOptions = withOptions; HasMultiStandards = hasMultiStandards;
            VersionConfirmed = versionConfirmed; OptionIsSet = optionIsSet;
        }
    }
}
