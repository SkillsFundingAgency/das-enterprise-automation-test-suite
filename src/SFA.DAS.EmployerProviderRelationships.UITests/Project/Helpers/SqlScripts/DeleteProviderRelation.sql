select id into #apids from AccountProviders where Providerukprn=@ukprn and AccountId = @accountid
select id, AccountLegalEntityId into #apleids from AccountProviderLegalEntities where AccountProviderId in (select id from #apids)
delete from permissions where AccountProviderLegalEntityId in (select id from #apleids)
delete from AccountProviderLegalEntities where id in (select id from #apleids)
delete from permissionsaudit where AccountLegalEntityId in (select AccountLegalEntityId from #apleids)
delete from notifications where AccountLegalEntityId in (select AccountLegalEntityId from #apleids)
delete from accountProviders where id in (select id from #apids)
drop table #apids
drop table #apleids
