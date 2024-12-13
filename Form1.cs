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

        //double valorAcumulado = 0;

        string ultimaOperacao = "";
        List<string> listaHistorico = new List<string>();
        string historico = "";

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
            //valorAcumulado = 0;
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

        //12/12
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
        }

        private void btnFracao_Click(object sender, EventArgs e)
        {
            operacao = "1/x";
        }

        private void btnPotencia_Click(object sender, EventArgs e)
        {
            operacao = "x²";
        }

        private void btnRaizQuadrada_Click(object sender, EventArgs e)
        {
            operacao = "raiz";
        }
        private void btnHistorico_Click(object sender, EventArgs e)
        {
            exibirHistorico();
        }

        //12/12
        private void preencherElementosDoVetor(string operacao, string[] vetCalculo)
        {
            if (vetCalculo[0] == "" & nroDigitado != "" & operacao != "=")
            {
                vetCalculo[0] = nroDigitado;
                vetCalculo[1] = operacao;
                if (operacao == "1/x" || operacao == "x²" || operacao == "raiz")
                {
                    calcularOperacaoEmCurso(vetCalculo);
                }

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
                    //vetCalculo[1] = "";
                }
            }          
        }

        //12/12
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

                case "1/x":
                    if(valorUM == 0)
                    {
                        resultado = "Não é possível divisão por zero";
                        gravarHistorico(vetCalculo, resultado);
                        limparPosicoesVetCalculo(vetCalculo);
                        this.txtOperacaoEmCurso.Clear();
                        this.txtResultado.Clear();
                        this.txtResultado.Text = resultado.ToString();
                    }else
                        resultado = (1/valorUM).ToString();
                    break;

                case "x²":
                    resultado = Math.Pow(valorUM, 2).ToString();
                    break;

                case "raiz":
                    resultado = Math.Sqrt(valorUM).ToString();
                    break;
            }
            operacao = "";
        }

        //12/12
        private void gravarHistorico(string[] vetCalculo, string resultado)
        {
            ultimaOperacao = $"{vetCalculo[0]} {vetCalculo[1]} {vetCalculo[2]} = {resultado}";
            listaHistorico.Add(ultimaOperacao);            
        }
        private void exibirHistorico()
        {
            foreach (string n in listaHistorico)
            {
                //ajustar exibição de linhas de historico
                historico += $"{n}       ";
            }
            MessageBox.Show(historico);
            historico = "";
        }
        //12/12 
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


