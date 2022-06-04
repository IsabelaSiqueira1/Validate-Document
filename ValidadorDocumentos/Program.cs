using Caelum.Stella.CSharp.Format;
using Caelum.Stella.CSharp.Validation;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValidadorDocumentos
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string CPF1 = "19561948001";
            string CPF2 = "98745366797";
            string CPF3 = "22222222222";

            ValidarCPF(CPF1);
            ValidarCPF(CPF2);
            ValidarCPF(CPF3);

            string CNPJ1 = "18499922000150";
            string CNPJ2 = "58797653000123";
            string CNPJ3 = "33079726000117";

            ValidarCNPJ(CNPJ1);
            ValidarCNPJ(CNPJ2);
            ValidarCNPJ(CNPJ3);

            string titulo1 = "845585840132";
            string titulo2 = "508365340110";

            ValidarTitulo(titulo1);
            ValidarTitulo(titulo2);

            Debug.WriteLine(CPF1);
             
            // Formatar um cpf
            //iden potencia = o mesmo metodo aplicado para um resultado, que retornou o mesmo resultado esperado
            string cpfFormatado = new CPFFormatter().Format(CPF1);
            Debug.WriteLine(cpfFormatado);

            Debug.WriteLine(new CPFFormatter().Format(cpfFormatado));

            // Desformatar um cpf
            Debug.WriteLine(new CPFFormatter().Unformat(cpfFormatado));
            
            // Formatar um CPNJ
            Debug.WriteLine(CNPJ1);
            Debug.WriteLine(new CNPJFormatter().Format(CNPJ1));

            //Formatar titulo eleitoral
            Debug.WriteLine(titulo1);
            Debug.WriteLine(new TituloEleitoralFormatter().Format(titulo1));
        }

        private static void ValidarTitulo(string titulo)
        {
            if (new TituloEleitoralValidator().IsValid(titulo))
            {
                Debug.WriteLine("Titulo válido: " + titulo);
            }
            else
            {
                Debug.WriteLine("Titulo inválido: " + titulo);
            }
        }

        private static void ValidarCNPJ(string cnpj)
        {
            if (new CNPJValidator().IsValid(cnpj))
            {
                Debug.WriteLine("CNPJ válido: " + cnpj);
            }
            else
            {
                Debug.WriteLine("CNPJ inválido: " + cnpj);
            }
        }

        private static void ValidarCPF(string cpf)
        {
            try
            {
                new CPFValidator().AssertValid(cpf);
                Debug.WriteLine("CPF válido: " + cpf);
            }
            catch (Exception exc)
            {
                Debug.WriteLine("CPF inválido: " + cpf + " : " + exc.ToString());
            }

            //metodo para retornar um valor booleano, mesma forma para cnpj e titulo eleitoral
          
            if (new CPFValidator().IsValid(cpf))
            {
                Debug.WriteLine("CPF válido: " + cpf);
            }
            else
            {
                Debug.WriteLine("CPF inválido: " + cpf);
            }
           
        }


    }   

        
}
