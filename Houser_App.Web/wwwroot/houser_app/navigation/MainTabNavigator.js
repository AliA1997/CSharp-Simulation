import React from 'react';
import { Platform } from 'react-native';
import { createStackNavigator, createBottomTabNavigator } from 'react-navigation';

import Colors from '../constants/Colors';

import TabBarIcon from '../components/TabBarIcon';
import HomeScreen from '../screens/HomeScreen';
import CreateHouseScreen from '../screens/CreateHouseScreen';
import AccountScreen from '../screens/AccountScreen';

//Enabled Nested Routes using the createStack navigator.
const HomeStack = createStackNavigator({
  Home: HomeScreen,
});

//Set it's tabBarLabel sicne it will be in a TabNavigator
HomeStack.navigationOptions = {
  tabBarLabel: 'Home',
  //Give it a tabBarIcon and based on it's os set a different icon.
  tabBarIcon: ({ focused }) => (
    <TabBarIcon
      focused={focused}
      name={
        Platform.OS === 'ios'
          ? `ios-information-circle${focused ? '' : '-outline'}`
          : 'md-information-circle'
      }
    />
  ),
};

const CreateHouseStack = createStackNavigator({
  CreateHouse: CreateHouseScreen,
});

CreateHouseStack.navigationOptions = {
  tabBarLabel: 'Create',
  tabBarIcon: ({ focused }) => (
    <TabBarIcon
      focused={focused}
      name={Platform.OS === 'ios' ? 'ios-home' : 'md-home'}
    />
  ),
};

const AccountStack = createStackNavigator({
  Account: AccountScreen,
});

AccountStack.navigationOptions = {
  tabBarLabel: 'Account',
  tabBarIcon: ({ focused }) => (
    <TabBarIcon
      focused={focused}
      name={Platform.OS === 'ios' ? 'ios-person' : 'md-person'}
    />
  ),
};

export default createBottomTabNavigator({
  HomeStack,
  CreateHouseStack,
  AccountStack,
}, 
{
  activeTintColor: Colors.tabIconSelected
});
