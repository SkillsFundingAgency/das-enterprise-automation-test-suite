Feature: EPAO_AD_Search_02


@epao
@epaoadmin
@regression
@deleteorganisationcontact
@deleteorganisationstandards
Scenario: EPAO_AD_Search_02_Search with Organsiation EPAO Id add Contact
	Then the admin can search using organisation epao id
	And the admin can add contact details
