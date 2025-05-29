Feature: AA_04_DeleteATask

Apprentice deletes a task

@ApprenticeApp
@regression
Scenario: AA_04_Apprentice deletes a task
	Given the apprentice has logged into the app
	When the apprentice clicks on view actions
	And the apprentice clicks on delete and confirms
	Then the task is removed from the list
