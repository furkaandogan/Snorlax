import { combineReducers } from 'redux';
import {loginReducer} from './login.reducer';
import {categoryReducer} from './category.reducer';

const rootReducer = combineReducers({
    loginReducer,
    categoryReducer
});

export default rootReducer;