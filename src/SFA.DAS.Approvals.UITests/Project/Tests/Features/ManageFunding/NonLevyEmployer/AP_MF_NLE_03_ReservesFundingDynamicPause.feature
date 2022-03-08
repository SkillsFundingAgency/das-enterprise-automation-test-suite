Feature: AP_MF_NLE_03_ReservesFundingDynamicPause
A Non Levy Employer reserves funding for an apprenticeship course when dymamic pause rule exists


@approvals
@regression
@reservefunds
@donotexecuteinparallel
Scenario: AP_MF_NLE_03 Non Levy Employer reserves funding when dynamic pause rule exists
	Given the Employer logins using existing NonLevy Account
	And a dynamic pause rule exists from <MonthActiveFrom> to <MonthActiveTo>
	When the Employer creates a reservation
	Then the Employer is told that funding can be reserved from <ReserveFrom> 
	And the Employer is given options <FirstMonth>, <SecondMonth> and <ThirdMonth> to select start date
	And the Employer is <ReserveAllowed> to reserve funding for an apprenticeship course

Examples:
	| MonthActiveFrom | MonthActiveTo | FirstMonth | SecondMonth | ThirdMonth | ReserveFrom | ReserveAllowed |
	| 0               | 3             |            |             |            | 3           | not able       |
	| -1              | 2             | 2          |             |            | 2           | able           |
	| -2              | 1             | 1          | 2           |            | 1           | able           |
	| -3              | 0             | 0          | 1           | 2          |             | able           |

# MonthActiveFrom and MonthActiveTo are the first day of the month e.g. MonthActiveFrom = 0 is the 1st day 
# of the current month and MonthActiveTo = 3 is the first day of 3rd month from now; when start months
# are suggested they include the current month and the following 2 months so in the first example there are no 
# start months suggested and no reservation can therefore be made