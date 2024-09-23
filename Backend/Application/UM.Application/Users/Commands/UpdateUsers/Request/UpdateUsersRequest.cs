using MediatR;

namespace UM.Application.Users.Commands.UpdateUsers.Request
{
    public class UpdateUsersRequest : IRequest
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string Gender { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public int Age { get; set; }
        public string Phone { get; set; } = string.Empty;
        public string CityName { get; set; } = string.Empty;
    }
}