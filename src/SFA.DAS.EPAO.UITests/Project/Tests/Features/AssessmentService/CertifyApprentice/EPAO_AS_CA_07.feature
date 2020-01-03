Feature: EPAO_AS_CA_07

@epao
@assessmentservice
@regression
Scenario: EPAO_CA_07 - Attempt to certify an Apprentice with Invalid details
	Given the User is logged into Assessment Service Application
	And navigates to Assessment page
	When the User clicks on the continue button 'with out entering Any details'
	Then the 'Family name and ULN missing error' is displayed
	When the User clicks on the continue button 'by entering valid Family name and blank ULN'
	Then the 'ULN missing error' is displayed
	When the User clicks on the continue button 'by entering blank Family name and Valid ULN'
	Then the 'Family name missing error' is displayed
	When the User clicks on the continue button 'by entering valid Family name but ULN less than 10 digits'
	Then the 'ULN validation error' is displayed
	When the User clicks on the continue button 'by entering valid Family name and Invalid ULN'
	Then 'We cannot find the apprentice details' message is displayed