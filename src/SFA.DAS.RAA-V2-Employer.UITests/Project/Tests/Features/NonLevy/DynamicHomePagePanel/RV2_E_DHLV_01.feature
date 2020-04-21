Feature: RV2_E_DHLV_01	
	As a Non Levy Employer, I want to add a vacancy after reserves funding from dynamic homepage
	
@raa-v2
@raa-v2e
@regression
@addpayedetails
Scenario: RV2_E_DHLV_01 Employer creates vacancy from dynamic homepage journey and approve	and close vacancy
	Given the user reserves funding from the dynamic home page
	And the employer continue to add vacancy in the Recruitment 
	When the Employer creates first submitted vacancy 'National Minimum Wage'
	And the Reviewer Approves the vacancy
	And the Applicant can apply for a Vacancy in FAA
	Given the Employer logs into Employer account
	Then the vacancy details is displayed on the Dynamic home page with Status 'LIVE'
	And Employer can go to Manage vacancy page
	And the Employer can close the vacancy
	And the vacancy details is displayed on the Dynamic home page with Status 'CLOSED'
	And Employer can go to Manage vacancy page