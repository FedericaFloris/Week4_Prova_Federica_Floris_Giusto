using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week4_Prova_Federica_Floris
{
    public class AdoNetConnected
    {
        static string connectionStringSQL = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=GestioneSpese;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        public static void DeleteSpesa()
        {
            using SqlConnection connessione = new SqlConnection(connectionStringSQL);
            try
            {
                connessione.Open();

                if (connessione.State == System.Data.ConnectionState.Open)
                    Console.WriteLine("Connessi al DB");
            
                else
            {
                Console.WriteLine("Non siamo connessi");
            }

                //richiesta utente
                int idEliminare;  //id spesa da eliminare
                do
                {
                    Console.WriteLine("Inserisci id della spesa da eliminare");

                } while (!int.TryParse(Console.ReadLine(), out idEliminare));


                string deleteSQL = "delete from Spese where Id=@id";

            SqlCommand deleteCommand = connessione.CreateCommand();
            deleteCommand.CommandText = deleteSQL;
            deleteCommand.Parameters.AddWithValue("@id", idEliminare);

            int righeCancellate = deleteCommand.ExecuteNonQuery();
            if (righeCancellate >= 1)
            {
                Console.WriteLine($"{righeCancellate} riga/righe eliminate correttamente");
            }
            else
            {
                Console.WriteLine("OOOOOPS...qualcosa non torna!");
            }
        } 
            catch (SqlException ex)
            {
                Console.WriteLine($"Errore SQL: {ex.Message}");

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Errore generico: {ex.Message}");
            }
            finally
            {
                connessione.Close();
                Console.WriteLine("Connessione chiusa");
            }
        }
        internal static void ElencoSpeseApprovate()
        {
            
            using SqlConnection connessione = new SqlConnection(connectionStringSQL);
            try
            {
                connessione.Open();

                if (connessione.State == System.Data.ConnectionState.Open) 
                {
                    Console.WriteLine("Connessi al DB");
                }
                else
                {
                    Console.WriteLine("Non siamo connessi");

                }

                

                string query = "select * from Spese where Approvato=1";
                
                SqlCommand comando = new SqlCommand();
                comando.Connection = connessione;
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = query;


                SqlDataReader reader = comando.ExecuteReader(); 

                Console.WriteLine("Spese");
               
                while (reader.Read()) 
                {
                  

                    var id = (int)reader["Id"];
                    var dataSpese = (DateTime)reader["DataSpesa"];
                    var categoriaId = (int)reader["CategoriaId"];
                    var descrizione = (string)reader["Descrizione"];
                    var utente = (string)reader["Utente"];
                    var importo = (decimal)reader["Importo"];
                    var approvato = (bool)reader["Approvato"];

                    Console.WriteLine($"{id} - {dataSpese.ToShortDateString()} - {categoriaId} - {descrizione} - {utente} - {importo} - {approvato}");
                }


            }
            catch (SqlException ex)
            {
                Console.WriteLine($"Errore SQL: {ex.Message}");

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Errore generico: {ex.Message}");
            }
            finally
            {
                connessione.Close();
                Console.WriteLine("Connessione chiusa");
            }
        }


        internal static void ElencoSpeseUtente()
        {

            using SqlConnection connessione = new SqlConnection(connectionStringSQL);
            try
            {
                connessione.Open();

                if (connessione.State == System.Data.ConnectionState.Open)
                {
                    Console.WriteLine("Connessi al DB");
                }
                else
                {
                    Console.WriteLine("Non siamo connessi");


                }

                //richiesta all utente
                Console.WriteLine("Inserisci il nome dell utente di cui visualizzare la spesa");
                string utenteRichiesto;
                utenteRichiesto = Console.ReadLine();

                string query = "select * from Spese where Utente= " + "  '"+ utenteRichiesto +"'";

                SqlCommand comando = new SqlCommand();
                comando.Connection = connessione;
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = query;


                SqlDataReader reader = comando.ExecuteReader();

                Console.WriteLine("Spese");
                //dobbiamo leggere il risultato (converte le tabelle)
                while (reader.Read())
                {


                    var id = (int)reader["Id"];
                    var dataSpese = (DateTime)reader["DataSpesa"];
                    var categoriaId = (int)reader["CategoriaId"];
                    var descrizione = (string)reader["Descrizione"];
                    var utente = (string)reader["Utente"];
                    var importo = (decimal)reader["Importo"];
                    var approvato = (bool)reader["Approvato"];

                    Console.WriteLine($"{id} - {dataSpese.ToShortDateString()} - {categoriaId} - {descrizione} - {utente} - {importo} - {approvato}");
                }


            }
            catch (SqlException ex)
            {
                Console.WriteLine($"Errore SQL: {ex.Message}");

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Errore generico: {ex.Message}");
            }
            finally
            {
                connessione.Close();
                Console.WriteLine("Connessione chiusa");
            }
        }

        internal static void ElencoTutteSpese()
        {

            using SqlConnection connessione = new SqlConnection(connectionStringSQL);
            try
            {
                connessione.Open();

                if (connessione.State == System.Data.ConnectionState.Open)
                {
                    Console.WriteLine("Connessi al DB");
                }
                else
                {
                    Console.WriteLine("Non siamo connessi");


                }


                string query = "select * from Spese";

                SqlCommand comando = new SqlCommand();
                comando.Connection = connessione;
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = query;


                SqlDataReader reader = comando.ExecuteReader();

                Console.WriteLine("Spese");
                //dobbiamo leggere il risultato (converte le tabelle)
                while (reader.Read())
                {


                    var id = (int)reader["Id"];
                    var dataSpese = (DateTime)reader["DataSpesa"];
                    var categoriaId = (int)reader["CategoriaId"];
                    var descrizione = (string)reader["Descrizione"];
                    var utente = (string)reader["Utente"];
                    var importo = (decimal)reader["Importo"];
                    var approvato = (bool)reader["Approvato"];

                    Console.WriteLine($"{id} - {dataSpese.ToShortDateString()} - {categoriaId} - {descrizione} - {utente} - {importo} - {approvato}");
                }


            }
            catch (SqlException ex)
            {
                Console.WriteLine($"Errore SQL: {ex.Message}");

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Errore generico: {ex.Message}");
            }
            finally
            {
                connessione.Close();
                Console.WriteLine("Connessione chiusa");
            }
        }

        internal static void TotSpeseXCategoria()
        {

            using SqlConnection connessione = new SqlConnection(connectionStringSQL);
            try
            {
                connessione.Open();

                if (connessione.State == System.Data.ConnectionState.Open)
                {
                    Console.WriteLine("Connessi al DB");
                }
                else
                {
                    Console.WriteLine("Non siamo connessi");


                }


                string query = "select c.Categoria, NewCategoria.Totale" +
                               " from categoria c join (select s.CategoriaId, sum(s.Importo) as Totale from spese s " +
                                                          "group by s.CategoriaId) as NewCategoria on c.Id = NewCategoria.CategoriaId";

                SqlCommand comando = new SqlCommand();
                comando.Connection = connessione;
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = query;


                SqlDataReader reader = comando.ExecuteReader();

                Console.WriteLine("Totale Spese per categoria");
                //dobbiamo leggere il risultato (converte le tabelle)
                while (reader.Read())
                {


                   
                    var categoria = (string)reader["Categoria"];
                    var totale = (decimal)reader["Totale"];
                   

                    Console.WriteLine($" {categoria} - {totale} ");
                }


            }
            catch (SqlException ex)
            {
                Console.WriteLine($"Errore SQL: {ex.Message}");

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Errore generico: {ex.Message}");
            }
            finally
            {
                connessione.Close();
                Console.WriteLine("Connessione chiusa");
            }
        }
    }
}
