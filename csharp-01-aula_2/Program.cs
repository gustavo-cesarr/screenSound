// Screen Sound
using System.Globalization;
using System.Linq.Expressions;

string mensagemDeBoasVindas = "Boas vindas ao Screen Sound";
//List<string> listaDasBandas = new List<string> {"U2", "The Beatles", "Calypso"};  

Dictionary<string, List<int>> bandasRegistradas = new Dictionary<string, List<int>>();
bandasRegistradas.Add("Linkin Park", new List<int> { 10, 8, 7 });
bandasRegistradas.Add("Flakes Power", new List<int>());

void ExibirLogo()
{
    Console.WriteLine(@"

░██████╗░█████╗░██████╗░███████╗███████╗███╗░░██╗  ░██████╗░█████╗░██╗░░░██╗███╗░░██╗██████╗░
██╔════╝██╔══██╗██╔══██╗██╔════╝██╔════╝████╗░██║  ██╔════╝██╔══██╗██║░░░██║████╗░██║██╔══██╗
╚█████╗░██║░░╚═╝██████╔╝█████╗░░█████╗░░██╔██╗██║  ╚█████╗░██║░░██║██║░░░██║██╔██╗██║██║░░██║
░╚═══██╗██║░░██╗██╔══██╗██╔══╝░░██╔══╝░░██║╚████║  ░╚═══██╗██║░░██║██║░░░██║██║╚████║██║░░██║
██████╔╝╚█████╔╝██║░░██║███████╗███████╗██║░╚███║  ██████╔╝╚█████╔╝╚██████╔╝██║░╚███║██████╔╝
╚═════╝░░╚════╝░╚═╝░░╚═╝╚══════╝╚══════╝╚═╝░░╚══╝  ╚═════╝░░╚════╝░░╚═════╝░╚═╝░░╚══╝╚═════╝░
");
    Console.WriteLine(mensagemDeBoasVindas);
}

void ExibirOpcoesDoMenu()
{
    ExibirLogo();
    Console.WriteLine("\nDigite 1 para registrar uma banda");
    Console.WriteLine("Digite 2 para mostrar todas as bandas");
    Console.WriteLine("Digite 3 para avaliar uma banda");
    Console.WriteLine("Digite 4 para exibir a média de uma banda");
    Console.WriteLine("Digite -1 para sair");

    Console.Write("\nDigite a sua opção: ");
    string opcaoEscolhida = Console.ReadLine()!;
    int opcaoEscolhidaNumerica = int.Parse(opcaoEscolhida);
    
    switch (opcaoEscolhidaNumerica)
    {
        case 1: RegistrarBanda();
            break;
        case 2: ExibirListaDeBandas();
            break;
        case 3: AvaliarBanda();
            break;
        case 4: Console.WriteLine("Você escolheu a opção " + opcaoEscolhidaNumerica);
            break;
        case -1: Console.WriteLine("Tchau tchau :)");
            break;
        default: Console.WriteLine("Opção inválida");
            break;
    }
}

void RegistrarBanda()
{
    Console.Clear();
    ExibirTituloDaOpcao("Registro de Bandas.");
    Console.Write("Digite o nome da banda que você deseja registrar: ");
    string nomeDaBanda = Console.ReadLine()!;
    bandasRegistradas.Add(nomeDaBanda, new List<int>());
    Console.WriteLine($"A banda {nomeDaBanda} foi registrada");
    Thread.Sleep(2000);
    ExibirOpcoesDoMenu();
}
void ExibirListaDeBandas()
{
    Console.Clear();
    ExibirTituloDaOpcao("Exibindo todas as bandas registradas!");
    /*for (int i=0; i < listaDasBandas.Count; i++)*/
    foreach (string banda in bandasRegistradas.Keys)
    {
        Console.WriteLine($"Banda: {banda}");
    }
    Console.WriteLine("\nPressione qualquer tecla para voltar ao menu principal.");
    Console.ReadKey();
    Console.Clear();
    ExibirOpcoesDoMenu();
}

void ExibirTituloDaOpcao(String titulo)
{
    int tamanhoTitulo = titulo.Length;
    string asterisco = string.Empty.PadLeft(tamanhoTitulo, '*');
    Console.WriteLine(asterisco);
    Console.WriteLine(titulo);
    Console.WriteLine(asterisco);

}

void AvaliarBanda()
{
    Console.Clear();
    ExibirTituloDaOpcao("Bem vindo ao campo de avaliação das bandas!\n");
    foreach (string banda in bandasRegistradas.Keys)
    {
        Console.WriteLine($"Banda: {banda}");
    }
    Console.Write("\nDigite o nome da banda que você deseja avaliar (O nome precisa ser idêntico): ");
    string nomeDaBanda = Console.ReadLine()!;
    if (bandasRegistradas.ContainsKey(nomeDaBanda))
    {
        Console.Write($"Qual nota a banda {nomeDaBanda} merece: ");
        int nota = int.Parse(Console.ReadLine()!);
        bandasRegistradas[nomeDaBanda].Add(nota);
        Console.WriteLine($"A nota foi registrada com sucesso para a banda {nomeDaBanda}.");
        Thread.Sleep(4000);
        Console.Clear();
        ExibirOpcoesDoMenu();

    } else { Console.WriteLine($"A banda {nomeDaBanda} não foi encontrada.");
        Console.WriteLine($"Pressione qualquer tecla para voltar ao menu principal. Após, ser redirecionado, selecione a opção 1 para cadastrar a banda {nomeDaBanda} e siga as instruções.");
        Console.ReadKey();
        Console.Clear();
        ExibirOpcoesDoMenu();
    }


}
ExibirOpcoesDoMenu();

