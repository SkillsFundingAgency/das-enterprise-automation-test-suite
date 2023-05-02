Feature: RP_Assessor_03

TestDataPreparation for RP_AD_AS_03_ExistingProvider

@roatpadmintestdataprep
@roatpadminastestdataprep
@donottakescreenshot
@rpadas03
Scenario: RP_Assessor_03_TestDataPreparation-For_RP_AD_AS_03_ExistingProvider
	Given the provider naviagate to Admin
    And the Provider is added to the register as Supporting provider
 	And the provider naviagate to Apply 
	And the provider completes the Apply Journey as Supporting Provider Route For Existing Provider
	And the GateWay user assess the application by confirming Gateway outcome as Pass
