using System;

namespace Revisao
{
    class Program
    {
        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();
            Aluno[] alunos = new Aluno[5];
            var indiceAluno = 0;

            while (opcaoUsuario.ToLower() != "x")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        //Inserir novo aluno
                        Aluno aluno = new Aluno();
                        Console.WriteLine("Digite o nome do novo aluno:");
                        aluno.Nome = Console.ReadLine();
                        
                        Console.WriteLine("Digite a nota do aluno:");
                            //Parse > para mudar o tipo da variável dentro do parenteses
                            //var > é uma referência de tipo que pega o tipo do valor atribuído a ela
                            // var nota = decimal.Parse(Console.ReadLine());
                        if (decimal.TryParse(Console.ReadLine(), out decimal nota))
                        {
                            aluno.Nota = nota;
                        }
                        else {
                            throw new ArgumentException("O valor da nota deve ser um número decimal");
                        }

                        alunos[indiceAluno] = aluno;
                        indiceAluno++;
                        break;
                    case "2":
                        //Listar alunos
                        foreach (var alun in alunos)
                        {
                            //não é possível comparar com valor nulo, pois alun é uma struct
                            if (!string.IsNullOrEmpty(alun.Nome)) 
                                Console.WriteLine($"Aluno: {alun.Nome}, Nota: {alun.Nota}");
                        }
                        break;
                    case "3":
                        //Calcular média geral
                        decimal notaTotal = 0;
                        var numeroAlunos = 0;
                        for (int i = 0; i < alunos.Length; i++)
                        {
                            if (!string.IsNullOrEmpty(alunos[i].Nome))
                            {
                                notaTotal = notaTotal + alunos[i].Nota;
                                numeroAlunos = 1 + i;
                            }
                        }
                        decimal mediaGeral = notaTotal/numeroAlunos;
                        ConceitoEnum conceitoGeral;
                        if (mediaGeral < 3){
                            conceitoGeral = ConceitoEnum.E;
                        } else if (mediaGeral < 5){
                            conceitoGeral = ConceitoEnum.D;
                        } else if (mediaGeral < 6){
                            conceitoGeral = ConceitoEnum.C;
                        } else if (mediaGeral < 8){
                            conceitoGeral = ConceitoEnum.B;
                        } else {
                            conceitoGeral = ConceitoEnum.A;
                        }
                        

                        Console.WriteLine($"Média: {mediaGeral}, Conceito: {conceitoGeral}");
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
                opcaoUsuario = ObterOpcaoUsuario();
            }
        }

        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("Informe a opção desejada:");
            Console.WriteLine("1 - Inserir novo aluno");
            Console.WriteLine("2 - Listar alunos");
            Console.WriteLine("3 - Calcular média geral");
            Console.WriteLine("x - Sair");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine();

            return opcaoUsuario;
        }
    }
}
