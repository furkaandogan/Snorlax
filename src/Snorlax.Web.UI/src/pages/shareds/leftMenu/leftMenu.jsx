import React from 'react';
import { Link } from 'react-router-dom';
import { connect } from 'react-redux';
import {history} from '../../../utilities';

class LeftMenu extends React.Component{
    constructor(props){
        super(props);

        this.changeHistory=this.changeHistory.bind(this);
    }

    changeHistory(e){
        e.preventDefault();
        const { href } = e.target;
        history.push(href);
    }

    render(){
        return(
            <div className="navbar-default sidebar" role="navigation">
                <div className="sidebar-nav navbar-collapse">
                    <ul className="nav" id="side-menu">
                        <li className="sidebar-search">
                            <div className="input-group custom-search-form">
                                <input type="text" className="form-control" placeholder="Search..." />
                                <span className="input-group-btn">
                                    <button className="btn btn-default" type="button">
                                        <i className="fa fa-search"></i>
                                    </button>
                                </span>
                            </div>
                        </li>
                        <li>
                            <Link to="/">
                                <i className="fa fa-dashboard fa-fw"></i> 
                                Dashboard
                            </Link>
                        </li>
                        <li>
                            <Link to="/category/list">
                                <i className="fa fa-wrench fa-fw"></i> 
                                Kategori Yönetimi
                            </Link>
                        </li>
                    </ul>
                </div>
            </div>
        );
    }
}

function mapStateToProps(state) {
    return {

    };
}

const connectedleftMenu = connect(mapStateToProps)(LeftMenu);
export { connectedleftMenu as LeftMenu }; 