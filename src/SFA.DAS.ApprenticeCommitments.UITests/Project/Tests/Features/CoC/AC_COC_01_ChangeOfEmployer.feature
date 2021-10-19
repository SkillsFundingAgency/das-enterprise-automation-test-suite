Feature: AC_COC_01_ChangeOfEmployer

@apprenticecommitments
@regression
@changeOfEmployer
@liveapprentice
Scenario: AC_COC_01_ChangeOfEmployer
	Given an apprenticeship has new employer
	When the apprentice logs into the Apprentice portal
	Then only employer details section should be marked as Incomplete
	And the apprentice is able to review and confirm apprenticeship details section
	