using Ardalis.GuardClauses;
using MediatR;
using Tumultu.Application.Common.Interfaces;
using Tumultu.Domain.Entities;

namespace Tumultu.Application.Behaviours.Commands;

public record UpdateBehaviourCommand(int Id) : IRequest;

public class UpdateBehaviourCommandHandler : IRequestHandler<UpdateBehaviourCommand>
{
    private readonly IBehaviourReadRepository _readRepository;
    private readonly IWriteRepository<Behaviour, int> _writeRepository;

    public UpdateBehaviourCommandHandler(IBehaviourReadRepository readRepository, IWriteRepository<Behaviour, int> writeRepository)
    {
        _readRepository = readRepository;
        _writeRepository = writeRepository;
    }

    public async Task Handle(UpdateBehaviourCommand request, CancellationToken cancellationToken)
    {
        Behaviour? entity = await _readRepository.GetByIdAsync(request.Id);

        Guard.Against.NotFound(request.Id, entity);

        // change anything in entity

        _writeRepository.Update(entity);
        await _writeRepository.SaveChangesAsync(cancellationToken);
    }
}