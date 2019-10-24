Feature: NonLevyEmployerDeletesAllUnusedFunding

A Non Levy Employer deletes all unused funding for an apprenticeship course

@regression
@cleanup
Scenario: Non Levy Employer deletes all unused funding
	Given the Employer login using existing eoi account
	When the Employer deletes all unused funding for an apprenticeship course
	Then all the unused funding are successfully deleted