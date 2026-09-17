import { createBottomTabNavigator } from '@react-navigation/bottom-tabs';
import { Ionicons } from '@expo/vector-icons';
import { Platform } from 'react-native';
import { TelaCartao } from '../telas/TelaCartao';
import { TelaCatalogo } from '../telas/TelaCatalogo';
import { TelaMovimentacoes } from '../telas/TelaMovimentacoes';
import { TelaRecarga } from '../telas/TelaRecarga';
import { cores } from '../tema/cores';

export type AbasParamList = {
  Cartao: undefined;
  Recarga: undefined;
  Movimentacoes: undefined;
  Catalogo: undefined;
};

const Abas = createBottomTabNavigator<AbasParamList>();

export function NavegacaoAbas() {
  return (
    <Abas.Navigator
      screenOptions={{
        headerShown: false,
        tabBarActiveTintColor: cores.azul,
        tabBarInactiveTintColor: cores.tintaSuave,
        tabBarHideOnKeyboard: true,
        tabBarStyle: {
          backgroundColor: cores.superficie,
          borderTopColor: cores.linha,
          borderTopWidth: 1,
          paddingTop: 8,
          paddingBottom: Platform.OS === 'android' ? 10 : 8,
          height: 78,
        },
        tabBarLabelStyle: {
          fontSize: 12,
          fontWeight: '600',
          marginBottom: 4,
        },
        tabBarIconStyle: {
          marginTop: 4,
        },
      }}
    >
      <Abas.Screen
        name="Cartao"
        component={TelaCartao}
        options={{
          title: 'Cartão',
          tabBarIcon: ({ color, size }) => <Ionicons name="card-outline" size={size} color={color} />,
        }}
      />
      <Abas.Screen
        name="Recarga"
        component={TelaRecarga}
        options={{
          tabBarIcon: ({ color, size }) => <Ionicons name="add-circle-outline" size={size} color={color} />,
        }}
      />
      <Abas.Screen
        name="Movimentacoes"
        component={TelaMovimentacoes}
        options={{
          title: 'Histórico',
          tabBarIcon: ({ color, size }) => <Ionicons name="time-outline" size={size} color={color} />,
        }}
      />
      <Abas.Screen
        name="Catalogo"
        component={TelaCatalogo}
        options={{
          title: 'Catálogo',
          tabBarIcon: ({ color, size }) => <Ionicons name="storefront-outline" size={size} color={color} />,
        }}
      />
    </Abas.Navigator>
  );
}
