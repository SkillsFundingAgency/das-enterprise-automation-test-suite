Feature: RP_SE_02

@rpse02
@roatp
@roatpapply
@roatpse
@regression
Scenario: RP_SE_02_CompanyAndCharity_Employer  
    Given the provider initates an application as employer route charity
    Then the provider completes Introduction and what you'll need section for main and employer route
    And the provider completes Organisation Information section for company
    And the provider completes Tell us who's in control section for charity and company
    And the provider completes Describe your organisation section as OrgTypeNoneOfTheAbove
    And the provider verifies section exemptions for employer route