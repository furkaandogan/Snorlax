import Axios from 'axios';
import { linkRender } from "../utilities";

// axios.defaults.headers.post['Content-Type']="application/json";

function login(email,password){
    return Axios.post(linkRender.login(),{
        'email':email,
        'password':password
    }).then((res)=>{
        if(!(res.status==200)){
            return Promise.reject(res);
        }
        return res.data;
    });
}

function logout(){
    localStorage.removeItem("user");
}

export const loginService={
    login,
    logout
};