Feature: RP_S1_09

@rps109
@roatp
@roatpapply
@roatps1
@regression
# Organisation Type is An Educational Institute And Type of Educational institue is  Academy
Scenario: RP_S1_09_CharityAndCompany - Supporting - Org Multiacademy
	Given the provider initates an application as supporting route
	Then the provider completes Introduction and what you'll need content for supporting route
	And the provider completes Organisation Information section for company
	And the provider completes Tell us who's in control section for charity and company
	And the provider completes Describe your organisation section
	And the provider completes Experience and Accreditations section by selecting Yes to Subcontractor training
	And the provider verifies Financial Section Status as not required
