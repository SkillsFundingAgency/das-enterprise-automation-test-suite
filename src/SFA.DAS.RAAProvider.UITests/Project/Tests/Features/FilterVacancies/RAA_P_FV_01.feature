Feature: RAA_P_FV_01

@raa	
@raaprovider
@regression	
Scenario: RAA_P_FV_01 - Provider views Rejected vacancies and receives email notification
	Given the Provider creates a vacancy by using a registered name
	And the Reviewer Refer the vacancy
	Then the provider receives 'rejected vacancy' email notification
	Then Provider can view the refered vacancy
