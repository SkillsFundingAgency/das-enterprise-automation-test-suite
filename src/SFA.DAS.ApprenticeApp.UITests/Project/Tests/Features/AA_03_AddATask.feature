@ApprenticeApp
@regression
Feature: AA_03_Add a task

Apprentice adds a task


Scenario: AA_03a_Apprentice adds a to do task
	Given the apprentice has logged into the app
	When the apprentice adds a new to do task
	Then the task is added to the to do tasks list


Scenario: AA_03b_Apprentice adds a done task
	Given the apprentice has logged into the app
	When the apprentice has clicked on the done tasks tab
	And the apprentice adds a new done task
	Then the task is added to the done tasks list

