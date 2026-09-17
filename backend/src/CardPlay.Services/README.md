# CardPlay.Services

Camada de infraestrutura para clientes de APIs e serviços **externos**.

Fica no mesmo nível de `CardPlay.Repository`: as duas implementam contratos da Application e não orquestram casos de uso.

Nesta versão o CardPlay não chama nenhum serviço externo. A orquestração (solicitar cartão, recarregar, listar produtos) vive em `CardPlay.Application`.
