// import styles from './index.less';
import { Table, Button, Form, Input, Modal, Popconfirm } from 'antd';
import ButtonGroup from 'antd/lib/button/button-group';
import { connect } from 'dva';
import { PureComponent } from 'react';

class User extends PureComponent {
    static defaultProps = {
        modelVisible: false,
        modelTitle: '添加',

        formValues: {},
    };

    constructor(props) {
        super(props);

        this.state = {
            modelVisible: false,
            formValues: {},
        };
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

        const handleModalShow = () => {
            form.resetFields();
            this.setState({
                modelTitle: '添加',
                modelVisible: true,
                formValues: {},
            });
        };

        const handleModalClose = () => {
            this.setState({
                modelVisible: false,
            });
        };

        const handleFormSubmit = e => {
            const { dispatch, form } = this.props;
            const { formValues } = this.state;
            e.preventDefault();

            form.validateFieldsAndScroll((err, values) => {
                // console.log(values);
                if (formValues.id) values['id'] = formValues.id;
                if (!err) {
                    dispatch({
                        type: 'user/formSubmit',
                        payload: values,
                        callback: result => {
                            if (result) this.setState({ modelVisible: false });
                        },
                    });
                }
            });
        };

        const handleRowEdit = row => {
            form.resetFields();

            this.setState({
                modelTitle: '编辑',
                modelVisible: true,
                formValues: row,
            });
        };

        const handleRowDelete = row => {
            dispatch({ type: 'user/remove', payload: row });
        };

        const handlePagerChange = (page, pageSize) => {
            dispatch({ type: 'user/getList', payload: { page, pageSize } });
        };

        const showPagerTotal = total => {
            return `共 ${total} 项`;
        };

        const formItemLayout = {
            labelCol: {
                xs: { span: 24 },
                sm: { span: 6 },
            },
            wrapperCol: {
                xs: { span: 24 },
                sm: { span: 18 },
            },
        };

        const { getFieldDecorator } = this.props.form;
        const { formValues } = this.state;

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
                        <Table.Column dataIndex="userName" title="用户名" />
                        <Table.Column dataIndex="displayName" title="姓名" />
                        <Table.Column
                            key="action"
                            title="操作"
                            width="160px"
                            align="center"
                            render={(text, record) => (
                                <span>
                                    <Button
                                        type="default"
                                        size="small"
                                        onClick={() => handleRowEdit(record)}
                                    >
                                        编辑
                                    </Button>

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
                    maskClosable={false}
                    onCancel={handleModalClose}
                    onOk={handleFormSubmit}
                >
                    <Form {...formItemLayout}>
                        <Form.Item label="用户名">
                            {getFieldDecorator('userName', {
                                initialValue: formValues.userName,
                                rules: [
                                    {
                                        required: true,
                                        message: 'the field is required.',
                                    },
                                ],
                            })(<Input maxLength={16} />)}
                        </Form.Item>
                        <Form.Item label="姓名">
                            {getFieldDecorator('displayName', {
                                initialValue: formValues.displayName,
                                rules: [{ required: true, message: 'the field is required.' }],
                            })(<Input maxLength={16} />)}
                        </Form.Item>
                        <Form.Item label="密码">
                            {getFieldDecorator('password', {
                                rules: [{ required: false, message: 'the field is required.' }],
                            })(<Input type="password" maxLength={16} />)}
                        </Form.Item>
                    </Form>
                </Modal>
            </div>
        );
    }
}

export default Form.create()(connect(({ user }) => ({ ...user }))(User));
