using System.IO;
using System.Threading.Tasks;
using Domain.Interfaces;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using API.Dtos;
using AutoMapper;
using Domain.Entities;
using Application.Repository;

namespace API.Controllers;

public class PersonController : BaseApiController
{
    public PersonController(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
    {
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<List<PersonDto>> Get()
    {
        var registros = await _unitOfWork.Persons.GetAll();
        return _mapper.Map<List<PersonDto>>(registros);
    }

    [HttpGet("Reporte")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<List<Person>> GetGenerarPdfPersonc()
    {
        string Path = "d:/Usuario/Downloads/reporte.pdf";


            using var writer = new PdfWriter(Path);
            using var pdf = new PdfDocument(writer);
            var document = new Document(pdf);

            // Añade el título al documento
            document.Add(new Paragraph("Reporte de personas").SetFontSize(14));

            // Crea la tabla y agrega las celdas de encabezado
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
                // Agrega las celdas de datos a la tabla
                cell = new Cell().Add(new Paragraph(persona.Id.ToString()));
                table.AddCell(cell);
                cell = new Cell().Add(new Paragraph(persona.Name));
                table.AddCell(cell);
                cell = new Cell().Add(new Paragraph(persona.LastName));
                table.AddCell(cell);
            }

            // Agrega la tabla al documento
            document.Add(table);
            return listaDePersonas;
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<PersonDto> GetById(int id)
    {
        var registro = await _unitOfWork.Persons.GetById(id);
        return _mapper.Map<PersonDto>(registro);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<PersonDto>> Post(PersonDto data)
    {
        if(data == null) return BadRequest();
        var registro = _mapper.Map<Person>(data);
        _unitOfWork.Persons.Add(registro);
        await _unitOfWork.SaveAsync();
        return CreatedAtAction(nameof(Post), new {id = registro.Id}, registro);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<PersonDto>> Put(int id, [FromBody] PersonDto updateData)
    {
        if(updateData == null) return NotFound();
        var registro = _mapper.Map<Person>(updateData);
        registro.Id = id;
        _unitOfWork.Persons.Update(registro);
        await _unitOfWork.SaveAsync();
        return updateData;
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> Delete(int id)
    {
        var registro = await _unitOfWork.Persons.GetById(id);
        if(registro == null) return NotFound();
        _unitOfWork.Persons.Remove(registro);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }

    // [HttpGet("pager")]
    // [ProducesResponseType(StatusCodes.Status200OK)]
    // [ProducesResponseType(StatusCodes.Status400BadRequest)]
    // public async Task<ActionResult<Pager<PersonxEmpleadoDto>>> GetWhithPage([FromQuery] Params personParams)
    // {
    //     var (totalRegistros, registros) = await _unitOfWork.Persons.GetAllAsync
    //     (
    //         personParams.PageIndex,
    //         personParams.PageSize,
    //         personParams.Search
    //     );
    //     var lstperson = _mapper.Map<List<PersonxEmpleadoDto>>(registros);
    //     return new Pager<PersonxEmpleadoDto>
    //     (
    //         lstperson,
    //         personParams.Search,
    //         totalRegistros,
    //         personParams.PageIndex,
    //         personParams.PageSize
    //     );
    // }
}   
