Feature: RP_S1_08

@rps108
@roatp
@roatps1
@regression
Scenario: RP_S1_08_Company - Main - Org- ITP - Meeting All Ofstead Requirements
    Given the provider initates an application as main route company
    Then the provider completes Introduction and what you'll need section for main and employer route
    And the provider completes Organisation Information section for company
    And the provider completes Tell us who's in control section
    And the provider completes Describe your organisation section as OrgTypeITP
    And the provider completes Experience and Accreditations section by meeting all Ofsted Requirements
