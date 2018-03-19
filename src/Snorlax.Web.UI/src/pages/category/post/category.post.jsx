import React from 'react';
import { Link } from 'react-router-dom';
import { connect } from 'react-redux';
import {categoryActions} from '../../../actions';

const cancelButtonStyle={
    marginLeft:"5px"
};

class CategoryPost extends React.Component{
    constructor(props){
        super(props);
        this.state={
            name:"",
            description:""
        }
        this.change=this.change.bind(this);
        this.save=this.save.bind(this);
    }
    change(e){
        const { name, value } = e.target;
        this.setState({ [name]: value });
    }
    save(){
        const { dispatch } = this.props;
        dispatch(categoryActions.insert(this.state));
    }
    back(){
        const { dispatch } = this.props;
        dispatch(categoryActions.back());
    }
    render(){
        return(
            <div>
                <h1 className="page-header">Yeni Kategori</h1>
                
                <div className="panel panel-default">
                    <div className="panel-body">
                        <div className="row">
                            <div className="col-lg-6">
                                <div className="form-group">
                                    <label>Kategori Adı</label>
                                    <input className="form-control" name="name" onChange={this.change} />
                                </div>
                                <div className="form-group">
                                    <label>Açıklaması</label>
                                    <textarea className="form-control" rows="3" name="description" onChange={this.change}></textarea>
                                </div>
                                <p>
                                    <button onClick={this.save.bind(this)} className="btn btn-default">Kaydet</button>
                                    <button onClick={this.back.bind(this)} type="button" className="btn btn-danger" style={cancelButtonStyle}>İptal</button>
                                </p>
                            </div>
                        </div>
                    </div>
                </div>
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

const connectedCategoryPost = connect(mapStateToProps)(CategoryPost);
export { connectedCategoryPost as CategoryPost }; 