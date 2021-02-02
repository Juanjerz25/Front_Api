# CHALLENGE - CODING DOJO APPLICATION - CSHARP #

## Resumen del Desarrollo Propuesto ##
El reto fue desarrollado en dos etapas:
	1 - Implementación de una WebApi: Se desarrolló en ASP.NET FrammeWork, donde se utilizó un programación por capas que constaba del COntrolador, Servicios y Acceso a datos, donde se implementaron todos los métodos a utilizar para el reto, donde la base de datos se modeló con 
	entity Frammework
	2 - Implementación del Front: El front se desarrolló también en la misma arquitectura del web api con la aplicación MVC, y consume los servicios implementados del WebApi.
La base de datos se diseñó e implementó en SQL Server, hice algunas modificaciones al modelo propuesto en el reto el cual se puede ver en el Diagrama de la base de datos que fue generado con dicho servidor (El archivo se encuentra dentro del repositorio).

Como dije anteriormente hay 2 etapas, las cuales se encuentran dentro del mismo proyecto, por tal motivo hay que ejecutar  por aparte el DojoApplicationApi y DojoApplicationWeb
DojoAaplicationApi :   https://localhost:44358/
DojoApplicationWeb :   https://localhost:44322/