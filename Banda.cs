public class Banda
{
    public string Nome { get; set; }
    public List<int> Notas { get; set; }
    public string Genero { get; set; }
    public List<Musica> ListaMusicas { get; set; }
    public Banda(string nome, List<int> notas, string genero, List<Musica>listaMusicas)
    {
        Nome = nome;
        Notas = notas;
        Genero = genero;
        this.ListaMusicas = listaMusicas;
    }
}