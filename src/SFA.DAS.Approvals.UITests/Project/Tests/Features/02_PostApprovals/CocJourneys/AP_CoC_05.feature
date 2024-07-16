Feature: AP_CoC_05

@regression
@liveapprentice
@cocscenarios
@selectstandardwithmultipleoptionsandversions
@postapprovals
Scenario: AP_CoC_05 Employer or Provider cannot make change to cost and course after ILR match on live Apprentice
	Given the Employer has approved apprentice
	Then Employer cannot make changes to cost and course after ILR match
	And Employer can still change course option and version
	Then provider cannot make changes to cost and course after ILR match
	And Provider can still change course option and version
