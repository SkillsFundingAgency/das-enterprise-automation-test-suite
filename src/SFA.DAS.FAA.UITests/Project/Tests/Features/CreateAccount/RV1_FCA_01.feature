Feature: FAA_CA_01

@raa-v1
@regression
Scenario: FAA_CA_01 - Create an FAA Account with Registerd Email
	When an Applicant initiates Account creation journey
	Then the Applicant should be told that Email is already registered
	