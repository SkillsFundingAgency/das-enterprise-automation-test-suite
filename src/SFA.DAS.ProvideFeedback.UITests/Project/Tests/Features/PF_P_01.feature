Feature: PF_P_01

As a Provider, I want to be able to login to view feedback left by Apprentices and Employers

@regression
Scenario: PF_P_01 Provider logs in to view feedback from apprentices
Given the provider has been rated by apprentices as follows
	| AcademicYear | Rating    |
	| Current      | Excellent |
	| Current      | Excellent |
	| Current      | Excellent |
	| Current      | Excellent |
	| Current      | Excellent |
	| Previous     | Poor      |
	| Previous     | Poor      |
	| Previous     | Poor      |
	| Previous     | Poor      |
	| Previous     | Poor      |
When The provider logs in to the provider portal
And the provider opts to view their feedback
Then their overall apprentice feedback score is 'Good'
When they select the apprentice feedback tab for the current academic year
Then their apprentice feedback score for that year is 'Excellent'
When they select the apprentice feedback tab for the previous academic year
Then their apprentice feedback score for that year is 'Poor'

Scenario: PF_P_02 Provider logs in to view feedback from employers
Given the provider has been rated by employers as follows
	| AcademicYear | Rating    |
	| Current      | Poor      |
	| Current      | Poor      |
	| Current      | Poor      |
	| Current      | Poor      |
	| Current      | Poor      |
	| Previous     | Excellent |
	| Previous     | Excellent |
	| Previous     | Excellent |
	| Previous     | Excellent |
	| Previous     | Excellent |
#When The provider logs in to the provider portal
#And the provider opts to view their feedback
#Then their overall employer feedback score is 'Good'