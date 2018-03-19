import React from 'react';
import { Link } from 'react-router-dom';
import { connect } from 'react-redux';
import {history} from '../../utilities';
import {loginActions} from '../../actions';
import {LeftMenu} from '../shareds';
import {CategoryList} from '../category';

class homePage extends React.Component{
    constructor(props){
        super(props);
        this.logout=this.logout.bind(this);
    }

    logout(){
        this.props.dispatch(loginActions.logout());
        history.push("/login");
    }
   
    render(){
        const { page,title,children } = this.props;
        return(
            <div >
                {children}
            </div>
        );
    }
}

function mapStateToProps(state) {
    const { loginReducer } = state;
    const { user } = loginReducer;
    return {
        user
    };
}

const connectedHomePage = connect(mapStateToProps)(homePage);
export { connectedHomePage as homePage }; 