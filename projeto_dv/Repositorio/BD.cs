using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using projeto_dv.Models;

namespace projeto_dv.Repositorio

{
    public class BD
    {
        SqlConnection Conexao = new SqlConnection();
        SqlCommand MeusComandos = new SqlCommand();

        public BD()
        {
            Conexao.ConnectionString = @"Data Source=;Initial Catalog=;Integrated Security=True";
            Conexao.Open();
        }
        public void Inserir(Ticket obj_ticket)
        {

            MeusComandos.Connection = Conexao;
            MeusComandos.CommandText = "INSERT INTO TICKET VALUES('" + obj_ticket.Descricao + "','" + obj_ticket.Unidade + "','" + obj_ticket.Contato + "','" + obj_ticket.Setor + "','" + obj_ticket.Prioridade + "','" + obj_ticket.Status + "','"
                + obj_ticket.Patrimonio + "','" + obj_ticket.Abertura_Por + "','" + obj_ticket.Data + "')";

            MeusComandos.ExecuteNonQuery();

        }
        public void Deletar(int codigo)
        {
            MeusComandos.Connection = Conexao;
            MeusComandos.CommandText = "DELETE FROM TICKET WHERE ID_TICKET=" + codigo;
            MeusComandos.ExecuteNonQuery();
        }

        public void Editar(Ticket obj_ticket)
        {
            MeusComandos.Connection = Conexao;
            MeusComandos.CommandText = "UPDATE TICKET SET DESCRICAO ='" + obj_ticket.Descricao + "',UNIDADE = '" + obj_ticket.Unidade + "', CONTATO = '" + obj_ticket.Contato + "', EMAIL = '" + obj_ticket.Email + "', SETOR ='" + obj_ticket.Setor + "', PRIORIDADE ='" + obj_ticket.Prioridade + "', STATUS ='" + obj_ticket.Status + "', PATRIMONIO ='" + obj_ticket.Patrimonio + "',ABERTUA_POR = '" + obj_ticket.Abertura_Por + "' WHERE ID_TICKET =" + obj_ticket.Id;


            MeusComandos.ExecuteNonQuery();

        }
        public List<Ticket> ListaTodos()
        {
            List<Ticket> tickets = new List<Ticket>();

            {
                MeusComandos.CommandType = CommandType.Text;
                MeusComandos.Connection = Conexao;
                MeusComandos.CommandText = "SELECT * FROM TICKET";
                SqlDataReader rdr = MeusComandos.ExecuteReader();
                while (rdr.Read())
                {
                    Ticket ticket = new Ticket();
                    ticket.Id = Convert.ToInt32(rdr["ID_TICKET"]);
                    ticket.Descricao = rdr["DESCRICAO"].ToString();
                    ticket.Unidade = rdr["UNIDADE"].ToString();
                    ticket.Contato = rdr["CONTATO"].ToString();
                    ticket.Email = rdr["EMAIL"].ToString();
                    ticket.Setor = rdr["SETOR"].ToString();
                    ticket.Prioridade = rdr["PRIORIDADE"].ToString();
                    ticket.Patrimonio = rdr["PATRIMONIO"].ToString();
                    
                    ticket.Data = Convert.ToDateTime(rdr["DATA_ABERTURA"]);
                    tickets.Add(ticket);
                }
            }
            return tickets;
        }
    }
}