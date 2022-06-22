using Classe;

public class Program
{
    private static void Main(string[] args)
    {
        var indiceAluno = 0;
        Aluno[] alunos = new Aluno[5];
        string opcaoUsuario = ObterOpcaoUsuario();

        while (opcaoUsuario.ToUpper() != "X")
        {
            switch (opcaoUsuario)
            {
                case "1":
                    Console.WriteLine("Insira o nome do aluno");
                    Aluno aluno = new Aluno();
                    aluno.Nome = Console.ReadLine();

                    Console.WriteLine("Informe a nota do Aluno");

                    if (decimal.TryParse(Console.ReadLine(), out decimal nota))
                    {
                        aluno.Nota = nota;
                    }
                    else
                    {
                        throw new ArgumentException("Valor da nota deve ser décimal.");
                    }

                    alunos[indiceAluno] = aluno;
                    indiceAluno++;
                    break;

                case "2":
                    foreach (var a in alunos)
                    {
                        if (!string.IsNullOrEmpty(a.Nome))
                        {
                            Console.WriteLine($"Aluno: {a.Nome} - NOTA: {a.Nota}");
                        }
                    }

                    break;

                case "3":
                    decimal notaTotal = 0;
                    var nrAlunos = 0;

                    for (int i = 0; i < alunos.Length; i++)
                    {
                        if (!string.IsNullOrEmpty(alunos[i].Nome))
                        {
                            notaTotal = notaTotal + alunos[i].Nota;
                            nrAlunos++;
                        }
                    }
                    var mediaGeral = notaTotal / nrAlunos;
                    System.Console.WriteLine($"A média geral é: {mediaGeral}");
                    break;

                default:
                    throw new ArgumentOutOfRangeException();
            }

            opcaoUsuario = ObterOpcaoUsuario();
        };

        static string ObterOpcaoUsuario()
        {
            Console.WriteLine($"|===============================|");
            Console.WriteLine($"|Informe a Opção desejada:      |");
            Console.WriteLine($"|1 - Inserir novo aluno         |");
            Console.WriteLine($"|2 - Listar alunos              |");
            Console.WriteLine($"|3 - Calcular média geral       |");
            Console.WriteLine($"|X = Sair                       |");
            Console.WriteLine($"|===============================|");

            string opcaoUsuario = Console.ReadLine();
            return opcaoUsuario;
        }
    }
}