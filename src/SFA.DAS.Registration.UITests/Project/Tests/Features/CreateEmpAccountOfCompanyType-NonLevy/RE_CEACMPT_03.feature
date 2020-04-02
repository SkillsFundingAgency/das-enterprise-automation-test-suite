Feature: RE_CEACMPT_03

@regression
@registration
@addpayedetails
@addanothernonlevypayedetails
Scenario: RE_CEACMPT_03_Validate changing Organisation and PAYE features from Check details page
	When the User is on the 'Check your details' page after adding PAYE and Company Type Org details
	Then the User is able to choose a different Company by clicking on Change Organisation
	Then the User is able to choose a different PAYE scheme by clicking on Change PAYE scheme and complete registation journey