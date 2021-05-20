  WITH StandardsList
  AS
  (
  SELECT LarsCode StdCode, MAX(Title) StandardName
  , CASE WHEN count(*) > 1 THEN 1 ELSE 0 END Has_versions
  , CASE WHEN SUM(version_active) > 1 THEN 1 ELSE 0 END Has_active_versions
  , CASE WHEN Sum(version_active) = COUNT(*) THEN 1 ELSE 0 END All_versions_active
  , CASE WHEN SUM(Options) = 0  THEN 0 ELSE 1 END Has_options
  ,MAX(standard_Active) Standard_active
FROM (
  SELECT osv.StandardUId, os.StandardCode as LarsCode, s.Title, s.Level, s.IFateReferenceNumber, s.Version, case when so1.options is null then 0 else so1.options end Options
,case when  (osv.EffectiveTo IS NULL OR osv.EffectiveTo > GETDATE() AND osv.Status = 'Live') THEN 1 ELSE 0 END version_Active
,case when  (os.EffectiveTo IS NULL OR os.EffectiveTo > GETDATE() AND os.status = 'Live')  THEN 1 ELSE 0 END standard_Active
FROM [dbo].[OrganisationStandardVersion] osv
JOIN [dbo].[OrganisationStandard] os on osv.OrganisationStandardId = os.Id
JOIN [dbo].[Organisations] o on os.EndPointAssessorOrganisationId = o.EndPointAssessorOrganisationId 
AND o.EndPointAssessorOrganisationId = (select EndPointAssessorOrganisationId from Contacts where email = @endPointAssessorEmail)
JOIN [dbo].[Standards] s on osv.StandardUId = s.StandardUId
LEFT JOIN ( SELECT COUNT(*) options, [StandardUId] from [Standardoptions] GROUP BY [StandardUId] ) so1 on so1.[StandardUId] = osv.[StandardUId]
) _ GROUP BY LarsCode
),
learner
AS
(
select count (StdCode) OVER (PARTITION BY uln, GivenNames, FamilyName) multi, uln, stdcode, familyname, GivenNames from ilrs
)
SELECT TOP 1
learner.uln, learner.stdcode, StandardName, GivenNames, familyname FROM StandardsList
JOIN  learner on learner.stdcode = StandardsList.stdcode
LEFT JOIN [dbo].[certificates] ce1 on ce1.uln=learner.uln and ce1.StandardCode = learner.stdcode
WHERE 1=1
AND standard_Active = __Isactivestandard__
AND Has_versions = __HasVersions__
AND Has_options = __HasOptions__     
AND multi = 1           
AND ce1.id IS NULL
and learner.uln is not null and GivenNames is not null and FamilyName is not null order by Newid() desc

-- set __Isactivestandard__ to 1 for active standards, 0 for inactive standards
-- set __HasVersions__ to 1 for standards with versions, 0 for standards with just one version, "1.0"
-- set __HasOptions__ to 1 for standards with options, 0 for standards without options
-- set to ce1.id "IS NULL" to get learner(s) without certificates, or "IS NOT NULL" to get learner(s) with certificate