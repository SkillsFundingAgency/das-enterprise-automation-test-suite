@employerincentivesPaymentsProcess
@createIncentive
Feature: CreateIncentive
	When an application has been submitted
	Then an apprenticeship incentive is created for each apprentiveship in the applicaiton

Scenario: Incentive application is submitted for withdrawn apprenticeship
	Given an existing withdrawn incentive
	And an employer is re-applying for apprenticeship incentive
	When they submit the application
	Then a new apprenticeship incentive is created
	And original withdrawn incentive is retained
