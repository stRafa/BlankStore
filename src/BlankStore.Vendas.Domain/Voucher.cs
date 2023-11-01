using BlankStore.Core.DomainObjects;

namespace BlankStore.Vendas.Domain
{
    public class Voucher : Entity
    {
        public string Codigo { get; private set; }
        public decimal? Percentual { get; private set; }
        public decimal? ValorDesconto { get; private set; }
        public int Quantidade { get; private set; }
        public TipoDescontoVoucher TipoDescontoVoucher { get; private set; }
        public DateTime DataCriacao { get; private set; }
        public DateTime? DataUtilizacao { get; private set; }
        public DateTime DataValidade { get; private set; }
        public bool Ativo { get; private set; }
        public bool Utilizacao { get; private set; }

        // EF Relation
        public ICollection<Pedido> Pedidos { get; set; }

        public override bool EhValido()
        {
            throw new NotImplementedException();
        }
    }
}
