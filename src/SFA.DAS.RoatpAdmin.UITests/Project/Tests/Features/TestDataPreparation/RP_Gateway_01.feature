Feature: RP_Gateway_01

TestDataPreparation for RP_AD_GW_01_MainRoute_Company_ExistingProvider

@roatpadmintestdataprep
@roatpadmingwtestdataprep
@donottakescreenshot
@rpadgw01
Scenario: RP_Gateway_01_TestDataPreparation-For_RP_AD_GW_01_MainRoute_Company_ExistingProvider
    Given the Provider is added to the register as Main provider
	And the provider naviagate to Apply
	Given the provider completes the Apply Journey as Main Provider Route For Existing Provider
