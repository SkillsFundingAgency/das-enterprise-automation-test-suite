DECLARE @empaccountid bigint; set @empaccountid = @accountid

select id into #incentiveapplicationids from dbo.IncentiveApplication where AccountId = @empaccountid
select id into #incentiveapplicationapprenticeshipids from dbo.IncentiveApplicationApprenticeship where IncentiveApplicationId in (select id from #incentiveapplicationids)
select id into #pendingpaymentids from incentives.PendingPayment where AccountId = @empaccountid

Delete from [incentives].[Payment] WHERE accountId = @empaccountid;
Delete from [incentives].[PendingPaymentValidationResult] where PendingPaymentId in (select id from #pendingpaymentids)
Delete from [incentives].[PendingPayment] WHERE accountId = @empaccountid;
Delete from [incentives].[ApprenticeshipIncentive] WHERE accountId = @empaccountid;
Delete from [dbo].[IncentiveApplicationStatusAudit] where IncentiveApplicationApprenticeshipId in (select id from #incentiveapplicationapprenticeshipids)
Delete from [dbo].[IncentiveApplicationApprenticeship] where IncentiveApplicationId in (select id from #incentiveapplicationids)
Delete from [dbo].[IncentiveApplication] WHERE accountId = @empaccountid