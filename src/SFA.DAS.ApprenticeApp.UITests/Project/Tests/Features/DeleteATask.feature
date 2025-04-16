Feature: DeleteATask

Apprentice deletes a task

@ApprenticeApp
@regression
Scenario: Apprentice deletes a task
	Given the apprentice has logged into the app
	When the apprentice clicks on view actions
	Then the apprentice clicks on delete and confirms
	And the task is removed from the list
