using MediatR;
using UM.Application.Users.Queries.GetAllUsers.Request;
using UM.Application.Users.Queries.GetAllUsers.Response;
using UM.Domain.Repositories.Users;

namespace UM.Application.Users.Queries.GetAllUsers
{
    public class GetAllUsersHandler(IUsersRepository usersRepository) : IRequestHandler<GetAllUsersRequest, IEnumerable<GetAllUsersResponse>>
    {
        private readonly IUsersRepository _usersRepository = usersRepository;

        public async Task<IEnumerable<GetAllUsersResponse>> Handle(GetAllUsersRequest request, CancellationToken cancellationToken)
        {
            var users = await _usersRepository.GetAllAsync();
            var responses = users.Where(c => string.IsNullOrWhiteSpace(request.Term) ||
                                          c.Id.ToString().Trim().Contains(request.Term, StringComparison.CurrentCultureIgnoreCase)).Select(res => new GetAllUsersResponse
                                          {
                                              FirstName = res.FirstName,
                                              LastName = res.LastName,
                                              Gender = res.Gender,
                                              UserName = res.UserName,
                                              Email = res.Email,
                                              Password = res.Password,
                                              DateOfBirth = res.DateOfBirth,
                                              Age = res.Age,
                                              Phone = res.Phone,
                                              Cell = res.Cell,
                                              PictureLarge = res.PictureLarge,
                                              PictureMedium = res.PictureMedium,
                                              PictureThumbnail = res.PictureThumbnail,
                                              Street = res.Address.Street,
                                              Number = res.Address.Number,
                                              PostCode = res.Address.PostCode,
                                              Latitude = res.Address.Latitude,
                                              Longitude = res.Address.Longitude,
                                              CityName = res.Address.City.Name,
                                              StateName = res.Address.City.State.Name,
                                              CountryName = res.Address.City.State.Country.Name
                                          }).ToList();
            return responses;
        }
    }
}