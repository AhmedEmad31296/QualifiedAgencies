using Abp.Domain.Repositories;

using Microsoft.EntityFrameworkCore;

using QualifiedAgencies.Entities;
using QualifiedAgencies.Lookups.Dto;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QualifiedAgencies.Lookups
{
    public class LookupsAppService : QualifiedAgenciesAppServiceBase, ILookupsAppService
    {
        private readonly IRepository<ActivityType, long> _ActivityTypeRepository;
        private readonly IRepository<Activity, long> _ActivityRepository;
        private readonly IRepository<Area, long> _AreaRepository;
        public LookupsAppService(IRepository<Activity, long> ActivityRepository, IRepository<ActivityType, long> ActivityTypeRepository, IRepository<Area, long> AreaRepository)
        {
            _ActivityTypeRepository = ActivityTypeRepository;
            _ActivityRepository = ActivityRepository;
            _AreaRepository = AreaRepository;
        }

        public async Task<List<CustomLookupsDto>> GetActivityTypes()
        {
            List<CustomLookupsDto> activityTypes = await _ActivityTypeRepository
                .GetAll()
                .Where(x => !x.IsDeleted)
                .Select(a => new CustomLookupsDto
                {
                    Id = a.Id,
                    Name = a.Name
                }).ToListAsync();
            return activityTypes;
        }
        public async Task<List<CustomLookupsDto>> GetActivities()
        {
            List<CustomLookupsDto> activities = await _ActivityRepository
                .GetAll()
                .Where(x => !x.IsDeleted)
                .Select(a => new CustomLookupsDto
                {
                    Id = a.Id,
                    Name = a.Name
                }).ToListAsync();
            return activities;
        }
        public async Task<List<CustomLookupsDto>> GetAreas()
        {
            List<CustomLookupsDto> areas = await _AreaRepository
                .GetAll()
                .Where(x => !x.IsDeleted)
                .Select(a => new CustomLookupsDto
                {
                    Id = a.Id,
                    Name = a.Name
                }).ToListAsync();
            return areas;
        }
    }
}
