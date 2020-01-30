Feature: FAA_Login_01
	

@raa-v1
@regression
Scenario: FAA_Login_01 -  Login to FAA with Unactivated registered Email
	Given an Applicant initiates Account creation journey
	Then Applicant should be redirected to Activation Page when Login With Unactivated email
	
	
	
