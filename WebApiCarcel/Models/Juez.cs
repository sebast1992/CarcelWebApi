﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiCarcel.Models
{
    public class Juez
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string  Rut { get; set; }
        public char Sexo { get; set; }
        public string Domicilio { get; set; }

        public List<Condena> Condenas { get; set; }

        public Juez()
        {

        }
    }
}