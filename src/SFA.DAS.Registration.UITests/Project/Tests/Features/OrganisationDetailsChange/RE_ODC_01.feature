Feature: RE_ODC_01

@registration
@addpayedetails
Scenario: RE_ODC_01_Create an Employer Account with Company Type Org and verify OrgName change scenario
	Given an Employer Account with Company Type Org is created and agreement is Signed
	When the Employer reviews Agreement page
	Then clicking on 'Update these details' link displays 'Review your details' page showing These details are the same as those previously held
	When the Employer revisits the Agreement page during change in Organisation name scenario
	Then clicking on 'Update these details' link displays 'Review your details' page showing We've retrieved the most up-to-date details we could find for your organisation
	And continuing by choosing 'Update details' option displays 'Details updated' page showing You've successfully updated your organisation details