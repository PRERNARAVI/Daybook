import React from 'react';

import {Text, TextInput, View, Block, StyleSheet, Dimensions} from 'react-native';
import {Button, theme } from 'galio-framework';
const { height, width } = Dimensions.get('screen');

export default class JournalEntry extends React.Component{
    render() {
        const { navigation } = this.props;

        return (
            <View style={styles.background}>
            <View style={styles.prompt}>
            <Text style={styles.textEntry}>What are you feeling upset about today? Why do you think you are feeling this way?</Text>
            </View>
            <View style={styles.textHere}>
            <TextInput placeholder={"Enter Jounal Entry Here..."}></TextInput>
            </View>
            <Button
                shadowless
                style={styles.button}
                color="#809fff"
                fontFamily="Avenir Next"
                onPress={() => navigation.navigate('Home')}>
                Submit
              </Button>
            
            </View>
        );
    }

}
const styles = StyleSheet.create({
    background: {
        backgroundColor: '#002080',
        flex: 1
    },
    prompt: {
        height: 150,
        backgroundColor: '#bfcfff',
        borderRadius: 5,
        padding: 28,
        margin: 20
    },
    textHere: {
        height: 300,
        backgroundColor: 'white',
        borderRadius: 5,
        padding: 30,
        margin: 20
    },
    button: {
        width: width - theme.SIZES.BASE * 2,
        height: theme.SIZES.BASE * 3,
        shadowRadius: 0,
        shadowOpacity: 0,
        marginLeft: 15,
    },
    textEntry: {
        fontSize: 20,
        textAlign: 'center',
        fontFamily: "Avenir Next",
        fontWeight: '600',
        color: '#002080'
    }
});
