using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using Microsoft.VisualBasic;

namespace Servicios
{
    public class Validador_Usuario : AbstractValidator<BE_Usuario>
    {
        public Validador_Usuario()
        {
            RuleFor(u => u.Nombre_Usuario).NotEmpty().WithMessage("Debe ingresar un nombre de usuario!!!");
            RuleFor(u => u.Mail_Usuario).Cascade(CascadeMode.Stop).EmailAddress().WithMessage("Debe ingresar un mail valido!!!");
            RuleFor(u => u.Telefono_Usuario).Matches(@"^\d{10}$").WithMessage("El número de usuario debe tener 10 dígitos!!!");
        }
    }
}
