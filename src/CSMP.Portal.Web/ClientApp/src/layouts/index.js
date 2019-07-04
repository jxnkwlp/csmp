import styles from './index.less';

import router from 'umi/router';

import HeaderLayout from './header';

import { Layout, Menu, Breadcrumb, Icon } from 'antd';
import { connect } from 'dva';

const { Header, Content, Footer, Sider } = Layout;
const { SubMenu } = Menu;

const menus = () => {
    return [
        {
            key: '',
            title: '',
        },
    ];
};

function BasicLayout(props) {
    const { dispatch, layout } = props;

    const handleMenuCollapse = payload =>
        dispatch &&
        dispatch({
            type: 'layout/changeCollapsed',
            payload,
        });

    const handleMenuClick = ({ item, key, keyPath, domEvent }) => {
        // console.log(key, keyPath);
        if (key === 'dashboard') {
            router.push('/home');
        } else {
            router.push(`/${keyPath.reverse().join('/')}`);
        }
    };

    return (
        <Layout style={{ minHeight: '100vh' }}>
            <Sider collapsible collapsed={props.collapsed} onCollapse={handleMenuCollapse}>
                <div className={[styles.logo, props.collapsed ? styles.logoMini : ''].join(' ')}>
                    CSMP
                </div>
                <Menu
                    theme="dark"
                    defaultSelectedKeys={['1']}
                    mode="inline"
                    onClick={handleMenuClick}
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
            <Layout>
                <Header className={styles.header}>
                    <HeaderLayout />
                </Header>
                <Content style={{ margin: '0 16px' }}>
                    <Breadcrumb style={{ margin: '16px 0' }}>
                        <Breadcrumb.Item>首页</Breadcrumb.Item>
                        <Breadcrumb.Item>Bill</Breadcrumb.Item>
                    </Breadcrumb>
                    <div className={styles['content-body']}>{props.children}</div>
                </Content>
                <Footer style={{ textAlign: 'center' }}>Ant Design ©2018 Created by Ant UED</Footer>
            </Layout>
        </Layout>
    );
}

export default connect(({ layout }) => ({ ...layout }))(BasicLayout);
