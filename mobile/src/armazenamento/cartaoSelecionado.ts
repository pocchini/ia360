import AsyncStorage from '@react-native-async-storage/async-storage';

const CHAVE_CARTAO_ID = '@cardplay/cartaoId';

export async function obterCartaoIdSalvo(): Promise<string | null> {
  return AsyncStorage.getItem(CHAVE_CARTAO_ID);
}

export async function salvarCartaoId(id: string): Promise<void> {
  await AsyncStorage.setItem(CHAVE_CARTAO_ID, id);
}
