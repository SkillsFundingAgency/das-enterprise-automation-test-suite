Feature: AC_COC_01_ChangeOfEmployer

@apprenticecommitments
@regression
@changeOfEmployer
@liveapprentice
Scenario: AC_COC_01_ChangeOfEmployer
	Given a new apprenticeship is CMAD created and fully confirmed that undergoes a Change of Employer
	When the apprentice logs into CMAD again following a CoC
	Then only the employer and apprenticeship detail sections should be marked as Incomplete
	And Home page has two cards with one each for current and previous confirmed apprenticeship details
	And the apprentice is able to review and confirm employer and apprenticeship details section