@approvals
Feature: NonLevyEmployerReservesFunding

A Non Levy Employer reserves funding for an apprenticeship course

@inprogress
@reservefunds
Scenario: Non Levy Employer reserves funding
	Given the Employer login using existing eoi account
	When the Employer reserves funding for an apprenticeship course
	Then the funding is successfully reserved
	And the funding can be deleted