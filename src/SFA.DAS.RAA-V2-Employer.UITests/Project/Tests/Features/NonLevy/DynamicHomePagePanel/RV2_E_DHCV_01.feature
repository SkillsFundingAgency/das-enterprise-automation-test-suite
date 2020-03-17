Feature: RV2_E_DHCV_01
	As a Non Levy Employer, I want to add a vacancy after reserves funding from dynamic homepage
	
Background: 
	Given the user reserves funding from the dynamic home page
@raa-v2
@raa-v2e
@regression
@addpayedetails
@LoginNewEmployerAccount
@approvalsdatahelpers
Scenario: RV2_E_DHCV_01 Employer creates vacancy from dynamic homepage journey, approve and close vacancy
	Given the employer continue to add vacancy in the Recruitment 
	When the Employer creates first submitted vacancy 'National Minimum Wage'
	And the Reviewer Approves the vacancy
	And the Applicant can apply for a Vacancy in FAA
	And the Employer can close the vacancy
	Then the vacancy details is displayed on the Dynamic home page with Status 'CLOSED'
