module.exports = {
  entry: './app.js',
  output: {
    filename: 'public/bundle.js'
  },
  devtool: "source-map",
  module: {
    rules: [{
      test: /\.js$/,
      exclude: /node_modules/,
      loader: "source-map-loader",
      enforce: "pre"
    }]
  }
}