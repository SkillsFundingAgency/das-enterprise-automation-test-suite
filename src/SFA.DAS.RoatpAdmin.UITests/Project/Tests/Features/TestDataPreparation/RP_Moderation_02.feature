Feature: RP_Moderation_02

TestDataPreparation for RP_AD_MOD_02

@roatpadmintestdataprep
@roatpadminmodtestdataprep
@donottakescreenshot
@rpadmod02
Scenario: RP_Moderation_02_TestDataPreparation-For_RP_AD_MOD_01
	Given the provider completes the Apply Journey as Employer Provider Route
	And the GateWay user assess the application by confirming Gateway outcome as Pass
	And the Asssesssors assess the application and marks the application as Ready for Moderation
