using BlankStore.Catalogo.Application.Services;
using BlankStore.Catalogo.Data;
using BlankStore.Catalogo.Data.Repository;
using BlankStore.Catalogo.Domain;
using BlankStore.Catalogo.Domain.Events;
using BlankStore.Core.Bus;
using BlankStore.Vendas.Application.Commands;
using MediatR;

namespace BlankStore.WebAPP.MVC.Setup;

public static class DependencyInjection
{
    public static void RegisterServices(this IServiceCollection services)
    {
        // Domain Bus (Mediatot)
        services.AddScoped<IMediatrHandler, MediatrHandler>();

        //Catalogo
        services.AddScoped<IProdutoRepository, ProdutoRepository>();
        services.AddScoped<IProdutoAppService, ProdutoAppService>();
        services.AddScoped<IEstoqueService, EstoqueService>();
        services.AddScoped<CatalogoContext>();

        services.AddScoped<INotificationHandler<ProdutoAbaixoEstoqueEvent>, ProdutoEventHandler>();

        // Vendas
        services.AddScoped<IRequestHandler<AdicionarItemPedidoCommand, bool>, PedidoCommandHandler>();
    }
}
