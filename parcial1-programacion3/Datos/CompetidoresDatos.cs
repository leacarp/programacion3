using parcial1_programacion3.Models;
using System.Data.SqlClient;

namespace parcial1_programacion3.Datos
{
    public class CompetidoresDatos
    {
        string connectionString = @"Data Source=DESKTOP-MLQ7ER4;Initial Catalog=RegistroCompetencia;Integrated Security=True;";

        public List<Competidores> listarCompetidores()
        {
            List<Competidores> lista = new List<Competidores>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "SELECT c.IDCompetidor, c.Edad, c.CiudadResidencia, c.Nombre, c.IDDisciplina AS CompetidorIDDisciplina, d.IDDisciplina AS DisciplinaID, d.NombreDisciplina FROM Competidores c INNER JOIN Disciplina d ON c.IDDisciplina = d.IDDisciplina ORDER BY c.Nombre";
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    lista.Add(new Competidores()
                    {
                        IDCompetidor = (int)reader["IDCompetidor"],
                        Edad = (int)reader["Edad"],
                        CiudadResidencia = reader["CiudadResidencia"].ToString(),
                        Nombre = reader["Nombre"].ToString(),
                        IDDisciplina = (int)reader["CompetidorIDDisciplina"],
                        Disciplina = new Disciplina()
                        {
                            IDDisciplina = (int)reader["DisciplinaID"],
                            NombreDisciplina = reader["NombreDisciplina"].ToString()
                        }
                    });
                }
                return lista;
            }
                
        }

        public string Crear(Competidores competidor)
        {
            string query = $"INSERT INTO Competidores (Edad, CiudadResidencia, Nombre, IDDisciplina) VALUES ({competidor.Edad}, '{competidor.CiudadResidencia}', '{competidor.Nombre}', {competidor.IDDisciplina})";
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand(query, con);
                    SqlDataReader reader = cmd.ExecuteReader();
                    return "";
                }
            } catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public List<Disciplina> ListarDisciplinas()
        {
            List<Disciplina> lista = new List<Disciplina>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Disciplina ORDER BY NombreDisciplina";
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader reader = cmd.ExecuteReader();
                while(reader.Read())
                {
                    lista.Add(new Disciplina()
                    {
                        IDDisciplina = (int)reader["IDDisciplina"],
                        NombreDisciplina = reader["NombreDisciplina"].ToString()
                    }); 
                }
                return lista;
            }
        }
    }
}
