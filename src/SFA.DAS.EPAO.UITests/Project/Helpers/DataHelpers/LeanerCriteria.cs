namespace SFA.DAS.EPAO.UITests.Project.Helpers.DataHelpers
{
    public struct LeanerCriteria
    {
        public readonly bool IsActiveStandard;
        public readonly bool HasMultipleVersions;
        public readonly bool WithOptions;
        public readonly bool HasMultiStandards;

        public LeanerCriteria(bool isActiveStandard, bool hasMultipleVersions, bool withOptions, bool hasMultiStandards)
        {
            IsActiveStandard = isActiveStandard; HasMultipleVersions = hasMultipleVersions; WithOptions = withOptions; HasMultiStandards = hasMultiStandards;
        }
    }
}
