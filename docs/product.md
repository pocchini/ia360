# Produto — comportamento desta versão

CardPlay é uma plataforma lúdica interna. O cartão não representa um cartão bancário e não se conecta a nenhum sistema financeiro.

## O que a pessoa consegue fazer

1. Solicitar um cartão virtual informando o próprio nome.
2. Ver o cartão com nome do titular, código amigável e saldo (inicia em zero).
3. Adicionar saldo com uma recarga simulada, desde que o valor seja maior que zero.
4. Consultar o histórico dessas recargas.
5. Percorrer um catálogo pequeno de produtos fictícios já cadastrados.
6. Ver um botão de “Usar cartão” / “Comprar” desabilitado, marcado como funcionalidade futura.

## O que esta versão não faz

- Comprar produtos
- Autenticar usuários
- Administrar catálogo
- Controlar estoque ou carrinho
- Integrar banco, adquirente ou gateway
- Gerar dados de cartão de pagamento

Uma recarga sem descrição usa o texto padrão “Recarga”. O aplicativo guarda localmente o cartão selecionado; a API pode ter vários cartões, mas não há login.

## Visual e usabilidade

A interface é lúdica, com bastante espaço e duas cores de destaque: **azul** (cartão, navegação) e **laranja** (saldo, preços, recarga).

A barra inferior permanece visível no celular, com ícone e rótulo acima da área segura. O catálogo lista um produto por linha em telas estreitas e duas colunas em telas largas.

O botão de compra continua visível, desabilitado e marcado como “Em breve”.

Detalhe da paleta e das regras: [ui.md](ui.md).
