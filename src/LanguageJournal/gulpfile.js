﻿"use strict";

var gulp = require("gulp"),
    ts = require("gulp-typescript"),
    sass = require("gulp-sass"),
    plumber = require("gulp-plumber"),
    watch = require("gulp-watch"),
    batch = require("gulp-batch"),
    pug = require("gulp-pug");

// This doesn't finish properly when the task claims to be finished.
// There is probably a way I need to modify this so that it works properly with streams.
gulp.task("copyNpm", ["systemSetup"], () => {
    ["@angular", "rxjs", "core-js", "zone.js", "reflect-metadata", "systemjs"].forEach((folder) => {
        gulp.src([`node_modules/${folder}/**/*`])
            .pipe(gulp.dest(`wwwroot/${folder}`));
    });
});

gulp.task("systemSetup", () => {
    return gulp.src(["Client/systemjs.config.js"])
        .pipe(gulp.dest("wwwroot"));
})

gulp.task("tsc", () => {
    let tsProject = ts.createProject("tsconfig.json");

    let tsResult = gulp.src("Client/**/*.ts")
        .pipe(plumber())
        .pipe(tsProject());

    return tsResult.js.pipe(gulp.dest("wwwroot"));
});

gulp.task("sass", () => {
    return gulp.src("Client/**/*.scss")
        .pipe(plumber())
        .pipe(sass())
        .pipe(gulp.dest("wwwroot"));
});

gulp.task("pug", () => {
    return gulp.src("Client/**/*.pug")
        .pipe(plumber())
        .pipe(pug({
            pretty: true
        }))
        .pipe(gulp.dest("wwwroot"));
})

gulp.task("build", ["copyNpm", "tsc", "sass", "pug"]);

gulp.task("watch", () => {
    watch("Client/**/*.ts", batch((events, done) => {
        gulp.start("tsc", done);
    }));
    watch("Client/**/*.scss", batch((events, done) => {
        gulp.start("sass", done);
    }));
    watch("Client/**/*.pug", batch((events, done) => {
        gulp.start("pug", done);
    }));
})

gulp.task('default', ["build", "watch"], () => {
    // place code for your default task here
});