import styles from './index.css';
import { Table, Tag, Button, Dropdown, Menu, Icon, Row, Col, Form, Input, Select } from 'antd';
import ButtonGroup from 'antd/lib/button/button-group';
import { Link } from 'react-router-dom';

export default function() {
    const dataSource = [];
    for (var i = 0; i < 10; i++) {
        dataSource.push({
            key: i,
            name: '阿里云' + (i + 1) + '号机',
            age: 32,
            address: '192.168.1.' + i,
            state: i % 2,
        });
    }

    const columns = [
        {
            title: '名称',
            dataIndex: 'name',
            key: 'name',
            render: text => <Link to="/server/detail">{text}</Link>,
        },
        {
            title: '标签',
            dataIndex: 'age',
            key: 'age',
        },
        {
            title: 'IP地址',
            dataIndex: 'address',
            key: 'address',
            width: 160,
        },
        {
            title: '状态',
            dataIndex: 'state',
            key: 'state',
            width: 80,
            align: 'center',
            render: state =>
                state ? (
                    <Tag color="green" style={{ marginRight: 0 }}>
                        正常
                    </Tag>
                ) : (
                    <Tag color="magenta" style={{ marginRight: 0 }}>
                        掉线
                    </Tag>
                ),
        },
        {
            title: '操作',
            align: 'center',
            key: 'action',
            width: 100,
            render: (text, record) => (
                <span>
                    <Dropdown overlay={rowActionMenu}>
                        <a className="ant-dropdown-link">
                            更多 <Icon type="down" />
                        </a>
                    </Dropdown>
                </span>
            ),
        },
    ];

    const rowActionMenu = (
        <Menu>
            <Menu.Item>关机</Menu.Item>
            <Menu.Item>开机</Menu.Item>
            <Menu.Item>重启</Menu.Item>
            <Menu.Divider />
            <Menu.Item>删除</Menu.Item>
        </Menu>
    );

    const rowSelection = {
        onChange: (selectedRowKeys, selectedRows) => {},
        getCheckboxProps: (selectedRowKeys, selectedRows) => {},
    };

    const showPagerTotal = total => {
        return `共 ${total} 项`;
    };

    return (
        <div>
            <div className="search-bar">
                <Form
                    labelAlign="right"
                    layout="horizontal"
                    labelCol={{ span: 4 }}
                    wrapperCol={{ span: 20 }}
                >
                    <Row gutter="15">
                        <Col span="8">
                            <Form.Item label="名称">
                                <Input placeholder="搜索" allowClear="true" />
                            </Form.Item>
                        </Col>
                        <Col span="8">
                            <Form.Item label="IP地址">
                                <Input placeholder="搜索" allowClear="true" />
                            </Form.Item>
                        </Col>
                        <Col span="8">
                            <Form.Item label="状态">
                                <Select allowClear="true">
                                    <Select.Option value="1">1</Select.Option>
                                    <Select.Option value="2">2</Select.Option>
                                </Select>
                            </Form.Item>
                        </Col>
                    </Row>
                </Form>
                <div class="search-bar-action">
                    <Button type="primary">搜索</Button>
                    <Button>重置</Button>
                </div>
            </div>
            <div className="tool-bar clearfix">
                <div className="pull-left">
                    <ButtonGroup>
                        <Button>关机</Button>
                        <Button>开机</Button>
                        <Button>重启</Button>
                    </ButtonGroup>

                    <ButtonGroup>
                        <Button>关机</Button>
                        <Button>开机</Button>
                        <Button>重启</Button>
                    </ButtonGroup>
                </div>
                <div className="pull-right" />
            </div>
            <div className="table">
                <Table
                    bordered
                    size="middle"
                    dataSource={dataSource}
                    columns={columns}
                    rowSelection={rowSelection}
                    pagination={{
                        total: dataSource.length,
                        showSizeChanger: true,
                        showQuickJumper: true,

                        showTotal: showPagerTotal,
                    }}
                />
            </div>
        </div>
    );
}
