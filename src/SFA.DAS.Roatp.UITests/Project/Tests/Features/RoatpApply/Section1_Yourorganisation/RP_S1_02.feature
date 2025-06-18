Feature: RP_S1_02

@rps102
@roatp
@roatpapply
@roatps1
@regression
Scenario: RP_S1_02_Company - Main - Org- Independent Training Provider
	Given the provider initates an application as main route company
    Then the provider completes Introduction and what you'll need section for main and employer route
    And the provider completes Organisation Information section for company
    And the provider completes Tell us who's in control section
    And the provider completes Describe your organisation section as OrgTypeITP
    And the provider completes Experience and Accreditations section by selecting No to all