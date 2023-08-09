Feature: AP_DO_01_ULN Overlap_Provider
OLTD release 2 (overlapping regression)

@approvals
@regression
@liveapprentice
Scenario: AP_DO_01_ULN Overlap_Provider
	Given a live apprentice record exists with startdate of <-6> months and endDate of <+6> months from current date
	When Provider tries to add a new apprentice using details from table below
	| NewStartDate	 | NewEndDate	| DisplayOverlapErrorOnStartDate   | DisplayOverlapErrorOnEndDate 	|
	| -12		     | +0		    | false				               | true				            |
	| -3		     | +3		    | true			                   | true				            |
	| -12		     | +12		    | true					           | true				            |
	| +6		     | +18		    | false					           | false				            |
	#Then Display ULN Overlap error as per above table


#Note: all above dates use datetime.now as the reference date