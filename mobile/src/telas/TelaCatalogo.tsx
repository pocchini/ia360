import { useEffect, useState } from 'react';
import { ActivityIndicator, ScrollView, StyleSheet, Text, useWindowDimensions, View } from 'react-native';
import { produtoApi } from '../api/produtoApi';
import { CardProduto } from '../componentes/CardProduto';
import { cores } from '../tema/cores';
import { usePaddingTela } from '../tema/usePaddingTela';
import type { Produto } from '../tipos';

const LARGURA_DUAS_COLUNAS = 720;

export function TelaCatalogo() {
  const [produtos, setProdutos] = useState<Produto[]>([]);
  const [carregando, setCarregando] = useState(true);
  const [erro, setErro] = useState<string | null>(null);
  const { width } = useWindowDimensions();
  const paddingTela = usePaddingTela(18);
  const duasColunas = width >= LARGURA_DUAS_COLUNAS;

  useEffect(() => {
    let ativo = true;

    async function carregar() {
      try {
        const lista = await produtoApi.listar();
        if (ativo) {
          setProdutos(lista);
        }
      } catch (falha) {
        if (ativo) {
          setErro(falha instanceof Error ? falha.message : 'Não foi possível carregar o catálogo.');
        }
      } finally {
        if (ativo) {
          setCarregando(false);
        }
      }
    }

    void carregar();
    return () => {
      ativo = false;
    };
  }, []);

  return (
    <ScrollView contentContainerStyle={[estilos.conteudo, paddingTela]}>
      <Text style={estilos.titulo}>Catálogo</Text>
      <Text style={estilos.subtitulo}>
        Produtos da plataforma. A compra ainda não está disponível nesta versão.
      </Text>

      {carregando ? <ActivityIndicator color={cores.azul} /> : null}
      {erro ? <Text style={estilos.erro}>{erro}</Text> : null}

      <View style={duasColunas ? estilos.grade : estilos.lista}>
        {produtos.map((produto) => (
          <View key={produto.id} style={duasColunas ? estilos.itemGrade : estilos.itemLista}>
            <CardProduto produto={produto} layout={duasColunas ? 'grade' : 'lista'} />
          </View>
        ))}
      </View>
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
    marginHorizontal: 6,
  },
  subtitulo: {
    marginTop: 8,
    marginBottom: 20,
    marginHorizontal: 6,
    color: cores.tintaSuave,
    fontSize: 15,
    lineHeight: 22,
  },
  erro: {
    color: cores.coral,
    marginHorizontal: 6,
    marginBottom: 12,
  },
  grade: {
    flexDirection: 'row',
    flexWrap: 'wrap',
  },
  lista: {
    flexDirection: 'column',
  },
  itemGrade: {
    width: '50%',
  },
  itemLista: {
    width: '100%',
  },
});
