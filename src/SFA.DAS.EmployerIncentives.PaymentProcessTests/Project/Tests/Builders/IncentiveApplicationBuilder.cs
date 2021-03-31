using AutoFixture;
using SFA.DAS.EmployerIncentives.PaymentProcessTests.Models;
using System;

namespace SFA.DAS.EmployerIncentives.PaymentProcessTests.Project.Tests.Builders
{
    public class IncentiveApplicationBuilder
    {
        private readonly Fixture _fixture = new Fixture();
        private readonly IncentiveApplication _incentiveApplication;

        public IncentiveApplicationBuilder()
        {
            _incentiveApplication = _fixture.Build<IncentiveApplication>()
                .Without(x => x.Apprenticeships)
                .Create();

        }

        public IncentiveApplicationBuilder WithAccountId(long accountId)
        {
            _incentiveApplication.AccountId = accountId;
            return this;
        }

        public IncentiveApplicationBuilder WithApprenticeship(long apprenticeshipId, long uln, long ukprn,
            DateTime plannedStartDate, DateTime dateOfBirth)
        {
            var apprenticeship = _fixture.Build<IncentiveApplicationApprenticeship>()
                .With(a => a.ApprenticeshipId, apprenticeshipId)
                .With(a => a.ULN, uln)
                .With(a => a.UKPRN, ukprn)
                .With(a => a.IncentiveApplicationId, _incentiveApplication.Id)
                .With(x => x.WithdrawnByCompliance, false)
                .With(x => x.WithdrawnByEmployer, false)
                .With(x => x.WithdrawnByEmployer, false)
                .With(x => x.PlannedStartDate, plannedStartDate)
                .With(x => x.DateOfBirth, dateOfBirth)
                .Create();
            _incentiveApplication.Apprenticeships.Add(apprenticeship);

            return this;
        }

        public IncentiveApplication Create()
        {
            return _incentiveApplication;
        }
    }
}