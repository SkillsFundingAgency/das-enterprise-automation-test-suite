#@ignore
Feature: RV2_P_PR_02_NonViewerRoles

# These tests work with existing data which must have been pre-created, it must include vacancies in
# each of the 5 states, Draft, Pending Review, Rejected, Live and Closed; there must be at least 1 
# application for at least 1 Live and Closed vacancy; all users must currently have an email 
# communication method selected


@Recruitproviderrole
Scenario Outline: Verify a non Viewer role is not shown permission denied for edit and submit link
	Given the provider logs in as a <User>
	And the user can view Draft, Pending, Rejected, Live and Closed vacancies
	Then the user can view previewable <EditAndSubmitAllowed> vacancies via edit and submit link

Examples:
	| EditAndSubmitAllowed | User                      |
	| Draft                | Contributor               |
	| Draft                | ContributorWithApproval   |
	| Draft                | AccountOwner              |
	| Rejected             | Contributor               |
	| Rejected             | ContributorWithApproval   |
	| Rejected             | AccountOwner              |

@Recruitproviderrole
Scenario Outline: Verify a non Viewer role is not shown permission denied for manage link
	Given the provider logs in as a <User>
	And the user can view Draft, Pending, Rejected, Live and Closed vacancies
	Then the user can view <ManageAllowed> vacancies via manage link
	
Examples:
	| ManageAllowed	| User                      |
	| PendingReview | Contributor               |
	| PendingReview | ContributorWithApproval   |
	| PendingReview | AccountOwner              |
	| Live          | Contributor               |
	| Live          | ContributorWithApproval   |
	| Live          | AccountOwner              |
	| Closed        | Contributor               |
	| Closed        | ContributorWithApproval   |
	| Closed        | AccountOwner              |

@Recruitproviderrole
Scenario Outline: Verify a non Viewer role is not shown permission denied for view applications
	Given the provider logs in as a <User>
	And the user can view Draft, Pending, Rejected, Live and Closed vacancies
	Then the user can view applications to a <ApplicationsAllowed> vacancy on manage vacancy page

Examples:
	| ApplicationsAllowed | User                      |
	| Live                | Contributor               |
	| Live                | ContributorWithApproval   |
	| Live                | AccountOwner              |
	| Closed              | Contributor               |
	| Closed              | ContributorWithApproval   |
	| Closed              | AccountOwner              |

@Recruitproviderrole
Scenario Outline: Verify a non Viewer role is not shown permission denied for read only actions
	Given the provider logs in as a <User>
	And the user can view Draft, Pending, Rejected, Live and Closed vacancies
	Then the user can create reports
	And the user can manage thier recruitment emails

Examples:
	| User                      |
	| Contributor               |
	| ContributorWithApproval   |
	| AccountOwner              |
	| Contributor               |
	| ContributorWithApproval   |
	| AccountOwner              |

@Recruitproviderrole
Scenario Outline: Verify a non Viewer role is not shown permissison denied for edit and submit modify actions
	Given the provider logs in as a <User>
	Then the user can view non-previewable Draft vacancies via edit and submit link
	And the user can create a new vacancy
	And the user can edit a <EditAndSubmitAllowed> vacancy via edit and submit link
	And the user can (re)submit a <EditAndSubmitAllowed> vacancy
	And the user can delete a <EditAndSubmitAllowed> vacancy
	
Examples:
	| EditAndSubmitAllowed    | User                      |
	| Draft                   | Contributor               |
	| Draft                   | ContributorWithApproval   |
	| Draft                   | AccountOwner              |
	| Rejected                | Contributor               |
	| Rejected                | ContributorWithApproval   |
	| Rejected                | AccountOwner              |

@Recruitproviderrole
Scenario Outline: Verify a non Viewer role is not shown permissison denied for clone via manage link
	Given the provider logs in as a <User>
	Then the user can clone a <ManageAllowed> vacancy

Examples:
	| ManageAllowed	| User                      |
	| PendingReview | Contributor               |
	| PendingReview | ContributorWithApproval   |
	| PendingReview | AccountOwner              |
	| Live          | Contributor               |
	| Live          | ContributorWithApproval   |
	| Live          | AccountOwner              |
	| Closed        | Contributor               |
	| Closed        | ContributorWithApproval   |
	| Closed        | AccountOwner              |

@Recruitproviderrole
Scenario Outline: Verify a non Viewer role is not shown permissison denied for manage modify actions
	Given the provider logs in as a <User>
	Then the user can edit a Live vacancy via manage link
	And the user can close a Live vacancy
	And the user can save successful or unsuccessful applications for a Live vacancy

Examples:
	| User                      |
	| Contributor               |
	| ContributorWithApproval   |
	| AccountOwner              |
	| Contributor               |
	| ContributorWithApproval   |
	| AccountOwner              |