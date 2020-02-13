using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SIVEDI.APIGeneral.Models
{
    public enum EnumResponseViewModel
    {
        Exitoso = 0,
        RegistroNoEncontrado = 1,
        ErrorInterno = 5,
        SinDatosEntrada = 6,
        DatosEntradaNoValidos = 7,
        RegistroInactivo = 8,
        ErrorDesconocido = 99
    }
}