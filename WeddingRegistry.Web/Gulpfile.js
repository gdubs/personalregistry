"use strict";
var sass = require("gulp-sass"),
    gulp = require("gulp"),
    rimraf = require("rimraf"),
  concat = require("gulp-concat"),
  cssmin = require("gulp-cssmin"),
  uglify = require("gulp-uglify");

var paths = {
    webroot: "./Content/assets/sass/"
}
//paths.scss = paths.webroot + "css/**/*.scss";
paths.scss = paths.webroot + "*.scss";
paths.scssColors = paths.webroot + "material-kit/_colors.scss";
gulp.task('sass', function () {
    gulp.src(paths.scss)
      .pipe(sass())
      .pipe(gulp.dest(paths.webroot + "css"));
});
gulp.task('watch-sass', function () {
    gulp.watch(paths.scss, ['sass']);
})
gulp.task('watch-sass-colors', function () {
    gulp.watch(paths.scssColors, ['sass']);
})
gulp.task('test', function () {
    gulp.watch(paths.scss + 'test.scss', ['sass']);
})