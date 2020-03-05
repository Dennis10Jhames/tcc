using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace projeto_dv.Models
{
    public class Usuario
    {
        public int Id_Usuario { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }        
        public string Unidade { get; set;}
        public string Categoria { get; set; }
        public string Contato { get; set; }
        public string Login { get; set; } 
        public string Responsavel { get; set; }
        public string Senha { get; set; }


    }
}