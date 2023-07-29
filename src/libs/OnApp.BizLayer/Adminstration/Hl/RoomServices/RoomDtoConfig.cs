using AutoMapper;
using OnApp.DataLayer.Repository;
using GenericServices.Configuration;

namespace OnApp.BizLayer.RoomServices
{
    public class RoomDtoConfig :
        PerDtoConfig<RoomDto, Room>
    {
        public override Action<IMappingExpression<Room, RoomDto>> AlterReadMapping 
            => cfg => cfg
                    .ForMember(dto => dto.OrganizationName,ex => ex.MapFrom(ent => ent.Organization.FullName))
                    .ForMember(dto => dto.StateName, ex => ex.MapFrom(ent => ent.State.FullName));
    }
}
