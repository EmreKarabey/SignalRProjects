using FluentValidation;
using SignalRWebUI.Dtos.Message;

namespace SignalRWebUI.ValidationRule
{
    public class SendMessageRule:AbstractValidator<SendMessage>
    {
        public SendMessageRule()
        {
            RuleFor(N => N.Name).NotEmpty().WithMessage("Lütfen İsim Giriniz");
            RuleFor(N => N.Mail).NotEmpty().WithMessage("Lütfen Mail Giriniz");
            RuleFor(N => N.Phone).NotEmpty().WithMessage("Lütfen Telefon Numarası Giriniz");
            RuleFor(N => N.Subject).NotEmpty().WithMessage("Lütfen Konnu Giriniz");
            RuleFor(N => N.MessageContent).NotEmpty().WithMessage("Lütfen Mesaj Açıklaması Giriniz");
        }
    }
}
