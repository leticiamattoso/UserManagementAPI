using MediatR;
using UM.Application.Users.Queries.GetAllUsers.Response;

namespace UM.Application.Users.Queries.GetAllUsers.Request
{
    public class GetAllUsersRequest : IRequest<IEnumerable<GetAllUsersResponse>>
    {
        public string? Term { get; set; }
    }
}