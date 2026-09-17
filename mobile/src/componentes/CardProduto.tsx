import { Pressable, StyleSheet, Text, View } from 'react-native';
import type { Produto } from '../tipos';
import { cores } from '../tema/cores';
import { formatarMoeda } from '../util/formatacao';

type Propriedades = {
  produto: Produto;
  layout?: 'grade' | 'lista';
};

export function CardProduto({ produto, layout = 'grade' }: Propriedades) {
  const lista = layout === 'lista';

  return (
    <View style={[estilos.card, lista && estilos.cardLista]}>
      <Text style={[estilos.icone, lista && estilos.iconeLista]}>{produto.icone}</Text>
      <View style={lista ? estilos.detalhes : undefined}>
        <Text style={estilos.nome}>{produto.nome}</Text>
        <Text style={[estilos.descricao, lista && estilos.descricaoLista]}>{produto.descricaoCurta}</Text>
        <Text style={estilos.preco}>{formatarMoeda(produto.preco)}</Text>
        <Pressable disabled style={estilos.botao}>
          <Text style={estilos.botaoTexto}>Usar cartão</Text>
          <Text style={estilos.emBreve}>Em breve</Text>
        </Pressable>
      </View>
    </View>
  );
}

const estilos = StyleSheet.create({
  card: {
    flex: 1,
    backgroundColor: cores.superficie,
    borderRadius: 24,
    padding: 16,
    margin: 6,
    minHeight: 230,
    borderWidth: 1,
    borderColor: cores.linha,
  },
  cardLista: {
    flexDirection: 'row',
    alignItems: 'flex-start',
    minHeight: 0,
    marginHorizontal: 0,
    marginBottom: 12,
  },
  icone: {
    fontSize: 36,
    marginBottom: 12,
  },
  iconeLista: {
    fontSize: 40,
    marginBottom: 0,
    marginRight: 14,
  },
  detalhes: {
    flex: 1,
  },
  nome: {
    fontSize: 16,
    fontWeight: '700',
    color: cores.tinta,
  },
  descricao: {
    marginTop: 8,
    color: cores.tintaSuave,
    fontSize: 13,
    lineHeight: 18,
    minHeight: 54,
  },
  descricaoLista: {
    minHeight: 0,
  },
  preco: {
    marginTop: 8,
    fontSize: 16,
    fontWeight: '700',
    color: cores.laranja,
  },
  botao: {
    marginTop: 14,
    backgroundColor: cores.azulSuave,
    borderRadius: 16,
    paddingVertical: 10,
    alignItems: 'center',
    opacity: 0.85,
  },
  botaoTexto: {
    color: cores.azul,
    fontWeight: '700',
  },
  emBreve: {
    color: cores.tintaSuave,
    fontSize: 11,
    marginTop: 2,
  },
});
