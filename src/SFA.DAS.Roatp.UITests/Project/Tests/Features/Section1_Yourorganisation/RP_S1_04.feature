Feature: RP_S1_04


# Organisation Type is An Educational Institute And Type of Educational institue is Higher Eduction Institute
@rps104
@roatp
@regression
Scenario: RP_S1_04_CharityAndCompany - Main - Org AEI - HEI 
	Given the provider initates an application as main route company
	Then the provider completes Introduction and what you'll need section for main and employer route
	And the provider completes Organisation Information section for company
	And the provider completes Tell us who's in control section for charity and company
	And the provider completes Describe your organisation section as OrgTypeAEI
	And the provider completes Experience and Accreditations section by selecting GradeTypeRequiresImprovement
