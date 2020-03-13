Feature: EPAO_AD_Search_02


@epao
@epaoadmin
@regression
Scenario: EPAO_AD_Search_02_Search with Organsiation EPAO Id
	Then the admin can search using organisation epao id
	And the admin can view contact details
	And the admin can view standards details

