Feature: RP_FHA_02

TestDataPreparation for RP_AD_FHA_02

@roatpadmintestdataprep
@roatpadminfhatestdataprep
@donottakescreenshot
@rpadfha02
Scenario: RP_FHA_02_TestDataPreparation-For_RP_AD_FHA_02
	Given the provider completes the Apply Journey as Employer Provider Route
	And the GateWay user assess the application by confirming Gateway outcome as Pass
