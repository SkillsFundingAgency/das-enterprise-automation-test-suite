using AutoFixture;
using SFA.DAS.EmployerIncentives.PaymentProcessTests.Models;
using System;
using System.Collections.Generic;

namespace SFA.DAS.EmployerIncentives.PaymentProcessTests.Project.Tests.Builders
{
    public class PriceEpisodeDtoBuilder
    {
        private readonly PriceEpisodeDto _data;

        public PriceEpisodeDtoBuilder()
        {
            var fixture = new Fixture();
            _data = fixture.Create<PriceEpisodeDto>();
            _data.Periods = new List<PeriodDto>();
        }

        public PriceEpisodeDto Create() => _data;

        public PriceEpisodeDtoBuilder WithStartDate(in DateTime value)
        {
            _data.StartDate = value;
            return this;
        }

        public PriceEpisodeDtoBuilder WithStartDate(in string value)
        {
            _data.StartDate = DateTime.Parse(value);
            return this;
        }

        public PriceEpisodeDtoBuilder WithEndDate(in DateTime value)
        {
            _data.EndDate = value;
            return this;
        }

        public PriceEpisodeDtoBuilder WithEndDate(in string value)
        {
            _data.EndDate = DateTime.Parse(value);
            return this;
        }

        public PriceEpisodeDtoBuilder WithPeriod(long apprenticeshipId, byte period, bool payable = true)
        {
            _data.Periods.Add(new PeriodDto
            {
                ApprenticeshipId = apprenticeshipId,
                IsPayable = payable,
                Period = period
            });
            return this;
        }
    }
}