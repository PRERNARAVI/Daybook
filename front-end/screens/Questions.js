import React, { Component } from 'react';
import { StyleSheet, Button, ScrollView, Text, TextInput, View, CheckBox } from 'react-native';
import { SimpleSurvey } from 'react-native-simple-survey';
//import { COLORS } from '../res/validColors';



const survey = [
    {
        questionType: 'Info',
        questionText: 'Welcome to your Tasks for Today!'
    },
    {
        questionType: 'SelectionGroup',
        questionText:
            "Which of the following are you struggling with?",
        questionId: 'struggle',
        options: 
            [
            {
                optionText: 'Depression',

                value: 'depression',
            },
            {
                optionText: 'Anxiety',
                value: 'anxiety'
            },
            {
                optionText: 'PTSD',
                value: 'PSTD'
            },
            {
                optionText: 'Eating Disorder',
                value: 'afraid'
            },
            {
                optionText: 'Personality Disorder',
                value: 'disgusted'
            },
            {
                optionText: 'Coping with COVID-19',
                value: 'covid'
            },
        ]
    },
    {
        questionType: 'MultipleSelectionGroup',
        questionText:
            "How are you feeling today?",
        questionId: 'feeling',
        questionSettings: {
            maxMultiSelect: 3,
            minMultiSelect: 1,
        },
        options: 
        [
            {
                optionText: 'Happy',
                value: 'happy'
            },
            {
                optionText: 'Sad',
                value: 'sad'
            },
            {
                optionText: 'Angry',
                value: 'angry'
            },
            {
                optionText: 'Afraid',
                value: 'afraid'
            },
            {
                optionText: 'Disgusted',
                value: 'disgusted'
            },
            {
                optionText: 'Surprised',
                value: 'surprised'
            },
        ]
    },
    
    {
        questionType: 'Info',
        questionText: 'Hit Finished to submit your responses!'
    },
];

export default class Questions extends Component {
    static navigationOptions = () => {
        return {
            headerStyle: {
                backgroundColor: "black",
                height: 40,
                elevation: 5,
            },
            headerTintColor: '#fff',
            headerTitle: 'Sample Survey',
            headerTitleStyle: {
                flex: 1,
            }
        };
    }

    constructor(props) {
        super(props);
        this.state = { backgroundColor: "#001f7d", answersSoFar: '' };
    }

    onSurveyFinished(answers) {
        /** 
         *  By using the spread operator, array entries with no values, such as info questions, are removed.
         *  This is also where a final cleanup of values, making them ready to insert into your DB or pass along
         *  to the rest of your code, can be done.
         * 
         *  Answers are returned in an array, of the form 
         *  [
         *  {questionId: string, value: any},
         *  {questionId: string, value: any},
         *  ...
         *  ]
         *  Questions of type selection group are more flexible, the entirity of the 'options' object is returned
         *  to you.
         *  
         *  As an example
         *  { 
         *      questionId: "favoritePet", 
         *      value: { 
         *          optionText: "Dogs",
         *          value: "dog"
         *      }
         *  }
         *  This flexibility makes SelectionGroup an incredibly powerful component on its own. If needed it is a 
         *  separate NPM package, react-native-selection-group, which has additional features such as multi-selection.
         */

        const infoQuestionsRemoved = [...answers];

        // Convert from an array to a proper object. This won't work if you have duplicate questionIds
        const answersAsObj = {};
        for (const elem of infoQuestionsRemoved) { answersAsObj[elem.questionId] = elem.value; }

        //this.props.navigation.navigate('SurveyCompleted', { surveyAnswers: answersAsObj });
    }

    /**
     *  After each answer is submitted this function is called. Here you can take additional steps in response to the 
     *  user's answers. From updating a 'correct answers' counter to exiting out of an onboarding flow if the user is 
     *  is restricted (age, geo-fencing) from your app.
     */
    onAnswerSubmitted(answer) {
        this.setState({ answersSoFar: JSON.stringify(this.surveyRef.getAnswers(), 2) });
        switch (answer.questionId) {
            case 'favoriteColor': {
                //if (COLORS.includes(answer.value.toLowerCase())) {
                    this.setState({ backgroundColor: answer.value.toLowerCase() });
                //}
                break;
            }
            default:
                break;
        }
    }

    renderPreviousButton(onPress, enabled) {
        return (
            <View style={{ backgroundColor: "#bfcfff",
            color: "#002080",
            flexGrow: 1, maxWidth: 100, marginTop: 10, marginBottom: 10,
            borderRadius: 5, justifyContent: 'center' }}>
                <Button
                    color="#002080"
                    onPress={onPress}
                    disabled={!enabled}
                    backgroundColor="#002080"
                    
                    title={'Previous'}
                />
            </View>
        );
    }

    renderNextButton(onPress, enabled) {
        return (
            <View style={{ backgroundColor: "#001f7d",
            flexGrow: 1, maxWidth: 100, marginTop: 10, marginBottom: 10, 
            borderRadius: 5, justifyContent: 'center'}}>
                <Button
                    fontSize='10'
                    color="white"
                    onPress={onPress}
                    disabled={!enabled}
                    backgroundColor="white"
                    title={'Next'}
                    
                />
            </View>
        );
    }

    renderFinishedButton(onPress, enabled) {
        return (

            <View style={{ backgroundColor: "#001f7d", flexGrow: 1, maxWidth: 100, 
            marginTop: 10, marginBottom: 10, borderRadius: 5 }}>

                <Button
                    title={'Finished'}
                    onPress={() => this.props.navigation.navigate('Prompt')}
                    disabled={!enabled}

                    color="white"

                />
            </View>
        );
    }

    renderButton(data, index, isSelected, onPress) {
        return (
            <View
                key={`selection_button_view_${index}`}

                style={{ marginTop: 5, marginBottom: 5 }}

            >
                <Button
                    title={data.optionText}
                    onPress={onPress}

                    color={isSelected ? "white" : "#809fff"}
                    style={isSelected ? { fontWeight: '600' } : {}} 

                    key={`button_${index}`}
                />
            </View>
        );
    }

    renderQuestionText(questionText) {
        return (
            <View style={{ marginLeft: 10, marginRight: 10 }}>
                <Text numLines={1} style={styles.questionText}>{questionText}</Text>
            </View>
        );
    }

    renderTextBox(onChange, value, placeholder, onBlur) {
        return (
            <View>
                <TextInput
                    style={styles.textBox}
                    onChangeText={text => onChange(text)}
                    numberOfLines={1}
                    underlineColorAndroid={'white'}
                    placeholder={placeholder}
                    placeholderTextColor={'rgba(184,184,184,1)'}
                    value={value}
                    multiline
                    onBlur={onBlur}
                    blurOnSubmit
                    returnKeyType='done'
                />
            </View>
        );
    }

    renderNumericInput(onChange, value, placeholder, onBlur) {
        return (<TextInput 
            style={styles.numericInput}
            onChangeText={text => { onChange(text); }}
            underlineColorAndroid={'white'}
            placeholderTextColor={'rgba(184,184,184,1)'}
            value={String(value)}
            placeholder={placeholder}
            keyboardType={'numeric'}
            onBlur={onBlur}
            maxLength={3}
        />);
    }

    renderInfoText(infoText) {
        return (
            <View style={{ marginLeft: 10, marginRight: 10 }}>
                <Text style={styles.infoText}>{infoText}</Text>
            </View>
        );
    }

    render() {
        return (
            <View style={[styles.background, { backgroundColor: this.state.backgroundColor }]}>
                <View style={styles.container}>
                    <SimpleSurvey
                        ref={(s) => { this.surveyRef = s; }}
                        survey={survey}
                        renderSelector={this.renderButton.bind(this)}
                        containerStyle={styles.surveyContainer}
                        selectionGroupContainerStyle={styles.selectionGroupContainer}
                        navButtonContainerStyle={{ flexDirection: 'row', justifyContent: 'space-around' }}
                        renderPrevious={this.renderPreviousButton.bind(this)}
                        renderNext={this.renderNextButton.bind(this)}
                        renderFinished={this.renderFinishedButton.bind(this)}
                        renderQuestionText={this.renderQuestionText}
                        onSurveyFinished={(answers) => this.onSurveyFinished(answers)}
                        onAnswerSubmitted={(answer) => this.onAnswerSubmitted(answer)}
                        renderTextInput={this.renderTextBox}
                        renderNumericInput={this.renderNumericInput}
                        renderInfo={this.renderInfoText}
                    />
                    
                </View>
                
                {/* <ScrollView style={styles.answersContainer}>
                    <Text style={{textAlign:'center'}}>JSON output</Text>
                    <Text>{this.state.answersSoFar}</Text>
                </ScrollView> */}
                
            </View>
        );
    }
}

const styles = StyleSheet.create({
    container: {
        minWidth: '70%',
        maxWidth: '90%',
        alignItems: 'stretch',

        elevation: 20,
        borderRadius: 10,
        flex: 1

         
    },
    answersContainer: {
        width: '90%',
        maxHeight: '20%',
        marginTop: 50,
        paddingHorizontal: 20,
        paddingVertical: 10,
        marginBottom: 20,
        backgroundColor: 'white',
        elevation: 20,
        borderRadius: 10,
    },
    surveyContainer: {
        marginTop: 60,
        position: 'relative',
        flex: 0,
        width: 'auto',
        backgroundColor: 'white',
        borderRadius: 10,
        paddingTop: '10%',
        alignContent: 'center',
        padding: 5,
        
        
    },
    selectionGroupContainer: {
        flexDirection: 'column',
        backgroundColor: '#002080',
        borderRadius: 10,
        margin: 10,
        fontWeight: '500',
        justifyContent: 'space-evenly',
        paddingTop: 20,
        paddingBottom: 20
        
    },
    background: {
        flex: 1,
        minHeight: 800,
        maxHeight: 900,
        justifyContent: 'center',
        alignItems: 'center',
    },
    questionText: {
        
        fontSize: 20,
        color: 'black',
        fontFamily: "Avenir Next",
        fontWeight: '600',
        textAlign: 'center'
        
    },
    textBox: {
        borderWidth: 1,
        borderColor: 'rgba(204,204,204,1)',
        backgroundColor: 'white',
        borderRadius: 10,
        
        padding: 10,
        textAlignVertical: 'top',
        marginLeft: 10,
        marginRight: 10
    },
    numericInput: {
        borderWidth: 1,
        borderColor: 'rgba(204,204,204,1)',
        backgroundColor: 'white',
        borderRadius: 10,
        padding: 10,
        textAlignVertical: 'top',
        marginLeft: 10,
        marginRight: 10
    },
    infoText: {
        marginBottom: 20,
        fontSize: 20,
        marginLeft: 10,
        fontFamily: "Avenir Next",
        fontWeight: '600',
        textAlign: 'center'
    },
});
