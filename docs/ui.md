# Visual e usabilidade

CardPlay deve parecer um aplicativo financeiro educacional/lúdico: simples, espaçado e visual. Azul e laranja são as cores predominantes. A paleta concreta vive em [`mobile/src/tema/cores.ts`](../mobile/src/tema/cores.ts). Não espalhe hexadecimais pelos componentes.

## Cores predominantes

**Azul** identifica o produto: fundo, cartão virtual, abas ativas e ações secundárias.

**Laranja** identifica dinheiro e ação: saldo, preços, marca no cartão e botões de recarga.

Vermelho (`coral`) fica só para erro, para não se misturar com o laranja.

| Token | Hex | Uso |
| --- | --- | --- |
| `fundo` | `#F3F6FB` | Fundo das telas |
| `superficie` | `#FFFFFF` | Cartões de conteúdo e barra inferior |
| `azul` | `#1D5AA6` | Aba ativa, “Olá!”, botão futuro |
| `azulEscuro` | `#163E75` | Cartão virtual |
| `azulSuave` | `#E4EEF9` | Fundo do botão desabilitado “Usar cartão” |
| `laranja` | `#E86A17` | Botões de ação, chips, preços |
| `laranjaEscuro` | `#C2510C` | Ênfase extra do laranja |
| `laranjaSuave` | `#F8E4D2` | Superfície auxiliar quente |
| `ouro` | `#FFB86B` | Marca CardPlay e valor no cartão |
| `coral` | `#C43C2C` | Mensagens de erro |
| `tinta` / `tintaSuave` | `#1B2430` / `#5B6775` | Texto principal e secundário |
| `linha` | `#D7E2F0` | Bordas |
| `noDestaque` | `#F4F8FF` | Texto sobre azul ou laranja fortes |
| `noDestaqueSuave` | `#C5D7F0` | Texto secundário sobre o cartão |

## Usabilidade

- Quatro abas: Cartão, Recarga, Histórico, Catálogo.
- A barra inferior precisa mostrar ícone e rótulo por completo. Ela fica acima da área segura (home indicator / barra do sistema). Não use altura tão baixa que corte o texto.
- O conteúdo das telas respeita o recorte superior (notch / status bar) via `usePaddingTela`.
- Catálogo em tela estreita (menos de 720px): **um produto por linha**, layout de lista. Em telas largas: grade de duas colunas.
- Botão **Usar cartão** permanece visível, desabilitado e marcado como **Em breve**. Não implementar compra.
- Recarga mostra o saldo atual, sugestões de valor e mensagem de sucesso ou erro.
- Sem animações ou bibliotecas de UI pesadas. Tipografia clara, cantos arredondados, bastante espaço.
- A URL da API não aparece nas telas; só em `mobile/src/config/ambiente.ts`.
