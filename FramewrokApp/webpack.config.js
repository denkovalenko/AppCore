﻿var path = require('path');
var webpack = require('webpack');
var zone = require('zone.js');
var UglifyJSPlugin = require('uglifyjs-webpack-plugin'); // плагин минимизации
const MiniCssExtractPlugin = require("mini-css-extract-plugin");

module.exports = {
    entry: {
        'polyfills': './ClientApp/polyfills.ts',
        'app': './ClientApp/main.ts',
    },
    output: {
        path: path.resolve(__dirname, './wwwroot/dist'),     // путь к каталогу выходных файлов - папка public
        publicPath: '/dist/',
        filename: "[name].js"       // название создаваемого файла
    },
    resolve: {
        extensions: ['.ts', '.js']
    },
    module: {
        rules: [   //загрузчик для ts
            {
                test: /\.ts$/, // определяем тип файлов
                use: [
                    {
                        loader: 'awesome-typescript-loader',
                        options: { configFileName: path.resolve(__dirname, 'tsconfig.json') }
                    },
                    'angular2-template-loader'
                ]
            }, {
                test: /\.html$/,
                loader: 'html-loader'
            }, {
                test: /\.css$/,
                use: [
                    MiniCssExtractPlugin.loader,
                    "css-loader",
                ],
            },
            {
                test: /\.scss$/,
                use: [{
                    loader: "style-loader"
                }, {
                    loader: "css-loader"
                }, {
                    loader: "sass-loader",
                }]
            }
        ]
    },
    //optimization: {
    //    splitChunks: {
    //        cacheGroups: {
    //            styles: {
    //                name: 'styles',
    //                test: /\.css$/,
    //                chunks: 'all',
    //                enforce: true
    //            }
    //        }
    //    }
    //},
    plugins: [
        //new MiniCssExtractPlugin({
        //    filename: '[name].css',
        //}),
        new MiniCssExtractPlugin({
            // Options similar to the same options in webpackOptions.output
            // both options are optional
            filename: "[name].css",
            chunkFilename: "[id].css"
        }),
        new webpack.ContextReplacementPlugin(
            /angular(\\|\/)core/,
            path.resolve(__dirname, 'ClientApp'), // каталог с исходными файлами
            {} // карта маршрутов
        ),
        new UglifyJSPlugin()
    ]
}