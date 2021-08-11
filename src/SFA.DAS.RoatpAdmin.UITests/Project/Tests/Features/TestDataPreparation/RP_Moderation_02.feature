Feature: RP_Moderation_02

TestDataPreparation for RP_AD_MOD_02_ExistingProvider

@roatpadmintestdataprep
@roatpadminmodtestdataprep
@donottakescreenshot
@rpadmod02
Scenario: RP_Moderation_02_TestDataPreparation-For_RP_AD_MOD_01_ExistingProvider
    Given the Provider is added to the register as Main provider
	And the provider naviagate to Apply 
	Given the provider completes the Apply Journey as Employer Provider Route For Existing Provider
	And the GateWay user assess the application by confirming Gateway outcome as Pass
	And the Asssesssors assess the application and marks the application as Ready for Moderation
