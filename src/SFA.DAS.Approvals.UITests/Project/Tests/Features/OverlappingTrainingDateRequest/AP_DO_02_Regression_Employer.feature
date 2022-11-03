Feature: AP_DO_02_Regression_Employer
OLTD release 2 (overlapping regression)

@approvals
@regression
Scenario: AP_DO_02_Regression_Employer
	Given a live apprentice record exists with startdate of <-6> months and endDate of <+6> months from current date
	When Employer tries to add a new apprentice using details from table below
	| NewStartDate | NewEndDate | DisplayOverlapErrorOnStartDate | DisplayOverlapErrorOnEndDate |
	| -12          | +0         | false                          | true                         |
	| -3           | +3         | true                           | true                         |
	| -12          | +12        | true                           | true                         |
	| +6           | +18        | false                          | false                        |