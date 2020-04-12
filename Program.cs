using System;
using System.Threading;

namespace AdivinheSepuder_Lista4
{
    class Program
    {
        /*  
        Grupo: 
            Fabricio Henrique | Matricula: 1924070026
            Heloisa Rocco | Matricula: 1924070015
         */
        static void Main ()
        {
            // Gerando dos valores aleatorios Max e Min
            Random rnd = new Random ();
            // Inicializando um tupla para quardar os valores (doc sobre tupla: https://bit.ly/2Vo0Eu0)
            // maximos e minimos
            (int max, int min) valores = (0, 0);
            //Imprime na tela o texto com cada caracter de uma cor diferente
            TextoColorido ("Bem vindo ao ADIVINHE SE PUDER! XD", rnd, 100);
            // Seleciona a Dificuldade e atribui
            // o intervalo de valores correspondente  
            valores = SelecaoDeDificuldade (valores, rnd);
            // Organizando os valores para o maior valor ficar no valores.max
            // e o menor ficar no valores.min
            valores = OrganizarValores (valores);
            // Gerando um valor entre Max e Min
            int senha = rnd.Next (valores.min, valores.max);
            // Mostrando quantos digitos a senha tem
            Console.WriteLine (DicaQuantosDigitos (senha));
            // Input do usuario
            // Analisando o input e imprimindo o resultado com um "Animacao"
            Tentativas (senha, rnd);
            //Pergunta se o usuario quer reniciar o jogo ou sair
            DerrotaOuReniciar (senha);
        }
        static (int, int) OrganizarValores ((int max, int min) valores)
        {
            // Para nao perder nem um valor e necessario
            // uma 3º variavel
            int aux = 0;
            // Ordenado os valores
            // valores.min -> aux (o min ta vazio)
            //valores.max -> valores.min (o max min ta vazio e o min nao esta mais)
            // aux -> valores.max (agora esta tudo organizado)
            if (valores.min > valores.max)
            {
                aux = valores.min;
                valores.min = valores.max;
                valores.max = aux;
            }
            return valores;
        }
        static string DicaQuantosDigitos (int senha)
        {
            // Tranformando a senha em um array
            // de char
            char[] charSeha = senha.ToString ().ToCharArray ();
            string stringSenha = "";
            // Para cada elemento no array stringSenha recebe *
            foreach (var item in charSeha)
            {
                stringSenha += "*";
            }
            // Quantidade de digitos da senha 
            return stringSenha;
        }
        static void TextoColorido (string texto, Random rnd, int tempoDeExcrita = 250)
        {
            // Lista da cores para o texto 0 a 14
            ConsoleColor[] cores = {
            ConsoleColor.Red,
            ConsoleColor.Green,
            ConsoleColor.Blue,
            ConsoleColor.Cyan,
            ConsoleColor.Magenta,
            ConsoleColor.Yellow,
            ConsoleColor.White,
            ConsoleColor.Gray,
            ConsoleColor.DarkRed,
            ConsoleColor.DarkBlue,
            ConsoleColor.DarkGreen,
            ConsoleColor.DarkCyan,
            ConsoleColor.DarkGray,
            ConsoleColor.DarkMagenta,
            ConsoleColor.DarkYellow
            };
            // Transformando o texto em um array de char
            char[] charTexto = texto.ToCharArray ();
            // Imprimindo os caracteres do array
            // e pegando um cor aleatorio para cada caracter
            for (int i = 0; i < texto.Length; i++)
            {
                Console.ForegroundColor = cores[rnd.Next (0, 14)];
                Console.Write (texto[i]);
                // Para fazer a "animacao" mnadei o Thread("processador")
                // parar por 0,25s(o Thread.Sleep usa ms) 
                Thread.Sleep (tempoDeExcrita);
            }
        }
        static (int, int) SelecaoDeDificuldade ((int max, int min) valores, Random rnd)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine ("\nFacil valores de 0 a 100 | Medio vaores de 0 a 2000 | Dificil valores de 10000 a 90000\n");
            Console.WriteLine ("Selecione a dificualdade: F->facil | M->medio | D->dificil ");
            // helo: ToUpper permite que o usuário coloque minusculo e fique maiusculo 
            char dificualdade = char.Parse (Console.ReadLine ().ToUpper ());
            //Ve qual e a dificuldade selecionade e aplica os valores
            switch (dificualdade)
            {
                case 'F':
                    valores = (rnd.Next (0, 100), rnd.Next (0, 100));
                    return valores;
                case 'M':
                    valores = (rnd.Next (0, 2000), rnd.Next (0, 2000));
                    return valores;
                case 'D':
                    valores = (rnd.Next (10000, 90000), rnd.Next (10000, 90000));
                    return valores;
                default:
                    Console.Clear ();
                    Main ();
                    break;
            }
            return valores;
        }
        static void DerrotaOuReniciar (int senha)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine ("VOCE PERDEU ;-; aperte R para reniciar ou S para sair");
            System.Console.WriteLine ($"A senha era {senha}");
            char continuar = char.Parse (Console.ReadLine ().ToUpper ());
            switch (continuar)
            {
                case 'R':
                    // limpa o console e roda a Main de novo
                    Console.Clear ();
                    Main ();
                    break;
                case 'S':
                    return;
                default:
                    return;
            }
        }
        static void Tentativas (int senha, Random rnd, int maxTentarivas = 5)
        {
            Console.Write ("Digite a Senha: ");
            int input = int.Parse (Console.ReadLine ());
            if (input == senha)
            {
                TextoColorido ("Voce acertou", rnd);
                return;
            }

            else if (input != senha && maxTentarivas != 0)
            {
                maxTentarivas--;
                TextoColorido ("Voce errou \n", rnd);
                // Para fazer a "animacao" mnadei o Thread("processador")
                // parar por 0,4s(o Thread.Sleep usa ms) 
                Thread.Sleep (400);
                // Roda essa funcao/metodo denovo
                // diminundo o numero de tentarivas
                maxTentarivas--;
                Tentativas (senha, rnd);
            }
        }
    }
}