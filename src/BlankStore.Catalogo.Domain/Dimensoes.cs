using BlankStore.Core.DomainObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlankStore.Catalogo.Domain;

public class Dimensoes : IValueObject
{
    public Dimensoes(decimal altura, decimal largura, decimal profundidade)
    {
        Altura = altura;
        Largura = largura;
        Profundidade = profundidade;

        Validar();
    }

    public decimal Altura { get; private set; }
    public decimal Largura { get; private set; }
    public decimal Profundidade { get; private set; }

    public void Validar()
    {
        Validacoes.ValidarSeMenorOuIgual(Altura, 0, "O campo Altura não pode ser menor ou igual a 0");
        Validacoes.ValidarSeMenorOuIgual(Largura, 0, "O campo Largura não pode ser menor ou igual a 0");
        Validacoes.ValidarSeMenorOuIgual(Profundidade, 0, "O campo Profundidade não pode ser menor ou igual a 0");
    }

    public string DescricaoFormatada()
    {
        return $"LxAxP: {Largura} x {Altura} x {Profundidade}";
    }

    public override string ToString()
    {
        return DescricaoFormatada();
    }
}
