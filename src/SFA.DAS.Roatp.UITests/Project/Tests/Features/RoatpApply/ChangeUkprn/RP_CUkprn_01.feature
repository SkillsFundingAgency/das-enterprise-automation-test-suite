Feature: RP_CUkprn_01

@rpchangeukprn01
@roatp
@roatpapplychangeukprn
@regression
Scenario: RP_CUkprn_01
    Given the provider initates an application as employer route charity
    When the provider completes Your organisation section for a ukprn
    Then the provider can change ukprn
