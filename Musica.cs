// <summary>
// Summary descrição para músicas

// Classes - Músicas
// Precisamos utilizar PascalCase para nomear as classes, ou seja, a primeira letra de cada palavra deve ser maiúscula.
// Não esquecer de tipar tudo.  Também é importante utilizar o construtor para inicializar os objetos da classe.
public class Musica
{
    // Propriedades da classe Musicas (auto-implemented properties)
    // get método de acesso que permite ler o valor da propriedade.
    // set método de acesso que permite atribuir um valor à propriedade.
    public string Nome { get; set; }
    public string Genero { get; set; }
    public int Duracao { get; set; }
    public List<double> Notas {get; set;}

// Construtor da classe Musicas
// O construtor é um método especial que é chamado quando um objeto da classe é criado.
// Ele é utilizado para inicializar as propriedades do objeto com valores fornecidos como parâmetros.
    public Musica(string nome, string genero, int duracao, List<double> notas) //parâmetros do construtor: nome, genero e duracao
    {
        Nome = nome;
        Genero = genero;
        Duracao = duracao;
        Notas = notas;
    }
    
}