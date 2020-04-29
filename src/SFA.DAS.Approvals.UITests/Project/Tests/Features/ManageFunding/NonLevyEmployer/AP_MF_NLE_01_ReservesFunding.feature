@approvals
Feature: AP_MF_NLE_01_ReservesFunding
A Non Levy Employer reserves funding for an apprenticeship course


@regression
@reservefunds
Scenario: AP_MF_NLE_01 Non Levy Employer reserves funding
	Given the Employer logins using existing NonLevy Account
	When the Employer reserves funding for an apprenticeship course
	Then The funding is successfully reserved