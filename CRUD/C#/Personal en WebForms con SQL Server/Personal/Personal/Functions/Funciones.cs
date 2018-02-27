// Written By Ismael Heredia in the year 2017

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Personal
{
    public class Funciones
    {
        public string mensaje(string texto)
        {
            return "<script>alert('" + texto + "')</script>";
        }
    }
}