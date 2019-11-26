Feature: RV1_FCA_01

@raa-v1
@regression
Scenario: RV1_FCA_01 - Create a FAA Account
	When an Applicant initiates Account creation journey
	Then the Applicant is able to create a FAA Account