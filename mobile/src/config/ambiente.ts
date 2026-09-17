import { Platform } from 'react-native';

function obterUrlApi(): string {
  const configurada = process.env.EXPO_PUBLIC_API_URL?.trim();
  if (configurada) {
    return configurada.replace(/\/$/, '');
  }

  if (Platform.OS === 'android') {
    return 'http://10.0.2.2:5080';
  }

  return 'http://localhost:5080';
}

export const URL_API = obterUrlApi();
