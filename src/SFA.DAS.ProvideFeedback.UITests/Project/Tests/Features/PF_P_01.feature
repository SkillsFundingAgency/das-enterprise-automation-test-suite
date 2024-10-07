Feature: PF_P_01

As a Provider, I want to be able to login to view feedback left by Apprentices and Employers

Scenario: PF_P_01 Provider logs in to view feedback
Given the provider has been rated as follows
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
Then their overall score is 'Good'
When they select the tab for the current academic year
Then their score for that year is 'Excellent'
When they select the tab for the previous academic year
Then their score for that year is 'Poor'


