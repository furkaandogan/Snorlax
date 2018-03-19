import React from 'react';
import { Router } from 'react-router-dom';
import { connect } from 'react-redux';
import { history,PrivateRoute,AppRoute } from './utilities';
import {loginPage,homePage,categoryPage,CategoryList,Layout,LoginLayout} from './pages';
import {loginConstants} from './constants';


let user = JSON.parse(localStorage.getItem('user'));


class App extends React.Component{

    constructor(props){
        super(props);

        const {dispatch}=this.props;
        history.listen((location,action)=>{
            console.log(action);
        });
    }

    render(){
        const { alert } = this.props;
        return (
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
                <Router history={history}>
                    <div>
                        <PrivateRoute exact path='/dashboard' component={homePage} layout={Layout}/>
                        <PrivateRoute exact path='/' component={homePage} layout={Layout}/>
                        <AppRoute path='/category' component={categoryPage} layout={Layout}/>
                        <AppRoute exact path="/login" component={loginPage} layout={LoginLayout} />
                    </div>
                </Router>
            </div>
        );
    }
}


function mapStateToProps(state) {
    const { alert } = state.loginReducer;
    return {
        alert
    };
}

const connectedApp = connect(mapStateToProps)(App);
export { connectedApp as App }; 