Feature: RP_Moderation_01

TestDataPreparation for RP_AD_MOD_01_ExistingProvider

@roatpadmintestdataprep
@roatpadminmodtestdataprep
@donottakescreenshot
@rpadmod01
Scenario: RP_Moderation_01A_TestDataPreparation-For_RP_AD_MOD_01_ExistingProvider
	Given the provider naviagate to Admin
	And the Provider is added to the register as Main provider
	And the provider naviagate to Apply 
	And the provider completes the Apply Journey as Main Provider Route For Existing Provider
	And the GateWay user assess the application by confirming Gateway outcome as Pass
	And the Asssesssors assess the application and marks the application as Ready for Moderation
