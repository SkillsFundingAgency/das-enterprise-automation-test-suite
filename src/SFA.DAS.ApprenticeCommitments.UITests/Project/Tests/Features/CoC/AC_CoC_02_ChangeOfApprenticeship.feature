Feature: AC_CoC_02_ChangeOfApprenticeship

@apprenticecommitments
@regression
@waitingtostartapprentice
Scenario: AC_CoC_02_ChangeOfApprenticeship
	Given a Course date CoC occurs on an apprenticeship on Employer side
	When the apprentice logs into CMAD again following a CoC
	Then only the apprenticeship detail section is marked as Incomplete
	And the apprentice confirms the Apprenticeship details displayed as Incorrect
	And the coc notification should not be displayed
	And the apprentice is able to review and confirm apprenticeship details section