import {categoryConstants} from '../constants';

let user = JSON.parse(localStorage.getItem('user'));

export function categoryReducer(state={},action){
    switch (action.type) {
        case categoryConstants.LIST_SUCCESS:
            return {
                categories:action.categories
            };
            break;
        case categoryConstants.GETBYID_SUCCESS:
            return {
                category:action.category
            };
            break;
        case categoryConstants.POST_SUCCESS:
        case categoryConstants.PUT_SUCCESS:
            return {
            };
            break;
        case categoryConstants.ERROR:
            return {
                alert:{
                    errors:action.res.errors
                }
            };
        case categoryConstants.DELETE_SUCCESS:
            return {
                categories:state.categories.filter(x=>x.id!=action.id)
            };
            break;
        default:
            return  {};
            break;
    }
}