Feature: RP_S1_06


@rps106
@roatp
@roatps1
@regression
Scenario: RP_S1_06_Company - Main - Org ATA - PGTA
    Given the provider initates an application as main route company
    Then the provider completes Introduction and what you'll need section for main and employer route
    And the provider completes Organisation Information section for company
    And the provider completes Tell us who's in control section
    And the provider completes Describe your organisation section as OrgTypeATP
    And the provider completes Experience and Accreditations section by selecting Yes to PGTA