using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_Zoologico.Clases
{
    internal class ClsAnimales
    {
        private ConexionBD Conexion = new ConexionBD();
        private SqlCommand Comando = new SqlCommand();
        private SqlDataReader LeerFilas;


        //ATRIBUTOS
        private int idanimal;
        private int idalimento;
        private int iddieta;
        private int idpesoymedida;
        private string animal;

        public int _Idanimal
        {
            get { return idanimal; }
            set { idanimal = value; }
        }


        public int _Idalimento
        {
            get { return idalimento; }
            set { idalimento = value; }
        }
        public int _Iddieta
        {
            get { return iddieta; }
            set { iddieta = value; }
        }
        public int _Idpesoymedida
        {
            get { return idpesoymedida; }
            set { idpesoymedida = value; }
        }
        public string _Animal
        {
            get { return animal; }
            set { animal = value; }
        }

        public DataTable ListarPesoyMedidas()
        {
            DataTable Tabla = new DataTable();
            Comando.Connection = Conexion.AbrirConexion();
            Comando.CommandText = "ListarPesoyMedidas";
            Comando.CommandType = CommandType.StoredProcedure;
            LeerFilas = Comando.ExecuteReader();
            Tabla.Load(LeerFilas);
            LeerFilas.Close();
            Conexion.CerrarConexion();
            return Tabla;
        }


        public DataTable ListarDietas()
        {
            DataTable Tabla = new DataTable();
            Comando.Connection = Conexion.AbrirConexion();
            Comando.CommandText = "ListarDietas";
            Comando.CommandType = CommandType.StoredProcedure;
            LeerFilas = Comando.ExecuteReader();
            Tabla.Load(LeerFilas);
            LeerFilas.Close();
            Conexion.CerrarConexion();
            return Tabla;
        }

        public DataTable ListarAlimentos()
        {
            DataTable Tabla = new DataTable();
            Comando.Connection = Conexion.AbrirConexion();
            Comando.CommandText = "ListarAlimentos";
            Comando.CommandType = CommandType.StoredProcedure;
            LeerFilas = Comando.ExecuteReader();
            Tabla.Load(LeerFilas);
            LeerFilas.Close();
            Conexion.CerrarConexion();
            return Tabla;
        }


        public void InsertarAnimal()
        {
            Comando.Connection = Conexion.AbrirConexion();
            Comando.CommandText = "AgregarAnimal";
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.Parameters.AddWithValue("@idalimento", idalimento);
            Comando.Parameters.AddWithValue("@iddieta", iddieta);
            Comando.Parameters.AddWithValue("@idpeso_y_medida", idpesoymedida);
            Comando.Parameters.AddWithValue("@animal", animal);
            Comando.ExecuteNonQuery();
            Comando.Parameters.Clear();
            Conexion.CerrarConexion();
        }

        public DataTable ListarAnimales()
        {
            DataTable Tabla = new DataTable();
            Comando.Connection = Conexion.AbrirConexion();
            Comando.CommandText = "ListarAnimales";
            Comando.CommandType = CommandType.StoredProcedure;
            LeerFilas = Comando.ExecuteReader();
            Tabla.Load(LeerFilas);
            LeerFilas.Close();
            Conexion.CerrarConexion();
            return Tabla;
        }

        public void EliminarAnimal()
        {
            Comando.Connection = Conexion.AbrirConexion();
            Comando.CommandText = "delete ANIMALES where IDANIMAL=" + idanimal;
            Comando.CommandType = CommandType.Text;
            Comando.ExecuteNonQuery();
            Conexion.CerrarConexion();
        }

        public void EditarAnimal()
        {
            Comando.Connection = Conexion.AbrirConexion();
            Comando.CommandText = "update ANIMALES set IDALIMENTO=" + idalimento + ",IDDIETA=" + iddieta + ",IDPESO_Y_MEDIDA=" + idpesoymedida + ",ANIMAL='" + animal + "' where IDANIMAL=" + idanimal;
            Comando.CommandType = CommandType.Text;
            Comando.ExecuteNonQuery();
            Conexion.CerrarConexion();
        }
    }
}
