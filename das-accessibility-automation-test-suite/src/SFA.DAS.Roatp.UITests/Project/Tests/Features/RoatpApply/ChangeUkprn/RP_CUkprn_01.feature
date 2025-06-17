Feature: RP_CUkprn_01

@rpchangeukprn01
@roatp
@roatpapplychangeukprn
@regression
Scenario: RP_CUkprn_01
    Given the provider initates an application as employer route
    When the provider completes Your organisation section using an ukprn
    Then the provider should be able to change the ukprn
