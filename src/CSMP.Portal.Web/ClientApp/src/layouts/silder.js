import styles from './index.less';

import { PureComponent } from 'react';

import router from 'umi/router';

import { Layout, Menu, Breadcrumb, Icon } from 'antd';

const { Header, Content, Footer, Sider } = Layout;
const { SubMenu } = Menu;

class Silder extends PureComponent {
    handleMenuCollapse(payload) {}

    handleMenuClick({ key, keyPath }) {
        if (key === 'dashboard') {
            router.push('/home');
        } else {
            router.push(`/${keyPath.reverse().join('/')}`);
        }
    }

    render() {
        return (
            <Sider
                collapsible
                collapsed={this.props.collapsed}
                onCollapse={this.handleMenuCollapse}
            >
                <div
                    className={[styles.logo, this.props.collapsed ? styles.logoMini : ''].join(' ')}
                >
                    CSMP
                </div>
                <Menu
                    theme="dark"
                    defaultSelectedKeys={['1']}
                    mode="inline"
                    onClick={this.handleMenuClick}
                >
                    <Menu.Item key="dashboard">
                        <Icon type="dashboard" />
                        <span>Dashboard</span>
                    </Menu.Item>
                    <Menu.Item key="server">
                        <Icon type="cloud-server" />
                        <span>服务器</span>
                    </Menu.Item>
                    <Menu.Item key="database">
                        <Icon type="cloud-server" />
                        <span>数据库</span>
                    </Menu.Item>

                    <SubMenu
                        key="system"
                        title={
                            <span>
                                <Icon type="setting" />
                                <span>System</span>
                            </span>
                        }
                    >
                        <Menu.Item key="user">用户</Menu.Item>
                        <Menu.Item key="logs">操作日志</Menu.Item>
                        <Menu.Item key="token">Token</Menu.Item>
                    </SubMenu>
                </Menu>
            </Sider>
        );
    }
}

export default Silder;
