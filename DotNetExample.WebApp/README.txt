Required Step: Install package.json file
	Open CMD and redirect to your application folder and Using npm from the command line, install the packages listed in package.json with the command:

	> npm install --save --save-dev

	wait for the installation to complete
	
Project Structure:
 
1. Folder name “App” in Scripts folder

2. Application module file (App/app.module.ts)
	Angular itself is split into separate Angular Modules. This makes it possible for you to keep payload size small by only importing the parts of Angular that your application needs.Every Angular application has at least one module: the root module, named AppModule here.

3. Component & add it to your application (App/app.component.ts)
	Every Angular application has at least one component: the root component, named AppComponent here.Components are the basic building blocks of Angular applications. A component controls a portion of the screen—a view—through its associated template.

4. Start up file (App/main.ts)
	Now we need to tell Angular to start up your application.

5. Index.cshtml in View Folders contain angular 2 directive 
	<my-app>Loading...</my-app>

6. _Layout.cshtml contain angular2 script reference and system.js startup configuration
	<script src="../../node_modules/core-js/client/shim.min.js"></script>
    <script src="../../node_modules/zone.js/dist/zone.js"></script>
    <script src="../../node_modules/reflect-metadata/Reflect.js"></script>
    <script src="../../node_modules/systemjs/dist/system.src.js"></script>

    <!-- 2. Configure SystemJS -->
    <script src="../../systemjs.config.js"></script>
    <script>
        System.import('../../Scripts/App/main').catch(function (err) {
            console.error(err);
        });
    </script>
