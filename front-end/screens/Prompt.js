import React, { Component } from 'react';
import {
  Platform,
  StyleSheet,
  Text,
  View
} from 'react-native';
import { CardList } from 'react-native-card-list';
 
const cards = [
  {
    id: "0",
    title: "Prompt 1",
    //picture: require('./assets/starry.jpg'),
    content: <Text style={{color: 'black'}}>Prompt 1</Text>,
    padding: 0
  },
  {
    id: "1",
    title: "Prompt 2",
    //picture: require('./assets/wheat.jpg'),
    content: <Text>Prompt 2</Text>
  },
  {
    id: "2",
    title: "Prompt 3",
    //picture: require('./assets/bed.jpg'),
    content: <Text>Prompt 3</Text>
  }
]
 
export default class Prompt extends Component {
  render() {
    return (
      <View style={styles.container}>
        <CardList cards={cards} style={styles.card}/>
      </View>
    );
  }
}
 
const styles = StyleSheet.create({
  container: {
    flex: 1,
    justifyContent: 'center',
    alignItems: 'center',
    backgroundColor: '#001f7d',
  },
  card: {
    justifyContent: 'center',
     width: '90%'
  },
  textFormat: {
      backgroundColor: 'black'
  }
});