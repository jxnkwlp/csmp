import { PureComponent, Fragment } from 'react';

import styles from './index.less';
import router from 'umi/router';

import AppHeader from './header';
import AppSilder from './silder';

import { Layout, Menu, Breadcrumb, Icon } from 'antd';
import { connect } from 'dva';

const { Header, Content, Footer, Sider } = Layout;
const { SubMenu } = Menu;

class PrimaryLayout extends PureComponent {
    componentDidMount() {}

    render() {
        const siderProps = {
            collapsed: false,
        };

        const headerProps = {
            login: {
                userName: 'youname',
            },
        };

        return (
            <Layout style={{ minHeight: '100vh' }}>
                <AppSilder {...siderProps} />
                <Layout>
                    <Header className={styles.header}>
                        <AppHeader {...headerProps} />
                    </Header>
                    <Content style={{ margin: '0 16px' }}>
                        <Breadcrumb style={{ margin: '16px 0' }}>
                            <Breadcrumb.Item>首页</Breadcrumb.Item>
                            <Breadcrumb.Item>Bill</Breadcrumb.Item>
                        </Breadcrumb>
                        <div className={styles['content-body']}>{this.props.children}</div>
                    </Content>
                    <Footer style={{ textAlign: 'center' }}>
                        Ant Design ©2018 Created by Ant UED
                    </Footer>
                </Layout>
            </Layout>
        );
    }
}

export default PrimaryLayout;
