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
        case 1:
            VerBandas();
            SubMenuBandas();
            break;
        case 2:
            VerMusicas();
            SubMenuMusicas();
            break;
        case 3:
            SubMenuNotas();
            break;
        case 4:
            Console.WriteLine("Tchau tchau :)"); ;
            break;
        default:
            Console.WriteLine("Opção inválida");
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

void SubMenuBandas()
{
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
        case 1:
            RegistrarBanda();
            break;
        case 2:
            AlterarBanda();
            break;
        case 3:
            DeletarBanda();
            break;
        case 4:
            VerMusicas();
            break;
        case 5:
            ExibirOpcoesDoMenu();
            return;
        default:
            Console.WriteLine("Opção inválida");
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

        }
        else if (opcao == 2)
        {
            Console.WriteLine("Digite o novo gênero: ");
            string novoGenero = Console.ReadLine()!;
            bandaEncontrada.Genero = novoGenero;
            Console.WriteLine("Gênero atualizado com sucesso.");
        }
        else
        {
            Console.WriteLine("Opção inválida. Aperte qualquer tecla para tentar novamente.");
            Console.ReadKey();
            Thread.Sleep(1500);
            AlterarBanda();
            return;
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

        }
        else if (opcao == 2)
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

void ExibirListaDeMusicas(Banda bandaEncontrada)
{
    foreach (Musica musica in bandaEncontrada.ListaMusicas)
    {
        Console.WriteLine($"Música: {musica.Nome}");
    }
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
            VerMusicas();
            return;
        }
        else
        {
            ExibirListaDeMusicas(bandaEncontrada);
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
        case 1:
            RegistrarMusica();
            break;
        case 2:
            AlterarMusica();
            break;
        case 3:
            DeletarMusica();
            break;
        case 4:
            ExibirOpcoesDoMenu();
            return;
        default:
            Console.WriteLine("Opção inválida");
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

void ValidacaoNegativaMusica()
{
    Console.WriteLine($"A música não foi encontrada.");
    Console.WriteLine($"Pressione qualquer tecla para voltar ao menu principal.");
    Console.ReadKey();
    Console.Clear();
    ExibirOpcoesDoMenu();

}

Banda ValidarBanda()
{
    Console.Write("\nDigite o nome da banda: ");
    string bandaDesejada = Console.ReadLine()!;
    Banda bandaEncontrada = bandasRegistradas.FirstOrDefault(b => b.Nome == bandaDesejada)!;
    return bandaEncontrada;
}

Musica ValidarMusica(Banda bandaEncontrada)
{
    ExibirListaDeMusicas(bandaEncontrada);
    string musicaSelecionada = Console.ReadLine()!;
    Musica musicaExiste = bandaEncontrada.ListaMusicas.FirstOrDefault(m => m.Nome == musicaSelecionada)!;
    return musicaExiste;
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

void AlterarMusica()
{
    Console.Clear();
    ExibirTituloDaOpcao("Alterando uma música");
    Console.Write("\nBanda autora: \n");
    ExibirListaDeBandas();
    Banda bandaEncontrada = ValidarBanda();
    if (bandaEncontrada != null)
    {
        if (bandaEncontrada.ListaMusicas.Count <= 0)
        {
            Console.Write($"\nA banda {bandaEncontrada.Nome} ainda não possui nenhuma música para ser avaliada.");
            Console.ReadKey();
            Console.WriteLine("Pressione qualquer tecla para voltar ao menu anterior.");
            VerMusicas();
            return;
        }
        else
        {
            Musica musicaEncontrada = ValidarMusica(bandaEncontrada);
            if (musicaEncontrada != null)
            {
                System.Console.WriteLine($"Você selecionou a música {musicaEncontrada.Nome} da banda {bandaEncontrada.Nome}");
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
                    musicaEncontrada.Nome = novoNome;
                    Console.WriteLine("Nome atualizado com sucesso.");

                }
                else if (opcao == 2)
                {
                    Console.WriteLine("Digite o novo gênero: ");
                    string novoGenero = Console.ReadLine()!;
                    musicaEncontrada.Genero = novoGenero;
                    Console.WriteLine("Gênero atualizado com sucesso.");
                }
                else
                {
                    Console.WriteLine("Opção inválida. Aperte qualquer tecla para tentar novamente.");
                    Console.ReadKey();
                    Thread.Sleep(1500);
                    AlterarMusica();
                    return;
                }

            }
            else
            {
                ValidacaoNegativaMusica();
                return;
            }
        }
    }
    else
    {
        ValidacaoNegativa();
        return;
    }
}

void DeletarMusica()
{
    Console.Clear();
    ExibirTituloDaOpcao("Deletando uma música");
    Console.Write("\nBanda autora: \n");
    ExibirListaDeBandas();
    Banda bandaEncontrada = ValidarBanda();
    if (bandaEncontrada != null)
    {
        if (bandaEncontrada.ListaMusicas.Count <= 0)
        {
            Console.Write($"\nA banda {bandaEncontrada.Nome} ainda não possui nenhuma música para ser avaliada.");
            Console.ReadKey();
            Console.WriteLine("Pressione qualquer tecla para voltar ao menu anterior.");
            VerMusicas();
            return;
        }
        else
        {
            Musica musicaEncontrada = ValidarMusica(bandaEncontrada);
            if (musicaEncontrada != null)
            {
                System.Console.WriteLine($"Você selecionou a música {musicaEncontrada.Nome} da banda {bandaEncontrada.Nome}");
                Console.WriteLine("\nTem certeza que deseja deletar essa música?");
                Console.WriteLine("1 - Sim. ");
                Console.WriteLine("2 - Não. ");
                int opcao = int.Parse(Console.ReadLine()!);
                Thread.Sleep(1500);
                Console.Clear();
                if (opcao == 1)
                {
                    listaDeMusicas.Remove(musicaEncontrada);
                    Console.WriteLine("Música deletada com sucesso.");

                }
                else if (opcao == 2)
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
                    DeletarMusica();
                    return;
                }

            }
            else
            {
                ValidacaoNegativaMusica();
                return;
            }
        }
    }
    else
    {
        ValidacaoNegativa();
        return;
    }
}

void SubMenuNotas()
{
    Thread.Sleep(1500);
    Console.Clear();
    ExibirTituloDaOpcao("Menu de Notas");
    Console.WriteLine("\nDigite 1 para ver notas de uma música.");
    Console.WriteLine("Digite 2 para dar nota para uma música.");
    Console.WriteLine("Digite 3 para alterar a nota de uma música.");
    Console.WriteLine("Digite 4 para deletar a nota de uma música.");
    Console.WriteLine("Digite 5 para ver a média de uma banda.");
    Console.WriteLine("Digite 6 para voltar ao menu principal.");

    Console.Write("\nDigite a sua opção: ");
    string opcaoEscolhida = Console.ReadLine()!;
    int opcaoEscolhidaNumerica = int.Parse(opcaoEscolhida);

    switch (opcaoEscolhidaNumerica)
    {
        case 1:
            VerNotas();
            break;
        case 2:
            DarNotas();
            break;
        case 3:
            AlterarNota();
            break;
        case 4:
            DeletarNota();
            break;
        case 5:
            VerMediaDeBanda();
            break;
        case 6:
            ExibirOpcoesDoMenu();
            return;
        default:
            Console.WriteLine("Opção inválida");
            break;
    }
}

void VerNotas()
{
    Console.Clear();
    ExibirTituloDaOpcao("Ver notas de Música");
    Console.Write("\nBanda autora: \n");
    ExibirListaDeBandas();
    Banda bandaEncontrada = ValidarBanda();
    if (bandaEncontrada != null)
    {
        if (bandaEncontrada.ListaMusicas.Count <= 0)
        {
            Console.Write($"\nA banda {bandaEncontrada.Nome} ainda não possui nenhuma música para ser avaliada.");
            Console.ReadKey();
            Console.WriteLine("Pressione qualquer tecla para voltar ao menu anterior.");
            VerMusicas();
            return;
        }
        else
        {
            Musica musicaEncontrada = ValidarMusica(bandaEncontrada);
            if (musicaEncontrada != null)
            {
                System.Console.WriteLine($"Você selecionou a música {musicaEncontrada.Nome} da banda {bandaEncontrada.Nome}");
                Console.WriteLine("\nMostrando notas...");
                foreach (double notas in musicaEncontrada.Notas)
                {
                    System.Console.WriteLine($"Notas: {notas}");
                }
                Thread.Sleep(1500);
                Console.Clear();
                Thread.Sleep(1000);
                Console.WriteLine($"Pressione qualquer tecla para voltar ao menu principal.");
                Console.ReadKey();
                Console.Clear();
                ExibirOpcoesDoMenu();
                return;
            }
            else
            {
                ValidacaoNegativaMusica();
                return;
            }
        }
    }
    else
        {
            ValidacaoNegativa();
            return;
        }
}



    void DarNotas()
    {

    }


    void AlterarNota()
    {

    }


    void DeletarNota()
    {

    }

    void VerMediaDeBanda()
    {

    }

