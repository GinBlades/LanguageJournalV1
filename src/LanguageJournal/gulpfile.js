var gulp = require("gulp"),
    concat = require("gulp-concat"),
    sourcemaps = require("gulp-sourcemaps");

gulp.task("copyNpm", () => {
    gulp.src(["node_modules/@angular/**/*"])
        .pipe(gulp.dest("wwwroot/@angular"))

    return gulp.src(["node_modules/rxjs/**/*"])
        .pipe(gulp.dest("wwwroot/rxjs"));
});

gulp.task('default', function () {
    // place code for your default task here
});