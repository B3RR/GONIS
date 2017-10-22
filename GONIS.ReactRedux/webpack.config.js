﻿{
    // Need for output path
    let path = require('path');

    // Plugin for clear folder 
    const CleanWebpackPlugin = require('clean-webpack-plugin');
    const bundleFolder = "wwwroot/bundle/";

    module.exports = {
        
        entry: "./App/main.jsx",
        
        output: {
            filename: 'script.js',
            path: path.resolve(__dirname, bundleFolder),
            publicPath: path.resolve(__dirname, bundleFolder),
        },
        // Babel,CSS,URL-Loader
        module: {
            rules: [{
                test: /\.(js|jsx)$/,
                exclude: /node_modules/,
                loader: "babel-loader",
                query: {
                    presets: ['env', 'react']
                }
            },
            { test: /\.css$/, loader: "style-loader!css-loader" },
            { test: /\.(png|woff|woff2|eot|svg|ttf)(\?|$)/, use: 'url-loader?limit=10000' },
            ]
        },
        plugins: [
            new CleanWebpackPlugin([bundleFolder])
        ]
    };
}