Feature: RP_Assessor_02

TestDataPreparation for RP_AD_AS_02_ExistingProvider

@roatpfulle2eviaadmintestdataprep
@roatpadmintestdataprep
@roatpadminastestdataprep
@donottakescreenshot
@rpadas02
Scenario: RP_Assessor_02_TestDataPreparation-For_RP_AD_AS_02_ExistingProvider
    Given the Provider is added to the register as Employer provider
 	And the provider naviagate to Apply 
	Given the provider completes the Apply Journey as Employer Provider Route For Existing Provider
	And the GateWay user assess the application by confirming Gateway outcome as Pass
