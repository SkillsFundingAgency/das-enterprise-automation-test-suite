Feature: AA_04_View KSBs

KSBs are listed!

@ApprenticeApp
@regression
Scenario: AA_04_KSBs are listed
	Given the apprentice has logged into the app
	When the apprentice clicks on the KSBs tab
	Then the KSBs are displayed
	
