# MVC5-API2-Without-Entity-Framework
insert, Update and Delete Records in ASP.NET MVC 5 without using heavy entity framework.  you will be able to write your own customize code in MVC 5. If you are beginners or trying to learn MVC. it will be so good start code for you. I am going to create a simple student registration form in MVC5 using CRUD (Create, Read, Update and Delete) Operation.  


 

## Installation 


* 1- Run SQL Server and you  can restore database name it NormalAPI.bak it is working on SQL 2014 or above. 
* 2- Run Visual Studio 2017.
* 3- Open Web.config file and replace the connection strings name it DefaultConnection with your  sqlserver user with my sa and password with my password.
* 4- run project by  Ctrl + F5 
* 5- if you have postman  chrome extensions or any same program you can start to put the api url and get and post and update and delete requests. 
*   example:
*     GET :
*    1- http://localhost:64721/api/student/ To get all students
*	 2- http://localhost:64721/api/student/1  to get one student
	 
*	  POST :
*	 1- http://localhost:64721/api/student/ to create student
*	 2- http://localhost:64721/api/student/3 to update student send your student with the id want change it and put the same id in url

*     Delete
*    1- http://localhost:64721/api/student/1 put your id you want delete it 
	 
	 

	






  