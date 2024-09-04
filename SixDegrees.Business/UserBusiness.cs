using SixDegrees.Dto;
using SixDegrees.Dal;
namespace SixDegrees.Business
{
    public class UserBusiness  :IUserBusiness
    {
            
        protected UserDal _userDal;
        public UserBusiness(UserDal userdal) {
        
            _userDal = userdal;
        }
        public async Task<List<UserDto>> GetUsers()
        {
            return await _userDal.GetUsers();
        }
    }
}
