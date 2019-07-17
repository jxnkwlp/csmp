// import styles from './index.less';
import {
    Table,
    Tag,
    Button,
    Dropdown,
    Menu,
    Icon,
    Row,
    Col,
    Form,
    Input,
    Select,
    Modal,
    Radio,
    Popconfirm,
} from 'antd';
import ButtonGroup from 'antd/lib/button/button-group';
import { Link } from 'react-router-dom';
import { connect } from 'dva';
import { PureComponent } from 'react';

class Token extends PureComponent {
    componentDidMount() {
        const { dispatch } = this.props;
        dispatch({ type: 'token/getList' });
    }

    render() {
        console.log(this.props);
        const { dispatch } = this.props;
        const { modelVisible, modelTitle, tableList, tableTotal } = this.props;

        const handleModalShow = () => {
            dispatch({ type: 'token/updateModalShow', payload: { show: true, title: '添加' } });
        };

        const handleModalClose = () => {
            dispatch({ type: 'token/updateModalShow', payload: { show: false } });
        };

        const handleFormSubmit = e => {
            const { dispatch, form } = this.props;
            e.preventDefault();

            form.validateFieldsAndScroll((err, values) => {
                if (!err) {
                    dispatch({ type: 'token/formSubmit', payload: values });
                }
            });
        };

        const handleRowDelete = row => {
            dispatch({ type: 'token/remove', payload: row });
        };

        const handlePagerChange = (page, pageSize) => {
            dispatch({ type: 'token/getList', payload: { page, pageSize } });
        };

        const showPagerTotal = total => {
            return `共 ${total} 项`;
        };

        const { getFieldDecorator } = this.props.form;

        return (
            <div>
                <div className="tool-bar clearfix">
                    <div className="pull-left">
                        <ButtonGroup>
                            <Button type="primary" onClick={handleModalShow}>
                                新建
                            </Button>
                        </ButtonGroup>
                    </div>
                    <div className="pull-right">{modelVisible}</div>
                </div>
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
                        <Table.Column dataIndex="token" title="token" />
                        <Table.Column dataIndex="expired" title="有效期" />
                        <Table.Column
                            key="action"
                            title="操作"
                            width="120px"
                            align="center"
                            render={(text, record) => (
                                <span>
                                    <Popconfirm
                                        title="确定要删除吗？"
                                        okText="确定"
                                        cancelText="取消"
                                        onConfirm={() => handleRowDelete(record)}
                                    >
                                        <Button type="danger" size="small">
                                            删除
                                        </Button>
                                    </Popconfirm>
                                </span>
                            )}
                        />
                    </Table>
                </div>

                {/* model */}
                <Modal
                    title={modelTitle}
                    visible={modelVisible}
                    okText="确认"
                    cancelText="取消"
                    onCancel={handleModalClose}
                    onOk={handleFormSubmit}
                >
                    <Form>
                        <Form.Item label="有效期">
                            {getFieldDecorator('period', { rules: [{ required: true }] })(
                                <Radio.Group>
                                    <Radio value={0}>长期</Radio>
                                    <Radio value={1}>1天</Radio>
                                    <Radio value={3}>1个月</Radio>
                                    <Radio value={4}>1年</Radio>
                                </Radio.Group>,
                            )}
                        </Form.Item>
                    </Form>
                </Modal>
            </div>
        );
    }
}

export default Form.create()(connect(({ token }) => ({ ...token }))(Token));
