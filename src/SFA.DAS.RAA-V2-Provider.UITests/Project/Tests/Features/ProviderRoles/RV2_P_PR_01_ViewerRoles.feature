#@ignore
Feature: RV2_P_PR_01_ViewerRoles

# These tests work with existing data which must have been pre-created, it must include vacancies in
# each of the 5 states, Draft, Pending Review, Rejected, Live and Closed; there must be at least 1 
# application for at least 1 Live and Closed vacancy; all users must currently have an email 
# communication method selected

@Recruitproviderrole
Scenario Outline: Verify a Viewer role is not shown permission denied for edit and submit link
	Given the provider logs in as a Viewer
	And the user can view Draft, Pending, Rejected, Live and Closed vacancies
	Then the user can view previewable <EditAndSubmitAllowed> vacancies via edit and submit link

Examples:
	| EditAndSubmitAllowed |
	| Draft                     |
	| Rejected					|

@Recruitproviderrole
Scenario Outline: Verify a Viewer role is not shown permission denied for manage link
	Given the provider logs in as a Viewer
	And the user can view Draft, Pending, Rejected, Live and Closed vacancies
	Then the user can view <ManageAllowed> vacancies via manage link
	
Examples:
	| ManageAllowed	|
	| PendingReview |
	| Live			|
	| Closed		|

@Recruitproviderrole
Scenario Outline: Verify a Viewer role is not shown permission denied for view applications
	Given the provider logs in as a Viewer
	And the user can view Draft, Pending, Rejected, Live and Closed vacancies
	Then the user can view applications to a <ApplicationsAllowed> vacancy on manage vacancy page

Examples:
	| ApplicationsAllowed	|
	| Live					|
	| Closed				|


@Recruitproviderrole
Scenario Outline: Verify a Viewer role is not shown permission denied for read only actions
	Given the provider logs in as a Viewer
	And the user can view Draft, Pending, Rejected, Live and Closed vacancies
	Then the user can create reports
	And the user can manage thier recruitment emails

@Recruitproviderrole
Scenario Outline: Verify a Viewer role is shown permissison denied for edit and submit modify actions
	Given the provider logs in as a Viewer
	Then the user cannot view non-previewable Draft vacancies via edit and submit link
	And the user cannot create a new vacancy
	And the user cannot edit a <EditAndSubmitNotAllowed> vacancy via edit and submit link
	And the user cannot (re)submit a <EditAndSubmitNotAllowed> vacancy
	And the user cannot delete a <EditAndSubmitNotAllowed> vacancy
	
Examples:
	| EditAndSubmitNotAllowed |
	| Draft          |
	| Rejected       |

@Recruitproviderrole
Scenario Outline: Verify a Viewer role is shown permissison denied for clone via manage link
	Given the provider logs in as a Viewer
	Then the user cannot clone a <ManageNotAllowed> vacancy

Examples:
	| ManageNotAllowed |
	| PendingReview    |
	| Live             |
	| Closed           |

@Recruitproviderrole
Scenario Outline: Verify a Viewer role is shown permissison denied for manage modify actions
	Given the provider logs in as a Viewer
	Then the user cannot edit a Live vacancy via manage link
	And the user cannot close a Live vacancy
	And the user cannot save successful or unsuccessful applications for a Live vacancy