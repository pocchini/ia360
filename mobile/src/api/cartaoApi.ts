import { clienteHttp } from './clienteHttp';
import type { Cartao, Movimentacao } from '../tipos';

export const cartaoApi = {
  solicitar(nomeTitular: string): Promise<Cartao> {
    return clienteHttp.post<Cartao>('/api/cartoes', { nomeTitular });
  },

  obter(id: string): Promise<Cartao> {
    return clienteHttp.get<Cartao>(`/api/cartoes/${id}`);
  },

  recarregar(id: string, valor: number, descricao?: string): Promise<Cartao> {
    return clienteHttp.post<Cartao>(`/api/cartoes/${id}/recargas`, { valor, descricao });
  },

  listarMovimentacoes(id: string): Promise<Movimentacao[]> {
    return clienteHttp.get<Movimentacao[]>(`/api/cartoes/${id}/movimentacoes`);
  },
};
