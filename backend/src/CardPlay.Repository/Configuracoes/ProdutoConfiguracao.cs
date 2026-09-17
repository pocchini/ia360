using CardPlay.Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CardPlay.Repository.Configuracoes;

public class ProdutoConfiguracao : IEntityTypeConfiguration<Produto>
{
    public void Configure(EntityTypeBuilder<Produto> builder)
    {
        builder.ToTable("Produtos");
        builder.HasKey(produto => produto.Id);

        builder.Property(produto => produto.Nome)
            .IsRequired()
            .HasMaxLength(80);

        builder.Property(produto => produto.DescricaoCurta)
            .IsRequired()
            .HasMaxLength(160);

        builder.Property(produto => produto.Preco)
            .HasColumnType("TEXT")
            .HasPrecision(18, 2)
            .IsRequired();

        builder.Property(produto => produto.Icone)
            .IsRequired()
            .HasMaxLength(16);

        builder.Property(produto => produto.Disponivel)
            .IsRequired();

        builder.HasData(
            new Produto(
                Guid.Parse("6f1c2a7e-0c4a-4b1d-9e2f-1a2b3c4d5e6f"),
                "Café especial",
                "Um espresso cremoso para começar bem o dia.",
                8.50m,
                "☕",
                true),
            new Produto(
                Guid.Parse("7a2d3b8f-1d5b-4c2e-8f3a-2b3c4d5e6f70"),
                "Livro ilustrado",
                "História curta com arte colorida para ler no intervalo.",
                32.90m,
                "📘",
                true),
            new Produto(
                Guid.Parse("8b3e4c9a-2e6c-4d3f-9a4b-3c4d5e6f7081"),
                "Fone compacto",
                "Áudio leve para estudar ou ouvir um podcast.",
                79.00m,
                "🎧",
                true),
            new Produto(
                Guid.Parse("9c4f5d0b-3f7d-4e4a-ab5c-4d5e6f708192"),
                "Adesivo CardPlay",
                "Um sticker brilhante para personalizar seu caderno.",
                4.00m,
                "🌟",
                true),
            new Produto(
                Guid.Parse("ad506e1c-408e-4f5b-bc6d-5e6f708192a3"),
                "Lanche da tarde",
                "Combo doce e salgado para recarregar a energia.",
                18.75m,
                "🥪",
                true),
            new Produto(
                Guid.Parse("be617f2d-519f-406c-cd7e-6f708192a3b4"),
                "Camiseta lúdica",
                "Algodão macio com estampa do cartão virtual.",
                59.90m,
                "👕",
                true));
    }
}
