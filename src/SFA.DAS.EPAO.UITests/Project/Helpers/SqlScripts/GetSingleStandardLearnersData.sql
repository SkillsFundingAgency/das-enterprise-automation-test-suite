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
) ab1 GROUP BY LarsCode
)
--
SELECT TOP 1 * FROM (
SELECT il1.ULN,familyname
    , min(il1.stdcode) "StdCode#1", (SELECT MAX(title) from standards WHERE larscode = min(il1.stdcode)) "Title#1"
    , min([LearnStartDate]) "LearnStartDate#1"
	, max(il1.stdcode) "StdCode#2", (SELECT MAX(title) from standards WHERE larscode = max(il1.stdcode)) "Title#2"
	, max([LearnStartDate]) "LearnStartDate#2", count(*) howmany
	, sum(case when ce1.id is null then 0 else 1 end) certs
    , sum(case when ce1.id is null then 0 else (case when ce1.status = 'Draft' THEN 0 ELSE 1 end) end) certs_submitted
	, MAX(EpaOrgId) EpaOrgId
	, MAX(CASE WHEN VersionConfirmed = 1 THEN 1 ELSE 0 END) VersionIsConfirmed
    , MAX(CASE WHEN ISNULL(CourseOption,'') = '' THEN 0 ELSE 1 END ) OptionIsSet 

FROM Learner il1
left join certificates ce1 on ce1.uln = il1.uln and ce1.StandardCode = il1.stdcode 
join StandardsList st1 on st1.StdCode = il1.StdCode
WHERE 1=1 
AND standard_Active = __Isactivestandard__
AND Has_versions = __HasVersions__
AND Has_options = __HasOptions__
AND learner.ULN not in (__InUseUln__)
AND ce1.id IS NULL       
GROUP BY il1.ULN,il1.familyname
HAVING  
MAX(CASE WHEN VersionConfirmed = __VersionConfirmed__ THEN 1 ELSE 0 END) = 1   -- Version is/isn't confirmed
AND 
MAX(CASE WHEN ISNULL(CourseOption,'') = '' THEN 0 ELSE 1 END ) = __OptionSet__  -- option is/isn't set
--HAVING COUNT(*) > 1      -- set to >1 for learners with more than one standard, =1 for learners with just one standard
) ab1
-- set __Isactivestandard__ to 1 for active standards, 0 for inactive standards
-- set __HasVersions__ to 1 for standards with versions, 0 for standards with just one version, "1.0"
-- set __HasOptions__ to 1 for standards with options, 0 for standards without options
-- set to ce1.id "IS NULL" to get learner(s) without certificates, or "IS NOT NULL" to get learner(s) with certificate

