using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_Zoologico.Clases
{
    internal class ClsMedicamentos
    {
        private ConexionBD Conexion = new ConexionBD();
        private SqlCommand Comando = new SqlCommand();
        private SqlDataReader LeerFilas;


        //ATRIBUTOS
        private int idmedicamento;
        private int idanimales_aplicables;
        private int idclasificacion_medicamento;
        private int id_tipomedicamento;
        private string medicamento;
        private string fecha_ingreso;
        private string feha_vencimiento;

        //metodos get y set

        public int _Idmedicamento
        {
            get { return idmedicamento; }
            set { idmedicamento = value; }
        }


        public int _Idanimales_aplicables
        {
            get { return idanimales_aplicables; }
            set { idanimales_aplicables = value; }
        }
        public int _Idclasificacion_medicamento
        {
            get { return idclasificacion_medicamento; }
            set { idclasificacion_medicamento = value; }
        }
        public int _Id_tipomedicamento
        {
            get { return id_tipomedicamento; }
            set { id_tipomedicamento = value; }
        }
        public string _Medicamento
        {
            get { return medicamento; }
            set { medicamento = value; }
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

        public DataTable ListarAnimalesAplicables()
        {
            DataTable Tabla = new DataTable();
            Comando.Connection = Conexion.AbrirConexion();
            Comando.CommandText = "ListarAnimalesAplicables";
            Comando.CommandType = CommandType.StoredProcedure;
            LeerFilas = Comando.ExecuteReader();
            Tabla.Load(LeerFilas);
            LeerFilas.Close();
            Conexion.CerrarConexion();
            return Tabla;
        }


        public DataTable ListarClasificacionMedicamentos()
        {
            DataTable Tabla = new DataTable();
            Comando.Connection = Conexion.AbrirConexion();
            Comando.CommandText = "ListarClasificacionMedicamentos";
            Comando.CommandType = CommandType.StoredProcedure;
            LeerFilas = Comando.ExecuteReader();
            Tabla.Load(LeerFilas);
            LeerFilas.Close();
            Conexion.CerrarConexion();
            return Tabla;
        }

        public DataTable ListarTipoMedicamentos()
        {
            DataTable Tabla = new DataTable();
            Comando.Connection = Conexion.AbrirConexion();
            Comando.CommandText = "ListarTipoMedicamentos";
            Comando.CommandType = CommandType.StoredProcedure;
            LeerFilas = Comando.ExecuteReader();
            Tabla.Load(LeerFilas);
            LeerFilas.Close();
            Conexion.CerrarConexion();
            return Tabla;
        }

        public void InsertarMedicamentos()
        {
            Comando.Connection = Conexion.AbrirConexion();
            Comando.CommandText = "AgregarMedicamento";
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.Parameters.AddWithValue("@idanimales_aplicable", idanimales_aplicables);
            Comando.Parameters.AddWithValue("@idclasificacion_medicamento", idclasificacion_medicamento);
            Comando.Parameters.AddWithValue("@idtipo_medicamento", id_tipomedicamento);
            Comando.Parameters.AddWithValue("@medicamento", medicamento);
            Comando.Parameters.AddWithValue("@fecha_ingreso", Convert.ToDateTime(fecha_ingreso));
            Comando.Parameters.AddWithValue("@fecha_vencimiento", Convert.ToDateTime(_Feha_vencimiento));
            Comando.ExecuteNonQuery();
            Comando.Parameters.Clear();
            Conexion.CerrarConexion();
        }

        public DataTable ListarMedicamentos()
        {
            DataTable Tabla = new DataTable();
            Comando.Connection = Conexion.AbrirConexion();
            Comando.CommandText = "ListarMedicamentos";
            Comando.CommandType = CommandType.StoredProcedure;
            LeerFilas = Comando.ExecuteReader();
            Tabla.Load(LeerFilas);
            LeerFilas.Close();
            Conexion.CerrarConexion();
            return Tabla;
        }

        public void EliminarMedicamento()
        {
            Comando.Connection = Conexion.AbrirConexion();
            Comando.CommandText = "delete MEDICAMENTOS where IDMEDICAMENTO=" + idmedicamento;
            Comando.CommandType = CommandType.Text;
            Comando.ExecuteNonQuery();
            Conexion.CerrarConexion();
        }

        public void EditarMedicamentos()
        {
            Comando.Connection = Conexion.AbrirConexion();
            Comando.CommandText = "update MEDICAMENTOS set IDANIMALES_APLICABLE=" + idanimales_aplicables + ",IDCLASIFICACION_MEDICAMENTO=" + idclasificacion_medicamento + ",IDTIPO_MEDICAMENTO=" + id_tipomedicamento + ",MEDICAMENTO='" + medicamento + "',FECHA_INGRESO='" + fecha_ingreso + "',FECHA_VENCIMIENTO='" + feha_vencimiento + "' where IDMEDICAMENTO=" + idmedicamento;
            Comando.CommandType = CommandType.Text;
            Comando.ExecuteNonQuery();
            Conexion.CerrarConexion();
        }
    }
}
