// Screen Sound
using System.Globalization;
using System.Linq.Expressions;


string mensagemDeBoasVindas = "Boas vindas ao Screen Sound";
//List<string> listaDasBandas = new List<string> {"U2", "The Beatles", "Calypso"};  

// Dicionário de bandas registradas, onde a chave é o nome da banda
// e o valor é uma lista de notas (inteiros) atribuídas a essa banda.

// Lista vazia por conta dos parênteses no final.
// Chaves são string e valores são listas de inteiros.
List<Banda> bandasRegistradas = new List<Banda>();

// Adicionando bandas ao dicionário com notas iniciais.
// nomeDoDicionário + .Add -> Realizando a adição de elementos ao dicionário.
// Repare como precisou colocar new List<int> para criar uma nova lista de inteiros para cada banda.
List<Musica> listaDeMusicas = new List<Musica>();


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
    Console.WriteLine("Digite 3 para avaliar uma música");
    Console.WriteLine("Digite 4 para exibir a média de uma banda");
    Console.WriteLine("Digite 5 para registrar uma música");
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
        case 3: AvaliarMusica();
            break;
        case 4: ExibirMediaDaBanda();
            break;
        case 5: RegistrarMusica();
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
    Console.Write("Digite o gênero da banda que você deseja registrar: ");
    string generoDaBanda = Console.ReadLine()!;
    bandasRegistradas.Add(new Banda(nomeDaBanda, new List<int>(), generoDaBanda, new List<Musica>()));
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
    foreach (Banda banda in bandasRegistradas) // Listando objetos do tipo Banda, que é a classe que criamos. Através do foreach, podemos percorrer todos os elementos da lista bandasRegistradas e exibir o nome de cada banda.
    {
        Console.WriteLine($"Banda: {banda.Nome}");
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


void AvaliarMusica()
{
    Console.Clear();
    ExibirTituloDaOpcao("Bem vindo ao campo de avaliação das musicas!\n");
    foreach (Banda banda in bandasRegistradas)
    {
        Console.WriteLine($"Banda: {banda.Nome}");
    }
    Console.Write("\nDigite o nome da banda que você deseja avaliar (O nome precisa ser idêntico): ");
    string nomeDaBanda = Console.ReadLine()!;
    Banda bandaEncontrada = bandasRegistradas.FirstOrDefault(b => b.Nome == nomeDaBanda)!;
    if (bandaEncontrada != null) 
    {
        if (bandaEncontrada.ListaMusicas.Count <= 0)
        {
            Console.Write($"\nA banda {bandaEncontrada.Nome} ainda não possui nenhuma música para ser avaliada.");
            Console.ReadKey();
            Console.WriteLine("Pressione qualquer tecla para voltar ao menu principal.");
            ExibirOpcoesDoMenu();
        } else{
        do{
            Console.Write($"Qual musica da banda {bandaEncontrada.Nome} você deseja avaliar? \n");
            Console.Write($"Ou digite F para voltar ao menu principal.\n");
            foreach (Musica musica in bandaEncontrada.ListaMusicas)
                {
                    Console.WriteLine($"Música: {musica.Nome}");
                }
            string musicaSelecionada = Console.ReadLine()!;
            if (musicaSelecionada == "F"){
                Console.WriteLine("\nVocê será redirecionado...");
                Thread.Sleep(3000);
                Console.Clear();
                ExibirOpcoesDoMenu();
                break;   
                }
            Musica musicaExiste = bandaEncontrada.ListaMusicas.FirstOrDefault(m => m.Nome == musicaSelecionada)!;
            if (musicaExiste != null){
                Console.Write("Digite a nota para a música: ");    
                int nota = int.Parse(Console.ReadLine()!);
                musicaExiste.Notas.Add(nota);
                Console.WriteLine($"A nota foi registrada com sucesso para a musica {musicaSelecionada} da banda {bandaEncontrada.Nome}.");
                break;
            }
            else
            {
                Console.WriteLine($"A música {musicaSelecionada} não existe ou foi digitada incorretamente.\n");
                Console.WriteLine($"Pressione qualquer tecla para digitar a música novamente.");
                Console.ReadKey();
                Console.Clear();        
            }
        }while(true);
        Thread.Sleep(2000);
        Console.Clear();
        ExibirOpcoesDoMenu();
        }

    } else { Console.WriteLine($"A banda {nomeDaBanda} não foi encontrada.");
        Console.WriteLine($"Pressione qualquer tecla para voltar ao menu principal. Após, ser redirecionado, selecione a opção 1 para cadastrar a banda {nomeDaBanda} e siga as instruções.");
        Console.ReadKey();
        Console.Clear();
        ExibirOpcoesDoMenu();
    }
}

void ExibirMediaDaBanda()
{
    Console.Clear();
    ExibirTituloDaOpcao("Exibindo a média de uma banda");
    Console.WriteLine("\nBandas registradas: \n");
    
    foreach (string banda in bandasRegistradas)
    {
        Console.WriteLine($"Banda: {banda}");
    }
    Console.Write("\nDigite o nome da banda que você deseja ver a média: ");
    string bandaDesejada = Console.ReadLine()!;
    Banda bandaEncontrada = bandasRegistradas.FirstOrDefault(b => b.Nome == bandaDesejada)!;
    if (bandaEncontrada != null) 
    {
        double media = bandasRegistradas[bandaDesejada].Average(); 
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

void RegistrarMusica()
{
    Console.Clear();
    ExibirTituloDaOpcao("Registrando uma música");
    Console.Write("\nBanda autora: \n");
    foreach (Banda banda in bandasRegistradas)
    {
        Console.WriteLine($"Banda: {banda}");
    }
    Console.Write("\nDigite o nome da banda que você deseja registrar a música: \n");
    string nomeBanda = Console.ReadLine()!;
    Banda bandaEncontrada = bandasRegistradas.FirstOrDefault(b => b.Nome == nomeBanda)!;
    if (bandaEncontrada != null)
    {
        Console.Write("\nDigite o nome da música: \n");
        string nomeMusica = Console.ReadLine()!;
        Console.Write("\nDigite o gênero da música: \n");
        string generoMusica = Console.ReadLine()!;
        Console.Write("\nDigite a duração da música em segundos: \n");
        int duracaoMusica = int.Parse(Console.ReadLine()!);

        Musica novaMusica = new Musica(nomeMusica, generoMusica, duracaoMusica, new List<double>());
        bandaEncontrada.ListaMusicas.Add(novaMusica);
        
        Console.WriteLine($"\nA música {novaMusica.Nome} da banda {nomeBanda} foi registrada com sucesso!");
        Thread.Sleep(2000);
        Console.Clear();
        ExibirOpcoesDoMenu();
    }
    else
    {
        Console.WriteLine($"A banda {nomeBanda} não foi encontrada.");
        Console.WriteLine($"Pressione qualquer tecla para voltar ao menu principal.");
        Console.ReadKey();
        Console.Clear();
        ExibirOpcoesDoMenu();
    }

}

ExibirOpcoesDoMenu();