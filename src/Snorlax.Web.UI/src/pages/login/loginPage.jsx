import React from 'react';
import { Link } from 'react-router-dom';
import { connect } from 'react-redux';
import {loginActions} from '../../actions';

class loginPage extends React.Component{
    constructor(props){
        super(props);

        this.props.dispatch(loginActions.logout());
        this.state={
            email:"",
            password:""
        };
        this.login=this.login.bind(this);
        this.change=this.change.bind(this);
    }

    change(e){
        const { name, value } = e.target;
        this.setState({ [name]: value });
    }
    login(){
        const { email, password } = this.state;
        const { dispatch } = this.props;
        if (email && password) {
            dispatch(loginActions.login(email, password));
        }
    }

    render(){
        const { email, password } = this.state;
        return(
            <fieldset>
                <div className="form-group">
                    <label htmlFor="email">Email address</label>
                    <input className="form-control" placeholder="E-mail" name="email" type="email" autoFocus="true" value={email} onChange={this.change} type="email" aria-describedby="emailHelp" placeholder="Enter email" />
                </div>
                <div className="form-group">
                    <label htmlFor="password">Password</label>
                    <input className="form-control" placeholder="Password" name="password" value={password} onChange={this.change} type="password" placeholder="Password" />
                </div>
                <button className="btn btn-lg btn-success btn-block"onClick={this.login}>Login</button>
            </fieldset>
        );
    }
}

function mapStateToProps(state) {
    const { loggingIn } = state.loginReducer;
    return {
        loggingIn
    };
}

const connectedLoginPage = connect(mapStateToProps)(loginPage);
export { connectedLoginPage as loginPage }; 