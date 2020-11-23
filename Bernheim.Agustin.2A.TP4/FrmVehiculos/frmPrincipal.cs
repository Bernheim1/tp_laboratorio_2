using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;
using Archivos;
using System.Data.SqlClient;

namespace FrmVehiculos
{
    public delegate void ultimoVendido();
    public partial class frmPrincipal : Form
    {
        #region Atributos
        private Concesionario<Vehiculos> concesionario;
        private DataTable tabla;

        private SqlConnection cn;
        private SqlDataAdapter da;

        public event ultimoVendido UltimoVendido;
        public Thread hiloUltimoVendido;

        public Vehiculos ultimoVendido;
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor del formulario principal
        /// </summary>
        public frmPrincipal()
        {
            InitializeComponent();

            this.concesionario = new Concesionario<Vehiculos>();

            this.cn = new SqlConnection(Properties.Settings.Default.conexionBD);
            this.da = new SqlDataAdapter();

            this.CrearDataTable();
            this.ConfigurarDataAdapter();
            this.ConfigurarGrilla();

            hiloUltimoVendido = new Thread(Actualizar);
            this.UltimoVendido += manejadorUltimoVendido;

            this.ObtenerListaPersonas();

            this.StartPosition = FormStartPosition.CenterScreen;

            this.CargarGrilla();
        }
        #endregion

        #region Botones
        /// <summary>
        /// Boton para agregar un vehiculo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAgregar_Click(object sender, EventArgs e)
        { 
        
            if (!this.AgregarObjeto())
            {
                MessageBox.Show("Error al INSERTAR el vehiculo", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
        }

        /// <summary>
        /// Boton para vender y eliminar un vehiculo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnVender_Click(object sender, EventArgs e)
        {
            if (!this.Eliminar())
            {
                MessageBox.Show("Error al ELIMINAR el vehiculo", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Boton para actualizar los datos a la base de datos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (!this.GuardarCambios())
            {
                MessageBox.Show("Error al ACTUALIZAR el vehiculo", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show("Los datos fueron actualizados", "ACTUALIZADO", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// Boton para guardar el concesionario en archivo de texto y XML
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!Concesionario<Vehiculos>.Guardar(concesionario) || !Concesionario<Vehiculos>.GuardarXml(concesionario))
            {
                MessageBox.Show("Error al GUARDAR el concesionario", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show("El concesionario fue guardado correctamente en el escritorio", "GUARDADO", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        #endregion

        #region FormClosing
        /// <summary>
        /// Pregunta si el usuario está seguro de cerrar sin actualizar, y cierra el hilo si sigue abierto
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("¿Está seguro de cerrar esta ventana? Perderá todos los datos si no presiona el boton Actualizar", "¿Seguro de cerrar?",
                                                        MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dialogResult == DialogResult.No)
            {
                e.Cancel = true;
            }
            else if(this.hiloUltimoVendido.IsAlive)
            {
                this.hiloUltimoVendido.Abort();
            }
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Crea el DataTable
        /// </summary>
        /// <returns></returns>
        public bool CrearDataTable()
        {
            bool res = true;

            try
            {
                this.tabla = new DataTable("vehiculos");

                this.tabla.Columns.Add("id", typeof(int));
                this.tabla.Columns.Add("marca", typeof(string));
                this.tabla.Columns.Add("precio", typeof(double));
                this.tabla.Columns.Add("patente", typeof(string));
                this.tabla.Columns.Add("tipo", typeof(string));

                this.tabla.PrimaryKey = new DataColumn[] { this.tabla.Columns[0] };

                this.tabla.Columns["id"].AutoIncrement = true;
                this.tabla.Columns["id"].AutoIncrementSeed = 1;
                this.tabla.Columns["id"].AutoIncrementStep = 1;

                this.dgv1.DataSource = this.tabla;
            }
            catch
            {
                res = false;
            }

            return res;
        }

        /// <summary>
        /// Carga la grilla con el metodo Fill
        /// </summary>
        /// <returns></returns>
        public bool CargarGrilla()
        {
            bool res = true;

            try
            {
                this.da.Fill(this.tabla);
                this.dgv1.DataSource = this.tabla;
            }
            catch (Exception e)
            {
                res = false;
                Console.WriteLine(e.Message);
            }

            return res;
        }

        /// <summary>
        /// Obtiene la lista de personas de la base de datos
        /// </summary>
        /// <returns></returns>
        public List<Vehiculos> ObtenerListaPersonas()
        {
            List<Vehiculos> lista = new List<Vehiculos>();

            try
            {
                this.cn.Open();

                SqlDataReader oDr = da.SelectCommand.ExecuteReader();

                while (oDr.Read())
                {
                    switch (oDr["tipo"].ToString())
                    {
                        case "Auto":
                            this.concesionario.Elementos.Add(new Auto(oDr.GetInt32(0), oDr["marca"].ToString(), (double)oDr["precio"], oDr["patente"].ToString()));
                            break;
                        case "Suv":
                            this.concesionario.Elementos.Add(new Suv(oDr.GetInt32(0), oDr["marca"].ToString(), (double)oDr["precio"], oDr["patente"].ToString()));
                            break;
                        case "Moto":
                            this.concesionario.Elementos.Add(new Moto(oDr.GetInt32(0), oDr["marca"].ToString(), (double)oDr["precio"], oDr["patente"].ToString()));
                            break;
                    }
                }

                oDr.Close();
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                if (this.cn.State == ConnectionState.Open)
                {
                    this.cn.Close();
                }
            }

            return lista;
        }

        /// <summary>
        /// Configura el DataAdapter
        /// </summary>
        /// <returns></returns>
        public bool ConfigurarDataAdapter()
        {
            bool rta = true;

            try
            {

                this.da.SelectCommand = new SqlCommand("SELECT * FROM [vehiculos].[dbo].[vehiculos]", cn);
                this.da.InsertCommand = new SqlCommand("INSERT INTO [vehiculos].[dbo].[vehiculos] (marca, precio, patente, tipo) VALUES (@marca, @precio, @patente, @tipo)", cn);
                this.da.UpdateCommand = new SqlCommand("UPDATE [vehiculos].[dbo].[vehiculos] SET marca=@marca, precio=@precio, patente=@patente, tipo=@tipo WHERE id=@id", cn);
                this.da.DeleteCommand = new SqlCommand("DELETE FROM [vehiculos].[dbo].[vehiculos] WHERE id=@id", cn);

                this.da.InsertCommand.Parameters.Add("@marca", SqlDbType.VarChar, 50, "marca");
                this.da.InsertCommand.Parameters.Add("@precio", SqlDbType.Float, 10, "precio");
                this.da.InsertCommand.Parameters.Add("@patente", SqlDbType.VarChar, 8, "patente");
                this.da.InsertCommand.Parameters.Add("@tipo", SqlDbType.VarChar, 50, "tipo");

                this.da.UpdateCommand.Parameters.Add("@marca", SqlDbType.VarChar, 50, "marca");
                this.da.UpdateCommand.Parameters.Add("@precio", SqlDbType.Float, 10, "precio");
                this.da.UpdateCommand.Parameters.Add("@patente", SqlDbType.VarChar, 8, "patente");
                this.da.UpdateCommand.Parameters.Add("@tipo", SqlDbType.VarChar, 50, "tipo");
                this.da.UpdateCommand.Parameters.Add("@id", SqlDbType.Int, 10, "id");

                this.da.DeleteCommand.Parameters.Add("@id", SqlDbType.Int, 10, "id");
            }
            catch (Exception e)
            {
                rta = false;
                Console.WriteLine(e.Message);
            }

            return rta;

        }

        /// <summary>
        /// Configura la grilla del formulario
        /// </summary>
        /// <returns></returns>
        private bool ConfigurarGrilla()
        {
            bool res = true;

            try
            {
                this.dgv1.RowsDefaultCellStyle.BackColor = Color.White;

                this.dgv1.ColumnHeadersDefaultCellStyle.Font = new Font(dgv1.Font, FontStyle.Bold);
                this.dgv1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                this.dgv1.GridColor = Color.Black;

                this.dgv1.MultiSelect = false;

                this.dgv1.EditMode = DataGridViewEditMode.EditProgrammatically;

                this.dgv1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

                this.dgv1.RowHeadersVisible = false;

                this.dgv1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                dgv1.AllowUserToResizeColumns = false;
                dgv1.AllowUserToResizeRows = false;

                dgv1.AllowUserToAddRows = false;
            }
            catch
            {
                res = false;
            }

            return res;
        }

        /// <summary>
        /// Agrega un objeto a la grilla
        /// </summary>
        /// <returns></returns>
        private bool AgregarObjeto()
        {
            bool res = true;

            try
            {

                frmVehiculo fv = new frmVehiculo();
                Vehiculos aux = default;

                if (fv.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    DataRow fila = this.tabla.NewRow();

                    fila["marca"] = fv.VehiculoDelFormulario.Marca;
                    fila["precio"] = fv.VehiculoDelFormulario.Precio;
                    fila["patente"] = fv.VehiculoDelFormulario.Patente;
                    fila["tipo"] = fv.Tipo;

                    this.tabla.Rows.Add(fila);

                    switch (fv.Tipo)
                    {
                        case "Auto":
                            aux = new Auto(fv.VehiculoDelFormulario.Marca, fv.VehiculoDelFormulario.Precio, fv.VehiculoDelFormulario.Patente);
                            break;
                        case "Suv":
                            aux = new Suv(fv.VehiculoDelFormulario.Marca, fv.VehiculoDelFormulario.Precio, fv.VehiculoDelFormulario.Patente);
                            break;
                        case "Moto":
                            aux = new Moto(fv.VehiculoDelFormulario.Marca, fv.VehiculoDelFormulario.Precio, fv.VehiculoDelFormulario.Patente);
                            break;
                    }

                    concesionario += aux;

                    this.da.Update(tabla);
                }
            }
            catch (Exception e)
            {
                res = false;
                Console.WriteLine(e.Message);
            }

            return res;
        }

        /// <summary>
        /// Elmina un objeto de la grilla
        /// </summary>
        /// <returns></returns>
        private bool Eliminar()
        {
            bool res = true;

            try
            {
                int indice = this.dgv1.SelectedRows[0].Index;

                DataRow fila = this.tabla.Rows[indice];

                int id = int.Parse(fila["id"].ToString());
                string marca = fila["marca"].ToString();
                double precio = (double)fila["precio"];
                string patente = fila["patente"].ToString();
                string tipo = fila["tipo"].ToString();

                frmVehiculo fp = null;
                Vehiculos aux = default;

                switch (tipo)
                {
                    case "Auto":
                        aux = new Auto(id, marca, precio, patente);
                        break;
                    case "Suv":
                        aux = new Suv(id, marca, precio, patente);
                        break;
                    case "Moto":
                        aux = new Moto(id, marca, precio, patente);
                        break;
                }

                fp = new frmVehiculo(aux);

                if (fp.ShowDialog() == DialogResult.OK)
                {
                    this.tabla.Rows[indice].Delete();
                    this.da.Update(tabla);
                    this.tabla = (DataTable)this.dgv1.DataSource;
                    this.concesionario -= aux;
                    this.ultimoVendido = aux;
                }

                if (!this.hiloUltimoVendido.IsAlive)
                {
                    this.UltimoVendido.Invoke();
                }
            }
            catch (Exception e)
            {
                res = false;
                MessageBox.Show(e.Message);
            }

            return res;
        }

        /// <summary>
        /// Guarda los cambios realizados en la grilla en la base de datos
        /// </summary>
        /// <returns></returns>
        public bool GuardarCambios()
        {
            bool res = true;

            try
            {
                this.da.Update(this.tabla);
            }
            catch (Exception e)
            {
                res = false;
                Console.WriteLine(e.Message);
            }

            return res;
        }

        /// <summary>
        /// Actualiza el txtUltimoVendido con el ultimo vehiculo vendido
        /// </summary>
        public void Actualizar()
        {
            do
            {
                Thread.Sleep(1000);
                if (this.txtUltimoVendido.InvokeRequired)
                {
                    this.BeginInvoke((MethodInvoker)delegate ()
                    {
                        this.txtUltimoVendido.Text = this.ultimoVendido.ToString();
                    }
                    );
                }
            }
            while (this.hiloUltimoVendido.IsAlive);
        }

        /// <summary>
        /// Manejador del evento UltimoVendido
        /// </summary>
        public void manejadorUltimoVendido()
        {
            this.hiloUltimoVendido.Start();
        }
        #endregion
    }
}
