using Exkyn.Core.Models;
using Exkyn.Mail;
using Exkyn.Mail.Configurations;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Site.Models;

namespace Site.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger) => _logger = logger;

        private string CreateMessage(ContatoModels contato)
        {
            //Criar o template para o envio da mensagem.
            return contato.Message!;
        }

        public void OnPost(ContatoModels contato)
        {
            var configuration = new SendingEmailConfiguration("remetente@email.com.br", "senha_email_remetente");

            var sendEmail = new Email(configuration);

            sendEmail.Send(Designer.Email, contato.Subject!, CreateMessage(contato));
        }
    }
}