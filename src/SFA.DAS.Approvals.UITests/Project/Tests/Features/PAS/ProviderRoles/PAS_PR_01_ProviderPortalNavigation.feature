Feature: PAS_PR_01_ProviderPortalNavigation

@approvals
@regression
@pasproviderrole
Scenario Outline: PAS_PR_01_ProviderPortalNavigation
	Given the provider logs in as a <UserRole>
	Then user can access <NotificationSettings> page as defined in the table below
	And user can access <OrgsAndAgreements> page as defined in the table below
	And user can access <Help> page as defined in the table below
	And user can access <Feedback> page as defined in the table below
	And user can access <PrivacyStatement> page as defined in the table below
	And user can access <Cookies> page as defined in the table below
	And user can access <TermsOfUse> page as defined in the table below
	And user can signout from their account 

Examples:
	| UserRole                | NotificationSettings | OrgsAndAgreements | Help | Feedback | PrivacyStatement | Cookies | TermsOfUse |
	| Viewer                  | true                 | true              | true | true     | true             | true    | true       |
	| Contributor             | true                 | true              | true | true     | true             | true    | true       |
	| ContributorWithApproval | true                 | true              | true | true     | true             | true    | true       |
	| AccountOwner            | true                 | true              | true | true     | true             | true    | true       |