Feature: EPAO_AD_ReprintCert_02

@epao
@recordagrade
@epaoadmin
@regression
Scenario: EPAO_AD_ReprintCert_02 Amend a Certificate - Change SendTo
	Given the Assessor User is logged into Assessment Service Application
	And the User certifies an Apprentice as 'pass' with 'employer' route and records a grade
	And the certificate is printed
	And the Admin all roles user is logged into the Admin Service Application 
	And the Admin can search using learner uln
	When the Admin reprints the certificate with ticket reference 'INC123456' and selects reason 'Delivery failed'
	Then the SendTo can be changed from 'employer' to 'apprentice'
	And the new address can be entered without employer name or recipient
	And the recipient is defaulted to the apprentice name
	