// Screen Sound
using System.Globalization;
using System.Linq.Expressions;
using System.Runtime.Serialization;
string mensagemDeBoasVindas = "Boas vindas ao Screen Sound";
List<Banda> bandasRegistradas = new List<Banda>();
List<Musica> listaDeMusicas = new List<Musica>();


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
    Console.WriteLine("\nDigite 1 para ver as informações de bandas.");
    Console.WriteLine("Digite 2 para ver informações de músicas");
    Console.WriteLine("Digite 3 para ver notas");
    Console.WriteLine("Digite 4 para sair");

    Console.Write("\nDigite a sua opção: ");
    string opcaoEscolhida = Console.ReadLine()!;
    int opcaoEscolhidaNumerica = int.Parse(opcaoEscolhida);
    
    switch (opcaoEscolhidaNumerica)
    {
        case 1: VerBandas();
                SubMenuBandas();
            break;
        case 2: VerMusicas();
                SubMenuMusicas();
            break;
        case 3: VerNotas();
                SubMenuNotas();
            break;
        case 4: Console.WriteLine("Tchau tchau :)");;
            break;
        default: Console.WriteLine("Opção inválida");
            break;
    }
}

void VerBandas()
{
    Console.Clear();
    Thread.Sleep(1000);
    ExibirTituloDaOpcao("Tela de Bandas");
    Thread.Sleep(1000);
    ExibirListaDeBandas();
}

void SubMenuBandas(){
    Console.WriteLine("\nDigite 1 para cadastrar uma nova banda.");
    Console.WriteLine("Digite 2 para alterar informação de banda.");
    Console.WriteLine("Digite 3 para deletar banda.");
    Console.WriteLine("Digite 4 para ver músicas de uma banda.");
    Console.WriteLine("Digite 5 para voltar ao menu principal.");

    Console.Write("\nDigite a sua opção: ");
    string opcaoEscolhida = Console.ReadLine()!;
    int opcaoEscolhidaNumerica = int.Parse(opcaoEscolhida);
    
    switch (opcaoEscolhidaNumerica)
    {
        case 1: RegistrarBanda();
            break;
        case 2: AlterarBanda();
            break;
        case 3: DeletarBanda();
            break;
        case 4: VerMusica();
            break;
        case 5: ExibirOpcoesDoMenu();
            return;
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
    Console.Write("Digite o gênero da banda que você deseja registrar: ");
    string generoDaBanda = Console.ReadLine()!;
    bandasRegistradas.Add(new Banda(nomeDaBanda, new List<int>(), generoDaBanda, new List<Musica>()));
    Console.WriteLine($"A banda {nomeDaBanda} foi registrada!");
    Thread.Sleep(2000);
    ExibirOpcoesDoMenu();
}

void AlterarBanda()
{
    Console.Clear();
    Thread.Sleep(1000);
    ExibirTituloDaOpcao("Alterar Bandas...");
    Thread.Sleep(1000);
    Banda bandaEncontrada = ValidarBanda();
    if (bandaEncontrada != null)
    {
        Console.WriteLine("\nDigite a opção de alteração: ");
        Console.WriteLine("1 - Nome. ");
        Console.WriteLine("2 - Gênero. ");
        int opcao = int.Parse(Console.ReadLine()!);
        Thread.Sleep(1500);
        Console.Clear();
        if (opcao == 1)
        {
            Console.WriteLine("Digite o novo nome: ");
            string novoNome = Console.ReadLine()!;
            bandaEncontrada.Nome = novoNome;
            Console.WriteLine("Nome atualizado com sucesso.");

        } else if (opcao == 2)
        {
            Console.WriteLine("Digite o novo gênero: ");
            string novoGenero = Console.ReadLine()!;
            bandaEncontrada.Genero = novoGenero;
            Console.WriteLine("Gênero atualizado com sucesso.");
        }else
        {
            Console.WriteLine("Opção inválida. Aperte qualquer tecla para tentar novamente.");
            Console.ReadKey();
            Thread.Sleep(1500);
            AlterarBanda();
            return;
        }

    }else
    {
        ValidacaoNegativa();
        return;
    }
    Console.WriteLine($"Pressione qualquer tecla para voltar ao menu principal.");
    Console.ReadKey();
    Console.Clear();
    ExibirOpcoesDoMenu();

}

void DeletarBanda()
{
    Console.Clear();
    Thread.Sleep(1000);
    ExibirTituloDaOpcao("Deletar Bandas...");
    Thread.Sleep(1000);
    Banda bandaEncontrada = ValidarBanda();
    if (bandaEncontrada != null)
    {
        Console.WriteLine("\nTem certeza que deseja deletar essa banda? ");
        Console.WriteLine("Essa ação não pode ser desfeita.\n");
        Console.WriteLine("1 - Sim. ");
        Console.WriteLine("2 - Não. ");
        int opcao = int.Parse(Console.ReadLine()!);
        Thread.Sleep(1500);
        Console.Clear();
        if (opcao == 1)
        {
            bandasRegistradas.Remove(bandaEncontrada);
            Console.WriteLine("Banda deletada com sucesso.");

        } else if (opcao == 2)
        {
            Console.Clear();
            Thread.Sleep(1500);
            Console.WriteLine($"Pressione qualquer tecla para voltar ao menu principal.");
            Console.ReadKey();
            Console.Clear();
            ExibirOpcoesDoMenu();
            return;       
        }
        else
        {
            Console.WriteLine("Opção inválida. Aperte qualquer tecla para tentar novamente.");
            Console.ReadKey();
            Thread.Sleep(1500);
            DeletarBanda();
            return;
        }
    }else
    {
        ValidacaoNegativa();
        return;
    }
    Console.WriteLine($"Pressione qualquer tecla para voltar ao menu principal.");
    Console.ReadKey();
    Console.Clear();
    ExibirOpcoesDoMenu();

}

void VerMusicas()
{
    Console.Clear();
    Thread.Sleep(1000);
    ExibirTituloDaOpcao("Ver Músicas...");
    Thread.Sleep(1000);
    Banda bandaEncontrada = ValidarBanda();
    if (bandaEncontrada != null)
    {
        if (bandaEncontrada.ListaMusicas.Count <= 0)
        {
            Console.Write($"\nA banda {bandaEncontrada.Nome} ainda não possui nenhuma música para ser avaliada.");
            Console.ReadKey();
            Console.WriteLine("Pressione qualquer tecla para voltar ao menu anterior.");
            VerMusica();
            return;
        } else{
            foreach (Musica musica in bandaEncontrada.ListaMusicas)
                {
                    Console.WriteLine($"Música: {musica.Nome}");
                }
        }
    }
    else
    {
        ValidacaoNegativa();
        return;
    }
    Console.WriteLine($"Pressione qualquer tecla para voltar ao menu principal.");
    Console.ReadKey();
    Console.Clear();
    ExibirOpcoesDoMenu();
}

void SubMenuMusicas()
{
    Console.WriteLine("\nDigite 1 para cadastrar uma nova música.");
    Console.WriteLine("Digite 2 para alterar informação de uma música.");
    Console.WriteLine("Digite 3 para deletar música.");
    Console.WriteLine("Digite 4 para voltar ao menu principal.");

    Console.Write("\nDigite a sua opção: ");
    string opcaoEscolhida = Console.ReadLine()!;
    int opcaoEscolhidaNumerica = int.Parse(opcaoEscolhida);
    
    switch (opcaoEscolhidaNumerica)
    {
        case 1: RegistrarMusica();
            break;
        case 2: AlterarMusica();
            break;
        case 3: DeletarMusica();
            break;
        case 4: ExibirOpcoesDoMenu();
            return;
        default: Console.WriteLine("Opção inválida");
            break;
}
}

void ValidacaoNegativa()
{
    Console.WriteLine($"A banda não foi encontrada.");
    Console.WriteLine($"Pressione qualquer tecla para voltar ao menu principal.");
    Console.ReadKey();
    Console.Clear();
    ExibirOpcoesDoMenu();

}

Banda ValidarBanda(){
    Console.Write("\nDigite o nome da banda: ");
    string bandaDesejada = Console.ReadLine()!;
    Banda bandaEncontrada = bandasRegistradas.FirstOrDefault(b => b.Nome == bandaDesejada)!;
    return bandaEncontrada;
}

void ExibirListaDeBandas()
{
    ExibirTituloDaOpcao("Exibindo todas as bandas registradas!");
    foreach (Banda banda in bandasRegistradas)
    {
        Console.WriteLine($"Banda: {banda.Nome}");
    }
}

void ExibirTituloDaOpcao(String titulo)
{
    int tamanhoTitulo = titulo.Length;
    string asterisco = string.Empty.PadLeft(tamanhoTitulo, '*');
    Console.WriteLine(asterisco);
    Console.WriteLine(titulo); 
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
    
    foreach (Banda banda in bandasRegistradas)
    {
        Console.WriteLine($"Banda: {banda}");
    }
    Banda bandaEncontrada = ValidarBanda();
    if (bandaEncontrada != null) 
    {
        //double media = bandasRegistradas[bandaDesejada].Average(); -- Erro aqui
        //Console.WriteLine($"A média da banda {bandaDesejada} é: {media}"); -- Erro aqui
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