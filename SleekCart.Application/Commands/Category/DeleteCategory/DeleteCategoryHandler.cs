using e_commerse.Domain.Abstractions.Repositories;
using SleekCart.Application.Abstractions.Commands;
using SleekCart.Application.Exceptions;
using SleekCart.Domain.Abstractions.Repositories;

namespace SleekCart.Application.Commands.Category.DeleteCategory;

public sealed class DeleteCategoryHandler: ICommandHandler<DeleteCategoryCommand>
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteCategoryHandler(ICategoryRepository categoryRepository, IUnitOfWork unitOfWork)
    {
        this._categoryRepository = categoryRepository;
        this._unitOfWork = unitOfWork;
    }

    public async Task HandleAsync(DeleteCategoryCommand command, CancellationToken ct)
    {
        var category = await _categoryRepository.GetAsync(command.CategoryId, ct);

        if(category is null)
        {
            throw new NotFoundCategoryException();
        }

        await _categoryRepository.DeleteAsync(category, ct);

        await _unitOfWork.SaveChangesAsync(ct);
    }
}
