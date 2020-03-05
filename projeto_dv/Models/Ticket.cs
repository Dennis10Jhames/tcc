using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace projeto_dv.Models
{
    public class Ticket
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public string Unidade { get; set; }
        public string Contato { get; set; }
        public string Email { get; set; }
        public string Setor { get; set; }
        public string Prioridade { get; set; }
        public string Status { get; set; }
        public string Patrimonio { get; set; }
        public string Abertura_Por{ get; set; }
        public DateTime Data { get; set; }
    }
}