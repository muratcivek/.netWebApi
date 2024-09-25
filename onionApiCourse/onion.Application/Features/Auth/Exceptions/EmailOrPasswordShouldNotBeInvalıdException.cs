using onion.Application.Bases;

namespace onion.Application.Features.Auth.Exceptions
{
    public class EmailOrPasswordShouldNotBeInvalıdException : BaseException
    {
        public EmailOrPasswordShouldNotBeInvalıdException() : base("Kullanıcı adı veya şifre yanlıştır!") { } 
    }

  
}
