using BlankStore.Core.DomainObjects;

namespace BlankStore.Catalogo.Domain.Tests
{
    public class ProdutoTests
    {
        [Fact]
        public void Produto_Validar_ValidacoesDevemRetornarExceptions()
        {
            var ex = Assert.Throws<DomainException>(() => new Produto(string.Empty, "Descricao", false, 100, Guid.NewGuid(), DateTime.Now, "imagem.png", new Dimensoes(2, 3, 2)));

            Assert.Equal("O campo Nome do produto não pode estar vazio", ex.Message);

            ex = Assert.Throws<DomainException>(() => new Produto("Nome Produto", string.Empty, false, 100, Guid.NewGuid(), DateTime.Now, "imagem.png", new Dimensoes(2, 3, 2)));

            Assert.Equal("O campo Descricao do produto não pode estar vazio", ex.Message);

            ex = Assert.Throws<DomainException>(() => new Produto("Nome Produto", "Descricao", false, 0, Guid.NewGuid(), DateTime.Now, "imagem.png", new Dimensoes(2, 3, 2)));

            Assert.Equal("O campo Valor do produto não pode ser menor ou igual a 0", ex.Message);

            ex = Assert.Throws<DomainException>(() => new Produto("Nome Produto", "Descricao", false, 100, Guid.Empty, DateTime.Now, "imagem.png", new Dimensoes(2, 3, 2)));

            Assert.Equal("O campo CategoriaId do produto não pode estar vazio", ex.Message);

            ex = Assert.Throws<DomainException>(() => new Produto("Nome Produto", "Descricao", false, 100, Guid.NewGuid(), DateTime.Now, string.Empty, new Dimensoes(2, 3, 2)));

            Assert.Equal("O campo Imagem do produto não pode estar vazio", ex.Message);
        }
    }
}