using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Arctodus.Infrastructure
{
    public class AutomapperWebProfile : AutoMapper.Profile
    {
        public AutomapperWebProfile()
        {

            //CreateMap<EmployeeDomainModel, EmployeeViewModel>();

            //CreateMap<EmployeeViewModel, EmployeeDomainModel>();

        }

        public static void Run()
        {
            AutoMapper.Mapper.Initialize(a =>
            {
                a.AddProfile<AutomapperWebProfile>();


            });
        }
    }
}