namespace SFA.DAS.RAA_V1.UITests.Project.Helpers
{
    public static class EnumHelper
    {
        public enum OrgType
        {
            Company,
            Charity,
            Charity2,
            PublicSector,
            Default
        }

        public enum AornErrors
        {
            BlankAornAndBlankPaye,
            BlankAornValidPaye,
            BlankPayeValidAorn,
            InvalidAornAndInvalidPaye
        }
    }
}
