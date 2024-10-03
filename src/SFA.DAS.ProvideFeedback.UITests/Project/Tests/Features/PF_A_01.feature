Feature: PF_A_01

@providefeedback
@regression
@apprenticefeedback
Scenario: PF_A_01 Apprenitce provides feedback for a provider
	Given the apprentice logs into apprentice portal
	And the apprentice is eligible to give feedback on their providers
	And the apprentice has not provided feedback previously
	Then the feedback status shows as Pending
	When apprentice completes the feedback journey for a training provider
	Then the feedback status shows as Submitted

