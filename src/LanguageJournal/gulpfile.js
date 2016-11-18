"use strict";

var gulp = require("gulp"),
    ts = require("gulp-typescript"),
    sass = require("gulp-sass"),
    concat = require("gulp-concat"),
    sourcemaps = require("gulp-sourcemaps"),
    uglify = require("gulp-uglify"),
    plumber = require("gulp-plumber");

gulp.task("sass", () => {
    return gulp.src("Client/**/*.scss")
        .pipe(plumber())
        .pipe(sass())
        .pipe(gulp.dest("wwwroot"));
});

gulp.task("vendorJs", () => {
    return gulp.src([
        "bower_components/jquery/dist/jquery.js",
        "bower_components/tether/dist/js/tether.js",
        "bower_components/bootstrap/dist/js/bootstrap.js"
    ])
        .pipe(plumber())
        .pipe(sourcemaps.init())
        .pipe(concat("vendor.js"))
        .pipe(uglify())
        .pipe(sourcemaps.write("."))
        .pipe(gulp.dest("wwwroot"));
});

gulp.task("tsc", () => {
    let tsProject = ts.createProject("tsconfig.json");

    let tsResult = gulp.src("Client/**/*.ts")
        .pipe(plumber())
        .pipe(sourcemaps.init())
        .pipe(tsProject());

    return tsResult.js
        .pipe(concat("app.js"))
        .pipe(uglify())
        .pipe(sourcemaps.write("."))
        .pipe(gulp.dest("wwwroot"));
});

gulp.task("build", ["vendorJs", "sass", "tsc"]);

gulp.task('default', () => {
    // place code for your default task here
});