using System;

namespace DIO.Musical
{
    class Program
    {
        static SerieRepositorio repositorio = new MusicalRepositorio();
        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();

			while (opcaoUsuario.ToUpper() != "X")
			{
				switch (opcaoUsuario)
				{
					case "1":
						ListarMusicais();
						break;
					case "2":
						InserirMusical();
						break;
					case "3":
						AtualizarMusical();
						break;
					case "4":
						ExcluirMusicall();
						break;
					case "5":
						VisualizarMusical();
						break;
					case "C":
						Console.Clear();
						break;

					default:
						throw new ArgumentOutOfRangeException();
				}

				opcaoUsuario = ObterOpcaoUsuario();
			}

			Console.WriteLine("Obrigado por utilizar nossos serviços.");
			Console.ReadLine();
        }

        private static void ExcluirMusical()
		{
			Console.Write("Digite o id da musical: ");
			int indiceSerie = int.Parse(Console.ReadLine());

			repositorio.Exclui(indiceMusical);
		}

        private static void VisualizarMusical()
		{
			Console.Write("Digite o id da musica: ");
			int indiceMusical = int.Parse(Console.ReadLine());

			var musical = repositorio.RetornaPorId(indiceMusical);

			Console.WriteLine(musical);
		}

        private static void AtualizarSerie()
		{
			Console.Write("Digite o id da musical: ");
			int indiceMusical = int.Parse(Console.ReadLine());

			// https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getvalues?view=netcore-3.1
			// https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getname?view=netcore-3.1
			foreach (int i in Enum.GetValues(typeof(Genero)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
			}
			Console.Write("Digite o gênero entre as opções acima: ");
			int entradaGenero = int.Parse(Console.ReadLine());

			Console.Write("Digite o Título da Musical: ");
			string entradaTitulo = Console.ReadLine();

			Console.Write("Digite o Ano de Início da Musical: ");
			int entradaAno = int.Parse(Console.ReadLine());

			Console.Write("Digite a Descrição da Musical: ");
			string entradaDescricao = Console.ReadLine();

			Musical AtualizarMusical = new Musical(id: indiceMusical,
										genero: (Genero)entradaGenero,
										titulo: entradaTitulo,
										ano: entradaAno,
										descricao: entradaDescricao);

			repositorio.Atualiza(indiceMusical, atualizaMusical);
		}
        private static void ListarMusicais()
		{
			Console.WriteLine("Listar musicais");

			var lista = repositorio.Lista();

			if (lista.Count == 0)
			{
				Console.WriteLine("Nenhuma musical cadastrada.");
				return;
			}

			foreach (var musical in lista)
			{
                var excluido = musical.retornaExcluido();
                
				Console.WriteLine("#ID {0}: - {1} {2}", musical.retornaId(), musical.retornaTitulo(), (excluido ? "*Excluído*" : ""));
			}
		}

        private static void InserirMusical()
		{
			Console.WriteLine("Inserir nova musical");

			// https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getvalues?view=netcore-3.1
			// https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getname?view=netcore-3.1
			foreach (int i in Enum.GetValues(typeof(Genero)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
			}
			Console.Write("Digite o gênero entre as opções acima: ");
			int entradaGenero = int.Parse(Console.ReadLine());

			Console.Write("Digite o Título da Musical: ");
			string entradaTitulo = Console.ReadLine();

			Console.Write("Digite o Ano de Início da Musical: ");
			int entradaAno = int.Parse(Console.ReadLine());

			Console.Write("Digite a Descrição da Musical: ");
			string entradaDescricao = Console.ReadLine();

			Musical novaMusical = new musical(id: repositorio.ProximoId(),
										genero: (Genero)entradaGenero,
										titulo: entradaTitulo,
										ano: entradaAno,
										descricao: entradaDescricao);

			repositorio.Insere(novoMusical);
		}

        private static string ObterOpcaoUsuario()
		{
			Console.WriteLine();
			Console.WriteLine("DIO Musicais a seu dispor!!!");
			Console.WriteLine("Informe a opção desejada:");

			Console.WriteLine("1- Listar musicais");
			Console.WriteLine("2- Inserir nova musicais");
			Console.WriteLine("3- Atualizar musicais");
			Console.WriteLine("4- Excluir musicais");
			Console.WriteLine("5- Visualizar musicais");
			Console.WriteLine("C- Limpar Tela");
			Console.WriteLine("X- Sair");
			Console.WriteLine();

			string opcaoUsuario = Console.ReadLine().ToUpper();
			Console.WriteLine();
			return opcaoUsuario;
		}
    }
}
