Visual Studio 2019
	ASP .NET Core Web Application
		ASP .NET Core 3.1
			API

Add Packages
	-Microsoft.EntityFrameworkCore
		-Needed to use the following packages
		-DbContext
	-Microsoft.EntityFrameworkCore.InMemory
		-Allow the usage of In-Memory database (testing purposes)
	-Microsoft.EntityFrameworkCore.Relational
		-Allow database relations
	-AutoMapper
		-Used to convert Service and Mapping
	-AutoMapper.Extensions.Microsoft.DependencyInjection
		-Allow the convertion of object between two differents classes
	-Swashbuckle.AspNetCore
	-Swashbuckle.AspNetCore.Annotations
	-Microsoft.OpenApi

Create folders:
	-Domain
		-Models
		-Persistence
			-Contexts
		-Repositories
		-Services
			-Communications
	-Extensions
	-Mapping
	-Persistence
		-Repositories
	-Resource
	-Service

Domain:
	Models:
		-Contains 
		

Controller -> API Controller with read/write actions