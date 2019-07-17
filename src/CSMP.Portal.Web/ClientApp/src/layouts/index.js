import PrimaryLayout from './PrimaryLayout';
import PublicLayout from './PublicLayout';

import { PureComponent } from 'react';

const menus = () => {
    return [
        {
            key: '',
            title: '',
        },
    ];
};

class Layout extends PureComponent {
    //   handleMenuCollapse = payload =>
    //     dispatch &&
    //     dispatch({
    //         type: 'layout/changeCollapsed',
    //         payload,
    //     });
    //   handleMenuClick = ({ item, key, keyPath, domEvent }) => {
    //     // console.log(key, keyPath);
    //     if (key === 'dashboard') {
    //         router.push('/home');
    //     } else {
    //         router.push(`/${keyPath.reverse().join('/')}`);
    //     }
    // };

    render() {
        // console.log(this.props);
        if (this.props.location.pathname == '/login') {
            return <PublicLayout>{this.props.children}</PublicLayout>;
        } else {
            return <PrimaryLayout>{this.props.children}</PrimaryLayout>;
        }
    }
}

export default Layout;
