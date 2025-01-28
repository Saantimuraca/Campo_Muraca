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
        public Validador_Usuario(List<string> lista)
        {
            RuleFor(u => u.Nombre_Usuario).NotEmpty().WithMessage("Debe ingresar un nombre de usuario!!!").Must((usuario, nombreUsuario) => !lista.Contains(nombreUsuario))
    .WithMessage("El nombre de usuario ya existe!!!");
            RuleFor(u => u.Contraseña_Usuario)
    .NotEmpty().WithMessage("Debe ingresar una contraseña!!!")
    .MinimumLength(8).WithMessage("La contraseña debe tener al menos 8 caracteres.")
    .Matches(@"[A-Z]").WithMessage("La contraseña debe contener al menos una letra mayúscula.")
    .Matches(@"[a-z]").WithMessage("La contraseña debe contener al menos una letra minúscula.")
    .Matches(@"\d").WithMessage("La contraseña debe contener al menos un número.")
    .Matches(@"[!@#$%^&*(),.?\").WithMessage("La contraseña debe contener al menos un carácter especial.");
            RuleFor(u => u.Mail_Usuario).Cascade(CascadeMode.Stop).EmailAddress().WithMessage("Debe ingresar un mail valido!!!");
            RuleFor(u => u.Telefono_Usuario).Matches(@"^\d{10}$").WithMessage("El número de usuario debe tener 10 dígitos!!!");
        }
    }
}
