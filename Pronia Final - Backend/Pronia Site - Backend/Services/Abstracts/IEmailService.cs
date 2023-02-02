using Pronia_Site___Backend.Contracts.Email;

namespace Pronia_Site___Backend.Services.Abstracts
{
    public interface IEmailService
    {
        public void Send(MessageDto messageDto);
    }
}
