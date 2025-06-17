Feature: RP_Moderation_03

TestDataPreparation for RP_AD_MOD_03_ExistingProvider

@roatpadmintestdataprep
@roatpadminmodtestdataprep
@donottakescreenshot
@rpadmod03
Scenario: RP_Moderation_03_TestDataPreparation-For_RP_AD_MOD_03_ExistingProvider
	Given the provider naviagate to Admin
    And the Provider is added to the register as Main provider
	And the provider naviagate to Apply 
	And the provider completes the Apply Journey as Supporting Provider Route For Existing Provider
	And the GateWay user assess the application by confirming Gateway outcome as Pass
	And the Asssesssors assess the application and marks the application as Ready for Moderation
