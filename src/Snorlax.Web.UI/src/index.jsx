import React from 'react';
import { render } from 'react-dom';
import { Router, Route,Switch } from 'react-router-dom';
import { Provider } from 'react-redux';
import { store } from './utilities';
import {App} from './app';

render(
    <Provider store={store}>
        <App/>
    </Provider>,
    document.getElementById("app")
);