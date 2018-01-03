using AutoMapper;
using Invenio.Data.Models;
using Invenio.Service.Models;
using Invenio.Web.Areas.Order.Models;

namespace Invenio.Web.Infrastructures.Mapping
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            this.CreateMap<Order, OrderViewModel>();
            this.CreateMap<Files, FileModel>();
            this.CreateMap<Report,ReportModel>();
            this.CreateMap<CustomerUser, AllCustomerModel>()
                .ForMember(x => x.OrderCount, cfg => cfg.MapFrom(x => x.Orders.Count));
            this.CreateMap<User,AllEmployeeModel>();
        }
    }
}
