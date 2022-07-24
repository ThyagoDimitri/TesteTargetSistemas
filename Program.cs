using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace TargetSistemas

{
    class Program
    {
        static int exercicio;
        //Exercicio 1
        static int buscaFibonacci;
        static List<int> fibonacci = new List<int>();
        //Exercicio 2
        static List<RendimentoMes> mes = new List<RendimentoMes>();
        static List<RendimentoMes> acimaDaMedia = new List<RendimentoMes>();
        static float media;
        static RendimentoMes menorRendimento;
        static RendimentoMes maiorRendimento;
        //Exercicio 3
        static List<RendimentoEstado> estados = new List<RendimentoEstado>();
        static float rendimentoTotal;
        //Exercicio 4
        static string texto;
        static string otxet;

        static void Main(string[] args)
        {
            Console.WriteLine("Escolha um exercicio: ");
            Console.WriteLine("1- Exercicio deFibonacci");
            Console.WriteLine("2- Exercicio de rendimento do mes");
            Console.WriteLine("3- Exercicio de rendimento do estado");
            Console.WriteLine("4- Exercicio de inverter string");
            exercicio = Convert.ToInt32(Console.ReadLine());
            switch (exercicio)
            {
                case 1:
                    Exercicio1();
                    break;
                case 2:
                    Exercicio2();
                    break;
                case 3:
                    Exercicio3();
                    break;
                case 4:
                    Exercicio4();
                    break;

            }


        }

        static void Exercicio1()
        {
            fibonacci.Add(0);
            fibonacci.Add(1);
            Console.WriteLine("Digite um número: ");
            buscaFibonacci = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine(fibonacci[fibonacci.Count - 1]);
            Console.WriteLine(fibonacci[fibonacci.Count - 2]);
            while (buscaFibonacci > fibonacci[fibonacci.Count - 1])
            {
                fibonacci.Add(fibonacci[fibonacci.Count - 1] + fibonacci[fibonacci.Count - 2]);
                Console.WriteLine(fibonacci[fibonacci.Count - 1]);
            }
            if (buscaFibonacci == fibonacci[fibonacci.Count - 1])
            {
                Console.WriteLine("Esse número faz parte da sequência de Fibonacci");
            }
            else
            {
                Console.WriteLine("Esse número nao faz parte da sequência de Fibonnaci");
            }
        }
        static void Exercicio2()
        {
            var filename = "dados.json";
            StreamReader r = new StreamReader(filename);

            string json = r.ReadToEnd();

            mes = JsonConvert.DeserializeObject<List<RendimentoMes>>(json);
            foreach (var dia in mes)
            {
                if (menorRendimento == null)
                {
                    menorRendimento = dia;
                }
                else if (menorRendimento.Valor > dia.Valor)
                {
                    menorRendimento = dia;
                }
                if (maiorRendimento == null)
                {
                    maiorRendimento = dia;
                }
                else if (maiorRendimento.Valor < dia.Valor)
                {
                    maiorRendimento = dia;
                }
                media += dia.Valor;

            }
            media = media / mes.Count;
            foreach (var dia in mes)
            {
                if (dia.Valor > media)
                {
                    acimaDaMedia.Add(dia);
                }
            }
            Console.WriteLine("o menor rendimento do mês foi de R$" + menorRendimento.Valor);
            Console.WriteLine("o maior rendimento do mês foi de R$" + maiorRendimento.Valor);
            Console.WriteLine("o total de dias com rendimento acima da média é de: " + acimaDaMedia.Count);
        }
        static void Exercicio3()
        {
            estados.Add(new RendimentoEstado("SP", 67836.43f));
            estados.Add(new RendimentoEstado("RJ", 36678.66f));
            estados.Add(new RendimentoEstado("MG", 29229.88f));
            estados.Add(new RendimentoEstado("ES", 27165.48f));
            estados.Add(new RendimentoEstado("Outros", 19849.53f));
            foreach (var estado in estados)
            {
                rendimentoTotal += estado.RendimentoReais;
            }
            foreach (var estado in estados)
            {
                estado.RendimentoPercent = estado.RendimentoReais / rendimentoTotal;
                Console.WriteLine("Estado: " + estado.UF + " Valor em reais: " + estado.RendimentoReais + " Porcentagem de contribuição: " + (estado.RendimentoPercent * 100).ToString("c2") + "%");
            }

        }

        static void Exercicio4()
        {
            Console.WriteLine("Escreva uma frase: ");
            texto = Console.ReadLine();
            StringBuilder builder = new StringBuilder(texto.Length);
            for (int i = texto.Length - 1; i >= 0; i--)
            {
                otxet = builder.Append(texto[i]).ToString();
            }
            Console.WriteLine(otxet);
        }

    }

}

