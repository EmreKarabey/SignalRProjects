using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.Concrete;
using FluentValidation;

namespace BusinessLayer.Validation
{
    public class AboutValidation:AbstractValidator<About>
    {
        public AboutValidation()
        {
            RuleFor(n => n.Title).NotEmpty().WithMessage("Lütfen Başlık Girin"); 
            RuleFor(n => n.Description).NotEmpty().WithMessage("Lütfen Açıklama Girin"); 
            RuleFor(n => n.ImageURL).NotEmpty().WithMessage("Lütfen Resim Girin"); 
            
        }
    }
}
