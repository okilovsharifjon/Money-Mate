using AutoMapper;
using DataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class GoalService(
        GoalRepositoryProxy repositoryProxy,
        IMapper mapper,
        IValidator<GoalDto> validator,
        IValidator<GoalDtoUpdate> validatorUp) : IGoalService
    {
        private readonly GoalRepositoryProxy _goalRepository = repositoryProxy;
        private readonly IMapper _mapper = mapper;
        private readonly IValidator<GoalDto> _validator = validator;
        private readonly IValidator<GoalDtoUpdate> _validatorUpdate = validatorUp;

        public async Task<int> CreateAsync(GoalDto goalDto, CancellationToken token = default)
        {
            await _validator.ValidateAndThrowAsync(goalDto, token);
            Goal goal = _mapper.Map<Goal>(goalDto);
            int id = await _goalRepository.CreateAsync(goal, token);
            return id;

        }
        public async Task<GoalDto> GetByIdAsync(int id, CancellationToken token = default)
            => _mapper.Map<GoalDto>(await _goalRepository.GetByIdAsync(id, token));
        public async Task<GoalDtoUpdate> GetByIdAsyncForUpdate(int id, CancellationToken token = default)
            => _mapper.Map<GoalDtoUpdate>(await _goalRepository.GetByIdAsync(id, token));
        public async Task<GoalDto> GetByNameAsync(string name, CancellationToken token = default)
            => _mapper.Map<GoalDto>(await _goalRepository.GetByNameAsync(name, token));
        public async Task UpdateAsync(int id, GoalDtoUpdate goalDto, CancellationToken token = default)
        {
            await _validatorUpdate.ValidateAndThrowAsync(goalDto, token);
            Goal goal = _mapper.Map<Goal>(goalDto);
            await _goalRepository.UpdateAsync(id, goal, token);
        }
        public async Task DeleteAsync(int id, CancellationToken token = default)
        {
            await _goalRepository.DeleteAsync(id, token);
        }

    }
}
