using AutoMapper;
using OsonCommerce.Application.Mappers;
using OsonCommerce.Domain.Entities;

namespace OsonCommerce.Application.Features
{
    public class StoreBranchDto : IMapWith<StoreBranch>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<Guid> ManagerIds { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public bool IsActive { get; set; }
        public string OperatingHours { get; set; }
        public int NumberOfEmployees { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<StoreBranch, StoreBranchDto>();
        }
    }
}
