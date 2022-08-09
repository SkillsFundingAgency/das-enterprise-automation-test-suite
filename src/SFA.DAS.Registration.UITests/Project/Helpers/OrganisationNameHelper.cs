using System.Collections.Generic;

namespace SFA.DAS.Registration.UITests.Project.Helpers
{
    public static class OrganisationNameHelper
    {
        internal static List<CharityTypeOrg> ListOfCharityTypeOrgOrganisation() => new()
        {
            new CharityTypeOrg {Number = "200895", Name = "ALLHALLOWS CHARITY", Address = "WBW Solicitors, 118 High Street, Honiton, EX14 1JP"},
            new CharityTypeOrg {Number = "202918", Name = "OXFAM", Address = "OXFAM, 2700 JOHN SMITH DRIVE, OXFORD BUSINESS PARK SOUTH, OXFORD, OX4 2JY"},
            new CharityTypeOrg {Number = "219348", Name = "CITY HOSPITAL NHS TRUST", Address = "LIFFORD HALL, TUNNEL LANE, KINGS NORTON, BIRMINGHAM, B30 3JN"},
            new CharityTypeOrg {Number = "509965", Name = "Friends of Nottingham University Hospitals NHS Trust", Address = "NOTTINGHAM, NG9 6AS"},
        };

        internal static List<string> ListOfPublicSectorTypeOrganisation() => new()
        {
            "Royal School Hampstead",
            "All Saints Centre",
            "Amersham Family Centre",
            "South Somerset East",
            "South Somerset West",
            "Taunton East",
            "Bromley Cross Start Well Link Site",
            "Barley Fields CC"
        };

        internal static List<string> ListOfCompanyTypeOrganisation() => new()
        {
            "BOOTS UK LIMITED",
            "ODEON CINEMAS LIMITED",
            "VUE ENTERTAINMENT LIMITED",
            "NEXT PLC",
            "MONZO BANK LIMITED",
            "SANTANDER UK PLC",
            "SCREWFIX DIRECT LIMITED",
            "TOOLSTATION LIMITED",
            "WICKES BUILDING SUPPLIES LIMITED",
            "BIRMINGHAM AIRPORT LIMITED",
            "LHR AIRPORTS LIMITED",
            "STANSTED AIRPORT LIMITED",
            "GATWICK AIRPORT LIMITED",
            "COSTCO ONLINE UK LIMITED",
            "COSTCO WHOLESALE UK LIMITED"
        };

        internal static List<string> ListOfListOfCompanyTypeOrganisationForFlexiJobApprentice() => new()
        {
            "FLEXI ACCESS LTD",
            "FLEXI ACCOMMODATION LTD",
            "FLEXI ACCOUNTING SOLUTIONS LTD",
            "FLEXI ADMIN LTD",
            "FLEXI ANALYSIS LTD",
            "FLEXI BILL LIMITED",
            "FLEXI BLOCK SPOT LIMITED",
            "FLEXI BUDGET ROOMS LTD",
            "FLEXI BUILD LIMITED",
            "FLEXI BUSINESS SOLUTIONS LIMITED",
            "FLEXI BUSINESS SUPPORT LIMITED",
            "FLEXI CAD HITEC LTD",
            "FLEXI CAPITAL LTD",
            "FLEXI CAR CONTRACTS LTD",
            "FLEXI CAR SOLUTIONS LTD",
            "FLEXI CAR WASH LTD",
            "FLEXI CARE SOLUTIONS LTD",
            "FLEXI CHEF LIMITED",
            "FLEXI CHARTER LIMITED",
            "FLEXI CLEAN GROUP LTD"
        };
    }
}
