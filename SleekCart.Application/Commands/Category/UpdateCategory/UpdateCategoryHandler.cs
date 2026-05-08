using e_commerse.Domain.Abstractions.Repositories;
using SleekCart.Application.Abstractions.Commands;
using SleekCart.Application.Exceptions;
using SleekCart.Application.Services;
using SleekCart.Domain.Abstractions.Repositories;
using SleekCart.Domain.ValueObjects.Category;

namespace SleekCart.Application.Commands.Category.UpdateCategory;

public sealed class UpdateCategoryHandler: ICommandHandler<UpdateCategoryCommand>
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly ICategoryReadService _categoryReadService;

    public UpdateCategoryHandler(ICategoryRepository categoryRepository, IUnitOfWork unitOfWork,
                                ICategoryReadService categoryReadService)
    {
        this._categoryRepository = categoryRepository;
        this._unitOfWork = unitOfWork;
        this._categoryReadService = categoryReadService;
    }

    public async Task HandleAsync(UpdateCategoryCommand command, CancellationToken ct)
    {
        if(await _categoryReadService.IsExistAsync(command.NewCategoryName, ct))
        {
            throw new AlreadyExistCategoryException(command.NewCategoryName);
        }

        var category = await _categoryRepository.GetAsync(command.CategoryId, ct);

        if(category is null)
        {
            throw new NotFoundCategoryException();
        }

        category.UpdateName(new CategoryName(command.NewCategoryName));

        await _categoryRepository.UpdateAsync(category, ct);
        
        await _unitOfWork.SaveChangesAsync(ct);
    }
}
