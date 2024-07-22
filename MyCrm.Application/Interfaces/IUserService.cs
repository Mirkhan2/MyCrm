using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyCrm.Domain.ViewModels.User;

namespace MyCrm.Application.Interface
{
    public interface IUserService
    {
        Task<AddMarketerResult> AddMarketer(AddMarketerViewModel marketer);

        Task<FilterUserViewModel > FilterUSer(FilterUserViewModel filter);

    }
}
