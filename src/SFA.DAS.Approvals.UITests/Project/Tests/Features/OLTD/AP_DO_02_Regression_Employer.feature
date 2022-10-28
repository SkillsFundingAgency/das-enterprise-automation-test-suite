Feature: AP_DO_02_Regression_Employer
OLTD release 2 (overlapping regression)

@approvals
@regression
Scenario: AP_DO_02_Regression_Employer
	Given a live apprentice record exists with <startDate> and <endDate>
	| startDate	| endDate	| newStartDate	 | newEndDate	| displayOverlapErrorOnStartDate   | displayOverlapErrorOnEndDate 	|
	| -6		| +6		| -12		     | +0		    | true				               | false				            |
	| -6 		| +6		| -3		     | +3		    | true			                   | true				            |
	| -6		| +6		| -12		     | +12		    | true					           | true				            |
	| -6		| +6		| +6		     | +18		    | false					           | false				            |
	When an employer tries to create a new cohort using same ULN but course dates as <newStartDate> and <newEndDate>
	Then displayOverlapErrorOnStartDate
	And displayOverlapErrorOnEndDate