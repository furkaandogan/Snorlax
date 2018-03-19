import React from 'react';
import { Link } from 'react-router-dom';
import { connect } from 'react-redux';
import {categoryActions} from '../../../actions';

const cancelButtonStyle={
    marginLeft:"5px"
};

class CategoryDetail extends React.Component{
    constructor(props){
        super(props);
        this.change=this.change.bind(this);
        this.update=this.update.bind(this);
    }
    componentDidMount() {
        this.props.dispatch(categoryActions.get(this.props.match.params.id));
    }
    change(e){
        const { name, value } = e.target;
        this.props.category[name]=value;
        this.setState({ [name]: value });
    }
    update(){
        const { id } = this.props.category;
        const { dispatch } = this.props;
        dispatch(categoryActions.update(id,this.props.category));
    }
    back(){
        const { dispatch } = this.props;
        dispatch(categoryActions.back());
    }
    render(){
        let { category } = this.props;
        if(category==undefined){
            category={
                id:"",
                name:"",
                description:""
            };
        }
        const {id,name,description}=category;
        return(
            <div>
                <h1 className="page-header">Kategori Düzenleme</h1>
                <div className="panel panel-default">
                    <div className="panel-body">
                        <div className="row">
                            <div className="col-lg-6">
                                <div className="form-group">
                                    <label>Kategori Adı</label>
                                    <input className="form-control" name="name" value={name} onChange={this.change} />
                                </div>
                                <div className="form-group">
                                    <label>Açıklaması</label>
                                    <textarea className="form-control" rows="3" name="description" onChange={this.change} value={description}></textarea>
                                </div>
                                <p>
                                    <button onClick={this.update.bind(this)} className="btn btn-default" >Güncelle</button>
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
    const { categoryReducer } = state;
    const { category } = categoryReducer;
    return {
        category
    };
}

const connectedCategoryDetail = connect(mapStateToProps)(CategoryDetail);
export { connectedCategoryDetail as CategoryDetail }; 