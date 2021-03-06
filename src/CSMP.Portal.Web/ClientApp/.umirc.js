// ref: https://umijs.org/config/
export default {
    treeShaking: true,
    plugins: [
        // ref: https://umijs.org/plugin/umi-plugin-react.html
        [
            'umi-plugin-react',
            {
                title: 'Portal Web',
                antd: true,
                dva: { immer: true },
                dynamicImport: false,
                dll: false,

                routes: {
                    exclude: [
                        /models\//,
                        /services\//,
                        /model\.(t|j)sx?$/,
                        /service\.(t|j)sx?$/,
                        /components\//,
                    ],
                },
            },
        ],
    ],

    devServer: {
        // proxy: {
        //     '/api': 'https://localhost:44334/',
        // },
    },
};
