import React from 'react';
import { withNavigation } from '@react-navigation/compat';

import { StyleSheet, Dimensions, Image, TouchableWithoutFeedback, ScrollView, View } from 'react-native';

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
            <View style={styles.prompt} onPress={() => navigation.navigate('Entry')}>
            <Text style={styles.textEntry} onPress={() => navigation.navigate('Entry')}>What are you feeling upset about today? Why do you think you are feeling this way?</Text>
            </View>
            <View style={styles.prompt}>
            <Text style={styles.textEntry}>Prompt 2</Text>
            </View>
            <View style={styles.prompt}>
            <Text style={styles.textEntry}>Prompt 3</Text>
            </View>
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
    marginLeft: 35,
    marginRight: 35,
    paddingTop: 0,
  },
  products: {
    justifyContent: 'center',
    //width: width - theme.SIZES.BASE * 2,
    paddingVertical: theme.SIZES.BASE * 3,
    backgroundColor: "#0000b3",
    marginRight: 0
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

 
  prompt: {
    height: 200,
    backgroundColor: '#bfcfff',
    borderRadius: 10,
    padding: 35,
    margin: 30
  },
    textEntry: {
        fontSize: 20,
        textAlign: 'center',
        fontFamily: "Avenir Next",
        fontWeight: '600',
        color: '#002080'
    }
});