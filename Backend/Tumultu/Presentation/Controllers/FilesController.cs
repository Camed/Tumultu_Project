using MediatR;
using Microsoft.AspNetCore.Mvc;
using Tumultu.Application.Files.Commands;
using Tumultu.Application.Files.Queries;
using Tumultu.Domain.Entities;

namespace Tumultu.Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
public class FilesController : ControllerBase
{
    private readonly ILogger<FilesController> _logger;
    private readonly IMediator _mediator;

    public FilesController(ILogger<FilesController> logger, IMediator mediator)
    {
        _logger = logger;
        _mediator = mediator;
    }

    [HttpGet]
    public Task<IEnumerable<FileEntity>> GetAll()
    {
        return _mediator.Send(new GetFilesQuery());
    }

    [HttpGet("{id:guid}")]
    public Task<FileEntity> GetById(Guid id)
    {
        return _mediator.Send(new GetFileByIdQuery(id));
    }

    [HttpPost]
    public Task<Guid> Upload(IFormFile file)
    {
        using var memoryStream = new MemoryStream();
        file.CopyTo(memoryStream);
        return _mediator.Send(new CreateFileCommand(file.FileName, memoryStream.ToArray()));
    }
}