Feature: EPAO_AD_Search_02


@epao
@epaoadmin
@regression
@clearcontact
@clearstandards
Scenario: EPAO_AD_Search_02_Search with Organsiation EPAO Id add Contact and Standards
	Then the admin can search using organisation epao id
	And the admin can add contact details
	And the admin can add standards details
	And the admin can view standards details
