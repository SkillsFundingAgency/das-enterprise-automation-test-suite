@approvals
Feature: AP_MF_NLE_02_ReservesFunding

A Non Levy Employer reserves funding for an apprenticeship course

@regression
@reservefunds
Scenario: AP_MF_NLE_02 Non Levy Employer reserves funding
	Given the Employer login using existing eoi account
	When the Employer reserves funding for an apprenticeship course
	Then the funding is successfully reserved
	And the funding can be deleted