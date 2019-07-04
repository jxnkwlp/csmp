import styles from './index.less';

import { PureComponent, Fragment } from 'react';

import { Form, Icon, Input, Button, Checkbox } from 'antd';
const FormItem = Form.Item;

@Form.create()
class Login extends PureComponent {
    handleSubmit = e => {
        e.preventDefault();
        const { dispatch, form } = this.props;
        const { validateFieldsAndScroll } = form;
        validateFieldsAndScroll((errors, values) => {
            if (errors) {
                return;
            }
        });
        return;
    };

    render() {
        const { getFieldDecorator } = this.props.form;

        return (
            <div className={styles.loginForm}>
                <Form onSubmit={this.handleSubmit} className="login-form">
                    <Form.Item>
                        {getFieldDecorator('username', {
                            rules: [{ required: true, message: 'Please input your username!' }],
                        })(
                            <Input
                                prefix={<Icon type="user" style={{ color: 'rgba(0,0,0,.25)' }} />}
                                placeholder="Username"
                                maxLength={16}
                            />,
                        )}
                    </Form.Item>
                    <Form.Item>
                        {getFieldDecorator('password', {
                            rules: [{ required: true, message: 'Please input your Password!' }],
                        })(
                            <Input
                                prefix={<Icon type="lock" style={{ color: 'rgba(0,0,0,.25)' }} />}
                                type="password"
                                placeholder="Password"
                                maxLength={16}
                            />,
                        )}
                    </Form.Item>
                    <Form.Item>
                        <Button type="primary" htmlType="submit" className="login-form-button">
                            Log in
                        </Button>
                    </Form.Item>
                </Form>
            </div>
        );
    }
}

export default Login;
