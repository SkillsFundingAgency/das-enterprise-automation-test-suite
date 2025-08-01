# ToBeMigrated to PlayWright under APPMAN-1769


Feature: AP_Pro_04ProviderFilterAndDownloadApprenticeInCsv

#@approvals
#@regression
@provideraddapprentice
@setdownloadsdirectory
Scenario: AP_Pro_04ProviderFilterAndDownloadApprenticeInCsv
	Given A Provider has navigated to Manage your apprentice page
	When the provider filters by 'Live'
	Then the provider is presented with first page with no filters applied
	And Provider is able to download the results in a csv file
	And Provider can confirm number of rows in Apprentices csv file