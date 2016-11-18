var gulp = require("gulp"),
    sourcemaps = require("gulp-sourcemaps"),
    ts = require("gulp-typescript");

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
        .pipe(tsProject());

    return tsResult.js.pipe(gulp.dest("wwwroot"));
});

gulp.task("build", ["copyNpm", "tsc"]);

gulp.task('default', ["build"], () => {
    // place code for your default task here
});