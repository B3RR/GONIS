{
    const webpack = require('webpack');
    const path = require('path');
    const bundleFolder = "wwwroot/bundle/";
    // Plugin for clear folder 
    const cleanWebpackPlugin = require('clean-webpack-plugin');

    module.exports = {
        
        entry: { main: './App/Main.jsx' },
        output: {
            filename: '[name].js',
            path: path.resolve(__dirname, bundleFolder),
            publicPath: '/wwwroot/bundle/',
        },
        // Babel,CSS,URL-Loader
        module: {
            rules: [{
                test: /\.(js|jsx)$/,
                exclude: /node_modules/,
                loader: "babel-loader",
                query: {
                    presets: ['env', 'react'],
                    plugins: ['transform-object-rest-spread']
                }
            },
            { test: /\.css$/, loader: "style-loader!css-loader" },
            { test: /\.(png|woff|woff2|eot|svg|ttf)(\?|$)/, use: 'url-loader?limit=10000' },
            ]
        },
        plugins: [
            new cleanWebpackPlugin([bundleFolder]),
            new webpack.ProvidePlugin({
                React: 'react'
            }),
        ]

    };
}