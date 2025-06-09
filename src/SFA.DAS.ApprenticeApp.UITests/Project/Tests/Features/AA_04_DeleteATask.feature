@ApprenticeApp
@regression
Feature: AA_04_DeleteATask

Apprentice deletes a task

Scenario: AA_04a_Apprentice deletes a Todo task
	Given the apprentice has logged into the app
	When the apprentice clicks on view actions
	And the apprentice clicks on delete and confirms
	Then the task is removed from the list

Scenario: AA_04b_Apprentice deletes a Done task
	Given the apprentice has logged into the app
	When the apprentice has clicked on the done tasks tab
	And the apprentice clicks on view actions
	And the apprentice clicks on delete and confirms
	Then the task is removed from the list
