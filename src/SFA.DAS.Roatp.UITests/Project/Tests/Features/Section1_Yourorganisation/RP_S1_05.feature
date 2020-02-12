Feature: RP_S1_05

@rps105
@roatp
@regression
Scenario: RP_S1_05_Government Statute - Employer - ShortOfsteadInspection
    Given the provider initates an application as employer route charity
    Then the provider completes Introduction and what you'll need section for main and employer route
    And the provider completes Organisation Information section for charity
    And the provider completes Tell us who's in control section for Government Statue
    And the provider completes Describe your organisation section 
    And the provider completes Experience and Accreditations section by selecting GradeOutstanding
