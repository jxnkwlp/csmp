import styles from './index.less';

import { connect } from 'dva';

import { Menu, Dropdown, Icon, message, Avatar } from 'antd';

function HeaderLayout(props) {
    console.log(props);

    const handleChangePassword = () => {
        message.info('待实现');
    };
    const handleLogout = () => {
        message.info('待实现');
    };

    const userMenu = (
        <Menu>
            <Menu.Item onClick={() => handleChangePassword()}>
                <Icon type="tool" />
                修改密码
            </Menu.Item>
            <Menu.Divider />
            <Menu.Item onClick={() => handleLogout()}>
                <Icon type="logout" />
                退出
            </Menu.Item>
        </Menu>
    );

    return (
        <div className="clearfix">
            <div className={styles['header-user']}>
                <Dropdown overlay={userMenu}>
                    <a className="ant-dropdown-link" href="javascript:;">
                        <Avatar icon="user" size="small" /> {props.login.userName}{' '}
                        <Icon type="down" />
                    </a>
                </Dropdown>
            </div>
        </div>
    );
}

export default connect(({ layout }) => ({ ...layout }))(HeaderLayout);
