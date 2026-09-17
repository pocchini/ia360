import { clienteHttp } from './clienteHttp';
import type { Produto } from '../tipos';

export const produtoApi = {
  listar(): Promise<Produto[]> {
    return clienteHttp.get<Produto[]>('/api/produtos');
  },
};
