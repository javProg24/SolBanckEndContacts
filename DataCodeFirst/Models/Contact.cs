﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataCodeFirst.Models
{
    public class Contact
    {
        public int ID {  get; set; }
        public string Nombre {  get; set; }
        public string Apellido { get; set; }
        public int Numero {  get; set; }
        public bool Estado {  get; set; }
    }
}
