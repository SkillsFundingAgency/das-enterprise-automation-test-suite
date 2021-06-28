Feature: PaymentsProcess
	Test feature to verify the payments process works

@employerincentivesPaymentsProcess
Scenario: Payments are generated
	Given there is a valid learner
	When the payment process is completed
	Then payments exist