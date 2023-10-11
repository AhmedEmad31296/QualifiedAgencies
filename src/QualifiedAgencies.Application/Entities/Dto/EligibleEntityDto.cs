using Abp.Domain.Entities;

using QualifiedAgencies.Common;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

using static QualifiedAgencies.Helpers.Datatable;

namespace QualifiedAgencies.Entities.Dto
{
    public class FilterEligibleEntityPagedInput : DatatableFilterInput
    {
        public int? Category { get; set; }

    }
    public class EligibleEntityPagedDto : Entity<long>
    {
        public string Name { get; set; }
        public string Activity { get; set; }
        public string PhoneNumber { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }
        public string Area { get; set; }
        public string ActivityType { get; set; }
        public DateTime? DeletionTime { get; set; }
    }
    public class InsertEligibleEntityInput
    {
        public string Name { get; set; }
        public long? ActivityId { get; set; }
        public Category Category { get; set; }
        public string PhoneNumber { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }
        public long? AreaId { get; set; }
        public long? ActivityTypeId { get; set; }
        public DateTime? DeletionTime { get; set; }
    }
    public class UpdateEligibleEntityInput : Entity<long>
    {
        public string Name { get; set; }
        public long? ActivityId { get; set; }
        public string PhoneNumber { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }
        public long? AreaId { get; set; }
        public long? ActivityTypeId { get; set; }
        public DateTime? DeletionTime { get; set; }
    }
    public class GetFullInfoEligibleEntityDto : Entity<long>
    {
        public string Name { get; set; }
        public long? ActivityId { get; set; }
        public Category Category { get; set; }
        public string PhoneNumber { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }
        public long? AreaId { get; set; }
        public long? ActivityTypeId { get; set; }
        public DateTime? DeletionTime { get; set; }
    }
    public class GetStatisticsDto
    {
        public List<GetCategoryStatisticsDto> CategoriesStatistics { get; set; }
        public List<GetActivityTypeStatisticsDto> ActivityTypesStatistics { get; set; }
    }
    public class GetCategoryStatisticsDto
    {
        public Category Category { get; set; }
        public int Total { get; set; }
        public double Percentage { get; set; }
    }
    public class GetActivityTypeStatisticsDto
    {
        public string ActivityTypeName { get; set; }
        public int Total { get; set; }
        public double Percentage { get; set; }
    }
}
