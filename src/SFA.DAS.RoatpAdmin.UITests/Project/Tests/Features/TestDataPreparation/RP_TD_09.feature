Feature: RP_TD_09

TestDataPreparation for RP_AD_MOD_01

@roatpadmintestdataprep
@roatpadminmodtestdataprep
@donottakescreenshot
@rpadmod01
Scenario: RP_TD_06_TestDataPreparation-For_RP_AD_MOD_01
	Given the provider completes the Apply Journey as Main Provider Route
	And the GateWay user assess the application by confirming Gateway outcome as Pass
	And the Asssesssors assess the application and marks the application as Ready for Moderation
