using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using MvcWebUI.Models;

namespace MvcWebUI.ValidationRules.FluentValidation
{
    public class ShippingDetailValidator : AbstractValidator<ShippingDetail>
    {
        public ShippingDetailValidator()
        {
            RuleFor(s => s.FirstName).NotEmpty().WithMessage("Require Firstname");
            RuleFor(s => s.FirstName).MinimumLength(2);
            RuleFor(s => s.LastName).NotEmpty();
            RuleFor(s => s.Address).NotEmpty();
            RuleFor(s => s.Email).NotEmpty();
            RuleFor(s => s.Email).EmailAddress();
            RuleFor(s => s.City).NotEmpty().When(s => s.Age < 18);//18den küçükse o zman şehir bilgisi girilmek zorunda
            RuleFor(s => s.Age).NotEmpty();
            //kendi klurlaımız yazabiliyoruz örenğin müşterilerin isimler a harfi ile başlıyacak
            //RuleFor(s => s.FirstName).Must(StartWithA);

        }

        private bool StartWithA(string arg)
        {
            return arg.StartsWith("A");
        }
    }
}
