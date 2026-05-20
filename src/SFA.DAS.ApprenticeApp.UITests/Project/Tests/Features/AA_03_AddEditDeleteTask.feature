@ApprenticeApp
@regression
Feature: AA_03_TaskAddEditDelete

Apprentice adds a task, edits and then deletes

@tag1
Scenario: AA_03a_Apprentice adds, edits and deletes a Todo task
	Given the apprentice has logged into the app
	When the apprentice adds a new to do task
	And the apprentice clicks on the created task
	And the apprentice clicks on edit task, edits and confirms
	And the apprentice clicks on the created task
	And the apprentice clicks on delete and confirms
	Then the task is removed from the list

Scenario: AA_03b_Apprentice adds, edits and deletes a Done task
	Given the apprentice has logged into the app
	When the apprentice has clicked on the done tasks tab
	And the apprentice adds a new done task
	And the apprentice clicks on the created task
	And the apprentice clicks on edit task, edits and confirms
	And the apprentice clicks on the created task
	And the apprentice clicks on delete and confirms
	Then the task is removed from the list