namespace SFA.DAS.CreateAccount.Helpers
{
    public static class ConstantsTimeoutInSeconds
    {
        public const int OneSecond = 1;
        public const int ControlTimeout = 15;
        public const int DefaultTimeout = 20;
    }

    public static class UserAccountConstants
    {
        public const string FirstName = "MA";
        public const string LastName = "Auto_Tester";
        public const string PendingEmail = "MA_Tester_Pending@mailinator.com";
        public const string InvalidEmail = "InvalidEmailFormat";
        public const string ValidAccessCode = "ABC123";
        public const string InvalidAccessCode = "InvalidAccessCode";
        public const string InvalidPassword = "InvalidPassword";
        public const string ValidNewPassword = "Password2";
        public const string TestPayeIdPattern = "easautomationuser";
        public const string ValidPayePassword = "password";
        public const string InvalidPayeId = "Invalid Paye id";
        public const string InvalidPayePassword = "Invalid Paye password";
    }

    public static class CompanyTypeOrgConstants
    {
        public const string CompaniesHouseNumber = "08926277";
        public const string CompanyTypeOrgName = "LYNKMII INTEGRATED SERVICES LIMITED";
        public const string InvalidCompaniesHouseNumber = "\"Invalid number\"";
    }

    public static class PublicSectorOrgConstants
    {
        public const string PublicSectorOrg = "Lawley Primary School";
        public const string PublicSectorOrgWithNoAddress = "Aberdeenshire Council";
        public const string AddressFirstLine = "44 Caerfai Bay Road";
        public const string Country = "GB";
        public const string TownOrCity = "Manchester";
        public const string PostalCode = "M1 1AA";
        public const string CustomOrganizationName = "Custom org";
    }

    public static class CharityOrgConstants
    {
        public const string CharityNumber = "327277";
        public const string CharityOrganizationAddress = "Prospect 8 Leake Street London SE1 7NN";
        public const string NonCharityNumber = "277444";
        public const string NonCharityOrganizationAddress = "44 Caerfai Bay Road Manchester GB M1 1AA";
        public const string AddressFirstLine = "44 Caerfai Bay Road";
        public const string Country = "GB";
        public const string TownOrCity = "Manchester";
        public const string PostalCode = "M1 1AA";
    }

    public static class OrgNotInOrgsDBConstants
    {
        public const string OrganizationName = "\"Invalid Org Name\"";
        public const string AddressFirstLine = "44 Caerfai Bay Road";
        public const string Country = "GB";
        public const string TownOrCity = "Manchester";
        public const string PostalCode = "M1 1AA";
    }
}