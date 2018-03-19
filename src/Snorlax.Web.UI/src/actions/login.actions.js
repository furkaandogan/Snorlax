import {history} from '../utilities';
import {loginService} from '../services';
import {loginConstants} from '../constants';


function login(email,password){
    return dispatch =>{
        loginService.login(email,password)
            .then(res=>{
                if(res.isOk){
                    const user={
                        user:{
                            email:email
                        },
                        token:res.data.token
                    };
                    localStorage.setItem("user",JSON.stringify(user));
                    dispatch({
                        type:loginConstants.LOGIN_SUCCESS, 
                        user
                    });
                    history.push('/dashboard');
                }else{
                    dispatch({
                        type:loginConstants.LOGIN_ERROR, 
                        res
                    });
                }
            }).catch(res=>{
                const alert={
                    message:res.message,
                    errors:res.errors,
                    type:500
                };
                dispatch({
                    type:loginConstants.LOGIN_ERROR,
                    alert
                })
            });
    };
}

function logout(){
    loginService.logout();
    return {type:loginConstants.LOGOUT};
}


export const loginActions={
    login,
    logout
};