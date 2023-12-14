namespace SFA.DAS.EPAO.UITests.Project.Helpers.DataHelpers
{
    public readonly struct LearnerCriteria(bool isActiveStandard, bool hasMultipleVersions, bool withOptions, bool hasMultiStandards, bool versionConfirmed, bool optionIsSet)
    {
        public readonly bool IsActiveStandard = isActiveStandard;
        public readonly bool HasMultipleVersions = hasMultipleVersions;
        public readonly bool WithOptions = withOptions;
        public readonly bool HasMultiStandards = hasMultiStandards;

        //These latter options dictate data coming from Approvals
        public readonly bool VersionConfirmed = versionConfirmed;
        public readonly bool OptionIsSet = optionIsSet;
    }
}
