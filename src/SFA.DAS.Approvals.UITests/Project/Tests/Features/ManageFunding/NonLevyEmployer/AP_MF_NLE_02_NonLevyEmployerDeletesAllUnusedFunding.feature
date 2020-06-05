Feature: AP_MF_NLE_02_NonLevyEmployerDeletesAllUnusedFunding
A Non Levy Employer deletes all unused funding for an apprenticeship course

@cleanup
Scenario: AP_MF_NLE_02 Non Levy Employer deletes all unused funding
	Given the Employer logins using existing NonLevy Account
	When the Employer deletes all unused funding for an apprenticeship course
	Then all the unused funding are successfully deleted