Feature: RP_Clarification_01

TestDataPreparation for RP_AD_CLA_01

@roatpadmintestdataprep
@roatpadminclatestdataprep
@donottakescreenshot
@rpadcla01
Scenario: RP_Clarification_01_TestDataPreparation-For_RP_AD_CLA_01
	Given the provider completes the Apply Journey as Main Provider Route
	And the GateWay user assess the application by confirming Gateway outcome as Pass
	And the Asssesssors assess the application and marks the application as Ready for Moderation
	And the Moderation user assess the application and marks every section as Fail and outcome As Clarification
