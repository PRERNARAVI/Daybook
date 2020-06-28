import React from 'react';
import { withNavigation } from '@react-navigation/compat';
import { StyleSheet, Dimensions, Image, TouchableWithoutFeedback, ScrollView } from 'react-native';
import { Block, Text, theme } from 'galio-framework';

import materialTheme from '../constants/Theme';

const { width } = Dimensions.get('screen');

const card = [
    {
      id: "0",
      title: "What are you feeling upset about today? Why do you think you are feeling this way?",
      //picture: require('./assets/starry.jpg'),
      content: <Text>Starry Night</Text>
    },
    {
      id: "1",
      title: "Prompt 2",
      //picture: require('./assets/wheat.jpg'),
      content: <Text>Wheat Field with Cypresses</Text>
    },
    {
      id: "2",
      title: "Prompt 3",
      //picture: require('./assets/bed.jpg'),
      content: <Text>Bedroom in Arles</Text>
    }
  ]

class Prompt extends React.Component {
  render() {
    const { navigation, horizontal, full, style, priceColor, imageStyle } = this.props;
    const imageStyles = [styles.image, full ? styles.fullImage : styles.horizontalImage, imageStyle];

    return (
        <ScrollView
            showsVerticalScrollIndicator={false}
            contentContainerStyle={styles.products}>
        <Block flex>
            {/** Item 1 */}
            <Block row={horizontal} card flex style={[styles.product, styles.shadow, style]}>
                <TouchableWithoutFeedback onPress={() => navigation.navigate('Entry')}>
                <Block flex style={[styles.imageContainer, styles.shadow]}>
                    <Image source={{  }} style={imageStyles} />
                </Block>
                </TouchableWithoutFeedback>
                <TouchableWithoutFeedback onPress={() => navigation.navigate('Entry')}>
                <Block flex space="between" style={styles.productDescription}>
                    <Text size={14} style={styles.productTitle}>{card[0].title}</Text>
                </Block>
                </TouchableWithoutFeedback>
            </Block>
            {/** Item 2 */}
            <Block row={horizontal} card flex style={[styles.product, styles.shadow, style]}>
                <TouchableWithoutFeedback onPress={() => navigation.navigate('Prompt')}>
                <Block flex style={[styles.imageContainer, styles.shadow]}>
                    <Image source={{  }} style={imageStyles} />
                </Block>
                </TouchableWithoutFeedback>
                <TouchableWithoutFeedback onPress={() => navigation.navigate('Prompt')}>
                <Block flex space="between" style={styles.productDescription}>
                    <Text size={14} style={styles.productTitle}>{card[1].title}</Text>
                </Block>
                </TouchableWithoutFeedback>
            </Block>
            {/** Item 3 */}
            <Block row={horizontal} card flex style={[styles.product, styles.shadow, style]}>
                <TouchableWithoutFeedback onPress={() => navigation.navigate('Prompt')}>
                <Block flex style={[styles.imageContainer, styles.shadow]}>
                    <Image source={{  }} style={imageStyles} />
                </Block>
                </TouchableWithoutFeedback>
                <TouchableWithoutFeedback onPress={() => navigation.navigate('Prompt')}>
                <Block flex space="between" style={styles.productDescription}>
                    <Text size={14} style={styles.productTitle}>{card[2].title}</Text>
                </Block>
                </TouchableWithoutFeedback>
            </Block>
        </Block>
      </ScrollView>
      
    );
  }
}

export default withNavigation(Prompt);

const styles = StyleSheet.create({
  product: {
    backgroundColor: "#bfcfff",
    marginVertical: theme.SIZES.BASE,
    borderWidth: 0,
    minHeight: 0,
    marginLeft: 25,
  },
  products: {
    justifyContent: 'center',
    width: width - theme.SIZES.BASE * 2,
    paddingVertical: theme.SIZES.BASE * 3,
  },
  productTitle: {
    color: "#001f7d",
    flex: 1,
    flexWrap: 'wrap',
    paddingBottom: 20,
    fontFamily: "Avenir Next",
    fontSize: 20,
    alignContent: 'center',
    textAlign: 'center',

  },
  productDescription: {
    padding: theme.SIZES.BASE / 2,
    padding: 10,
  },
  imageContainer: {
    elevation: 1,
  },
  image: {
    borderRadius: 3,
    marginHorizontal: theme.SIZES.BASE,
    marginTop: 1,

  },
  horizontalImage: {
    height: 122,
    width: 'auto',
  },
  fullImage: {
    height: 215,
    width: width - theme.SIZES.BASE * 3,
  },
  shadow: {
    shadowColor: theme.COLORS.BLACK,
    shadowOffset: { width: 0, height: 2 },
    shadowRadius: 4,
    shadowOpacity: 0.1,
    elevation: 2,
  },
});