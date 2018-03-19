import React from 'react';
import { Router,Route  } from 'react-router-dom';
import { Link } from 'react-router-dom';
import { connect } from 'react-redux';
import { AppRoute } from '../../utilities';
import { CategoryList } from './list';
import { CategoryDetail } from './detail';
import { CategoryPost } from './post';
import { Layout } from '../shareds';

class categoryPage extends React.Component{
    constructor(props){
        super(props);
    }

    render(){
        const {alert}=this.props;
        return(
            <div>
                {
                    alert&&
                    <div className="alert alert-danger alert-dismissable">
                        <button type="button" className="close" data-dismiss="alert" aria-hidden="true">&times;</button>
                        {alert.errors.map(x=>
                            <span>{x.userMessage}</span>
                        )}
                    </div>
                } 
                <Route path='/category/list' component={CategoryList}/>
                <Route path='/category/new' component={CategoryPost}/>
                <Route path='/category/edit/:id' component={CategoryDetail}/>
            </div>
        );
    }
}

function mapStateToProps(state) {
    const { categoryReducer } = state;
    const {alert}=categoryReducer;
    return {
        alert
    };
}

const connectedCategoryPage = connect(mapStateToProps)(categoryPage);
export { connectedCategoryPage as categoryPage }; 