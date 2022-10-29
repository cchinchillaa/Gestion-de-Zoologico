using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_Zoologico.Clases
{
    internal class ClsEntradas
    {
        private ConexionBD Conexion = new ConexionBD();
        private SqlCommand Comando = new SqlCommand();
        private SqlDataReader LeerFilas;


        //ATRIBUTOS

        private int identrada;
        private int idtipovisitante;
        private int iddia;
        private string pago;
        private string nombre;
        private string fecha_ingreso;
        private string hora_ingreso;
        private string tiket;

        //metodos get y set


        public int _Identrada
        {
            get { return identrada; }
            set { identrada = value; }
        }
        public int _Idtipovisitante
        {
            get { return idtipovisitante; }
            set { idtipovisitante = value; }
        }

        public int _Iddia
        {
            get { return iddia; }
            set { iddia = value; }
        }

        public string _Pago
        {
            get { return pago; }
            set { pago = value; }
        }



        public string _Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }



        public string _Fecha_ingreso
        {
            get { return fecha_ingreso; }
            set { fecha_ingreso = value; }
        }

        public string _Hora_ingreso
        {
            get { return hora_ingreso; }
            set { hora_ingreso = value; }
        }

        public string _Tiket
        {
            get { return tiket; }
            set { tiket = value; }
        }


        public DataTable ListarTipoVisita()
        {
            DataTable Tabla = new DataTable();
            Comando.Connection = Conexion.AbrirConexion();
            Comando.CommandText = "ListarTipoVisita";
            Comando.CommandType = CommandType.StoredProcedure;
            LeerFilas = Comando.ExecuteReader();
            Tabla.Load(LeerFilas);
            LeerFilas.Close();
            Conexion.CerrarConexion();
            return Tabla;
        }

        public DataTable ListarDias()
        {
            DataTable Tabla = new DataTable();
            Comando.Connection = Conexion.AbrirConexion();
            Comando.CommandText = "ListarDias";
            Comando.CommandType = CommandType.StoredProcedure;
            LeerFilas = Comando.ExecuteReader();
            Tabla.Load(LeerFilas);
            LeerFilas.Close();
            Conexion.CerrarConexion();
            return Tabla;
        }

        public DataTable ListarEntradas()
        {
            DataTable Tabla = new DataTable();
            Comando.Connection = Conexion.AbrirConexion();
            Comando.CommandText = "ListarVisitantes";
            Comando.CommandType = CommandType.StoredProcedure;
            LeerFilas = Comando.ExecuteReader();
            Tabla.Load(LeerFilas);
            LeerFilas.Close();
            Conexion.CerrarConexion();
            return Tabla;
        }

        public void InsertarEntrada()
        {
            Comando.Connection = Conexion.AbrirConexion();
            Comando.CommandText = "AgregarEntrada";
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.Parameters.AddWithValue("@idtipo_visitante", idtipovisitante);
            Comando.Parameters.AddWithValue("@iddia", iddia);
            Comando.Parameters.AddWithValue("@nombre", nombre);
            Comando.Parameters.AddWithValue("@fecha_ingreso", Convert.ToDateTime(fecha_ingreso));
            Comando.Parameters.AddWithValue("@hora_ingreso", hora_ingreso);
            Comando.Parameters.AddWithValue("@pago", pago);
            Comando.Parameters.AddWithValue("@tiket", tiket);
            Comando.ExecuteNonQuery();
            Comando.Parameters.Clear();
            Conexion.CerrarConexion();
        }

        public void EliminarEntrada()
        {
            Comando.Connection = Conexion.AbrirConexion();
            Comando.CommandText = "delete ENTRADAS where IDENTRADA=" + identrada;
            Comando.CommandType = CommandType.Text;
            Comando.ExecuteNonQuery();
            Conexion.CerrarConexion();
        }
    }
}
