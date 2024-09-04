using SixDegrees.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SixDegrees.Business
{
    public interface IUserBusiness
    {
        Task<List<UserDto>> GetUsers();
    }
}
