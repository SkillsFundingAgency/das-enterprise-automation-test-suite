Feature: RP_GateWayFail_Appeals_01

@roatpadmintestdataprep
@roatpadminoutcometestdataprep
@donottakescreenshot
@rpadgatewayfailappeals01
@roatpoutcome
Scenario: RP_GatewayFailAppeals_01_TestDataPreparation-For_RP_AD_OUTCOME_Appeals_01
	Given the provider naviagate to Apply
	And the provider completes the Apply Journey as Main Provider Route
	When the GateWay user assess the application by confirming Gateway outcome as Fail