using e_commerse.Domain.Abstractions.Repositories;
using SleekCart.Application.Abstractions.Commands;
using SleekCart.Application.Exceptions;
using SleekCart.Application.Services;
using SleekCart.Domain.Abstractions.Factories;
using SleekCart.Domain.Abstractions.Repositories;

namespace SleekCart.Application.Commands.Category.CreateCategory;

public sealed class CreateCategoryHandler: ICommandHandler<CreateCategoryCommand>
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly ICategoryReadService _categoryReadService;
    private readonly ICategoryFactory _categoryFactory;

    public CreateCategoryHandler(ICategoryRepository  categoryRepository, IUnitOfWork unitOfWork,
                            ICategoryReadService categoryReadService, ICategoryFactory categoryFactory)
    {
        this._categoryRepository = categoryRepository;
        this._unitOfWork = unitOfWork;
        this._categoryReadService = categoryReadService;
        this._categoryFactory = categoryFactory;
    }

    public async Task HandleAsync(CreateCategoryCommand command, CancellationToken ct)
    {
        if(await _categoryReadService.IsExistAsync(command.CategoryName, ct))
        {
            throw new AlreadyExistCategoryException(command.CategoryName);
        }

        var newCategory = _categoryFactory.Create(command.CategoryName);

        await _categoryRepository.InsertAsync(newCategory, ct);
        
        await _unitOfWork.SaveChangesAsync(ct);
    }
}
