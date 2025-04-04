Feature: Add a task

Apprentice adds a task

@ApprenticeApp
@regression
Scenario: Apprentice user adds a task
	Given the apprentice has logged into the app
	When the apprentice adds a new task
	Then the task is added to the task list
