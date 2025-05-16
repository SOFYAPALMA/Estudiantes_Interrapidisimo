using Business.IService;
using Commun;
using Domain.Model;
using Repository.IRepository;

namespace Business.Service
{
    public class Auth : IAuth
    {
        private readonly IEstudiantesRepository _estudiantesR;

        public Auth(IEstudiantesRepository estudiantesRepo)
        {
            _estudiantesR = estudiantesRepo;
        }

        //private string JWT(EstudiantesModel user)
        //{
        //    if (user != null)
        //    {
        //        string secret = _configuration["JwtSettings:Key"] ?? "";

        //        if (string.IsNullOrEmpty(secret))
        //        {
        //            return "";
        //        }
        //        else
        //        {
        //            double expire = double.Parse(_configuration["JwtSettings:TimeSegurity"] ?? "5");
        //            var issuer = _configuration["JwtSettings:Issuer"];
        //            var audience = _configuration["JwtSettings:Audience"];

        //            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret));
        //            var signingCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

        //            //create claims details based on the user information
        //            var subject = new ClaimsIdentity(new[] {
        //                new Claim(JwtRegisteredClaimNames.Sub, "JWTServiceAccessToken"),
        //                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
        //                new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
        //                //new Claim(JwtRegisteredClaimNames.correo, user.correo),
        //                new Claim("UserId", user.id.ToString()),
        //                new Claim("DisplayName", user.nombre),
        //            });

        //            var tokenDescriptor = new SecurityTokenDescriptor
        //            {
        //                Subject = subject,
        //                Expires = DateTime.UtcNow.AddMinutes(expire),
        //                Issuer = issuer,
        //                Audience = audience,
        //                SigningCredentials = signingCredentials
        //            };

        //            var tokenHandler = new JwtSecurityTokenHandler();
        //            var token = tokenHandler.CreateToken(tokenDescriptor);
        //            var jwtToken = tokenHandler.WriteToken(token);

        //            return jwtToken;
        //        }
        //    }
        //    else
        //    {
        //        return "";
        //    }
        //}

        public async Task<Result> Validar(string correo, string password)
        {
          
            Result result = new Result();
            EstudiantesModel estudiante = await _estudiantesR.ConsultarEstudianteEmail(correo);


            if (estudiante.correo == correo && estudiante.password == password)
            {
                result.Success = true;
                //result.Data = JWT(usuario);
                result.Message = "Se ha autenticado con exito.";                
            }
            else
            {
                result.Success = false;
                result.Message = "NO se ha autenticado con exito.";
            }

            return await Task.FromResult(result);
        }
    }
}
