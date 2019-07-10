import styles from './header.css';

import PropTypes from 'prop-types';

import { connect } from 'dva';

import React, { PureComponent, Fragment } from 'react';
import { Menu, Dropdown, Icon, message, Avatar } from 'antd';

class Header extends PureComponent {
    constructor(props) {
        super(props);
        console.log(props);
    }

    handleLogout = () => {
        var { onLogout } = this.props;
        if (onLogout) onLogout();
    };

    render() {
        const { login } = this.props;

        const handleChangePassword = () => {
            message.info('待实现');
        };

        const userMenu = (
            <Menu>
                <Menu.Item onClick={() => handleChangePassword()}>
                    <Icon type="tool" />
                    修改密码
                </Menu.Item>
                <Menu.Divider />
                <Menu.Item onClick={() => this.handleLogout()}>
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
                            <Avatar icon="user" size="small" /> {login.userName}{' '}
                            <Icon type="down" />
                        </a>
                    </Dropdown>
                </div>
            </div>
        );
    }
}

Header.propTypes = {
    login: PropTypes.object,
};

export default Header;
