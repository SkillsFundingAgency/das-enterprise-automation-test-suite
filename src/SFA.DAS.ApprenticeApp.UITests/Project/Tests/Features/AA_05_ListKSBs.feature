Feature: AA_05_View KSBs

KSBs are listed!

@ApprenticeApp
@regression
Scenario: AA_05_KSBs are listed
	Given the apprentice has logged into the app
	When the apprentice clicks on the KSBs tab
	Then the KSBs are displayed
	
