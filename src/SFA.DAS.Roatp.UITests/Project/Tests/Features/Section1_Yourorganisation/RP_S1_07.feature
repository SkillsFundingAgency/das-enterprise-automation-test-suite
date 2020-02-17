Feature: RP_S1_07

@rps107
@roatp
@regression
Scenario: RP_S1_07_CharityAndCompany - Main - Org PublicBody - GovtDept - Exempt from FHA
    Given the provider initates an application as main route company
    Then the provider completes Introduction and what you'll need section for main and employer route
    And the provider completes Organisation Information section for company
    And the provider completes Tell us who's in control section for charity and company
    And the provider completes Describe your organisation section as OrgTypePublicBody
    And the provider completes Experience and Accreditations section by selecting No to all
