// Screen Sound
using System.Globalization;
using System.Linq.Expressions;

string mensagemDeBoasVindas = "Boas vindas ao Screen Sound";
//List<string> listaDasBandas = new List<string> {"U2", "The Beatles", "Calypso"};  



// Dicionário de bandas registradas, onde a chave é o nome da banda
// e o valor é uma lista de notas (inteiros) atribuídas a essa banda.

// Dicionário criado vazio por conta dos parênteses no final.
// Chaves são string e valores são listas de inteiros.
Dictionary<string, List<int>> bandasRegistradas = new Dictionary<string, List<int>>();

// Adicionando bandas ao dicionário com notas iniciais.
// nomeDoDicionário + .Add -> Realizando a adição de elementos ao dicionário.
// Repare como precisou colocar new List<int> para criar uma nova lista de inteiros para cada banda.
bandasRegistradas.Add("Linkin Park", new List<int> { 10, 8, 7 });
bandasRegistradas.Add("Flakes Power", new List<int>());


// Função void para exibir a logo do Screen Sound no console.
// O "@" antes da string permite que a string seja interpretada como um literal, preservando quebras de linha e outros caracteres especiais.
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


// Criação do Menu.
// Função void para exibir as opções do menu e chamar outras funções com base na escolha do usuário.
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
        case 4: ExibirMediaDaBanda();
            break;
        case -1: Console.WriteLine("Tchau tchau :)");
            break;
        default: Console.WriteLine("Opção inválida");
            break;
    }
}


// Função de registrar uma banda.
// Primeiro é feito a limpeza do terminal.
// Em seguida, é exibido o título da opção escolhida. Que é feito através de uma função que recebe o título como parâmetro.
// Depois, é solicitado ao usuário que digite o nome da banda que deseja registrar. Essa string é guardada em uma variável chamada nomeDaBanda.
// Em seguida, é adicionado ao dicionário bandasRegistradas a chave nomeDaBanda e um novo valor que é uma lista de inteiros vazia.
void RegistrarBanda()
{
    Console.Clear();
    ExibirTituloDaOpcao("Registro de Bandas.");
    Console.Write("Digite o nome da banda que você deseja registrar: ");
    string nomeDaBanda = Console.ReadLine()!;
    bandasRegistradas.Add(nomeDaBanda, new List<int>());
    Console.WriteLine($"A banda {nomeDaBanda} foi registrada!");
    Thread.Sleep(2000);
    ExibirOpcoesDoMenu();
}

// Função para exibir a lista de bandas registradas.
// Primeiro é feito a limpeza do terminal.
// Em seguida, é exibido o título da opção escolhida. Que é feito através de uma função que recebe o título como parâmetro.
// Utilização de um loop foreach para percorrer todas as chaves do dicionário bandasRegistradas e exibir o nome de cada banda.
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


// Função para exibir o título da opção escolhida.
// Primeiro é calculado o tamanho do título com a propriedade Length da string.
// Esse valor é armazenado em uma variável chamada tamanhoTitulo.
// Em seguida, é criado uma string de asteriscos com o mesmo tamanho do título utilizando o método PadLeft.
// O método PadLeft coloca a string original à esquerda e preenche o restante com o caractere especificado (neste caso, o asterisco).
// Como utilizamos string.Empty, estamos começando com uma string vazia e adicionando asteriscos à esquerda até atingir o tamanho desejado.
// A função rece be o título como parâmetro e exibe o título e os asteriscos no console.
void ExibirTituloDaOpcao(String titulo) // Parâmetro do tipo string chamado titulo
{
    int tamanhoTitulo = titulo.Length;
    string asterisco = string.Empty.PadLeft(tamanhoTitulo, '*');
    Console.WriteLine(asterisco);
    Console.WriteLine(titulo); // Assume o Parâmetro titulo e exibe no console.
    Console.WriteLine(asterisco);

}


// Função para avaliar uma banda.
// Primeiro é feito a limpeza do terminal.
// Em seguida, é exibido o título da opção escolhida. Que é feito através de uma função que recebe o título como parâmetro.
// Depois, é exibida a lista de bandas registradas para que o usuário possa escolher qual banda deseja avaliar, tudo isso através de um loop foreach que percorre todas as chaves do dicionário bandasRegistradas.
// Em seguida, é solicitado ao usuário que digite o nome da banda que deseja avaliar.

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
    if (bandasRegistradas.ContainsKey(nomeDaBanda)) // ContainsKey é um método do dicionário que verifica se a chave especificada existe no dicionário. Retorna true se a chave existir, caso contrário, retorna false.
    {
        Console.Write($"Qual nota a banda {nomeDaBanda} merece: ");
        int nota = int.Parse(Console.ReadLine()!);
        bandasRegistradas[nomeDaBanda].Add(nota); // Uma vez que a banda foi indexada, podemos acessar a lista de notas e adicionar a nova nota com o método Add.
        Console.WriteLine($"A nota foi registrada com sucesso para a banda {nomeDaBanda}.");
        Thread.Sleep(2000);
        Console.Clear();
        ExibirOpcoesDoMenu();

    } else { Console.WriteLine($"A banda {nomeDaBanda} não foi encontrada.");
        Console.WriteLine($"Pressione qualquer tecla para voltar ao menu principal. Após, ser redirecionado, selecione a opção 1 para cadastrar a banda {nomeDaBanda} e siga as instruções.");
        Console.ReadKey();
        Console.Clear();
        ExibirOpcoesDoMenu();
    }
}


// Função para exibir a média de uma banda.
// Primeiro é feito a limpeza do terminal.
// Em seguida, é exibido o título da opção escolhida. Que é feito através de uma função que recebe o título como parâmetro.
// Depois, é exibida a lista de bandas registradas para que o usuário possa escolher qual banda deseja ver a média, tudo isso através de um loop foreach que percorre todas as chaves do dicionário bandasRegistradas.
void ExibirMediaDaBanda()
{
    Console.Clear();
    ExibirTituloDaOpcao("Exibindo a média de uma banda");
    Console.WriteLine("\nBandas registradas: \n");
    
    foreach (string banda in bandasRegistradas.Keys)
    {
        Console.WriteLine($"Banda: {banda}");
    }
    Console.Write("\nDigite o nome da banda que você deseja ver a média: ");
    string bandaDesejada = Console.ReadLine()!;
    if (bandasRegistradas.ContainsKey(bandaDesejada)) // ContainsKey é um método do dicionário que verifica se a chave especificada existe no dicionário. Retorna true se a chave existir, caso contrário, retorna false.
    {
        double media = bandasRegistradas[bandaDesejada].Average(); // Average é um método do LINQ que calcula a média dos elementos de uma coleção. No caso, estamos calculando a média das notas da banda desejada.
        // Procuramos a banda desejada no dicionário bandasRegistradas, acessamos a lista de notas associada a essa banda e chamamos o método Average() para calcular a média das notas.
        Console.WriteLine($"A média da banda {bandaDesejada} é: {media}");
        Console.WriteLine($"Pressione qualquer tecla para voltar ao menu principal.");
        Console.ReadKey();
        Console.Clear();
        ExibirOpcoesDoMenu();
    } else
    {
        Console.WriteLine($"A banda {bandaDesejada} não foi encontrada.");
        Console.WriteLine($"Pressione qualquer tecla para voltar ao menu principal.");
        Console.ReadKey();
        Console.Clear();
        ExibirOpcoesDoMenu();
    }
}

ExibirOpcoesDoMenu();

