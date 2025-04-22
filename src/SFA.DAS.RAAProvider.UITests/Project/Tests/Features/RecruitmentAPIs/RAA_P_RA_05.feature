@raa
@raaprovider
@regression
@recruitmentapikey
Feature: RAA_P_RA_05


Scenario: RAA_P_RA_05_01 - Provider views Display advert api from dev hub
	Then the provider views 'Display advert api'

Scenario: RAA_P_RA_05_02 - Provider views Recruitment api from dev hub
	Then the provider views 'Recruitment api'

Scenario: RAA_P_RA_05_03 - Provider signs in to dev hub
	Then the provider signs in to developer hub
	And the provider views 'API List page'