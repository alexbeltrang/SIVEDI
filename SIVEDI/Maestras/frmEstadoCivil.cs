﻿using Microsoft.VisualBasic;
using SIVEDI.Clases;
using SIVEDI.ServicioGeneral;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SIVEDI.Maestras
{
    public partial class frmEstadoCivil : Form
    {
        int intCodigoEstado = 0;
        public frmEstadoCivil()
        {
            InitializeComponent();
        }

        private void frmEstadoCivil_Load(object sender, EventArgs e)
        {
            this.BackColor = System.Drawing.ColorTranslator.FromHtml(System.Configuration.ConfigurationManager.AppSettings["color"]);
            totCampos.Active = clsConnection.blnAyudaEnlinea;
            dtgEstadoCivil.ReadOnly = true;
            llenaGrilla();
        }

        private void llenaGrilla()
        {
            ServiceClient servicioGeneral = new ServiceClient();
            var withBlock = dtgEstadoCivil;
            withBlock.DataSource = servicioGeneral.getEstadoCivil(3, 0);
        }
        private bool validaCampos()
        {
            if (txtEstadoCivil.Text == "" | txtEstadoCivil.Text == null)
            {
                MessageBox.Show("Digite el nombre del Estado Civil", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return false;
            }
            else if (!rbnActivo.Checked & !rbnInactivo.Checked)
            {
                MessageBox.Show("Seleccione el estado para el Estado Civil", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return false;
            }
            else
                return true;
        }
        private void limpiaCampos()
        {
            txtEstadoCivil.Text = null;
            rbnActivo.Checked = false;
            rbnInactivo.Checked = false;
            intCodigoEstado = 0;
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            limpiaCampos();
        }

        private void dtgEstadoCivil_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                intCodigoEstado = Convert.ToInt32(dtgEstadoCivil.Rows[e.RowIndex].Cells["CODIGO"].Value);
                txtEstadoCivil.Text = Convert.ToString(dtgEstadoCivil.Rows[e.RowIndex].Cells["NOMBRE"].Value);
                if (Convert.ToString(dtgEstadoCivil.Rows[e.RowIndex].Cells["ESTADO"].Value) == "ACTIVO")
                {
                    rbnActivo.Checked = true;
                    rbnInactivo.Checked = false;
                }
                else if (Convert.ToString(dtgEstadoCivil.Rows[e.RowIndex].Cells["ESTADO"].Value) == "INACTIVO")
                {
                    rbnInactivo.Checked = true;
                    rbnActivo.Checked = false;
                }
                else
                {
                    rbnActivo.Checked = true;
                    rbnInactivo.Checked = true;
                }
            }
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            if (validaCampos())
            {
                string strResultado;
                EstadoCivil estadoCivil = new EstadoCivil();
                ServiceClient servicioGeneral = new ServiceClient();
                if (rbnActivo.Checked)
                {
                    estadoCivil.ESTADO = true;
                }
                else if (rbnInactivo.Checked)
                {
                    estadoCivil.ESTADO = false;
                }
                estadoCivil.CODIGO = intCodigoEstado;
                estadoCivil.NOMBRE = txtEstadoCivil.Text.ToUpper();

                strResultado = Convert.ToString(servicioGeneral.insEstadoCivil(estadoCivil));
                if (Information.IsNumeric(strResultado))
                {
                    llenaGrilla();
                    limpiaCampos();
                    if (Convert.ToInt32(strResultado) == 1)
                    {
                        MessageBox.Show("Registro creado exitosamente", "Registro", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    }
                    else if (Convert.ToInt32(strResultado) == 2)
                    {
                        MessageBox.Show("Registro Actualizado exitosamente", "Actualización", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    }

                }
                else
                {
                    MessageBox.Show("Error al grabar en la Base de Datos, contacte al Administrador del Sistema", "Error BD", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                }
            }
        }
    }
}
