import React from 'react';
import { Link } from 'react-router-dom';
import { connect } from 'react-redux';
import {categoryActions} from '../../../actions';

class CategoryList extends React.Component{
    constructor(props){
        super(props);
    }
    componentDidMount() {
        this.props.dispatch(categoryActions.list(0,20));
    }
    delete(id){
        this.props.dispatch(categoryActions.delete(id));
    }
    render(){
        const { categories } = this.props;
        return(
            <div>
                <h1 className="page-header">Kategori Yönetimi</h1>
                <Link to="/category/new" className="btn btn-success">
                    <i className="fa fa fa-plus" />
                    Yeni Kayıt
                </Link>
                <table  width="100%" className="table table-striped table-bordered table-hover" id="dataTables-example">
                    <thead>
                        <tr>
                            <th>Ad</th>
                            <th>Açıklama</th>
                            <th>İşlem</th>
                        </tr>
                    </thead>
                    {/* <tfoot>
                        <tr>
                            <th>Ad</th>
                            <th>Açıklama</th>
                            <th>İşlem</th>
                        </tr>
                    </tfoot> */}
                    <tbody>
                        {categories && categories.map((category, index) =>
                                <tr key={category.id}>
                                    <td>{category.name}</td>
                                    <td>{category.description}</td>
                                    <td className="center">
                                        <Link to={`/category/edit/${category.id}`}>
                                            <i className="fa fa-edit"/>
                                        </Link>
                                        <i onClick={this.delete.bind(this,category.id)} className="fa fa-trash-o"/>
                                    </td>
                                </tr>
                            )}
                    </tbody>
            </table>
            </div>
        );
    }
}

function mapStateToProps(state) {
    const { loginReducer,categoryReducer } = state;
    const { user } = loginReducer;
    const { categories } = categoryReducer;
    return {
        user,
        categories
    };
}

const connectedCategoryList = connect(mapStateToProps)(CategoryList);
export { connectedCategoryList as CategoryList }; 