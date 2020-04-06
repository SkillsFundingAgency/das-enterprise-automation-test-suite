Feature: RP_SE_01

@rpse01
@roatp
@roatpapply
@roatpse
@regression
Scenario: RP_SE_01_Company- Main
 Given the provider initates an application as main route company
  Then the provider completes Introduction and what you'll need section for main and employer route
    And the provider completes Organisation Information section for company
    And the provider completes Tell us who's in control section
    And the provider completes Describe your organisation section as OrgTypeITP
    And the provider verifies section exemptions   