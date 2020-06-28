import React from 'react';
import {Text, TextInput, View, Block, StyleSheet} from 'react-native';

export default class JournalEntry extends React.Component{
    render() {
        return (
            <View style={styles.background}>
            <View style={styles.prompt}>
            <Text>Prompt Question here</Text>
            </View>
            <View style={styles.textHere}>
            <TextInput placeholder={"Enter Jounal Entry Here..."}></TextInput>
            </View>
            
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
        padding: 30,
        margin: 20
    },
    textHere: {
        height: 300,
        backgroundColor: 'white',
        borderRadius: 5,
        padding: 30,
        margin: 20
    }
});