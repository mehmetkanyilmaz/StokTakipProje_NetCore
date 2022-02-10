using Business.Contants;
using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class StockValidator: AbstractValidator<Stock>
    {
        public StockValidator()
        {
            RuleFor(x => x.name).NotEmpty().WithMessage(Messages.StockNameEmpty);
        }
    }
}
