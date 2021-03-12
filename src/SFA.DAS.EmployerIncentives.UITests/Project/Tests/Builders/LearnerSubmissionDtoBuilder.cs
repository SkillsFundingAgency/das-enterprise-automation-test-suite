using AutoFixture;
using SFA.DAS.EmployerIncentives.UITests.Models;
using System;
using System.Collections.Generic;

namespace SFA.DAS.EmployerIncentives.UITests.Project.Tests.Builders
{
    public class LearnerSubmissionDtoBuilder
    {
        private readonly LearnerSubmissionDto _data;

        public LearnerSubmissionDtoBuilder()
        {
            var fixture = new Fixture();
            _data = fixture.Create<LearnerSubmissionDto>();
            _data.Training = new List<TrainingDto>
            {
                new TrainingDto
                {
                    Reference = "ZPROG001",
                    PriceEpisodes = new List<PriceEpisodeDto>()
                }
            };
        }

        public LearnerSubmissionDto Create() => _data;

        public LearnerSubmissionDtoBuilder WithStartDate(in DateTime value)
        {
            _data.StartDate = value;
            return this;
        }

        public LearnerSubmissionDtoBuilder WithStartDate(in string value)
        {
            _data.StartDate = DateTime.Parse(value);
            return this;
        }

        public LearnerSubmissionDtoBuilder WithIlrSubmissionDate(in DateTime value)
        {
            _data.IlrSubmissionDate = value;
            return this;
        }

        public LearnerSubmissionDtoBuilder WithIlrSubmissionDate(in string value)
        {
            _data.IlrSubmissionDate = DateTime.Parse(value);
            return this;
        }

        public LearnerSubmissionDtoBuilder WithAcademicYear(in int value)
        {
            _data.AcademicYear = value;
            return this;
        }


        public LearnerSubmissionDtoBuilder WithIlrSubmissionWindowPeriod(in int value)
        {
            _data.IlrSubmissionWindowPeriod = value;
            return this;
        }


        public LearnerSubmissionDtoBuilder WithUkprn(in long value)
        {
            _data.Ukprn = value;
            return this;
        }

        public LearnerSubmissionDtoBuilder WithUln(in long value)
        {
            _data.Uln = value;
            return this;
        }

        public LearnerSubmissionDtoBuilder WithPriceEpisode(in PriceEpisodeDto value)
        {
            _data.Training[0].PriceEpisodes.Add(value);
            return this;
        }
    }
}