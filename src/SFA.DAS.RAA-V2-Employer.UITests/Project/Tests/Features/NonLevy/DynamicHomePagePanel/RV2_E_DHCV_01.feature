Feature: RV2_E_DHCV_01
	As a Non Levy Employer, I want to add a vacancy after reserves funding from dynamic homepage
	

@raa-v2
@raa-v2e
@regression
@addpayedetails
@LoginNewEmployerAccount
Scenario: RV2_E_DHCV_01 Employer creates vacancy from dynamic homepage journey, approve and close vacancy
	Given the User creates Employer account and sign an agreement
	When the Employer reserves funding for an apprenticeship course from reserved panel
	Then the funding is successfully reserved
	And the new reserved funding panel is shown to employer on the homepage
	Then the employer continue to add vacancy in the Recruitment 
	Given the Employer creates first submitted vacancy 'National Minimum Wage'
	And the Reviewer Approves the vacancy
	And the Applicant can apply for a Vacancy in FAA
	And the Employer can close the vacancy
	And the vacancy details is displayed on the Dynamic home page with Status 'CLOSED'
	And the Employer is able to go back to the Recruitment after clicking 'application'
