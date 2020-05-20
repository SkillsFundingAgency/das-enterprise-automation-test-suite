Feature: FAA_Login_01

@raa-v1
@regression
@FAALoginNewCredentials
Scenario: FAA_Login_01 -  Login to FAA with Unactivated registered Email
	When an Applicant initiates Account creation journey
	Then Applicant is redirected to Activation Page when Login With Unactivated email