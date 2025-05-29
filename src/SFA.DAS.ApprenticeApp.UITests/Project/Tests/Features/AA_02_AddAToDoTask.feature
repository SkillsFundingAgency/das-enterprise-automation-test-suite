Feature: AA_02_Add a to do task

Apprentice adds a to do task

@ApprenticeApp
@regression
Scenario: AA_02_Apprentice adds a to do task
	Given the apprentice has logged into the app
	When the apprentice adds a new to do task
	Then the task is added to the to do tasks list
