Feature: RV2_E_DHSRV_01
As a Non Levy Employer, I want to add a vacancy after reserves funding from dynamic homepage

Background: 
	Given the user reserves funding from the dynamic home page

@raa-v2
@raa-v2e
@regression
@addpayedetails
Scenario: RV2_E_DHSV_01 Employer creates Submitted vacancy from dynamic homepage journey and rejects the vacancy
	Given the employer continue to add vacancy in the Recruitment 
	When the Employer creates first submitted vacancy 'National Minimum Wage'
	Then the vacancy details is displayed on the Dynamic home page with Status 'PENDING REVIEW'
	Given the Reviewer Refer the vacancy
	And the Employer logs into Employer account
	Then the vacancy details is displayed on the Dynamic home page with Status 'REJECTED'	