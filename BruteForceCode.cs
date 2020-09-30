using System;
using System.Linq;

namespace BruteForce
{
    class Program
    {
        #region Declaração de Variáveis
        static char[] caraters = "abcdefghijklmnopqrstuvwxyz0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ!#$%&'()*+,-./:;<=>?@[]^_`".ToCharArray();
        static string oldPass;
        static bool stop, aprovado;
        static DateTime inicio, fim;
        #endregion

        static void Main(string[] args)
        {
            #region Declaração da palavra-passe com verificação
            do
            {
                Console.WriteLine("Por favor insira uma password com um limite de 20 carateres,\nque só contenha carateres do alfabeto inglês, porque eu sou preguiçoso: ");
                oldPass = Console.ReadLine();
                if (oldPass.Length > 20) oldPass = oldPass.Substring(0, 20);
                for(int x=0; x<=oldPass.Length-1;x++)
                {
                    if (caraters.Contains(oldPass[x]) != true)
                    {
                        aprovado = false;
                        break;
                    }
                    aprovado = true;
                }
            } while (aprovado != true);
            Console.Clear();
            Console.WriteLine("Password gravada.\nProcesso de Brute Force iniciado!");
            #endregion //Verifica se o utilizador inseriu uma password compativel com o código.

            inicio = DateTime.Now; //Inicia o Timer.
            
            for (int i = 0; i <= caraters.Length; i++) //Alimenta um valor incremental ao gerador
            {
                gerar("", 0, i);
            }
        }

        static public void gerar(string str, int pos, int length)
        {
            if (length == 0) //A cada combinação corre o código em baixo.
            {
                if(str==oldPass) //Verifica se a combinação atual é igual à password introduzida.
                {
                    stop = true; //Dá o sinal para parar de gerar combinações
                    fim = DateTime.Now; //Obtem o tempo final
                    TimeSpan tempo = fim.Subtract(inicio); //Calcula o tempo demorado
                    Console.WriteLine("Palavra-passe crackeada! A sua palavra-passe é: " + str); //Apresenta a password
                    Console.WriteLine("Demorou: "+ tempo.ToString(@"hh\:mm\:ss\:fff")); //Apresenta o tempo demorado
                }
            }
            else
            {
                if (pos != 0) pos = 0; //Reseta a posição sempre para o primeiro carater.
                for (int i = 0; i <= caraters.Length - 1; i++)
                {
                    if (stop == true) break; //Recebe o sinal para parar
                    gerar(str + caraters[i], i, length - 1); //Acrescenta caraters a uma string vazia, gerando combinações
                }
            }
        }
    }
}
