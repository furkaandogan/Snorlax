import Axios from 'axios';
import {authHeader} from '../utilities';
import { linkRender } from "../utilities";

// axios.defaults.headers.post['Content-Type']="application/json";

function getListWithPagination(pageIndex,pageSize){
    return Axios.get(linkRender.category.listWithPagination(pageIndex,pageSize),{
            headers:authHeader()
        })
        .then((res)=>{
            if(!(res.status==200)){
                return Promise.reject(res);
            }
            return res.data;
        });
}
function getById(id){
    return Axios.get(linkRender.category.getById(id),{
        headers:authHeader()
    })
    .then((res)=>{
        if(!(res.status==200)){
            return Promise.reject(res);
        }
        return res.data;
    });
}
function post(data){
    return Axios.post(linkRender.category.post(),data,{
            headers:authHeader()
        })
        .then((res)=>{
            if(!(res.status==200)){
                return Promise.reject(res);
            }
            return res.data;
        });
}

function _delete(id){
    return Axios.delete(linkRender.category.delete(id),{
            headers:authHeader()
        })
        .then((res)=>{
            if(!(res.status==200)){
                return Promise.reject(res);
            }
            return res.data;
        });
}
function put(id,data){
    return Axios.put(linkRender.category.update(id),data,{
            headers:authHeader()
        })
        .then((res)=>{
            if(!(res.status==200)){
                return Promise.reject(res);
            }
            return res.data;
        });
}


export const categoryService={
    getListWithPagination,
    getById:getById,
    post,
    put,
    delete:_delete
};