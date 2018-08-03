const path = require('path');
const webpack = require('webpack');
const MiniCssExtractPlugin = require('mini-css-extract-plugin');
const ExtractTextPlugin = require('extract-text-webpack-plugin');

module.exports = (env = {}, argv = {}) => {

    const isProd = argv.mode === 'production';

    const config = {
        mode: argv.mode || 'development', // we default to development when no 'mode' arg is passed
        entry: {
            'main': './ClientApp/app.tsx'
        },
        output: {
            filename: '[name].js',
            path: path.resolve(__dirname, 'wwwroot/dist'),
            publicPath: "/dist/"
        },
        resolve: {
            // Add `.ts` and `.tsx` as a resolvable extension.
            extensions: [".ts", ".tsx", ".js"]
        },
        plugins: [
            new MiniCssExtractPlugin({
                filename: 'styles.css'
            }),
            new webpack.ProvidePlugin({
                $: 'jquery',
                jQuery: 'jquery',
                'windows.jQuery': 'jquery',
            }),
        ],
        module: {
            rules: [{
                    test: /\.css$/,
                    use: [isProd ? MiniCssExtractPlugin.loader : 'style-loader', 'css-loader']
                },
                {
                    test: /\.scss$/,
                    use: isProd ? ExtractTextPlugin.extract({
                        fallback: 'style-loader',
                        use: ['css-loader', 'sass-loader']
                    }) : ['style-loader',
                        {
                            loader: 'css-loader',
                            options: {
                                sourceMap: true,
                            },
                        },
                        {
                            loader: 'sass-loader',
                            options: {
                                sourceMap: true,
                            },
                        }
                    ]
                },
                {
                    test: /\.tsx?$/,
                    use: 'awesome-typescript-loader',
                    exclude: /node_modules/
                }
            ]
        }
    }

    if (!isProd) {
        config.devtool = 'eval-source-map';
    }

    return config;
};