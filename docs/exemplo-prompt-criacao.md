# Exemplo de prompt de criação

Este arquivo registra o prompt usado para pedir o estado inicial do CardPlay. Serve como exemplo didático de como o repositório foi solicitado a uma ferramenta de IA: contexto, visão, limites, stack, arquitetura, qualidade, testes e forma de trabalho incremental.

O texto abaixo é o pedido de criação do CardPlay. A nomenclatura de domínio no briefing está em inglês; a implementação usa português no código (`Cartao`, `Produto`, rotas `/api/cartoes`) e mantém `CardPlay` só no produto e nos projetos.

A divisão de camadas neste prompt está alinhada com o repositório: **Application orquestra os casos de uso**; **Services** só existe para integrações com APIs externas, no mesmo nível do Repository.

As cores predominantes e as regras de usabilidade também estão alinhadas: **azul** para identidade e navegação, **laranja** para saldo e ações. O detalhe está em `docs/ui.md`.

---

# Contexto

Estamos criando o projeto-base de um curso chamado **Desenvolvimento de Software com IA**.

Este projeto será usado ao longo do curso para ensinar um método profissional de desenvolvimento assistido por IA:

**Entender → Planejar → Desenvolver → Validar → Entregar → Evoluir**

Portanto, não quero apenas uma aplicação funcionando. Quero um repositório simples, compreensível, bem documentado e adequado para demonstrar exploração, análise de impacto, planejamento, implementação incremental, testes, revisão, Git e validação por evidências.

O nome provisório do produto é **CardPlay**. Mantenha o nome suficientemente isolado para que possa ser alterado depois sem grande impacto.

# Visão do produto

CardPlay é uma pequena plataforma lúdica onde uma pessoa pode solicitar um cartão virtual interno, adicionar saldo a esse cartão e visualizar produtos disponíveis dentro da plataforma.

O cartão não representa um cartão bancário real.

Não implemente integração com adquirentes, bancos, gateways ou sistemas financeiros externos. Não gere PAN, CVV ou outros dados reais de cartão de pagamento.

O cartão é apenas um recurso interno da aplicação que possui identificador, nome do titular e saldo.

A aplicação deve ter aparência amigável, moderna, simples e visual, sem complexidade desnecessária.

As cores predominantes são **azul** e **laranja**. Azul identifica o produto (fundo, cartão virtual, navegação). Laranja identifica dinheiro e ação (saldo, preços, recarga). Erros usam vermelho, separado da marca.

# Estado inicial que queremos construir

Nesta primeira versão, o usuário deve conseguir:

1. solicitar um cartão virtual informando seu nome; visualizar o cartão e seu saldo; adicionar saldo usando uma recarga simulada; consultar o histórico de recargas; visualizar um pequeno catálogo de produtos previamente cadastrados; perceber visualmente que futuramente poderá utilizar seu cartão nesses produtos.

A compra de produtos **NÃO deve ser implementada nesta versão**.

Ela será uma demanda futura usada ao longo do curso.

Registre somente a seguinte demanda em um backlog, sem inventar regras de negócio, critérios de aceite ou decisões adicionais:

> Permitir que o usuário utilize o saldo do cartão para adquirir produtos disponíveis na plataforma.

Não tente resolver essa demanda agora.

# Stack

Backend em C# e ASP.NET Core.

Utilize uma versão LTS do .NET disponível no ambiente. Antes de escolher a versão, verifique o SDK instalado e não faça upgrade desnecessário do ambiente.

Persistência com Entity Framework Core e SQLite.

Frontend em React Native com TypeScript.

Pode utilizar Expo caso seja a alternativa mais simples para executar o projeto localmente, mas evite dependências que não tragam benefício concreto.

Versionamento com Git.

Testes backend com xUnit.

# Estrutura do repositório

Quero um monorepositório aproximadamente desta forma:

```text
/
  backend/
    CardPlay.sln
    src/
      CardPlay.Api/
      CardPlay.Application/
      CardPlay.Domain/
      CardPlay.Repository/
      CardPlay.Services/
    tests/
      CardPlay.Tests/

  mobile/
    ...

  docs/
    architecture.md
    product.md
    ui.md
    backlog.md
    exemplo-prompt-criacao.md

  README.md
  AGENTS.md
  .gitignore
```

Adapte detalhes quando houver justificativa técnica, mas mantenha a arquitetura pequena e fácil de explicar.

# Responsabilidade das camadas

**CardPlay.Domain**

Deve conter entidades, enums e regras essenciais do domínio.

Não deve depender de ASP.NET Core, Entity Framework ou detalhes de infraestrutura.

**CardPlay.Application**

Deve conter contratos da aplicação, DTOs, interfaces dos casos de uso, interfaces necessárias para acesso a dados e a **orquestração dos casos de uso**.

Evite lógica de infraestrutura. Não implemente clientes de APIs externas nesta camada.

**CardPlay.Repository**

Deve conter DbContext, configurações do Entity Framework Core, migrations e implementações concretas dos repositórios.

Utilize SQLite.

Esta camada é infraestrutura de persistência. Fica no mesmo nível de CardPlay.Services.

**CardPlay.Services**

Deve existir apenas para consumir APIs e serviços externos que não pertencem ao projeto.

Fica no mesmo nível de CardPlay.Repository: ambas implementam contratos da Application e não orquestram casos de uso internos.

Nesta versão não há integrações externas. Não coloque a orquestração da aplicação aqui só para preencher a camada.

Não crie abstrações apenas para aumentar o número de classes.

**CardPlay.Api**

Deve expor a aplicação por HTTP e funcionar como composition root.

Controllers ou endpoints devem permanecer pequenos.

Utilize respostas HTTP coerentes e ProblemDetails quando apropriado.

A direção das dependências deve permanecer clara e não pode haver referências circulares.

# Modelo inicial

Mantenha o domínio propositalmente pequeno.

Precisamos inicialmente de conceitos equivalentes a:

**Card**

Representa o cartão interno da plataforma.

Deve possuir identificador, nome do titular, código amigável para exibição, saldo e data de criação.

Não armazene informações que possam ser confundidas com dados reais de cartão bancário.

Valores monetários devem usar `decimal`.

**CardTransaction**

Representa movimentações realizadas no cartão.

Nesta versão, teremos somente recargas.

Deve permitir registrar valor, descrição e data/hora.

Não adicione antecipadamente regras ou estruturas específicas de compra apenas porque sabemos que essa funcionalidade aparecerá posteriormente.

**Product**

Representa um produto disponível no catálogo.

Deve possuir identificador, nome, descrição curta, preço, representação visual simples como emoji/ícone e indicação de disponibilidade.

Cadastre alguns produtos fictícios por seed para deixar a interface visualmente interessante.

Não implemente estoque, carrinho, checkout ou administração.

# API inicial

A API deve permitir criar um cartão, consultar um cartão, realizar uma recarga, consultar suas movimentações e listar produtos.

Defina rotas REST simples e previsíveis.

Não implemente endpoint de compra.

Inclua OpenAPI/Swagger se estiver disponível de maneira simples na stack utilizada.

Valide entradas básicas.

Uma recarga deve rejeitar valores iguais ou inferiores a zero.

A alteração do saldo e o registro da transação correspondente precisam permanecer consistentes.

# Aplicativo React Native

A experiência precisa ser simples e visual.

Não quero uma interface corporativa pesada.

Imagine um aplicativo financeiro educacional/lúdico, com bastante espaço, cartões arredondados, tipografia clara, ícones simples e duas cores de destaque: azul e laranja.

A paleta deve viver em um único arquivo de tema. Não espalhe códigos de cor pelos componentes.

A barra de navegação inferior precisa permanecer visível em telas mobile: ícone e rótulo completos, acima da área segura do aparelho. O conteúdo das telas deve respeitar o recorte superior (notch/status bar).

No catálogo, em telas estreitas liste um produto por linha. Em telas largas pode usar duas colunas.

Evite animações ou bibliotecas de UI pesadas nesta primeira versão.

A aplicação deve permitir criar um cartão quando ainda não houver um selecionado; visualizar um cartão virtual com nome do titular, código amigável e saldo; realizar uma recarga; consultar movimentações; navegar pelo catálogo de produtos.

No catálogo, apresente os produtos visualmente.

Pode existir uma chamada visual como “Usar cartão” ou “Comprar”, mas ela deve estar desabilitada ou identificada como funcionalidade futura.

Não implemente silenciosamente a compra.

Organize a comunicação com a API em uma camada própria no frontend.

A URL da API deve ser configurável e não espalhada pelos componentes.

Explique no README como configurar localhost, emulador e dispositivo físico quando isso for relevante.

# Qualidade técnica

Evite overengineering.

Não utilize microserviços.

Não utilize Event Sourcing.

Não introduza CQRS, MediatR, mensageria, Redis ou padrões avançados apenas por preferência arquitetural.

Não crie um Generic Repository sem necessidade.

Prefira repositórios específicos e código explícito.

Evite abstrações que não resolvam um problema atual.

Use async/await e CancellationToken onde fizer sentido.

Não coloque regras de negócio nos controllers.

Não exponha diretamente entidades do Entity Framework pela API.

Mantenha DTOs claros.

Use migrations para o banco.

Não armazene credenciais ou secrets no repositório.

# Testes

Os testes devem existir principalmente onde demonstram comportamento relevante.

Crie testes para regras essenciais, incluindo pelo menos criação de cartão válida, rejeição de recarga inválida, atualização do saldo após uma recarga e registro da movimentação correspondente.

Adicione outros testes somente quando houver valor claro.

Não busque cobertura artificial.

# Repositório AI-Ready

Este projeto será explorado por alunos e por ferramentas de IA.

Portanto, conhecimento importante precisa estar descobrível no próprio projeto.

O `README.md` deve explicar propósito, arquitetura resumida, pré-requisitos, como executar backend, como executar mobile, como criar/aplicar banco, como executar testes, estrutura principal do repositório e um resumo das cores/usabilidade com link para `docs/ui.md`.

O `AGENTS.md` deve explicar para humanos e agentes como trabalhar neste projeto, incluindo arquitetura, dependências entre camadas, comandos importantes, regras de implementação, regras de teste, padrões visuais/usabilidade e orientação explícita para explorar antes de modificar.

`docs/architecture.md` deve explicar a arquitetura em linguagem simples e mostrar o fluxo:

```text
React Native
     ↓
ASP.NET Core API
     ↓
Application
     ↓
Domain
     ↙                    ↘
Repository / EF Core      Services / APIs externas
     ↓
SQLite
```

Explique também as dependências reais entre projetos para que o diagrama não esconda a implementação. No frontend, descreva o cliente HTTP isolado e aponte para `docs/ui.md` para paleta e usabilidade.

`docs/product.md` deve descrever apenas o comportamento existente nesta versão, incluindo a aparência lúdica e as regras visíveis de usabilidade.

`docs/ui.md` deve explicar as cores predominantes (azul e laranja), os tokens do tema e as regras de usabilidade: barra inferior com área segura, recorte superior, um produto por linha em telas estreitas e botão de compra visível porém desabilitado.

`docs/backlog.md` deve conter a demanda futura de utilização do saldo para produtos, sem completar as regras que ainda não foram definidas.

# Forma de trabalho

Não execute a construção inteira de uma vez.

Queremos trabalhar de forma incremental:

**pequena mudança → inspeção → build/teste → validação → próxima mudança**

Antes de modificar qualquer arquivo, examine o diretório atual.

Verifique estrutura existente, arquivos existentes e estado do Git.

Não sobrescreva trabalho existente.

Caso o diretório ainda não seja um repositório Git, apenas informe isso; não execute operações destrutivas ou remotas.

# Primeira interação: SOMENTE PLANEJAMENTO

Nesta primeira interação, não implemente código.

Primeiro faça a exploração disponível do ambiente e apresente um plano de construção.

O plano deve explicar o estado encontrado no diretório, estrutura que pretende criar, dependências entre projetos, modelo mínimo de domínio, persistência, endpoints iniciais, organização do frontend, estratégia de testes, sequência de implementação e validação prevista após cada etapa.

Identifique também decisões ou suposições que esteja fazendo.

Questione qualquer requisito que gere complexidade sem benefício evidente.

Não invente funcionalidades adicionais.

No final, apresente uma proposta de execução dividida aproximadamente em:

Fundação do repositório e backend → domínio e persistência → casos de uso/API → testes backend → frontend → integração → documentação e validação final.

Cada etapa precisa terminar com alguma evidência verificável, como diff, build, teste ou execução.

Depois de apresentar o plano, **PARE**.

Não altere arquivos até que eu responda explicitamente autorizando a execução.

# Depois da aprovação

Quando eu responder que o plano está aprovado, execute somente a primeira etapa.

Ao terminar cada etapa, apresente:

arquivos criados ou alterados; decisões tomadas; resumo do diff; comandos executados; resultado do build/testes; problemas encontrados; o que ainda não foi validado.

Depois pare novamente para revisão humana antes de seguir para a próxima etapa.

Não interprete ausência de erro como prova de funcionamento.

A afirmação “está funcionando” precisa ser acompanhada pela evidência que sustenta essa conclusão.

# Critério de sucesso do estado inicial

Ao final da construção, devemos conseguir iniciar backend e mobile seguindo apenas o README; criar um cartão pela interface; visualizar seu saldo; realizar uma recarga; observar o novo saldo; consultar o registro da recarga; visualizar produtos do catálogo; confirmar que a compra ainda não existe; executar build e testes com sucesso; compreender rapidamente onde cada responsabilidade vive no repositório.

A aplicação deve parecer intencional e agradável, com azul e laranja como cores predominantes e usabilidade adequada a telas mobile, mas continuar pequena o suficiente para que um desenvolvedor iniciante consiga explorar o projeto e explicar o caminho de uma ação do React Native até o SQLite.

Lembre-se do objetivo principal:

**não estamos construindo uma arquitetura impressionante; estamos construindo um projeto didático suficientemente real para ensinar desenvolvimento profissional com IA.**
