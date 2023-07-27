Feature: RP_AD_REPORT_01

#Bug raised CSP-920 Will remove the tag once the bug is fixed
@ignore
@roatp
@newroatpadmin
@newroatpadminreporting
@regression
Scenario: RP_AD_REPORT_01_Download List of Training Providers and Application data
	Given the admin lands on the Dashboard
	Then the admin can download list of apprenticeship training providers
	And the admin can download the application data
	And the admin can download all current finance applications