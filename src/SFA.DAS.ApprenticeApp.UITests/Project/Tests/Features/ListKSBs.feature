Feature: ListKSBs

KSBs are listed!

@ApprenticeApp
@regression
Scenario: KSBs are listed
	Given the apprentice has logged into the app
	When the apprentice clicks on the KSBs tab
	Then the KSBs are displayed
	
