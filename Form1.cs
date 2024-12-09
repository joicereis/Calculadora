using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculadora
{
    public partial class frmCalculadora : Form
    {
        double nroDigitado;
        double primeiroValor = 0, segundoValor = 0;

        public frmCalculadora()
        {
            InitializeComponent();
        }
        private string Dividir(decimal primeiroValor, decimal segundoValor)
        {
            if (segundoValor == 0)
            {
                return "Não é possível dividir por zero.";
            }

            return (primeiroValor / segundoValor).ToString();
        }
        private void btnVirgula_Click(object sender, EventArgs e)
        {
            AcumularNumerosDigitados(this.btnVirgula.Text);
        }
        private void btn0_Click(object sender, EventArgs e)
        {
            AcumularNumerosDigitados(this.btn0.Text);
        }
        private void btn1_Click(object sender, EventArgs e)
        {
            AcumularNumerosDigitados(this.btn1.Text);
        }
        private void btn2_Click(object sender, EventArgs e)
        {
            AcumularNumerosDigitados(this.btn2.Text);
        }
        private void btn3_Click_1(object sender, EventArgs e)
        {
            AcumularNumerosDigitados(this.btn3.Text);
        }
        private void btn4_Click(object sender, EventArgs e)
        {
            AcumularNumerosDigitados(this.btn4.Text);
        }
        private void btn5_Click(object sender, EventArgs e)
        {
            AcumularNumerosDigitados(this.btn5.Text);
        }
        private void btn6_Click(object sender, EventArgs e)
        {
            AcumularNumerosDigitados(this.btn6.Text);
        }
        private void btn7_Click(object sender, EventArgs e)
        {
            AcumularNumerosDigitados(this.btn7.Text);
        }
        private void btn8_Click(object sender, EventArgs e)
        {
            AcumularNumerosDigitados(this.btn8.Text);
        }
        private void btn9_Click(object sender, EventArgs e)
        {
            AcumularNumerosDigitados(this.btn9.Text);
        }

        /*PROBLEMAS COM ESSA VALIAÇÃO - SE O NRO DIGITADO JÁ POSSUI UMA VIRGULA, NÃO DEVE SER ADICIONADO OUTRA.
        CASO CONTRARIO, A VIRGULA DEVE SER ADICIONADA À STRING*/
        private void AcumularNumerosDigitados(string valorDigitado)
        {
            if (valorDigitado == ",")
            {
                if (this.txtResultado.Text.Contains(valorDigitado))
                {
                    this.txtResultado.Text += "";
                    //nroDigitado = Convert.ToDouble(this.txtResultado.Text);
                }
                else
                    this.txtResultado.Text += ",";
            }
            else
            {
                this.txtResultado.Text += valorDigitado;
            }
            nroDigitado = Convert.ToDouble(this.txtResultado.Text);
            //return nroDigitado;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            this.txtResultado.Clear();
        }

        private void btnSoma_Click(object sender, EventArgs e)
        {
            MessageBox.Show(nroDigitado.ToString());

            if(txtOperacaoEmCurso.Text == "")
            {
                txtOperacaoEmCurso.Text = nroDigitado.ToString();
                primeiroValor += nroDigitado;
            }
            else
            {
                txtOperacaoEmCurso.Text = nroDigitado.ToString();
            }
            
            this.txtResultado.Clear();
        }
    }
}

// textBox com propriedades multilines

