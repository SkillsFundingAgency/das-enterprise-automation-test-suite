Feature: RP_Clarification_02

TestDataPreparation for RP_AD_CLA_02_ExistingProvider

@roatpadmintestdataprep
@roatpadminclatestdataprep
@donottakescreenshot
@rpadcla02
Scenario: RP_Clarification_02_TestDataPreparation-For_RP_AD_CLA_02_ExistingProvider
	Given the provider naviagate to Admin
    And the Provider is added to the register as Main provider
	And the provider naviagate to Apply
	And the provider completes the Apply Journey as Employer Provider Route For Existing Provider
	And the GateWay user assess the application by confirming Gateway outcome as Pass
	And the Asssesssors assess the application and marks the application as Ready for Moderation
	And the Moderation user assess the application and marks few section as Fail and outcome As Clarification