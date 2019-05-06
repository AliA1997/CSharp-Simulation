import React from 'react';
import {
  Image,
  Platform,
  ScrollView,
  StyleSheet,
  Text,
  TouchableOpacity,
  View,
} from 'react-native';
import Expo, { WebBrowser} from 'expo';

// const { manifest } = Expo.Constants;


export default class HomeScreen extends React.Component {

  state = {
    list: [] 
  }

  static navigationOptions = {
    header: null,
  };

  componentDidMount() {
    // const server = manifest.debuggerHost.split(`:`).shift().concat(`:45456`);
    // console.log('server--------------', server);
    alert('componentDidMount Hitt---------');
    fetch(`https://10.0.2:44330/api/houses`, {
      method: "GET",
      type: 'application/json',
      origin: 'include',
      mode: 'cors',
      headers: {
        'Context-Type': 'application/json'
      }
    })
    .then(res => res ? res.json() : console.log('res--------', res))
    .then(resJSON => console.log('resJSON----------', resJSON))
    .catch(err => {
      console.log(JSON.stringify(err))
    });
    try {


      // console.log('items----------', items); 
      
    } catch(error) {
      
      console.log('Error---------', error);
    
    }
  
    // console.log('componentDidMount Hit------------');
  }

  _maybeRenderDevelopmentModeWarning() {
    if (__DEV__) {
      const learnMoreButton = (
        <Text onPress={this._handleLearnMorePress} style={styles.helpLinkText}>
          Learn more
        </Text>
      );

      return (
        <Text style={styles.developmentModeText}>
          Development mode is enabled, your app will be slower but you can use useful development
          tools. {learnMoreButton}
        </Text>
      );
    } else {
      return (
        <Text style={styles.developmentModeText}>
          You are not in development mode, your app will run at full speed.
        </Text>
      );
    }
  }

  _handleLearnMorePress = () => {
    WebBrowser.openBrowserAsync('https://docs.expo.io/versions/latest/guides/development-mode');
  };

  _handleHelpPress = () => {
    WebBrowser.openBrowserAsync(
      'https://docs.expo.io/versions/latest/guides/up-and-running.html#can-t-see-your-changes'
    );
  };

  render() {
    return (
      <View style={styles.container}>
        <ScrollView style={styles.container} contentContainerStyle={styles.contentContainer}>

        </ScrollView>
      </View>
    );
  }

}

const styles = StyleSheet.create({
  container: {
    flex: 1,
    backgroundColor: '#fff',
  },
  developmentModeText: {
    marginBottom: 20,
    color: 'rgba(0,0,0,0.4)',
    fontSize: 14,
    lineHeight: 19,
    textAlign: 'center',
  },
  contentContainer: {
    paddingTop: 30,
  },
});
