import styles from './token.less';
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
            <div className="tool-bar clearfix">
                <div className="pull-left">
                    <ButtonGroup>
                        <Button type="primary">新建</Button>
                    </ButtonGroup>
                </div>
                <div className="pull-right" />
            </div>
            <div className="table">
                <Table
                    bordered
                    size="middle"
                    dataSource={dataSource}
                    pagination={{
                        total: dataSource.length,
                        showSizeChanger: true,
                        showQuickJumper: true,

                        showTotal: showPagerTotal,
                    }}
                >
                    <Table.Column
                        key="_index"
                        title=""
                        width="50px"
                        align="center"
                        render={(text, record, index) => `${index + 1}`}
                    />
                    <Table.Column key="token" title="token" />
                    <Table.Column key="expired" title="有效期" />
                    <Table.Column
                        key="action"
                        title="操作"
                        width="120px"
                        align="center"
                        render={(text, record) => (
                            <span>
                                <Button type="danger" size="small">
                                    删除
                                </Button>
                            </span>
                        )}
                    />
                </Table>
            </div>
        </div>
    );
}
