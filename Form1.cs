using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculadora
{
    public partial class frmCalculadora : Form
    {
        double nroDigitado= 0;
        double valorAcumulado = 0, segundoValor = 0;
        string operacao = "";
        string expressao = "";

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
            acumularValoresDigitados(this.btnVirgula.Text);
        }
        private void btn0_Click(object sender, EventArgs e)
        {
            acumularValoresDigitados(this.btn0.Text);
        }
        private void btn1_Click(object sender, EventArgs e)
        {
            acumularValoresDigitados(this.btn1.Text);
        }
        private void btn2_Click(object sender, EventArgs e)
        {
            acumularValoresDigitados(this.btn2.Text);
        }
        private void btn3_Click_1(object sender, EventArgs e)
        {
            acumularValoresDigitados(this.btn3.Text);
        }
        private void btn4_Click(object sender, EventArgs e)
        {
            acumularValoresDigitados(this.btn4.Text);
        }
        private void btn5_Click(object sender, EventArgs e)
        {
            acumularValoresDigitados(this.btn5.Text);
        }
        private void btn6_Click(object sender, EventArgs e)
        {
            acumularValoresDigitados(this.btn6.Text);
        }
        private void btn7_Click(object sender, EventArgs e)
        {
            acumularValoresDigitados(this.btn7.Text);
        }
        private void btn8_Click(object sender, EventArgs e)
        {
            acumularValoresDigitados(this.btn8.Text);
        }
        private void btn9_Click(object sender, EventArgs e)
        {
            acumularValoresDigitados(this.btn9.Text);
        }

        /*PROBLEMAS COM ESSA VALIAÇÃO - SE O NRO DIGITADO JÁ POSSUI UMA VIRGULA, NÃO DEVE SER ADICIONADO OUTRA.
        CASO CONTRARIO, A VIRGULA DEVE SER ADICIONADA À STRING*/
        private void acumularValoresDigitados(string valorDigitado)
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
            txtOperacaoEmCurso.Clear();
            this.txtResultado.Clear();
            valorAcumulado = 0;
        }

        private void btnMultiplica_Click(object sender, EventArgs e)
        {
            if (txtOperacaoEmCurso.Text == "" & this.txtResultado.Text != "")
            {
                operacao = "x";
                valorAcumulado = nroDigitado;
                txtOperacaoEmCurso.Text = $"{valorAcumulado.ToString()} {operacao}";
                this.txtResultado.Clear();
            }
            else if (txtOperacaoEmCurso.Text != "" & this.txtResultado.Text == "")
            {
                operacao = "x";
                txtOperacaoEmCurso.Text = $"{valorAcumulado.ToString()} {operacao}";
            }
            else
            {
                //se já havi um expressão sendo construída antes, el deve ser mantida
                calcularOperacaoEmCurso(valorAcumulado, operacao);
                this.txtResultado.Clear();
                operacao = "x";
                txtOperacaoEmCurso.Text = $"{valorAcumulado.ToString()} {operacao}";
            }
        }

        private void btnSoma_Click(object sender, EventArgs e)
        {
            if (txtOperacaoEmCurso.Text == "" & this.txtResultado.Text != "")
            {
                operacao = "+";
                valorAcumulado = nroDigitado;
                txtOperacaoEmCurso.Text = $"{valorAcumulado.ToString()} {operacao}";
                this.txtResultado.Clear();
            }
            else if (txtOperacaoEmCurso.Text != "" & this.txtResultado.Text == "")
            {
                operacao = "+";
                txtOperacaoEmCurso.Text = $"{valorAcumulado.ToString()} {operacao}";
            }
            else
            {
                calcularOperacaoEmCurso(valorAcumulado, operacao);
                this.txtResultado.Clear();
                operacao = "+";
                txtOperacaoEmCurso.Text = $"{valorAcumulado.ToString()} {operacao}";
            }
        }

        private void calcularOperacaoEmCurso(double valorEmCurso, string operacao)
        {
                switch (operacao)
                {
                    case "+":
                    valorAcumulado += nroDigitado;
                    break;

                    case "x":
                    valorAcumulado *= nroDigitado;
                    break;
                    ;               }

        }
    }
}

// textBox com propriedades multilines

