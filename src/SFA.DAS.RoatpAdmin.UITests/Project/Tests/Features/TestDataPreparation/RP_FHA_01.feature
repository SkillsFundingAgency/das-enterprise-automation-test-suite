Feature: RP_FHA_01

TestDataPreparation for RP_AD_FHA_01

@roatpadmintestdataprep
@roatpadminfhatestdataprep
@donottakescreenshot
@rpadfha01
Scenario: RP_FHA_01_TestDataPreparation-For_RP_AD_FHA_01
	Given the provider completes the Apply Journey as Supporting Provider Route
	And the GateWay user assess the application by confirming Gateway outcome as Pass
