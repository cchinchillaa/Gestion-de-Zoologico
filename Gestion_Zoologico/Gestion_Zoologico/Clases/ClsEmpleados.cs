using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_Zoologico.Clases
{
    internal class ClsEmpleados
    {
        private ConexionBD Conexion = new ConexionBD();
        private SqlCommand Comando = new SqlCommand();
        private SqlDataReader LeerFilas;


        //ATRIBUTOS
        private int idempleado;
        private int idArea;
        private int idLugarArea;
        private int idhora;
        private string nombre;
        private string direccion;
        private double telefono;

        //metodos get y set

        public int _Idempleado
        {
            get { return idempleado; }
            set { idempleado = value; }
        }

        public int _IdArea
        {
            get { return idArea; }
            set { idArea = value; }
        }
        public int _IdLugarArea
        {
            get { return idLugarArea; }
            set { idLugarArea = value; }
        }
        public int _Idhora
        {
            get { return idhora; }
            set { idhora = value; }
        }
        public string _Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        public string _Direccion
        {
            get { return direccion; }
            set { direccion = value; }
        }

        public double _Telefono
        {
            get { return telefono; }
            set { telefono = value; }
        }



        public DataTable ListarAreas()
        {
            DataTable Tabla = new DataTable();
            Comando.Connection = Conexion.AbrirConexion();
            Comando.CommandText = "ListarAreas";
            Comando.CommandType = CommandType.StoredProcedure;
            LeerFilas = Comando.ExecuteReader();
            Tabla.Load(LeerFilas);
            LeerFilas.Close();
            Conexion.CerrarConexion();
            return Tabla;
        }

        public DataTable ListarLugarArea()
        {
            DataTable Tabla = new DataTable();
            Comando.Connection = Conexion.AbrirConexion();
            Comando.CommandText = "ListarLugarArea";
            Comando.CommandType = CommandType.StoredProcedure;
            LeerFilas = Comando.ExecuteReader();
            Tabla.Load(LeerFilas);
            LeerFilas.Close();
            Conexion.CerrarConexion();
            return Tabla;
        }

        public DataTable ListarHora()
        {
            DataTable Tabla = new DataTable();
            Comando.Connection = Conexion.AbrirConexion();
            Comando.CommandText = "ListarHora";
            Comando.CommandType = CommandType.StoredProcedure;
            LeerFilas = Comando.ExecuteReader();
            Tabla.Load(LeerFilas);
            LeerFilas.Close();
            Conexion.CerrarConexion();
            return Tabla;
        }

        public void InsertarEmpleados()
        {
            Comando.Connection = Conexion.AbrirConexion();
            Comando.CommandText = "AgregarEmpleado";
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.Parameters.AddWithValue("@idarea", idArea);
            Comando.Parameters.AddWithValue("@idlugar_area", idLugarArea);
            Comando.Parameters.AddWithValue("@idhora", idhora);
            Comando.Parameters.AddWithValue("@nombre", nombre);
            Comando.Parameters.AddWithValue("@direccion", direccion);
            Comando.Parameters.AddWithValue("@telefono", telefono);
            Comando.ExecuteNonQuery();
            Comando.Parameters.Clear();
            Conexion.CerrarConexion();
        }

        public DataTable ListarEmpleados()
        {
            DataTable Tabla = new DataTable();
            Comando.Connection = Conexion.AbrirConexion();
            Comando.CommandText = "ListarEmpleados";
            Comando.CommandType = CommandType.StoredProcedure;
            LeerFilas = Comando.ExecuteReader();
            Tabla.Load(LeerFilas);
            LeerFilas.Close();
            Conexion.CerrarConexion();
            return Tabla;
        }

        public void EliminarProducto()
        {
            Comando.Connection = Conexion.AbrirConexion();
            Comando.CommandText = "delete EMPLEADOS where IDEMPLEADO=" + idempleado;
            Comando.CommandType = CommandType.Text;
            Comando.ExecuteNonQuery();
            Conexion.CerrarConexion();
        }


        public void EditarProductos()
        {
            Comando.Connection = Conexion.AbrirConexion();
            Comando.CommandText = "update EMPLEADOS set IDAREA=" + idArea + ",IDLUGAR_AREA=" + idLugarArea + ",IDHORA=" + idhora + ",NOMBRE='" + nombre + "',DIRECCION='" + direccion + "',TELEFONO=" + telefono + " where IDEMPLEADO=" + idempleado;

            Comando.CommandType = CommandType.Text;
            Comando.ExecuteNonQuery();
            Conexion.CerrarConexion();
        }

        public DataTable ListarLimpieza()
        {
            DataTable Tabla = new DataTable();
            Comando.Connection = Conexion.AbrirConexion();
            Comando.CommandText = "ListarEmpleadosLimpieza";
            Comando.CommandType = CommandType.StoredProcedure;
            LeerFilas = Comando.ExecuteReader();
            Tabla.Load(LeerFilas);
            LeerFilas.Close();
            Conexion.CerrarConexion();
            return Tabla;
        }

        public void EditarEmpleadosLimpieza()
        {
            Comando.Connection = Conexion.AbrirConexion();
            Comando.CommandText = "update EMPLEADOS set IDLUGAR_AREA=" + idLugarArea + ",IDHORA=" + idhora + " where IDEMPLEADO=" + idempleado;
            Comando.CommandType = CommandType.Text;
            Comando.ExecuteNonQuery();
            Conexion.CerrarConexion();
        }
    }
}
