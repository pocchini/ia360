using CardPlay.Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CardPlay.Repository.Configuracoes;

public class CartaoConfiguracao : IEntityTypeConfiguration<Cartao>
{
    public void Configure(EntityTypeBuilder<Cartao> builder)
    {
        builder.ToTable("Cartoes");
        builder.HasKey(cartao => cartao.Id);

        builder.Property(cartao => cartao.NomeTitular)
            .IsRequired()
            .HasMaxLength(80);

        builder.Property(cartao => cartao.CodigoAmigavel)
            .IsRequired()
            .HasMaxLength(16);

        builder.Property(cartao => cartao.Saldo)
            .HasColumnType("TEXT")
            .HasPrecision(18, 2)
            .IsRequired();

        builder.Property(cartao => cartao.DataCriacao)
            .IsRequired();

        builder.Property(cartao => cartao.Id)
            .ValueGeneratedNever();

        builder.HasMany(cartao => cartao.Movimentacoes)
            .WithOne()
            .HasForeignKey(movimentacao => movimentacao.CartaoId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Navigation(cartao => cartao.Movimentacoes)
            .HasField("_movimentacoes")
            .UsePropertyAccessMode(PropertyAccessMode.Field);
    }
}
