Feature: AC_COC_01_ChangeOfEmployer

@apprenticecommitments
@regression
@changeOfEmployer
@liveapprentice
Scenario: AC_COC_01_ChangeOfEmployer
	Given an apprenticeship has new employer
	When the apprentice logs into the Apprentice portal
	Then only the employer and apprenticeship detail sections should be marked as Incomplete
	And the apprentice is able to review and confirm employer and apprenticeship details section
	