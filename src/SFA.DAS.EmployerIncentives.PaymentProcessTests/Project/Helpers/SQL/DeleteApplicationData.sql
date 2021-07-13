delete x from IncentiveApplicationStatusAudit x 
    inner join IncentiveApplicationApprenticeship a on x.IncentiveApplicationApprenticeshipId=a.Id
where IncentiveApplicationId=@incentiveApplicationId;

delete from IncentiveApplicationApprenticeship where IncentiveApplicationId=@incentiveApplicationId;

delete from IncentiveApplication where Id=@incentiveApplicationId;