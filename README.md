# Language Journal

## Overview

This is a demo of ASP.NET Core with Angular 2. The final product would be a web application where users can make journal entries in a foreign language to be reviewed by friends and other members of the community that are fluent in that language.

Overall, I found it pretty easy to get up and running with ASP.NET Core. [The documentation](https://docs.microsoft.com/en-us/aspnet/core/) is pretty thorough and easy to read. Visual Studio can be a bit sluggish, but it seems to run fine on Ubuntu from the command line.

Angular 2 is a bit challenging. The [getting started tutorial](https://angular.io/docs/ts/latest/guide/) is fine, but in general it's a lot of setup with a lot of dependencies. It may be more trouble than it's worth, but we do have some highly interactive applications and features that may be difficult to maintain without the organization provided by a frontend framework. Some specific concerns I have are:

* Frontend routing - allowing users to bookmark the right location when a partial page request has completed.
* In-Place editing and other complex interactivity on forms.

I would like to continue using TypeScript even if we decide to give up on Angular. It has a lot of benefits and implements ES6 features that are not yet supported in many browsers.

## Backend

### C#/ASP.NET Core

The backend is built with ASP.NET Core 1.1, using packages that support both Windows and Ubuntu.

* To install .NET Core [follow the instructions here](https://www.microsoft.com/net/core#linuxubuntu) for the desired system.
* This project was built on Windows using a template from Visual Studio 2015, but you can also use a [yeoman generator](https://github.com/OmniSharp/generator-aspnet) if you have NodeJS installed on another operating system.
* This project uses the backend as an API and a host for static files(JS and CSS). None of the ASP.NET view helpers are used.

### Database

* The database is PostgreSQL, accessed via the [Npgsql package](http://www.npgsql.org/doc/index.html) for Entity Framework. [Entity Framework](https://docs.microsoft.com/en-us/ef/) serves as the ORM.
* The connection string is hard coded into the `appsettings.json` file, but the more secure alternative would be to use the [Secret Manager](https://docs.microsoft.com/en-us/aspnet/core/security/app-secrets).
* This project uses **Code-First** migrations, which means you write code for your models, using annotations or the fluent syntax in the DbContext(`Services/PostgresDbContext.cs`) to define relationships and field properties. 

### Token Authentication

The rudamentary token authentication scheme I have set up is to simply test a mechanism for API authentication. It seems to work OK, but there are many security issues that will need consideration.

* Passwords should be hashed.
* Tokens should be encrypted.
* Tokens should probably follow the [JWT](https://tools.ietf.org/html/rfc7519) standard.
* There might be a way to wrap all this in with Microsoft's Identity package, which will give us some additional functionality and helpers.

## Frontend

### Angular 2

[Angular 2](https://angular.io/) is a complete rewrite of the AngularJS framework. Though functionally similar, it requires a completely different workflow than the original framework.

* Built in [TypeScript](https://www.typescriptlang.org/), it offers some additional functionality and development tools if you use TypeScript in your own project, but this is not required.
* The sample applications and tutorials I've gone through depend on [SystemJS](https://github.com/systemjs/systemjs) a JavaScript module loader configured in the `systemjs.config.js` file and initialized in the HTML view (`Views/Home/Index.cshtml`).

### TypeScript

As recommended by the Angular team and Microsoft, this project uses TypeScript as a precompiler for the frontend JavaScript.

* Because of it's type checking support, TypeScript requires a bit of additional setup, compared to other JavaScript precompilers.
* Loading 3rd party type definition files used to be done with an additional package manager, [Typings](https://github.com/typings/typings). Recently, the npm repository [@types](https://blogs.msdn.microsoft.com/typescript/2016/06/15/the-future-of-declaration-files/) has been recommended as the standard.
* I haven't found a good way to work with Visual Studio's TypeScript compiler, so I turn it off with a project setting: `<TypeScriptCompileBlocked>true</TypeScriptCompileBlocked>` in `LanguageJournal.xproj`.
* Even with its compiler turned off, Visual Studio does provide some helpful code completion and syntax checking tools.

### Gulp

[Gulp](http://gulpjs.com/) is one of several popular JavaScript build tools. I have been working with it for a while and it seems to have the largest community for plugins. I use Gulp tasks to:

* Move `node_modules` files into the static file serving directory.
* Compile TypeScript
* Compile CSS
* Compile HTML templates from Pug

When the default task is run, it will watch for file changes in the specified directories.

### Pug

Formerly [Jade](https://www.npmjs.com/package/jade), Pug is like HAML/Slim for JavaScript.
