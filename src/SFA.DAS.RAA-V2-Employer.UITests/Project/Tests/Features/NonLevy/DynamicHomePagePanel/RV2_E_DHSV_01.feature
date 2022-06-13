Feature: RV2_E_DHSRV_01
As a Non Levy Employer, I want to add a vacancy after reserves funding from dynamic homepage

@raa-v2
@raa-v2e
@regression
@addnonlevyfunds
Scenario: RV2_E_DHSV_01 Employer creates Submitted vacancy from dynamic homepage journey and rejects the vacancy
	Given The User creates NonLevyEmployer account and sign an agreement
	And the employer reserves funding from the dynamic home page
	And the user waits for 30 seconds
	And the employer continue to add advert in the Recruitment 
	When the Employer creates first submitted advert
	Then the vacancy details is displayed on the Dynamic home page with Status 'PENDING REVIEW'
	And Employer can go to vacancy dashboard
	Given the Reviewer Refer the vacancy
	And the Employer logs into Employer account
	Then the vacancy details is displayed on the Dynamic home page with Status 'REJECTED'	
	And the Employer can review and resubmit the vacancy