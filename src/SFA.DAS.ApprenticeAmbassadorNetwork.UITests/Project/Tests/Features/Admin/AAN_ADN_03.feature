Feature:AAN_ADN_03

@aan
@aanadmin
@aanadn01
@regression
Scenario: AAN_ADN_03 admin user filter ambassadors
    Given a super admin logs into the AAN portal
    Then the user should be able to successfully filter ambassadors by status
    And the user should be able to successfully filter ambassadors by regions
    And the user should be able to successfully filter ambassadors by multiple combination of filters
