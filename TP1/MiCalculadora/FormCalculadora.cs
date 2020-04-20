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

namespace MiCalculadora
{
    public partial class FormCalculadora : Form
    {
        public FormCalculadora()
        {
            InitializeComponent();
        }

        private void Limpiar()
        {
            this.textNumero1.Text = "";
            this.textNumero2.Text = "";
            this.comboOperador.Text = "";
            this.labelResultado.Text = "0";
            buttonConvertirABinario.Enabled = true;
        }

        public static double Operar(string num1, string num2, string operador)
        {
            Numero numero1 = new Numero(num1);
            Numero numero2 = new Numero(num2);
            double retorno = Calculadora.Operar(numero1, numero2, operador);

            return retorno;
        }

        private void buttonOperar_Click(object sender, EventArgs e)
        {
            double auxResultado = FormCalculadora.Operar(textNumero1.Text, textNumero2.Text, comboOperador.Text);
            labelResultado.Text = auxResultado.ToString();
            buttonConvertirABinario.Enabled = true;
        }

        private void buttonLimpiar_Click(object sender, EventArgs e)
        {
            this.Limpiar();
        }

        private void buttonCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonConvertirABinario_Click(object sender, EventArgs e)
        {
            string auxResultado = Numero.DecimalBinario(labelResultado.Text);
            labelResultado.Text = auxResultado;
        }

        private void buttonConvertirADecimal_Click(object sender, EventArgs e)
        {
            string auxResultado = Numero.BinarioDecimal(labelResultado.Text);
            labelResultado.Text = auxResultado;
            if (labelResultado.Text == "Valor invalido!")
            {
                buttonConvertirABinario.Enabled = false;
            }
        }
    }
}
