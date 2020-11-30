Feature: RP_TD_13

TestDataPreparation for RP_AD_CLA_02

@roatpadmintestdataprep
@roatpadminmodtestdataprep
@donottakescreenshot
@rpadmod02
Scenario: RP_TD_13_TestDataPreparation-For_RP_AD_CLA_02
	Given the provider completes the Apply Journey as Employer Provider Route
	And the GateWay user assess the application by confirming Gateway outcome as Pass
	And the Asssesssors assess the application and marks the application as Ready for Moderation
	And the Moderation user assess the application and marks few section as Fail and outcome As Clarification