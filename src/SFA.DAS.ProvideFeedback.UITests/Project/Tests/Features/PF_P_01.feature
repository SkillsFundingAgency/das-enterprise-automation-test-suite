Feature: PF_P_01

As a Provider, I want to be able to login to view feedback left by Apprentices and Employers

@regression
@donotexecuteinparallel
Scenario: PF_P_01 Provider logs in to view feedback from apprentices when the minimum number of reviews has not been reached
Given the provider has been rated by apprentices as follows
	| AcademicYear | Rating    |
	| Current      | Excellent |
	| Current      | VeryPoor  |
	| Current      | Excellent |
	| Current      | Good      |
When The provider logs in to the provider portal
And the provider opts to view their feedback
Then they see the following text: "You'll see apprentice reviews after at least 5 apprentices give feedback during an academic year."

@regression
@donotexecuteinparallel
Scenario: PF_P_02 Provider logs in to view feedback from apprentices
Given the provider has been rated by apprentices as follows
	| AcademicYear | Rating    |
	| Current      | Excellent |
	| Current      | Excellent |
	| Current      | Excellent |
	| Current      | Good      |
	| Current      | Good      |
	| Previous     | Excellent |
	| Previous     | Excellent |
	| Previous     | Excellent |
	| Previous     | Good      |
	| Previous     | Poor      |
When The provider logs in to the provider portal
And the provider opts to view their feedback
Then their overall apprentice feedback score is 'Excellent'
When they select the apprentice feedback tab for the current academic year
Then their apprentice feedback score for that year is 'Excellent'
When they select the apprentice feedback tab for the previous academic year
Then their apprentice feedback score for that year is 'Good'

@regression
@donotexecuteinparallel
Scenario: PF_P_03 Provider logs in to view feedback from employers when the minimum number of reviews has not been reached
Given the provider has been rated by employers as follows
	| AcademicYear | Rating    |
When The provider logs in to the provider portal
And the provider opts to view their feedback
Then they see the following text: "There are no employer reviews for this period of time."

@regression
@donotexecuteinparallel
Scenario: PF_P_04 Provider logs in to view feedback from employers
Given the provider has been rated by employers as follows
	| AcademicYear | Rating    |
	| Current      | Excellent |
	| Current      | Excellent |
	| Current      | Excellent |
	| Current      | Good      |
	| Current      | Poor      |
	| Previous     | Excellent |
	| Previous     | Excellent |
	| Previous     | Excellent |
	| Previous     | Good      |
	| Previous     | Poor      |
When The provider logs in to the provider portal
And the provider opts to view their feedback
Then their overall employer feedback score is 'Excellent'
When they select the employer feedback tab for the current academic year
Then their employer feedback score for that year is 'Good'
When they select the employer feedback tab for the previous academic year
Then their employer feedback score for that year is 'Excellent'