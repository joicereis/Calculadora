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
        string[] vetCalculo = new string[4] { "", "", "", "" }; //vetor das operacoes acumuladas
        
        string nroDigitado = "";
        double valorUM = 0.0; double valorDois = 0.0;
        string operacao = "";

        double valorAcumulado = 0;

        public frmCalculadora()
        {
            InitializeComponent();
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

        private void acumularValoresDigitados(string valorDigitado)
        {
    
            if (valorDigitado == ",")
            {
                if (this.txtResultado.Text.Contains(valorDigitado))
                {
                    this.txtResultado.Text += "";
                }
                else
                    this.txtResultado.Text += ",";
            }
            else
                this.txtResultado.Text += valorDigitado;
            nroDigitado = this.txtResultado.Text;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            limparPosicoesVetCalculo(vetCalculo);
            this.txtOperacaoEmCurso.Clear();
            this.txtResultado.Clear();
            valorAcumulado = 0;
            nroDigitado = "";
            valorUM = 0.0;
            valorDois = 0.0;
            operacao = "";
        }
        //12/12 - noite
        private void btnSoma_Click(object sender, EventArgs e)
        {
            operacao = "+";
            preencherElementosDoVetor(operacao, vetCalculo);
            preencherTxtOperacaoEmCurso();
        }

        //12/12 - noite
        private void btnSubtrai_Click(object sender, EventArgs e)
        {
            operacao = "-";
            preencherElementosDoVetor(operacao, vetCalculo);
            preencherTxtOperacaoEmCurso();
        }

        private void btnMultiplica_Click(object sender, EventArgs e)
        {
            operacao = "*";
            preencherElementosDoVetor(operacao, vetCalculo);
            preencherTxtOperacaoEmCurso();
        }
        private void btnDivide_Click(object sender, EventArgs e)
        {
            operacao = "/";
            preencherElementosDoVetor(operacao, vetCalculo);
            preencherTxtOperacaoEmCurso();
        }


        private void btnResultado_Click(object sender, EventArgs e)
        {
            operacao = "=";
            preencherElementosDoVetor(operacao, vetCalculo);
            preencherTxtOperacaoEmCurso();
            // preencherTxtOperacaoEmCurso();

            /*
            if(vetCalculo[0] != "" & vetCalculo[1] != "" & nroDigitado != "")
            {
                vetCalculo[2] = nroDigitado;
                calcularOperacaoEmCurso(vetCalculo);
                this.txtOperacaoEmCurso.Text = vetCalculo[0];
                limparAcumulo();
            }
            */
        }

        //12/12 - noite
        private void preencherElementosDoVetor(string operacao, string[] vetCalculo)
        {
            if (vetCalculo[0] == "" & nroDigitado != "" & operacao != "=")
            {
                vetCalculo[0] = nroDigitado;
                vetCalculo[1] = operacao;
                limparAcumulo();
            }
            else if (vetCalculo[0] != "" & vetCalculo[2] == "" & operacao != "=")
            {
                if (nroDigitado == "") //& operacao != "="
                {
                    vetCalculo[1] = operacao;
                }
                else if (nroDigitado != "") //& operacao != "="
                {
                    vetCalculo[2] = nroDigitado;
                    vetCalculo[3] = operacao;
                    calcularOperacaoEmCurso(vetCalculo);
                    limparAcumulo();
                }
            }
            else if(vetCalculo[0] != "" & vetCalculo[1] != "" & operacao == "=")
            {
                if (nroDigitado != "") //& operacao != "="
                {
                    vetCalculo[2] = nroDigitado;
                    vetCalculo[3] = operacao;
                    calcularOperacaoEmCurso(vetCalculo);
                    limparAcumulo();
                    vetCalculo[1] = "";
                }
            
                /*
            else if (nroDigitado != "" & operacao == "=")
            {
                //this.txtOperacaoEmCurso.Text = "tst igual";
                vetCalculo[2] = nroDigitado;
                vetCalculo[3] = operacao;
                //this.txtOperacaoEmCurso.Text = $"{vetCalculo[0]} {vetCalculo[1]} {vetCalculo[2]} = ";
                calcularOperacaoEmCurso(vetCalculo);
                limparAcumulo();
                vetCalculo[1] = "";



                /*
                vetCalculo[2] = nroDigitado;
                vetCalculo[3] = operacao;
                calcularOperacaoEmCurso(vetCalculo);
                limparAcumulo();
                */
            }
            
        }

        //12/12 - noite
        private void calcularOperacaoEmCurso(string[] vetCalculo)
        {
            double valorUM = Convert.ToDouble(vetCalculo[0]);
            string operacaoEmCurso = vetCalculo[1];
            double valorDois = Convert.ToDouble(vetCalculo[2]);
            string resultado = "";

            switch (operacaoEmCurso)
            {
                case "+":
                    resultado = (valorUM + valorDois).ToString();
                    gravarHistorico(vetCalculo, resultado);
                    reordenarVetor(resultado, vetCalculo);
                    break;

                case "-":
                    resultado = (valorUM - valorDois).ToString();
                    gravarHistorico(vetCalculo, resultado);
                    reordenarVetor(resultado, vetCalculo);
                    break;

                case "*":
                    resultado = (valorUM * valorDois).ToString();
                    gravarHistorico(vetCalculo, resultado);
                    reordenarVetor(resultado, vetCalculo);
                    break;

                case "/":
                    validaDivisaoPorZero(vetCalculo, valorUM, valorDois);
                    break;
            }
            operacao = "";
        }

        //12/12 - noite
        private void gravarHistorico(string[] vetCalculo, string resultado)
        {
            string ultimaOperacao = $"{vetCalculo[0]} {vetCalculo[1]} {vetCalculo[2]} = {resultado}";
            List<string> listaHistorico = new List<string>();
            listaHistorico.Add(ultimaOperacao);
        }

        //12/12 - noite
        private void reordenarVetor(string resultado, string[] vetCalculo)
        {
            vetCalculo[0] =  resultado;
            vetCalculo[1] =  vetCalculo[3];
            vetCalculo[2] = "";
            vetCalculo[3] = "";
        }

        private void limparPosicoesVetCalculo(string[] vetCalculo)
        {
            for (int index = 0; index < vetCalculo.Length; index++)
                vetCalculo[index] = "";
        }

        private void preencherTxtOperacaoEmCurso()
        {
            this.txtOperacaoEmCurso.Text = $"{vetCalculo[0]}{vetCalculo[1]}";
            string tst = this.txtOperacaoEmCurso.Text;
        }

        private void validaDivisaoPorZero(string[] vetCalculo, double valorUM, double valorDois)
        {
            if (valorDois == 0) {
                string resultado = "Não é possível divisão por zero";
                gravarHistorico(vetCalculo, resultado);
                limparPosicoesVetCalculo(vetCalculo);
                this.txtOperacaoEmCurso.Clear();
                this.txtResultado.Clear();
                this.txtResultado.Text = resultado.ToString();
            }
            else
            {
                string resultado = (valorUM / valorDois).ToString();
                gravarHistorico(vetCalculo, resultado);
                reordenarVetor(resultado, vetCalculo);
            }
            
        }

        private void limparAcumulo()
        {
            nroDigitado = "";
            this.txtResultado.Clear();
        }

    }
}


