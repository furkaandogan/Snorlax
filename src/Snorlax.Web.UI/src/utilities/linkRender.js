import { createBrowserHistory } from 'history';

const apiUrl='http://localhost:5000';

function login(){
    return apiUrl+"/api/login";
}

function categoryListWithPagination(pageIndex,pageSize){
    return apiUrl+"/api/categories/"+pageIndex+"/"+pageSize;
}

function categoryPost()
{
    return apiUrl+ "/api/categories";
}
function categoryUpdate(id)
{
    return apiUrl+ "/api/categories/"+id;
}
function categoryDelete(id)
{
    return apiUrl+ "/api/categories/"+id;
}
function categoryGetById(id)
{
    return apiUrl+ "/api/categories/"+id;
}

export const linkRender = {
    login,
    category:{
        listWithPagination:categoryListWithPagination,
        post:categoryPost,
        delete:categoryDelete,
        update:categoryUpdate,
        getById:categoryGetById
    }
};
