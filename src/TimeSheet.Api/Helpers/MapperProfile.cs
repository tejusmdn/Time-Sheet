using AutoMapper;
using Microsoft.VisualStudio.Services.WebApi;
using TimeSheet.Core.Models;
using TimeSheet.Infrastructure.Entities;
using TfsWorkItem = Microsoft.TeamFoundation.WorkItemTracking.WebApi.Models.WorkItem;

namespace TimeSheet.Api.Helpers
{
    using Microsoft.TeamFoundation.Core.WebApi;
    using TimeSheet.Core.Helpers;

    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            this.CreateMap<IdentityRef, User>();

            this.CreateMap<TfsWorkItem, DevOpsWorkItem>()
                .ForMember(item => item.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(item => item.Url, opt => opt.MapFrom(src => src.Url))
                .ForMember(item => item.Title, opt => opt.MapFrom(src => src.Fields[Constants.WorkItemTitleField]))
                .ForMember(item => item.IterationPath, opt => opt.MapFrom(src => src.Fields[Constants.WorkItemIterationPathField]))
                .ForMember(item => item.Completed,
                    opt => opt.MapFrom(src =>
                        src.Fields.ContainsKey(Constants.WorkItemCompletedWorkField)
                            ? src.Fields[Constants.WorkItemCompletedWorkField]
                            : 0))
                .ForMember(item => item.Effort,
                    opt => opt.MapFrom(src =>
                        src.Fields.ContainsKey(Constants.WorkItemEffortField)
                            ? src.Fields[Constants.WorkItemEffortField]
                            : 0))
                .ForMember(item => item.Remaining,
                    opt => opt.MapFrom(src =>
                        src.Fields.ContainsKey(Constants.WorkItemRemainingWorkField)
                            ? src.Fields[Constants.WorkItemRemainingWorkField]
                            : 0))
                .ForMember(item => item.AssignedTo,
                    opt => opt.MapFrom(src =>
                        src.Fields.ContainsKey(Constants.WorkItemAssignedToField) ? src.Fields[Constants.WorkItemAssignedToField] : null));

            this.CreateMap<TeamProject, Project>();
            this.CreateMap<WebApiTeamRef, Team>();

        }
    }
}
