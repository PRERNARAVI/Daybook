import React from 'react';
import { ImageBackground, StyleSheet, StatusBar, Dimensions, Platform, View } from 'react-native';
import { Block, Button, Text, theme } from 'galio-framework';
import HomePageWallPaper from '../assets/images/HomeScreenWallpaper.jpg';

const { height, width } = Dimensions.get('screen');

import materialTheme from '../constants/Theme';
import Images from '../constants/Images';

export default class Onboarding extends React.Component {
  render() {
    const { navigation } = this.props;

    return (
      <Block flex style={styles.container}>
        <StatusBar barStyle="light-content" />
        <View style={styles.container} >
          <ImageBackground
            source={ HomePageWallPaper }
            style={styles.image}
          />
        </View>
        <Block flex space="between" style={styles.padded}>
          <Block flex space="around" style={{ zIndex: 2 }}>
            <Block>
              <Block>
                <Text color="black" size={60}>Daybook</Text>
              </Block>
              <Text size={16} color="black">
                A Mental Health Journaling App!
              </Text>
            </Block>
            <Block center>
              <Button
                shadowless
                style={styles.button}
                color={materialTheme.COLORS.BUTTON_COLOR}
                onPress={() => navigation.navigate('App')}>
                GET STARTED
              </Button>
            </Block>
          </Block>
        </Block>
      </Block>
    );
  }
}

const styles = StyleSheet.create({
  container: {
    /**backgroundColor: theme.COLORS.BLACK,*/
    flex: 2,
    flexDirection: "column"
  },
  padded: {
    paddingHorizontal: theme.SIZES.BASE * 2,
    position: 'relative',
    bottom: theme.SIZES.BASE,
  },
  button: {
    width: width - theme.SIZES.BASE * 4,
    height: theme.SIZES.BASE * 3,
    shadowRadius: 0,
    shadowOpacity: 0,
  },
  image: {
    flex: 1,
    resizeMode: "cover",
    justifyContent: "center" 
  },
});
