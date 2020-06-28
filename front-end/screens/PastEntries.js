import React from 'react';
import { withNavigation } from '@react-navigation/compat';

import { StyleSheet, Dimensions, Image, TouchableWithoutFeedback, ScrollView, View } from 'react-native';

import { Block, Text, theme } from 'galio-framework';

import materialTheme from '../constants/Theme';

const { width } = Dimensions.get('screen');

class PastEntries extends React.Component {
  render() {
    const { navigation, horizontal, full, style, priceColor, imageStyle } = this.props;
    const imageStyles = [styles.image, full ? styles.fullImage : styles.horizontalImage, imageStyle];

    return (
        <ScrollView
            showsVerticalScrollIndicator={false}
            contentContainerStyle={styles.products}>
            <View style={styles.prompt} onPress={() => navigation.navigate('Entry')}>
            <Text style={styles.textEntry} onPress={() => navigation.navigate('Entry')}>
                <Text style={styles.date}>28th June 2020: {"\n"}</Text>
                How do you want to maintain your connections to people in your life and things that add joyfulness during the pandemic?{"\n"}
                <Text style={styles.text}>Dear Diary...</Text>
            </Text>
            </View>
            <View style={styles.prompt}>
            <Text style={styles.textEntry}>
                <Text style={styles.date}>28th June 2020: {"\n"}</Text>
                Write a letter to your body. What would you say to it as it experiences fear, uncertainty, and anxiety?{"\n"}
                <Text style={styles.text}>Dear Diary...</Text>
            </Text>
            </View>
            <View style={styles.prompt}>
            <Text style={styles.textEntry}>
                <Text style={styles.date}>28th June 2020: {"\n"}</Text>
                Write about a difficult time in your life you overcame.{"\n"}
                <Text style={styles.text}>Dear Diary...</Text>
            </Text>
            </View>
      </ScrollView>
      
    );
  }
}

export default withNavigation(PastEntries);

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
    //width: width - theme.SIZES.BASE * 2,
    paddingVertical: theme.SIZES.BASE * 3,
    backgroundColor: "#0000b3",
    marginRight: 0,
  },
  date: {
    fontWeight: 'bold',
    color: 'black'
  },
  text: {
    fontSize: 13,
    color: "#809fff"
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
    padding: 30,
    margin: 25
  },
    textEntry: {
        fontSize: 16,
        textAlign: 'left',
        fontFamily: "Avenir Next",
        fontWeight: '600',
        color: '#002080'
    }
});