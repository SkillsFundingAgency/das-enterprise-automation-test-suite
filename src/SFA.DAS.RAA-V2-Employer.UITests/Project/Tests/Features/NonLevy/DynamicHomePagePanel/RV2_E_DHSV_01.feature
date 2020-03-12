Feature: RV2_E_DHSV_01
As a Non Levy Employer, I want to add a vacancy after reserves funding from dynamic homepage

Background: 
	Given the User creates Employer account and sign an agreement
	When the Employer reserves funding for an apprenticeship course from reserved panel
	Then the funding is successfully reserved
	And the new reserved funding panel is shown to employer on the homepage

@raa-v2
@raa-v2e
@regression
@addpayedetails
@dynamichomepage
Scenario: RV2_E_DHSV_01 Employer creates Submitted vacancy from dynamic homepage journey
	Given the employer continue to add vacancy in the Recruitment 
	When the Employer creates first submitted vacancy 'National Minimum Wage'
	Then the vacancy details is displayed on the Dynamic home page with Status 'PENDING REVIEW'
	And the Employer is able to go back to the Recruitment after clicking 'Go to your vacancy dashboard'
	