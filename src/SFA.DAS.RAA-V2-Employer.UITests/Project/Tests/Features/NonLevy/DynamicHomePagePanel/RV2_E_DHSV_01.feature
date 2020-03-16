Feature: RV2_E_DHSV_01
As a Non Levy Employer, I want to add a vacancy after reserves funding from dynamic homepage

Background: 
	Given the user reserves funding from the dynamic home page

@raa-v2
@raa-v2e
@regression
@addpayedetails
Scenario: RV2_E_DHSV_01 Employer creates Submitted vacancy from dynamic homepage journey
	Given the employer continue to add vacancy in the Recruitment 
	When the Employer creates first submitted vacancy 'National Minimum Wage'
	Then the vacancy details is displayed on the Dynamic home page with Status 'PENDING REVIEW'
	And the Employer is able to go back to the Recruitment after clicking 'Go to your vacancy dashboard'
	