select id into #appfeedbacktargetid from ApprenticeFeedbackTarget where ApprenticeshipId in (select id from #commitmentsapprenticeshipid)
select id into #appfeedbackresult from ApprenticeFeedbackResult where ApprenticeFeedbackTargetId in (select id from #appfeedbacktargetid);

PRINT 'delete from ProviderAttribute';
delete from ProviderAttribute where ApprenticeFeedbackResultId in (select id from #appfeedbackresult);
PRINT 'delete from ApprenticeFeedbackResult';
delete from ApprenticeFeedbackResult where ApprenticeFeedbackTargetId in (select id from #appfeedbacktargetid);
PRINT 'delete from ApprenticeFeedbackTarget';
delete from ApprenticeFeedbackTarget where ApprenticeshipId in (select id from #commitmentsapprenticeshipid)