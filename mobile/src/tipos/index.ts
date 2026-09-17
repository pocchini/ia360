export type Cartao = {
  id: string;
  nomeTitular: string;
  codigoAmigavel: string;
  saldo: number;
  dataCriacao: string;
};

export type Movimentacao = {
  id: string;
  valor: number;
  descricao: string;
  dataHora: string;
};

export type Produto = {
  id: string;
  nome: string;
  descricaoCurta: string;
  preco: number;
  icone: string;
  disponivel: boolean;
};
