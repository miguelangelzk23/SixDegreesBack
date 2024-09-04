using System.Data.SqlClient;
using SixDegrees.Dto;
namespace SixDegrees.Dal
{
    public class UserDal: IUserDal
    { 

        protected SqlConnection _context;
        protected SqlTransaction _transaction;
        public UserDal(SqlConnection context, SqlTransaction transaction)
        {
            _context = context;
            _transaction = transaction;
        }

        public async Task<List<UserDto>> GetUsers()
        {
          
            List<UserDto> ListuserDto = new List<UserDto>();

            try
            {
                string sqlText = "select * from  dbo.Usuario";
                SqlConnection connection = new SqlConnection("Server=localhost;Database=PruebaSD;Trusted_Connection=True;");
                var cmd = new SqlCommand(sqlText, connection, _transaction);
                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        UserDto userDto = new UserDto();
                        userDto.Id = reader.GetInt32(0);
                        userDto.Nombre = reader.GetString(1);
                        userDto.Apellido = reader.GetString(2);
                        userDto.Telefono = reader.GetString(3);

                        ListuserDto.Add(userDto);
                    }

                    return ListuserDto;
                }
            }
            catch (Exception ex)
            {
                return ListuserDto;
            }
        }

    }
}
