import { ScrollView, StyleSheet, Text, View } from 'react-native';
import { useCartao } from '../estado/CartaoContexto';
import { cores } from '../tema/cores';
import { usePaddingTela } from '../tema/usePaddingTela';
import { formatarDataHora, formatarMoeda } from '../util/formatacao';

export function TelaMovimentacoes() {
  const { cartao, movimentacoes } = useCartao();
  const paddingTela = usePaddingTela();

  if (!cartao) {
    return (
      <View style={[estilos.conteudo, paddingTela]}>
        <Text style={estilos.titulo}>Movimentações</Text>
        <Text style={estilos.subtitulo}>Quando houver um cartão, as recargas aparecerão aqui.</Text>
      </View>
    );
  }

  return (
    <ScrollView contentContainerStyle={[estilos.conteudo, paddingTela]}>
      <Text style={estilos.titulo}>Movimentações</Text>
      <Text style={estilos.subtitulo}>Histórico simples das recargas deste cartão.</Text>

      {movimentacoes.length === 0 ? (
        <View style={estilos.vazio}>
          <Text style={estilos.vazioTexto}>Nenhuma recarga ainda.</Text>
        </View>
      ) : (
        movimentacoes.map((movimentacao) => (
          <View key={movimentacao.id} style={estilos.item}>
            <View style={estilos.itemTopo}>
              <Text style={estilos.descricao}>{movimentacao.descricao}</Text>
              <Text style={estilos.valor}>+ {formatarMoeda(movimentacao.valor)}</Text>
            </View>
            <Text style={estilos.data}>{formatarDataHora(movimentacao.dataHora)}</Text>
          </View>
        ))
      )}
    </ScrollView>
  );
}

const estilos = StyleSheet.create({
  conteudo: {
    flexGrow: 1,
    backgroundColor: cores.fundo,
  },
  titulo: {
    fontSize: 32,
    fontWeight: '800',
    color: cores.tinta,
  },
  subtitulo: {
    marginTop: 8,
    marginBottom: 24,
    color: cores.tintaSuave,
    fontSize: 15,
    lineHeight: 22,
  },
  vazio: {
    backgroundColor: cores.superficie,
    borderRadius: 20,
    padding: 20,
    borderWidth: 1,
    borderColor: cores.linha,
  },
  vazioTexto: {
    color: cores.tintaSuave,
  },
  item: {
    backgroundColor: cores.superficie,
    borderRadius: 20,
    padding: 16,
    marginBottom: 12,
    borderWidth: 1,
    borderColor: cores.linha,
  },
  itemTopo: {
    flexDirection: 'row',
    justifyContent: 'space-between',
    gap: 12,
  },
  descricao: {
    flex: 1,
    color: cores.tinta,
    fontWeight: '600',
    fontSize: 16,
  },
  valor: {
    color: cores.laranja,
    fontWeight: '700',
  },
  data: {
    marginTop: 8,
    color: cores.tintaSuave,
    fontSize: 13,
  },
});
