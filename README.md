# PostCodeLookup with Registraion and Login using JWT (JSON Web Token) token
The front end of this application was build using Angular 10 and the backend using ASP.Net core WebAPI.

How to run the project:
========================
1. Open PostCodeLookup solution in Visual Studio Community 2019 edition.
2. PostCodeLookupAPI project in PostCodeLookup solution should be loaded.
3. PostCodeLookupUI project within this solution will not necessarily load in visual studio. This is Angular application.
4. Update ConnectionString in appSettings.json file for the key 'WebApiDBConnection' if required.
5. This is the Code first SQL DB, so please run the migrations.
6. To run the migrations, open Package Manager Console (View => Other Windows => Package Manager Console from top menu) and execute the following commands Add-Migration and supply the name 'Initial Migration'. Then run the command <Update-Database>
7. Run Visual Studio using IIS Express for the WebAPI to start processing the incoming HTTP requests. The application will be running at http://localhost:58981 (refer launchSettings.json if necessary). The Angular APP (detailed below) should be pointed to thsi WebAPI URL in environment.prod.ts file (located at src => environments => environment.prod.ts)
8. Using Visual Studio Code, open the folder/project with the name PostcodeLookupUI.
9. Click on Terminal => New Terminal from the top menu.
10. In the terminal, execute the command 'npm start' and this will fire the Angular app.
11. Click on the Register button to register a new user or simply login for an existing user.
12. On registering a user, WebAPI will pass a JWT token to the Angular App for making further requests to the API using the token. This token is valid for 1 day. At the moment the token validity is harcoded in the code but can be moved to appSettings.json.
13. On login, user can view all other users (if available) and manage the users. This can be extended to use role based operations.
14. From the top menu, click on 'Delivery' and enter the postcode in the textbox and click 'Find' button. This should bring up the expected results. 
