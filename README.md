# ASP.NET (C#) API with MySQL

I started this project to tackle a few things...

1. How to build an ASP.NET API / REST Service with C#
2. How to connect an ASP.NET API to my local MySQL database
3. How to perform dynamic query mapping*


\* What I mean by dynamic query mapping: An issue I've commonly encountered at work was finding a lot of query mapping functions all over the DAO layer. For every table object, there was a data access layer. And within each data access layer, there was a query mapper specifically for that table object. I found the process to be a tad redundant. I figured there had to be a way to pass in the SQL string and the object type in order to dynamically map the results by iterating through the list of the properties of the object type. By making the query mapping more generic, there is less chance of error and less code to be written on the rest of the project.    

##### Future Solutions
- Column names should not have to strictly match property names of the table object
- There needs to be an  enumeration referencing table names (ex.: ```api/values/1``` = Get all values referencing table 1)
- Where clause (ex.: POST REQUEST: ```api/values/1``` BODY: ```{ sql: string }```

