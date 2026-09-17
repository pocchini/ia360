import { useSafeAreaInsets } from 'react-native-safe-area-context';

export function usePaddingTela(horizontal = 24) {
  const insets = useSafeAreaInsets();

  return {
    paddingTop: insets.top + 16,
    paddingHorizontal: horizontal,
    paddingBottom: 24,
  };
}
