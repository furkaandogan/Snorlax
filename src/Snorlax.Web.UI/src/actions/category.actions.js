import {history} from '../utilities';
import {categoryService} from '../services';
import {categoryConstants} from '../constants';


function list(pageIndex,pageSize){
    return dispatch =>{
        categoryService.getListWithPagination(pageIndex,pageSize)
            .then(res=>{
                if(res.isOk){
                    const categories=res.data;
                    dispatch({
                        type:categoryConstants.LIST_SUCCESS, 
                        categories
                    });
                }else{
                    dispatch({
                        type:categoryConstants.ERROR,
                        res
                    });
                }
            }).catch(res=>{
                dispatch({
                    type:categoryConstants.LIST_ERROR,
                    res
                })
            });
    };
}

function get(id){
    return dispatch =>{
        categoryService.getById(id)
            .then(res=>{
                if(res.isOk){
                    const category=res.data;
                    dispatch({
                        type:categoryConstants.GETBYID_SUCCESS, 
                        category
                    });
                }else{
                    dispatch({
                        type:categoryConstants.ERROR,
                        res
                    });
                }
            }).catch(res=>{
                dispatch({
                    type:categoryConstants.GETBYID_ERROR,
                    res
                })
            });
    };
}

function insert(data){
    return dispatch =>{
        categoryService.post(data)
            .then(res=>{
                if(res.isOk){
                    dispatch({
                        type:categoryConstants.POST_REQUEST, 
                    });
                    history.push("/category/list");
                }else{
                    dispatch({
                        type:categoryConstants.ERROR,
                        res
                    });
                }
            }).catch(res=>{
                dispatch({
                    type:categoryConstants.POST_ERROR,
                    res
                })
            });
    };
}
function update(id,data){
    return dispatch =>{
        categoryService.put(id,data)
            .then(res=>{
                if(res.isOk){
                    dispatch({
                        type:categoryConstants.PUT_SUCCESS, 
                    });
                    history.push("/category/list");
                }else{
                    dispatch({
                        type:categoryConstants.ERROR,
                        res
                    });
                }
            }).catch(res=>{
                dispatch({
                    type:categoryConstants.PUT_ERROR,
                    res
                })
            });
    };
}

function _delete(id){
    return dispatch =>{
        categoryService.delete(id)
            .then(res=>{
                if(res.isOk){
                    dispatch({
                        type:categoryConstants.DELETE_SUCCESS, 
                        id
                    });
                }else{
                    dispatch({
                        type:categoryConstants.ERROR,
                        res
                    });
                }
            }).catch(res=>{
                dispatch({
                    type:categoryConstants.DELETE_ERROR,
                    res
                });
            });
    };
}

function back(){  
    return dispatch =>{
        history.push("/category/list");
    };
}

export const categoryActions={
    list,
    insert,
    update,
    delete:_delete,
    get:get,
    back
};