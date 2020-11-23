using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;

namespace FrmVehiculos
{
    public partial class frmVehiculo : Form
    {
        #region Atributos
        private Vehiculos v;
        private string tipo;
        #endregion

        #region Constructores
        /// <summary>
        /// Constructor por defecto del formulario de Vehiculo
        /// </summary>
        public frmVehiculo()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        /// <summary>
        /// Constructor parametrizado para el formulario de Vehiculo con un Vehiculo como parametro
        /// </summary>
        /// <param name="v"></param>
        public frmVehiculo(Vehiculos v)
            :this()
        {
            this.v = v;

            this.txtMarca.Text = v.Marca;
            this.txtPrecio.Text = v.Precio.ToString(); 
            this.txtPatente.Text = v.Patente;
            this.comboBoxTipo.SelectedIndex = 0;
        }
        #endregion

        #region Propiedades
        /// <summary>
        /// Propiedad que retorna el vehiculo del formulario frmVehiculo
        /// </summary>
        public Vehiculos VehiculoDelFormulario
        {
            get { return v; }
        }

        /// <summary>
        /// Propiedad que retorna el tipo del vehiculo
        /// </summary>
        public string Tipo
        {
            get { return this.tipo; }
        }
        #endregion

        #region Botones
        /// <summary>
        /// Boton que crea asigna valores al atributo vehiculo de la clase segun su tipo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            this.v = default;
            try
            {
                if (this.comboBoxTipo.SelectedIndex != -1 && this.txtMarca.Text != "" && this.txtPrecio.Text != "" && this.txtPatente.Text != "")
                {
                    switch (this.comboBoxTipo.SelectedIndex)
                    {
                        case 0:
                            this.v = new Auto(this.txtMarca.Text, float.Parse(this.txtPrecio.Text), this.txtPatente.Text);
                            this.tipo = "Auto";
                            break;
                        case 1:
                            this.v = new Suv(this.txtMarca.Text, float.Parse(this.txtPrecio.Text), this.txtPatente.Text);
                            this.tipo = "Suv";
                            break;
                        case 2:
                            this.v = new Moto(this.txtMarca.Text, float.Parse(this.txtPrecio.Text), this.txtPatente.Text);
                            this.tipo = "Moto";
                            break;
                    }

                    this.DialogResult = System.Windows.Forms.DialogResult.OK;
                }
                else
                {
                    throw new Exception();
                }
            }
            catch(Exception ex)
            {
                this.DialogResult = System.Windows.Forms.DialogResult.Abort;
                Console.WriteLine(ex.Message);
            }

        }

        /// <summary>
        /// Boton que cancela la ejecucion del formulario frmVehiculo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }
        #endregion
    }
}
