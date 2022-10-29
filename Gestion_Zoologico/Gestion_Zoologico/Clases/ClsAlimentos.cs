using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_Zoologico.Clases
{
    internal class ClsAlimentos
    {
        private ConexionBD Conexion = new ConexionBD();
        private SqlCommand Comando = new SqlCommand();
        private SqlDataReader LeerFilas;


        //ATRIBUTOS

        private int idalimento;
        private int idpesoymedida;
        private float cantidad;
        private string alimento;
        private string fecha_ingreso;
        private string feha_vencimiento;

        public float _Cantidad
        {
            get { return cantidad; }
            set { cantidad = value; }
        }


        public int _Idalimento
        {
            get { return idalimento; }
            set { idalimento = value; }
        }
        public string _Alimento
        {
            get { return alimento; }
            set { alimento = value; }
        }
        public int _Idpesoymedida
        {
            get { return idpesoymedida; }
            set { idpesoymedida = value; }
        }


        public string _Fecha_ingreso
        {
            get { return fecha_ingreso; }
            set { fecha_ingreso = value; }
        }

        public string _Feha_vencimiento
        {
            get { return feha_vencimiento; }
            set { feha_vencimiento = value; }
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

        public DataTable ListarAlimentos()
        {
            DataTable Tabla = new DataTable();
            Comando.Connection = Conexion.AbrirConexion();
            Comando.CommandText = "ListarTotalAlimentos";
            Comando.CommandType = CommandType.StoredProcedure;
            LeerFilas = Comando.ExecuteReader();
            Tabla.Load(LeerFilas);
            LeerFilas.Close();
            Conexion.CerrarConexion();
            return Tabla;
        }


        public void InsertarAlimento()
        {
            Comando.Connection = Conexion.AbrirConexion();
            Comando.CommandText = "AgregarAlimento";
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.Parameters.AddWithValue("@idpeso_y_medida", idpesoymedida);
            Comando.Parameters.AddWithValue("@alimento", alimento);
            Comando.Parameters.AddWithValue("@cantidad", cantidad);
            Comando.Parameters.AddWithValue("@fecha_ingreso", Convert.ToDateTime(fecha_ingreso));
            Comando.Parameters.AddWithValue("@fecha_vencimiento", Convert.ToDateTime(feha_vencimiento));
            Comando.ExecuteNonQuery();
            Comando.Parameters.Clear();
            Conexion.CerrarConexion();
        }

        public void EliminarAlimento()
        {
            Comando.Connection = Conexion.AbrirConexion();
            Comando.CommandText = "delete ALIMENTOS where IDALIMENTO=" + idalimento;
            Comando.CommandType = CommandType.Text;
            Comando.ExecuteNonQuery();
            Conexion.CerrarConexion();
        }

        public void EditarAlimento()
        {
            Comando.Connection = Conexion.AbrirConexion();
            Comando.CommandText = "update ALIMENTOS set IDPESO_Y_MEDIDA=" + idpesoymedida + ",ALIMENTO='" + alimento + "',CANTIDAD='" + cantidad + "',FECHA_INGRESO='" + fecha_ingreso + "',FECHA_VENCIMIENTO='" + feha_vencimiento + "' where IDALIMENTO=" + idalimento;
            Comando.CommandType = CommandType.Text;
            Comando.ExecuteNonQuery();
            Conexion.CerrarConexion();
        }
    }
}
