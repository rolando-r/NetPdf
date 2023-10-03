# NetPDf

🚀 **Welcome to this practice guide for developing a Web API using the recommended folder structure!** In this guide, we will explore how to organize and build a Web API application using the `Api`, `Application`, `Persistence`, and `Domain` folders.

## 🎯 Objective

Generate detailed PDF reports on individuals stored in the database, leveraging the UnitOfWork pattern and iTextSharp. The API provides structured access to the list of individuals.

## 🎮 Controller
```csharp
    [HttpGet("Reporte")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<List<Person>> GetGenerarPdfPersonc()
    {
        string Path = "d:/Usuario/Downloads/reporte.pdf";


            using var writer = new PdfWriter(Path);
            using var pdf = new PdfDocument(writer);
            var document = new Document(pdf);

            document.Add(new Paragraph("Reporte de personas").SetFontSize(14));

            Table table = new Table(3).UseAllAvailableWidth();
            Cell cell = new Cell().Add(new Paragraph("Id"));
            table.AddCell(cell);
            cell = new Cell().Add(new Paragraph("Name"));
            table.AddCell(cell);
            cell = new Cell().Add(new Paragraph("Last Name"));
            table.AddCell(cell);

            var tarea = _unitOfWork.Persons.GetAll();

            IEnumerable<Person> personas = await tarea;

            List<Person> listaDePersonas = personas.ToList();

            foreach (var persona in personas)
            {
                cell = new Cell().Add(new Paragraph(persona.Id.ToString()));
                table.AddCell(cell);
                cell = new Cell().Add(new Paragraph(persona.Name));
                table.AddCell(cell);
                cell = new Cell().Add(new Paragraph(persona.LastName));
                table.AddCell(cell);
            }

            document.Add(table);
            return listaDePersonas;
    }
```

  ### HTTP Get Method

  ```csharp
  [HttpGet("Reporte")]
  [ProducesResponseType(StatusCodes.Status200OK)] // Atributos que responden las peticiones HTTP 
  [ProducesResponseType(StatusCodes.Status400BadRequest)]
  public async Task<List<Person>> GetGenerarPdfPersonc() // Un método asincrónico que devuelve la lista de objetos tipo "Person"
  {
```
  ### Define the Specific Path of the PDF File

  ```csharp
  string Path = "d:/User/Downloads/report.pdf";
```
  ### Write to a PDF File at the Specified Path

  ```csharp
  using var writer = new PdfWriter(Path);
```
  ### Create a New PDF Document Using Itext7

  ```csharp
  using var pdf = new PdfDocument(writer);
```
  ### Create a "Document" Object Representing the PDF Document

  ```csharp
  var document = new Document(pdf);
```
  ### Add a Title to the PDF

  ```csharp
  document.Add(new Paragraph("People Report").SetFontSize(14));
```
  ### Create a Table with 3 Columns

  ```csharp
  Table table = new Table(3).UseAllAvailableWidth();
```
  ### Add Header Cells to the Table

  ```csharp
    Cell cell = new Cell().Add(new Paragraph("Id"));
    table.AddCell(cell);
    cell = new Cell().Add(new Paragraph("Name"));
    table.AddCell(cell);
    cell = new Cell().Add(new Paragraph("Last Name"));
    table.AddCell(cell);e la lista de objetos tipo "Person"
```
  ### Get All People from the Database

  ```csharp
  var task = _unitOfWork.Persons.GetAll();
```
  ### Wait for the Completion of the Asynchronous Task

  ```csharp
  IEnumerable<Person> people = await task;
```
  ### Convert the 'people' Collection to a List

  ```csharp
  List<Person> listOfPeople = people.ToList();
```
  ### Iterate Over Each Person Object in the 'people' Collection

  ```csharp
  foreach (var person in people)
    {
```
  ### Add Data Cells to the Table

  ```csharp
  cell = new Cell().Add(new Paragraph(person.Id.ToString()));
        table.AddCell(cell);
        cell = new Cell().Add(new Paragraph(person.Name));
        table.AddCell(cell);
        cell = new Cell().Add(new Paragraph(person.LastName));
        table.AddCell(cell);
    }
```
  ### Add the Table to the Document

  ```csharp
  document.Add(table);
```
  ### Return the List of People

  ```csharp
  return listOfPeople;
```



## 📂 Folder Structure

- **Api:** This folder contains your Web API entry point, controllers, and routing configurations.

- **Aplicacion:** This is where the application logic resides. Application services, DTO mappings, validations, and other application layer components are located in this folder.

- **Persistencia:** In this folder you will find the persistence layer, where you will define your database contexts, repositories and migration configurations.

- **Dominio:** Here you define the fundamental business entities and rules for your application.

## 🛠 Skills

C#, .NETCore, Refresh Token

## 📖 How to Use This Guide
1. Clone the repository.
2. Open it on your machine and navigate to the "Person" controller within the "API" folder.
3. Run "dotnet run" within the "API" folder to start the service.
4. Access Swagger and retrieve the PDF using the GET method for "Reporte."
5. Open the downloaded file.

## 📚 Additional Resources

- [iText 7 Documentation](https://itextpdf.com/en/how-to)
- [Official ASP.NET Core Documentation](https://docs.microsoft.com/aspnet/core)
- [Entity Framework Core Documentation](https://docs.microsoft.com/ef/core)
- [Architectural Patterns for .NET Applications](https://docs.microsoft.com/dotnet/architecture/)
- [Best Practices Guide for ASP.NET Core](https://dotnet.microsoft.com/learn/web/aspnet-best-practices)
- [ASP.NET Core Web API Development Tutorial](https://docs.microsoft.com/aspnet/core/tutorials/first-web-api)

## ✍️ Authors

- [@rolando-r](https://www.github.com/rolando-r)

## 🆘 Support

For support, email roolandoor@gmail.com or join our Slack channel.

## 🔗 Links
[![linkedin](https://img.shields.io/badge/linkedin-0A66C2?style=for-the-badge&logo=linkedin&logoColor=white)](https://www.linkedin.com/in/rolando-rodriguez-garcia)
