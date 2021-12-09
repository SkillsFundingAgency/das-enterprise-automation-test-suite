Feature: RP_GateWayReject_Reapplication_01

@roatpadmintestdataprep
@roatpadminoutcometestdataprep
@donottakescreenshot
@rpadgatewayrejectreapplications01
@roatpoutcome
Scenario: RP_GatewayRejectReapplication_01_TestDataPreparation-For_RP_AD_OUTCOME_Appeals_01
	Given the provider completes the Apply Journey as Main Provider Route
	When the GateWay user assess the application by confirming Gateway outcome as Reject