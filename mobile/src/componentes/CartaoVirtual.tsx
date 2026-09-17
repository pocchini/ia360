import { StyleSheet, Text, View } from 'react-native';
import type { Cartao } from '../tipos';
import { cores } from '../tema/cores';
import { formatarMoeda } from '../util/formatacao';

type Propriedades = {
  cartao: Cartao;
};

export function CartaoVirtual({ cartao }: Propriedades) {
  return (
    <View style={estilos.cartao}>
      <Text style={estilos.marca}>CardPlay</Text>
      <Text style={estilos.rotulo}>Cartão virtual interno</Text>
      <Text style={estilos.codigo}>{cartao.codigoAmigavel}</Text>
      <Text style={estilos.titular}>{cartao.nomeTitular}</Text>
      <View style={estilos.saldoBloco}>
        <Text style={estilos.saldoRotulo}>Saldo disponível</Text>
        <Text style={estilos.saldo}>{formatarMoeda(cartao.saldo)}</Text>
      </View>
    </View>
  );
}

const estilos = StyleSheet.create({
  cartao: {
    backgroundColor: cores.azulEscuro,
    borderRadius: 28,
    padding: 24,
    minHeight: 210,
    justifyContent: 'space-between',
    shadowColor: cores.azulEscuro,
    shadowOpacity: 0.25,
    shadowRadius: 16,
    shadowOffset: { width: 0, height: 10 },
    elevation: 6,
  },
  marca: {
    color: cores.ouro,
    fontSize: 18,
    fontWeight: '700',
    letterSpacing: 1,
  },
  rotulo: {
    color: cores.noDestaqueSuave,
    marginTop: 4,
    fontSize: 13,
  },
  codigo: {
    color: cores.noDestaque,
    fontSize: 28,
    fontWeight: '700',
    letterSpacing: 2,
    marginTop: 28,
  },
  titular: {
    color: cores.noDestaque,
    fontSize: 16,
    marginTop: 8,
  },
  saldoBloco: {
    marginTop: 28,
  },
  saldoRotulo: {
    color: cores.noDestaqueSuave,
    fontSize: 13,
  },
  saldo: {
    color: cores.ouro,
    fontSize: 32,
    fontWeight: '700',
    marginTop: 4,
  },
});
