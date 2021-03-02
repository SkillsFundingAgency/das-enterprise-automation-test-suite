Feature: RP_Outcome_01

@roatpadmintestdataprep
@roatpadminoutcometestdataprep
@donottakescreenshot
@rpadoutcome01
Scenario: RP_Outcome_01_TestDataPreparation-For_RP_AD_OUTCOME_01
	Given the provider completes the Apply Journey as Main Provider Route
	When the GateWay user assess the application by confirming Gateway outcome as Pass
	And the Financial user assess the application by confirming Finance outcome as Outstanding
	And the Asssesssors assess the application and marks the application as Ready for Moderation
	Then the Moderation user assess the application and marks outcomes as Pass
