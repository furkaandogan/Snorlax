import React from 'react';
import { connect } from 'react-redux';

class LoginLayout extends React.Component{
    constructor(props){
        super(props);
    }

    render(){
        const { page,title,children } = this.props;
        return(
            <div className="container">
                <div className="row">
                    <div className="col-md-4 col-md-offset-4">
                        <div className="login-panel panel panel-default">
                            <div className="panel-heading">
                                <h3 className="panel-title">Please Sign In</h3>
                            </div>
                            <div className="panel-body">
                                {children}
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        );
    }
}

function mapStateToProps(state) {
    return {
    };
}

const connectedLoginLayout = connect(mapStateToProps)(LoginLayout);
export { connectedLoginLayout as LoginLayout }; 