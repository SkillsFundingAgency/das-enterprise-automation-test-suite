Feature: FAA_CA_01

@raa-v1
@regression
Scenario: FAA_CA_01 - Create a FAA Account
	When an Applicant initiates Account creation journey
	Then the Applicant is able to create a FAA Account