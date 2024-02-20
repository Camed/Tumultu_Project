using MediatR;
using Microsoft.AspNetCore.Mvc;
using Tumultu.Application.AnalysisResults.Commands;
using Tumultu.Application.Files.Commands;
using Tumultu.Application.Files.Queries;
using Tumultu.Application.FileVariants.Commands;
using Tumultu.Domain.Entities;

namespace Tumultu.Presentation.Controllers;

[ApiController]
[Route("[controller]")]
public class FilesController : ControllerBase
{
    private readonly ILogger<FilesController> _logger;
    private readonly IMediator _mediator;

    public FilesController(ILogger<FilesController> logger, IMediator mediator)
    {
        _logger = logger;
        _mediator = mediator;
    }

    [HttpGet(Name = "GetFiles")]
    public Task<IEnumerable<FileEntity>> GetFiles()
    {
        return _mediator.Send(new GetFilesQuery());
    }

    [HttpPost(Name = "CreateFile")]
    public async Task<Guid> AddFile(CreateFileCommand command)
    {
        var newFile = await _mediator.Send(command);
        return newFile!.Id;
        
    }
}