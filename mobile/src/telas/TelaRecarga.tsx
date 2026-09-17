import { useState } from 'react';
import { Pressable, StyleSheet, Text, TextInput, View } from 'react-native';
import { useCartao } from '../estado/CartaoContexto';
import { cores } from '../tema/cores';
import { usePaddingTela } from '../tema/usePaddingTela';
import { formatarMoeda } from '../util/formatacao';

const SUGESTOES = [10, 25, 50];

export function TelaRecarga() {
  const { cartao, recarregar } = useCartao();
  const paddingTela = usePaddingTela();
  const [valor, setValor] = useState('25');
  const [descricao, setDescricao] = useState('Recarga');
  const [enviando, setEnviando] = useState(false);
  const [mensagem, setMensagem] = useState<string | null>(null);

  async function aoRecarregar() {
    const numero = Number(valor.replace(',', '.'));
    setEnviando(true);
    setMensagem(null);
    try {
      await recarregar(numero, descricao);
      setMensagem('Recarga registrada com sucesso.');
    } catch (falha) {
      setMensagem(falha instanceof Error ? falha.message : 'Não foi possível recarregar.');
    } finally {
      setEnviando(false);
    }
  }

  if (!cartao) {
    return (
      <View style={[estilos.conteudo, paddingTela]}>
        <Text style={estilos.titulo}>Recarga</Text>
        <Text style={estilos.subtitulo}>Solicite um cartão na primeira aba para adicionar saldo.</Text>
      </View>
    );
  }

  return (
    <View style={[estilos.conteudo, paddingTela]}>
      <Text style={estilos.titulo}>Adicionar saldo</Text>
      <Text style={estilos.subtitulo}>
        Recarga simulada. Nada é cobrado de verdade.
      </Text>
      <Text style={estilos.saldoAtual}>Saldo atual: {formatarMoeda(cartao.saldo)}</Text>

      <View style={estilos.sugestoes}>
        {SUGESTOES.map((sugestao) => (
          <Pressable
            key={sugestao}
            onPress={() => setValor(String(sugestao))}
            style={[estilos.chip, valor === String(sugestao) && estilos.chipAtivo]}
          >
            <Text style={[estilos.chipTexto, valor === String(sugestao) && estilos.chipTextoAtivo]}>
              {formatarMoeda(sugestao)}
            </Text>
          </Pressable>
        ))}
      </View>

      <Text style={estilos.rotulo}>Valor</Text>
      <TextInput
        keyboardType="decimal-pad"
        value={valor}
        onChangeText={setValor}
        style={estilos.campo}
      />

      <Text style={estilos.rotulo}>Descrição</Text>
      <TextInput value={descricao} onChangeText={setDescricao} style={estilos.campo} />

      <Pressable
        onPress={() => void aoRecarregar()}
        disabled={enviando}
        style={[estilos.botao, enviando && estilos.botaoDesabilitado]}
      >
        <Text style={estilos.botaoTexto}>{enviando ? 'Recarregando...' : 'Recarregar'}</Text>
      </Pressable>

      {mensagem ? <Text style={estilos.mensagem}>{mensagem}</Text> : null}
    </View>
  );
}

const estilos = StyleSheet.create({
  conteudo: {
    flex: 1,
    backgroundColor: cores.fundo,
  },
  titulo: {
    fontSize: 32,
    fontWeight: '800',
    color: cores.tinta,
  },
  subtitulo: {
    marginTop: 8,
    color: cores.tintaSuave,
    fontSize: 15,
    lineHeight: 22,
  },
  saldoAtual: {
    marginTop: 24,
    marginBottom: 16,
    color: cores.laranja,
    fontWeight: '700',
    fontSize: 16,
  },
  sugestoes: {
    flexDirection: 'row',
    gap: 8,
    marginBottom: 20,
  },
  chip: {
    backgroundColor: cores.superficie,
    borderRadius: 999,
    paddingVertical: 10,
    paddingHorizontal: 14,
    borderWidth: 1,
    borderColor: cores.linha,
  },
  chipAtivo: {
    backgroundColor: cores.laranja,
    borderColor: cores.laranja,
  },
  chipTexto: {
    color: cores.tinta,
    fontWeight: '600',
  },
  chipTextoAtivo: {
    color: cores.noDestaque,
  },
  rotulo: {
    marginTop: 12,
    marginBottom: 8,
    color: cores.tinta,
    fontWeight: '600',
  },
  campo: {
    backgroundColor: cores.superficie,
    borderRadius: 16,
    paddingHorizontal: 16,
    paddingVertical: 14,
    fontSize: 16,
    color: cores.tinta,
    borderWidth: 1,
    borderColor: cores.linha,
  },
  botao: {
    marginTop: 24,
    backgroundColor: cores.laranja,
    borderRadius: 16,
    paddingVertical: 14,
    alignItems: 'center',
  },
  botaoDesabilitado: {
    opacity: 0.6,
  },
  botaoTexto: {
    color: cores.noDestaque,
    fontWeight: '700',
    fontSize: 16,
  },
  mensagem: {
    marginTop: 16,
    color: cores.tintaSuave,
  },
});
