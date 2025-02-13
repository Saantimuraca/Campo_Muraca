using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using Microsoft.VisualBasic;
using System.Net;

namespace Servicios
{
    public class Validador_Usuario : AbstractValidator<BE_Usuario>
    {
        public Validador_Usuario(List<string> lista, List<string> lista2)
        {
            RuleFor(u => u.Nombre_Usuario).NotEmpty().WithMessage("Debe ingresar un nombre de usuario!!!").Must((usuario, nombreUsuario) => !lista.Contains(nombreUsuario))
    .WithMessage("El nombre de usuario ya existe!!!");
            RuleFor(u => u.Contraseña_Usuario)
    .NotEmpty().WithMessage("Debe ingresar una contraseña!!!")
    .MinimumLength(8).WithMessage("La contraseña debe tener al menos 8 caracteres.")
    .Matches(@"[A-Z]").WithMessage("La contraseña debe contener al menos una letra mayúscula.")
    .Matches(@"[a-z]").WithMessage("La contraseña debe contener al menos una letra minúscula.")
    .Matches(@"\d").WithMessage("La contraseña debe contener al menos un número.");
            RuleFor(u => u.Mail_Usuario).Cascade(CascadeMode.Stop).EmailAddress().WithMessage("Debe ingresar un mail valido!!!");
            RuleFor(u => u.Telefono_Usuario).Matches(@"^\d{10}$").WithMessage("El número de usuario debe tener 10 dígitos!!!");
            RuleFor(u => u.Dni_Usuario)
    .NotEmpty().WithMessage("Debe ingresar un DNI!!!")
    .Matches(@"^\d{7,8}$").WithMessage("El DNI debe contener 7 u 8 dígitos numéricos.")
    .Must(dni => ValidarDNI(dni)).WithMessage("El DNI ingresado no es válido.")
    .Must((usuario, dni) => !lista2.Contains(dni)).WithMessage("El DNI ingresado ya existe.");
            RuleFor(u => u.Rol).NotNull().WithMessage("Debe seleccionar un rol para el usuario!!!");
            RuleFor(u => u.Idioma).NotEmpty().WithMessage("Debe seleccionar un idioma para el usuario!!!");
        }

        public bool ValidarDNI(string dni)
        {
            var dniesInvalidos = new List<string> { "00000000", "11111111", "12345678" };
            return !dniesInvalidos.Contains(dni);
        }
    }
}
