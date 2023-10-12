using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using Abp.UI;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;

using Newtonsoft.Json;

using QualifiedAgencies.Entities.Dto;
using QualifiedAgencies.Helpers;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Dynamic.Core;
using static QualifiedAgencies.Helpers.Datatable;
using QualifiedAgencies.Common;
using System.Diagnostics.Metrics;
using System.Globalization;

namespace QualifiedAgencies.Entities
{
    public class EligibleEntityAppService : QualifiedAgenciesAppServiceBase, IEligibleEntityAppService
    {
        private readonly IRepository<EligibleEntity, long> _EligibleEntityRepository;
        public EligibleEntityAppService(IRepository<EligibleEntity, long> EligibleEntityRepository)
        {
            _EligibleEntityRepository = EligibleEntityRepository;
        }

        [AbpAllowAnonymous]
        public async Task<DatatableFilterdDto<EligibleEntityPagedDto>> GetPaged(FilterEligibleEntityPagedInput input)
        {
            await SetDeleteAfterExpirationDate();

            IQueryable<EligibleEntity> query = _EligibleEntityRepository.GetAll().Where(e => !e.IsDeleted)
                .WhereIf(input.ActivityTypeId.HasValue, c => c.ActivityTypeId == input.ActivityTypeId)
                ;

            int totalCount = await query.CountAsync();

            query = query
                .WhereIf(!string.IsNullOrEmpty(input.SearchTerm), b => b.Name.ToLower().Contains(input.SearchTerm) ||
                                                                         b.PhoneNumber.Contains(input.SearchTerm) ||
                                                                         b.Email.ToLower().Contains(input.SearchTerm) ||
                                                                         b.Fax.ToLower().Contains(input.SearchTerm) ||
                                                                         b.Activity.Name.ToLower().Contains(input.SearchTerm) ||
                                                                         b.Area.Name.ToLower().Contains(input.SearchTerm))
                ;


            int recordsFiltered = await query.CountAsync();

            // Apply sorting
            if (!string.IsNullOrEmpty(input.SortColumn) && !string.IsNullOrEmpty(input.SortDirection))
            {
                query = query.OrderBy(string.Concat(input.SortColumn, " ", input.SortDirection));
            }

            // Pagination
            List<EligibleEntityPagedDto> eligibleEntities = await query
                .Select(b => new EligibleEntityPagedDto
                {
                    Id = b.Id,
                    Name = b.Name,
                    PhoneNumber = b.PhoneNumber,
                    Email = b.Email,
                    Activity = b.Activity.Name,
                    Category = b.Category,
                    Area = b.Area.Name,
                    Fax = b.Fax,
                    DeletionTime = b.DeletionTime
                })
                //.Skip((input.Page - 1) * input.PageSize)
                //.Take(input.PageSize)
                .Page(input.Page, input.PageSize)
                .ToListAsync();

            return new DatatableFilterdDto<EligibleEntityPagedDto>
            {
                RecordsFiltered = recordsFiltered,
                RecordsTotal = totalCount,
                AaData = eligibleEntities,
                Draw = input.Draw
            };

        }

        [AbpAuthorize]
        public async Task<string> Insert(InsertEligibleEntityInput input)
        {
            bool eligibleEntityIsExisting = await _EligibleEntityRepository.GetAll().Where(b => b.Name.Equals(input.Name)).AnyAsync();
            if (eligibleEntityIsExisting)
                throw new UserFriendlyException(L("QualifiedAgencies.QualifiedAgency.IsAlreadyExisting"));

            EligibleEntity eligibleEntity = new()
            {
                Name = input.Name,
                PhoneNumber = input.PhoneNumber,
                Email = input.Email,
                Fax = input.Fax,
                ActivityId = input.ActivityId,
                ActivityTypeId = input.ActivityTypeId,
                AreaId = input.AreaId,
                Category = input.Category,
                DeletionTime = input.DeletionTime
            };

            await _EligibleEntityRepository.InsertAsync(eligibleEntity);
            return L("SavedSuccessfully");

        }



        [AbpAuthorize]
        public async Task<string> Update(UpdateEligibleEntityInput input)
        {
            bool eligibleEntityIsExisting = await _EligibleEntityRepository.GetAll().Where(b => b.Id != input.Id && b.Name.Equals(input.Name)).AnyAsync();
            if (eligibleEntityIsExisting)
                throw new UserFriendlyException(L("QualifiedAgencies.QualifiedAgency.IsAlreadyExisting"));

            EligibleEntity eligibleEntity = await _EligibleEntityRepository.GetAll().Where(b => b.Id == input.Id).FirstOrDefaultAsync();

            eligibleEntity.Name = input.Name;
            eligibleEntity.PhoneNumber = input.PhoneNumber;
            eligibleEntity.Email = input.Email;
            eligibleEntity.Fax = input.Fax;
            eligibleEntity.ActivityId = input.ActivityId;
            eligibleEntity.ActivityTypeId = input.ActivityTypeId;
            eligibleEntity.AreaId = input.AreaId;
            eligibleEntity.DeletionTime = input.DeletionTime;
            eligibleEntity.Category = input.Category;
            await _EligibleEntityRepository.UpdateAsync(eligibleEntity);

            return L("UpdatedSuccessfully");
        }
        [AbpAuthorize]
        public async Task<GetFullInfoEligibleEntityDto> Get(long id)
        {
            EligibleEntity eligibleEntity = await _EligibleEntityRepository.GetAll()
               .Where(x => x.Id == id)
               .FirstOrDefaultAsync() ?? throw new UserFriendlyException(L("QualifiedAgencies.QualifiedAgency.IsNotExisting"));

            GetFullInfoEligibleEntityDto entity = await _EligibleEntityRepository.GetAll()
                                                                .Where(e => e.Id == id)
                                                                .Select(e => new GetFullInfoEligibleEntityDto
                                                                {
                                                                    Id = e.Id,
                                                                    Name = e.Name,
                                                                    PhoneNumber = e.PhoneNumber,
                                                                    Email = e.Email,
                                                                    Fax = e.Fax,
                                                                    ActivityId = e.ActivityId,
                                                                    ActivityTypeId = e.ActivityTypeId,
                                                                    AreaId = e.AreaId,
                                                                    DeletionTime = e.DeletionTime,
                                                                    Category = e.Category,
                                                                }).FirstOrDefaultAsync();
            return entity;
        }
        [AbpAuthorize]
        public async Task<string> Delete(long id)
        {

            EligibleEntity eligibleEntity = await _EligibleEntityRepository.GetAll()
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync() ?? throw new UserFriendlyException(L("QualifiedAgencies.QualifiedAgency.IsNotExisting"));

            await _EligibleEntityRepository.DeleteAsync(eligibleEntity);

            return L("DeletedSuccessfully");
        }
        public async Task<GetStatisticsDto> GetStatistics()
        {
            GetStatisticsDto statistics = new()
            {
                CategoriesStatistics = await GetCategoriesStatistics(),
                ActivityTypesStatistics = await GetActivityTypesStatistics()
            };
            return statistics;
        }

        async Task<List<GetCategoryStatisticsDto>> GetCategoriesStatistics()
        {
            int totalEntitiesCount = await _EligibleEntityRepository.GetAll().CountAsync(e => !e.IsDeleted);

            List<GetCategoryStatisticsDto> statistics = await _EligibleEntityRepository.GetAll()
                .Where(e => !e.IsDeleted && e.Category.HasValue)
                .GroupBy(e => e.Category)
                .Select(e => new GetCategoryStatisticsDto
                {
                    Category = e.Key.Value,
                    Total = e.Count(),
                    Percentage = ((double)e.Count() / totalEntitiesCount) * 100
                })
                .OrderBy(c => c.Category)
                .ToListAsync();
            return statistics;
        }
        async Task<List<GetActivityTypeStatisticsDto>> GetActivityTypesStatistics()
        {
            int totalEntitiesCount = await _EligibleEntityRepository.GetAll().CountAsync(e => !e.IsDeleted);

            List<GetActivityTypeStatisticsDto> statistics = await _EligibleEntityRepository.GetAll()
                .Where(e => !e.IsDeleted)
                .GroupBy(e => e.ActivityType.Name)
                .Select(e => new GetActivityTypeStatisticsDto
                {
                    ActivityTypeName = e.Key,
                    Total = e.Count(),
                    Percentage = ((double)e.Count() / totalEntitiesCount) * 100
                })
                .ToListAsync();

            return statistics;
        }
        async Task SetDeleteAfterExpirationDate()
        {
            List<EligibleEntity> eligibleEntities = await _EligibleEntityRepository
                .GetAll()
                .Where(x => x.DeletionTime.HasValue && (x.DeletionTime.Value.Date == DateTime.Now.Date || x.DeletionTime.Value.Date < DateTime.Now.Date))
                .ToListAsync();

            if (eligibleEntities.Count > 0)
                foreach (var el in eligibleEntities)
                {
                    el.IsDeleted = true;
                    await _EligibleEntityRepository.UpdateAsync(el);
                }
        }

    }
}
