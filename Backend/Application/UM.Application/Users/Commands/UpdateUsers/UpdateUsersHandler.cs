using MediatR;
using UM.Application.Users.Commands.UpdateUsers.Request;
using UM.Domain.Repositories.Users;

namespace UM.Application.Users.Commands.UpdateUsers
{
    public class UpdateUsersHandler(IUsersRepository usersRepository) : IRequestHandler<UpdateUsersRequest>
    {
        private readonly IUsersRepository _usersRepository = usersRepository;

        public async Task Handle(UpdateUsersRequest request, CancellationToken cancellationToken)
        {
            var user = await _usersRepository.GetAsync(request.Id) ?? throw new Exception("Usuário não encontrado.");

            user.FirstName = request.FirstName;
            user.Gender = request.Gender;
            user.UserName = request.UserName;
            user.Email = request.Email;
            user.Age = request.Age;
            user.Phone = request.Phone;

            await _usersRepository.UpdateAsync(user);
        }
    }
}