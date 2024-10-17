# ANALYTICALWAYS Code Challenge

## Introduction

Welcome to the ACME School project. This repository contains source code for the following projects:

- .NET Core Backend Service (WebApi)
- .NET Core Unit Tests (XUnit)

Current version use an in-memory sql database.

## How to Tests

There is a postman collection attached in the repo, that includes examples of use. 

The expected flow is:

- [POST] /Course
	This inserts a Course into the DB
- [POST] /Student
	This inserts a Student into the DB
- [POST] /Enrollment/PaymentLink
	This return a payment Link so the user can pay using the selected payment processor (asumming that the payment processor is in charge of recieve the payment data)
- [POST] /Enrollment
	This insert and Enrollment into the DB, after validate that the paymentId is valid in the payment processor
- [GET] /Course/GetAllWithStudents
	Get the courses and his students

## Questions

### What things would you have liked to do but didn't do?

I would like implement some kind of authentication, and add auditory over database entities.

### What things did you do but you think could be improved or would be necessary to return to them if the project goes ahead

- A few more unit tests could be added on the repository layer
- Repository and paymentGateway are mock implementations, they need to be improve when definitions of database engine and payment processor are defined.
- /Enrollment/PaymentLink could be a GET insted of POST

### What third-party libraries have you used and why.

I have no used any third-party libraries, all has been resolved using .net native dependencies 

### How much time you have invested in doing the project and what things you have had to research and what things were new to you.

I invest arrond 10 to 12 development hours. I had to refresh how to implement entity framework using in-memory database, and how to do some of the unit tests.
Also it's the first time I write a project using Net 8, and I found that they get rid of Startup.cs, all that code lives now on Program.cs, injected services now are added to builder.Services collection.

