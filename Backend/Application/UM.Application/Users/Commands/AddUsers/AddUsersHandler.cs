using MediatR;
using UM.Application.Users.Commands.AddUsers.Request;
using UM.Domain.Entities;
using UM.Domain.Repositories.Users;

namespace UM.Application.Users.Commands.AddUsers
{
    public class AddUsersHandler(IUsersRepository usersRepository) : IRequestHandler<AddUsersRequest>
    {
        private readonly IUsersRepository _usersRepository = usersRepository;

        public async Task Handle(AddUsersRequest request, CancellationToken cancellationToken)
        {
            var addTo = new User
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Gender = request.Gender,
                UserName = request.UserName,
                Email = request.Email,
                Password = request.Password,
                DateOfBirth = request.DateOfBirth,
                Age = request.Age,
                Phone = request.Phone,
                Cell = request.Cell,
                PictureLarge = request.PictureLarge,
                PictureMedium = request.PictureMedium,
                PictureThumbnail = request.PictureThumbnail,
                Address = new Address
                {
                    Street = request.Street,
                    Number = request.Number,
                    PostCode = request.PostCode,
                    Latitude = request.Latitude,
                    Longitude = request.Longitude,
                    City = new City
                    {
                        Name = request.CityName,
                        State = new State
                        {
                            Name = request.StateName,
                            Country = new Country
                            {
                                Name = request.CountryName
                            }
                        }
                    }
                }
            };

            await _usersRepository.CreateAsync(addTo);
        }
    }
}