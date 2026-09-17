import { useState } from 'react';
import {
  ActivityIndicator,
  KeyboardAvoidingView,
  Platform,
  Pressable,
  ScrollView,
  StyleSheet,
  Text,
  TextInput,
  View,
} from 'react-native';
import { CartaoVirtual } from '../componentes/CartaoVirtual';
import { useCartao } from '../estado/CartaoContexto';
import { cores } from '../tema/cores';
import { usePaddingTela } from '../tema/usePaddingTela';

export function TelaCartao() {
  const { cartao, carregando, erro, solicitar } = useCartao();
  const paddingTela = usePaddingTela();
  const [nome, setNome] = useState('');
  const [enviando, setEnviando] = useState(false);

  async function aoSolicitar() {
    setEnviando(true);
    try {
      await solicitar(nome);
    } catch {
      // a mensagem já aparece no contexto
    } finally {
      setEnviando(false);
    }
  }

  if (carregando && !cartao) {
    return (
      <View style={estilos.centralizado}>
        <ActivityIndicator color={cores.azul} />
      </View>
    );
  }

  return (
    <KeyboardAvoidingView
      style={estilos.flex}
      behavior={Platform.OS === 'ios' ? 'padding' : undefined}
    >
      <ScrollView contentContainerStyle={[estilos.conteudo, paddingTela]}>
        <Text style={estilos.saudacao}>Olá!</Text>
        <Text style={estilos.titulo}>Seu cartão lúdico</Text>
        <Text style={estilos.subtitulo}>
          Um cartão interno da plataforma, só para aprender e brincar com saldo.
        </Text>

        {cartao ? (
          <CartaoVirtual cartao={cartao} />
        ) : (
          <View style={estilos.formulario}>
            <Text style={estilos.rotulo}>Como você gostaria de ser chamado?</Text>
            <TextInput
              value={nome}
              onChangeText={setNome}
              placeholder="Seu nome"
              placeholderTextColor={cores.tintaSuave}
              style={estilos.campo}
            />
            <Pressable
              onPress={() => void aoSolicitar()}
              disabled={enviando}
              style={[estilos.botao, enviando && estilos.botaoDesabilitado]}
            >
              <Text style={estilos.botaoTexto}>
                {enviando ? 'Criando...' : 'Solicitar cartão'}
              </Text>
            </Pressable>
          </View>
        )}

        {erro ? <Text style={estilos.erro}>{erro}</Text> : null}
      </ScrollView>
    </KeyboardAvoidingView>
  );
}

const estilos = StyleSheet.create({
  flex: { flex: 1, backgroundColor: cores.fundo },
  centralizado: {
    flex: 1,
    backgroundColor: cores.fundo,
    alignItems: 'center',
    justifyContent: 'center',
  },
  conteudo: {
    flexGrow: 1,
  },
  saudacao: {
    color: cores.azul,
    fontWeight: '700',
    fontSize: 16,
  },
  titulo: {
    marginTop: 6,
    fontSize: 32,
    fontWeight: '800',
    color: cores.tinta,
  },
  subtitulo: {
    marginTop: 8,
    marginBottom: 28,
    color: cores.tintaSuave,
    fontSize: 15,
    lineHeight: 22,
  },
  formulario: {
    backgroundColor: cores.superficie,
    borderRadius: 24,
    padding: 20,
    borderWidth: 1,
    borderColor: cores.linha,
  },
  rotulo: {
    color: cores.tinta,
    fontWeight: '600',
    marginBottom: 12,
  },
  campo: {
    backgroundColor: cores.fundo,
    borderRadius: 16,
    paddingHorizontal: 16,
    paddingVertical: 14,
    fontSize: 16,
    color: cores.tinta,
  },
  botao: {
    marginTop: 16,
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
  erro: {
    marginTop: 16,
    color: cores.coral,
  },
});
