Feature: AC_CoC_01_PositiveCoCJourney

@apprenticecommitments
@regression
@waitingtostartapprentice
Scenario: AC_CoC_01_PositiveCoCJourney
	Given a Course date CoC occurs on an apprenticeship on Employer side
	When the apprentice logs into the Apprentice portal
	Then the apprenticeship details section on the overview page is marked as Incomplete
	And the apprentice is able to review and confirm apprenticeship details section