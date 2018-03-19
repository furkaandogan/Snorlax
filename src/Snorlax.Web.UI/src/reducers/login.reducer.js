import {loginConstants} from '../constants';

let user = JSON.parse(localStorage.getItem('user'));
const initialState = user ? { loggedIn: true, user } : {};

export function loginReducer(state=initialState,action){
    switch (action.type) {
        case loginConstants.LOGIN_REQUEST:
        case loginConstants.LOGIN_SUCCESS:
            return {
                loggingIn:true,
                user:action.user
            };
        case loginConstants.LOGIN_ERROR:
            return {
                alert:{
                    errors:action.res.errors
                }
            };
        case loginConstants.LOGOUT:
            return {};
        default:
            return  {};
        break;
    }
}