# Project


## Backend
Se implementó autenticación y autorización en Backend:



<img align="center" src="https://github.com/GregHowe/Library-Backend-UnitTest/blob/master/LibraryBackend/Images/Credentials.png" height="300" />            

Se requiere el token generado para las acciones configuradas

<img align="center" src="https://github.com/GregHowe/Library-Backend-UnitTest/blob/master/LibraryBackend/Images/Permission-JsonWebTokens.JPG?raw=true" height="500" />              

Se usó JsonWebTokens para generar el Token

<img align="center" src="https://github.com/GregHowe/Library-Backend-UnitTest/blob/master/LibraryBackend/Images/JsonWebTokens.JPG" height="400" />
   


## UnitTesting: Se uso Moq nuget Package para realizar las pruebas

### Pruebas desarrolladas

1- GetBooks_ShouldReturnBook_WhenBooksExists
2- GetBooks_ShouldReturnNothing_WhenBooksDoesntExists
3- GetBookById_ShouldReturnBook_WhenBooksExists
4- GetBookById_ShouldReturnNothing_WhenBooksDoesNotExists
5- PostBook_ShouldReturnBook_WhenBookIsInserted
6- DeleteLibrary_ShouldReturnDoesnExist_WhenSendIdBookThatDoesnExist
7- PostBook_ThrowException_WhenNameBookAlreadyExist



