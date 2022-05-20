using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week4_Prova_Federica_Floris
{
    public class AdoNetDisconnected
    {
        static string connectionStringSQL = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=GestioneSpese;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        private static SqlDataAdapter InizializzaAdapter(SqlConnection conn)
        {
            SqlDataAdapter adapter = new SqlDataAdapter();
            //Fill
            adapter.SelectCommand = new SqlCommand("Select * from Spese", conn); //copia dei valori della tabella che poi mettera nel nostro dataset
            adapter.MissingSchemaAction = MissingSchemaAction.AddWithKey; //ci portiamo dietro anche la parte delle chiavi

            //Insert

            adapter.InsertCommand = GeneraInsertCommand(conn);
            //UPDATE
            adapter.UpdateCommand = GeneraUpdateCommand(conn);

            return adapter;

            

        }

        private static SqlCommand GeneraUpdateCommand(SqlConnection conn)
        {
            SqlCommand command = new SqlCommand(); //mi creo un comando vuoto
            command.Connection = conn;
            command.CommandType = CommandType.Text;
            command.CommandText = "Update Spese set Approvato=@approvato ";

            
            
            command.Parameters.Add(new SqlParameter("@approvato", SqlDbType.Bit, 0, "Approvato"));

            return command;
        }

        internal static void FillDataSet()
        {
            DataSet speseDS = new DataSet();  //istanzio data set vuoto
            using SqlConnection conn = new SqlConnection(connectionStringSQL);
            try
            {
                conn.Open(); //apro connessione
                if (conn.State == ConnectionState.Open)
                    Console.WriteLine("Connessi al DB");
                else
                    Console.WriteLine("Non connessi al DB");

                SqlDataAdapter speseAdapter = InizializzaAdapter(conn);
                speseAdapter.Fill(speseDS, "SpeseDT");
                conn.Close();
                Console.WriteLine("Conessione chiusa");

                //Da qui si lavora in modalità disconessa ---> siamo offline
                foreach (DataTable table in speseDS.Tables)
                {
                    Console.WriteLine($"{table.TableName} - {table.Rows.Count}");
                }


                Console.WriteLine("--------Spese-------");
                foreach (DataRow riga in speseDS.Tables["SpeseDT"].Rows)
                {
                    Console.WriteLine($"{riga["Id"]} - {riga["DataSpesa"]} - {riga["CategoriaId"]} - {riga["Descrizione"]} - {riga["Utente"]} - {riga["Importo"]} - {riga["Approvato"]}");
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
                conn.Close();
            }

        }    
            
            internal static void AggiungiSpesa()
        { 
            DataSet speseDS = new DataSet();
            using SqlConnection conn = new SqlConnection(connectionStringSQL);
            try
            {
                conn.Open(); //apro connessione
                if (conn.State == ConnectionState.Open)
                    Console.WriteLine("Connessi al DB");
                else
                    Console.WriteLine("Non connessi al DB");

                //Richiesta dati utente
                DateTime dataSpese;
                do
                {
                    Console.WriteLine("Inserisci una data valida");
                } while (!DateTime.TryParse(Console.ReadLine(), out dataSpese));
                int categoriaId;
                do
                {
                    Console.WriteLine("Inserisci id categoria");

                } while (!int.TryParse(Console.ReadLine(), out categoriaId));
                Console.WriteLine("Inserisci descrizione");
                string descrizione;
                descrizione = Console.ReadLine();
                Console.WriteLine("Inserisci utente");
                string utente;
                utente = Console.ReadLine();
                decimal importo;
                do
                {
                    Console.WriteLine("Inserisci importo");

                } while (!decimal.TryParse(Console.ReadLine(), out importo));
                bool approvato;
                do
                {
                    Console.WriteLine("Inserisci se la spesa è approvata o meno(true o false)");

                } while (!bool.TryParse(Console.ReadLine(), out approvato));

                SqlDataAdapter speseAdapter = InizializzaAdapter(conn);
                speseAdapter.Fill(speseDS, "SpeseDT");
                conn.Close();
                Console.WriteLine("conessione chiusa");
                

                DataRow nuovaRiga = speseDS.Tables["SpeseDT"].NewRow();
                nuovaRiga["DataSpesa"] = dataSpese;
                nuovaRiga["CategoriaId"] = categoriaId;
                nuovaRiga["Descrizione"] = descrizione;
                nuovaRiga["Utente"] = utente;
                nuovaRiga["Importo"] = importo;
                nuovaRiga["Approvato"] = approvato;




                speseDS.Tables["SpeseDT"].Rows.Add(nuovaRiga); //aggiungo la mia nuova riga del dataset

                //riconciliazione e quindi il vero salvataggio del dato sul DB
                speseAdapter.Update(speseDS, "SpeseDT");
                Console.WriteLine("Database aggiornato");


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
                conn.Close();
            }
        }

        private static SqlCommand GeneraInsertCommand(SqlConnection conn)
        {
            SqlCommand command = new SqlCommand();
            command.Connection = conn;
            command.CommandType = CommandType.Text;
            command.CommandText = "Insert into Spese values(@dataSpesa,@categoriaId,@descrizione,@utente,@importo,@approvato)";

            command.Parameters.Add(new SqlParameter("@dataSpesa", SqlDbType.DateTime, 0, "DataSpesa"));
            command.Parameters.Add(new SqlParameter("@categoriaId", SqlDbType.Int, 0, "CategoriaId"));
            command.Parameters.Add(new SqlParameter("@descrizione", SqlDbType.VarChar, 500, "Descrizione"));
            command.Parameters.Add(new SqlParameter("@utente", SqlDbType.VarChar, 100, "Utente"));
            command.Parameters.Add(new SqlParameter("@importo", SqlDbType.Decimal, 0, "Importo"));
            command.Parameters.Add(new SqlParameter("@approvato", SqlDbType.Bit, 0, "Approvato"));
            return command;



        }

        internal static void AggiornaSpesa()
        {
            DataSet speseDS = new DataSet();
            using SqlConnection conn = new SqlConnection(connectionStringSQL);
            try
            {
                conn.Open(); //apro connessione
                if (conn.State == ConnectionState.Open)
                    Console.WriteLine("Connessi al DB");
                else
                    Console.WriteLine("Non connessi al DB");

                //richiesta dati utente
                
                int idAggiornare;
                do
                {
                    Console.WriteLine("Inserisci id da aggiornare");

                } while (!int.TryParse(Console.ReadLine(), out idAggiornare));
                bool approvatoAggiornare;
                do
                {
                    Console.WriteLine("Inserisci l approvato");

                } while (!bool.TryParse(Console.ReadLine(), out approvatoAggiornare));


                SqlDataAdapter SpeseAdapter = InizializzaAdapter(conn);
                SpeseAdapter.Fill(speseDS, "SpeseDT");
                conn.Close();
                Console.WriteLine("conessione chiusa");

                DataRow rigaDaAggiornare = speseDS.Tables["SpeseDT"].Rows.Find(idAggiornare); //mi sta recuperando la riga della tabella dt del mio database mi sta prendendo la chiave primaria
                                                                                                 //Find metodo che cerca per chiava primaria
                if (rigaDaAggiornare != null)
                {
                    rigaDaAggiornare["Approvato"] = approvatoAggiornare;
                }



                //riconciliazione e quindi il vero salvataggio del dato sul DB
                SpeseAdapter.Update(speseDS, "SpeseDT");
                Console.WriteLine("Database aggiornato");


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
                conn.Close();
            }
        }





    }
}
