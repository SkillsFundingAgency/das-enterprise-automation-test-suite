Feature: RP_Assessor_01

TestDataPreparation for RP_AD_AS_01_ExistingProvider

#@roatpadmintestdataprep
#@roatpadminastestdataprep
#@donottakescreenshot
#@rpadas01
#Scenario: RP_Assessor_01_TestDataPreparation-For_RP_AD_AS_01
#	Given the provider completes the Apply Journey as Main Provider Route
#	And the GateWay user assess the application by confirming Gateway outcome as Pass



@roatpadmintestdataprep
@roatpadminastestdataprep
@donottakescreenshot
@rpadas01
Scenario: RP_Assessor_01A_TestDataPreparation-For_RP_AD_AS_01A_ExistingProvider
	Given the Provider is added to the register as Main provider
	And the provider naviagate to Apply 
	Given the provider completes the Apply Journey as Main Provider Route For Existing Provider
	And the GateWay user assess the application by confirming Gateway outcome as Pass
