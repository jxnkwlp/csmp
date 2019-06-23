import { Tabs } from 'antd';

export default function() {
    return (
        <div>
            <Tabs defaultActiveKey="1">
                <Tabs.TabPane tab="基本信息" key="1">
                    Content of Tab Pane 1
                </Tabs.TabPane>
                <Tabs.TabPane tab="监控" key="2">
                    Content of Tab Pane 2
                </Tabs.TabPane>
            </Tabs>
        </div>
    );
}
