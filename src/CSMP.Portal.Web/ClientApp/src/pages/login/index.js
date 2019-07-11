import styles from './index.less';

import { PureComponent, Fragment } from 'react';

import { connect } from 'dva';

import { Form, Icon, Input, Button, Checkbox, Card } from 'antd';
const FormItem = Form.Item;

@connect(({ loading }) => ({ loading }))
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

            dispatch({ type: 'login/login', payload: values });
        });
        return;
    };

    render() {
        const { getFieldDecorator } = this.props.form;

        return (
            <div className={styles.loginForm}>
                <Card title="LOGIN">
                    <Form onSubmit={this.handleSubmit} className="login-form">
                        <Form.Item>
                            {getFieldDecorator('username', {
                                rules: [{ required: true, message: 'Please input your username!' }],
                            })(
                                <Input
                                    prefix={
                                        <Icon type="user" style={{ color: 'rgba(0,0,0,.25)' }} />
                                    }
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
                                    prefix={
                                        <Icon type="lock" style={{ color: 'rgba(0,0,0,.25)' }} />
                                    }
                                    type="password"
                                    placeholder="Password"
                                    maxLength={16}
                                />,
                            )}
                        </Form.Item>
                        <div>
                            <Button type="primary" htmlType="submit" className="login-form-button">
                                Log in
                            </Button>
                        </div>
                    </Form>
                </Card>
            </div>
        );
    }
}

export default Login;
