# Project

### Ver Video Resumen:

[![Watch the video](https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTIgHAHff9apu1ZuaDfziL_os6AvslE1rtEkvzCW_ipJ2kuUtgObKo55zbBy7O8I34xKf8&usqp=CAU)](https://youtu.be/cyxVnyldStY)

## Backend
Se implementó autenticación y autorización en Backend:


<img align="center" src="https://github.com/GregHowe/Library-Backend-UnitTest/blob/master/LibraryBackend/Images/Credentials.png" height="300" />            

Se usó JsonWebTokens para generar el Token

<img align="center" src="https://github.com/GregHowe/Library-Backend-UnitTest/blob/master/LibraryBackend/Images/JsonWebTokens.JPG" height="400" />
   

Se requiere el token generado para las acciones configuradas

<img align="center" src="https://github.com/GregHowe/Library-Backend-UnitTest/blob/master/LibraryBackend/Images/Permission-JsonWebTokens.JPG?raw=true" height="500" />              

#### Se desacopló los objetos, entidades con interfaces, injeccion de dependencias, servicios. etc.

<img align="center" src="https://github.com/GregHowe/Library-Backend-UnitTest/blob/master/LibraryBackend/Images/Architecture.JPG" height="400" />


## UnitTesting: 
### Se usó Moq nuget Package para realizar las pruebas

### Pruebas desarrolladas

##### 1- GetBooks_ShouldReturnBook_WhenBooksExists 
##### 2- GetBooks_ShouldReturnNothing_WhenBooksDoesntExists
##### 3- GetBookById_ShouldReturnBook_WhenBooksExists
##### 4- GetBookById_ShouldReturnNothing_WhenBooksDoesNotExists
##### 5- PostBook_ShouldReturnBook_WhenBookIsInserted
##### 6- DeleteLibrary_ShouldReturnDoesnExist_WhenSendIdBookThatDoesnExist
##### 7- PostBook_ThrowException_WhenNameBookAlreadyExist



