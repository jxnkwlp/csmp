// import styles from './index.less';
import { Table, Button, Form, Input, Modal, Popconfirm } from 'antd';
import ButtonGroup from 'antd/lib/button/button-group';
import { connect } from 'dva';
import { PureComponent } from 'react';

class Logs extends PureComponent {
    static defaultProps = {};

    constructor(props) {
        super(props);

        this.state = {};
    }

    componentDidMount() {
        const { dispatch } = this.props;
        dispatch({ type: 'user/getList' });
    }

    render() {
        console.log(this.props);
        const { dispatch, form } = this.props;
        const { tableList, tableTotal } = this.props;
        const { modelVisible, modelTitle } = this.state;

        const handlePagerChange = (page, pageSize) => {
            dispatch({ type: 'user/getList', payload: { page, pageSize } });
        };

        const showPagerTotal = total => {
            return `共 ${total} 项`;
        };

        return (
            <div>
                <div className="table">
                    <Table
                        bordered
                        size="middle"
                        dataSource={tableList}
                        rowKey="id"
                        pagination={{
                            total: tableTotal,
                            showTotal: showPagerTotal,
                            onChange: handlePagerChange,
                        }}
                    >
                        <Table.Column
                            key="_index"
                            title=""
                            width="50px"
                            align="center"
                            render={(text, record, index) => `${index + 1}`}
                        />
                        <Table.Column dataIndex="userName" title="用户" width="120px" />
                        <Table.Column dataIndex="userName" title="时间" width="150px" />
                        <Table.Column dataIndex="displayName" title="摘要" />
                    </Table>
                </div>
            </div>
        );
    }
}

export default Form.create()(connect(({ logs }) => ({ ...logs }))(Logs));
