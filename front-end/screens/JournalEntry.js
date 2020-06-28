import React from 'react';

import {Text, View, Block, StyleSheet, Dimensions} from 'react-native';
import {Input} from 'react-native-elements';
import {Button, theme } from 'galio-framework';
const { height, width } = Dimensions.get('screen');

export default class JournalEntry extends React.Component{
    constructor(props) {
        super(props);
        this.state = {
          userId: 1,
          prompt: "What are you feeling upset about today? Why do you think you are feeling this way?",
          contents: "",
          feeling: 1
        };
    }
    render() {
        const { navigation } = this.props;

        return (
            <View style={styles.background}>
                <View style={styles.prompt}>
                    <Text style={styles.textEntry}>What are you feeling upset about today? Why do you think you are feeling this way?</Text>
                </View>
                <View style={styles.textHere}>
                    <Input
                        label = {"28th June 2020"}
                        placeholder = "Enter your Journal Entry Here"
                        onChangeText = {(text) => this.setState({contents: text})}
                        defaultValue={(this.state.contents) ? String(this.state.contents) : ""}
                    ></Input>
                </View>
                <Button
                    shadowless
                    style={styles.button}
                    color="#809fff"
                    fontFamily="Avenir Next"
                    onPress={this._submitChangesAsync}>
                    Submit
                </Button>
            
            </View>
        );
    }
    _submitChangesAsync = async () => {
        let prompt = this.state.prompt;
        let contents = this.state.contents;
        let feeling = this.state.feeling;
        let userId = this.state.userId;
        fetch(`https://hackathonapi20200627131743.azurewebsites.net/api/JournalEntries`, {
            method: 'POST',
            body: JSON.stringify({"userId": userId,"prompt": prompt, "contents": contents, "feeling": feeling })
        }) .then (response => {
            this.props.navigation.navigate('Home');
        });
            
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
