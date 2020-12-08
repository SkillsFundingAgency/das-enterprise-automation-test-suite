Feature: RP_Moderation_03

TestDataPreparation for RP_AD_MOD_03

@roatpadmintestdataprep
@roatpadminmodtestdataprep
@donottakescreenshot
@rpadmod03
Scenario: RP_Moderation_03_TestDataPreparation-For_RP_AD_MOD_03
	Given the provider completes the Apply Journey as Supporting Provider Route
	And the GateWay user assess the application by confirming Gateway outcome as Pass
	And the Asssesssors assess the application and marks the application as Ready for Moderation
