using BlankStore.Catalogo.Domain.Events;
using BlankStore.Core.Bus;

namespace BlankStore.Catalogo.Domain;

public class EstoqueService : IEstoqueService // Representa uma ação conhecida da linguagem ubíqua, todo serviço de domínio deve ser aprovado pelo domain expert. implemetando uma regra de ne´gócio que vai além da entidade em si
{
    private readonly IProdutoRepository _produtoRepository; // Salvar produto/ att e etc é crud. logo não pertence aos serviços de domínio
    private readonly IMediatrHandler _bus;

    public EstoqueService(IProdutoRepository produtoRepository, IMediatrHandler bus)
    {
        _produtoRepository = produtoRepository;
        _bus = bus;
    }

    public async Task<bool> DebitarEstoque(Guid produtoId, int quantidade)
    {
        var produto = await _produtoRepository.ObterPorId(produtoId);

        if (produto == null) return false;

        if(!produto.PossuiEstoque(quantidade)) return false;

        produto.DebitarEstoque(quantidade);

        // TODO: Parametrizar a quantidade de estoque baixo
        if(produto.QuantidadeEstoque < 10)
        {
            await _bus.PublicarEvento(new ProdutoAbaixoEstoqueEvent(produto.Id, produto.QuantidadeEstoque));
        }

        _produtoRepository.Atualizar(produto);

        return await _produtoRepository.UnitOfWork.Commit();
    }

    public async Task<bool> ReporEstoque(Guid produtoId, int quantidade)
    {
        var produto = await _produtoRepository.ObterPorId(produtoId);

        if (produto == null) return false;

        produto.ReporEstoque(quantidade);

        _produtoRepository.Atualizar(produto);

        return await _produtoRepository.UnitOfWork.Commit();
    }

    public void Dispose()
    {
        _produtoRepository.Dispose();
    }
}
