select id into #apids from AccountProviders where Providerukprn = @ukprn and AccountId = @accountid
select id, AccountLegalEntityId into #apleids from AccountProviderLegalEntities where AccountProviderId in (select id from #apids)
select id into #requestids from Requests where ukprn = @ukprn and EmployerContactEmail = @empemail
delete from permissions where AccountProviderLegalEntityId in (select id from #apleids)
delete from AccountProviderLegalEntities where id in (select id from #apleids)
delete from permissionsaudit where AccountLegalEntityId in (select AccountLegalEntityId from #apleids)
delete from notifications where AccountLegalEntityId in (select AccountLegalEntityId from #apleids)
delete from notifications where RequestId in (select id from #requestids)
delete from accountProviders where id in (select id from #apids)
delete from PermissionRequests where RequestId in (select id from #requestids)
delete from Requests where id in (select id from #requestids)
drop table #apids
drop table #apleids
drop table #requestids
