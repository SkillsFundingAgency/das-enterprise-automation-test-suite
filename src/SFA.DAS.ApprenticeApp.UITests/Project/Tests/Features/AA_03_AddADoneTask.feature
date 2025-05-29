Feature: AA_03_Add a done task

Apprentice adds a done task

@ApprenticeApp
@regression
Scenario: AA_03_Apprentice adds a done task
	Given the apprentice has logged into the app
	When the apprentice has clicked on the done tasks tab
	And the apprentice adds a new done task
	Then the task is added to the done tasks list
