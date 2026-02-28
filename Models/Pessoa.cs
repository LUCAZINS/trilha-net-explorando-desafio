namespace DesafioProjetoHospedagem.Models;

public class Pessoa
{
    public Pessoa() { }

    public Pessoa(string nome)
    {
        Nome = nome;
    }

    public Pessoa(string nome, string sobrenome)
    {
        Nome = nome;
        Sobrenome = sobrenome;
    }

    public string Nome { get; set; } = null!;
    public string Sobrenome { get; set; } = null!;
    public string NomeCompleto => $"{Nome} {Sobrenome}".ToUpper();
} 