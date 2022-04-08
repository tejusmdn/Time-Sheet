using AutoMapper;
using Microsoft.VisualStudio.Services.WebApi;
using TimeSheet.Core.Models;
using TimeSheet.Infrastructure.Entities;
using TfsWorkItem = Microsoft.TeamFoundation.WorkItemTracking.WebApi.Models.WorkItem;

namespace TimeSheet.Api.Helpers
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            this.CreateMap<IdentityRef, User>();

            this.CreateMap<TfsWorkItem, DevOpsWorkItem>()
                .ForMember(item => item.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(item => item.Url, opt => opt.MapFrom(src => src.Url))
                .ForMember(item => item.Title, opt => opt.MapFrom(src => src.Fields["System.Title"]))
                .ForMember(item => item.Completed,
                    opt => opt.MapFrom(src =>
                        src.Fields.ContainsKey("Microsoft.VSTS.Scheduling.CompletedWork")
                            ? src.Fields["Microsoft.VSTS.Scheduling.CompletedWork"]
                            : 0))
                .ForMember(item => item.Effort,
                    opt => opt.MapFrom(src =>
                        src.Fields.ContainsKey("Microsoft.VSTS.Scheduling.Effort")
                            ? src.Fields["Microsoft.VSTS.Scheduling.Effort"]
                            : 0))
                .ForMember(item => item.Remaining,
                    opt => opt.MapFrom(src =>
                        src.Fields.ContainsKey("Microsoft.VSTS.Scheduling.RemainingWork")
                            ? src.Fields["Microsoft.VSTS.Scheduling.RemainingWork"]
                            : 0))
                .ForMember(item => item.AssignedTo,
                    opt => opt.MapFrom(src =>
                        src.Fields.ContainsKey("System.AssignedTo") ? src.Fields["System.AssignedTo"] : null));



        }
    }
}
