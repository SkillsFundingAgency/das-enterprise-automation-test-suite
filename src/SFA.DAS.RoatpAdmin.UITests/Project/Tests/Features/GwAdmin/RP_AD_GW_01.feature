Feature: RP_AD_GW_01

@notestdata
@resetApplicationToNew
@roatp
@roatpadmin
@newroatpadmin
@rpadgw01
@regression
Scenario: RP_AD_GW_01
Given the admin lands on the Dashboard
When the admin access the GatewayApplications
And the gateway admin assess all sections as PASS
Then the gateway admin completes assessment by confirming the Gateway outcome as PASS