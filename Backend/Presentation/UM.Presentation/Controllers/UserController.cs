using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using UM.Application.Users.Commands.AddUsers.Request;
using UM.Application.Users.Commands.UpdateUsers.Request;
using UM.Application.Users.Queries.GetAllUsers.Request;
using UM.Presentation.ViewModels;

namespace UM.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class UserController : BaseController
    {
        private static readonly HttpClient client = new();

        private static async Task<Result?> GetRandomUserAsync()
        {
            var response = await client.GetStringAsync("https://randomuser.me/api/");
            var randomUserResponse = JsonConvert.DeserializeObject<RandomUserResponse>(response);
            return randomUserResponse?.Results[0];
        }

        /// <summary>
        /// Get all Users
        /// </summary>
        /// <param name="term">Enter registration number</param>
        /// <returns>If there is a User, return the User, if not, return empty list</returns>
        [HttpGet("GetAll")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<object>))]
        public async Task<ActionResult> GetAll(string? term)
        {
            try
            {
                var request = new GetAllUsersRequest { Term = term };
                var result = await Mediator!.Send(request);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Registration creation
        /// </summary>
        /// <returns></returns>
        [HttpPost("Create")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(object))]
        public async Task<ActionResult> Create()
        {
            try
            {
                var response = await GetRandomUserAsync();

                if (response == null)
                    return BadRequest(new { Message = "Não foi possível coletar dados do usuário." });

                var request = new AddUsersRequest
                {
                    FirstName = response.Name.First,
                    LastName = response.Name.Last,
                    Gender = response.Gender,
                    UserName = response.Login.Username,
                    Email = response.Email,
                    Password = response.Login.Password,
                    DateOfBirth = response.Dob.Date,
                    Age = response.Dob.Age,
                    Phone = response.Phone,
                    Cell = response.Cell,
                    PictureLarge = response.Picture.Large,
                    PictureMedium = response.Picture.Medium,
                    PictureThumbnail = response.Picture.Thumbnail,
                    Street = response.Location.Street.Name,
                    Number = response.Location.Street.Number,
                    PostCode = response.Location.Postcode,
                    Latitude = response.Location.Coordinates.Latitude,
                    Longitude = response.Location.Coordinates.Longitude,
                    CityName = response.Location.City,
                    StateName = response.Location.State,
                    CountryName = response.Location.Country
                };

                await Mediator!.Send(request);

                //var request = new RandomUserResponse { };

                return Ok("Usuário criado com sucesso!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Registration update
        /// </summary>
        /// <returns></returns>
        [HttpPut("Update")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(object))]
        public async Task<ActionResult> Update([FromBody] UpdateUsersViewModel viewModel)
        {
            try
            {
                var request = new UpdateUsersRequest
                {
                    Id = viewModel.Id,
                    FirstName = viewModel.FirstName,
                    Gender = viewModel.Gender,
                    UserName = viewModel.UserName,
                    Email = viewModel.Email,
                    Age = viewModel.Age,
                    Phone = viewModel.Phone
                };

                await Mediator!.Send(request);

                return Ok("Usuário atualizado com sucesso!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }


    public class RandomUserResponse
    {
        public Result[] Results { get; set; } = [];
    }

    public class Result
    {
        public Name Name { get; set; } = new Name();
        public string Gender { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public Login Login { get; set; } = new Login();
        public Dob Dob { get; set; } = new Dob();
        public string Phone { get; set; } = string.Empty;
        public string Cell { get; set; } = string.Empty;
        public Picture Picture { get; set; } = new Picture();
        public Location Location { get; set; } = new Location();
    }

    public class Name
    {
        public string First { get; set; } = string.Empty;
        public string Last { get; set; } = string.Empty;
    }

    public class Login
    {
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }

    public class Dob
    {
        public DateTime Date { get; set; }
        public int Age { get; set; }
    }

    public class Picture
    {
        public string Large { get; set; } = string.Empty;
        public string Medium { get; set; } = string.Empty;
        public string Thumbnail { get; set; } = string.Empty;
    }

    public class Location
    {
        public Street Street { get; set; } = new Street();
        public string City { get; set; } = string.Empty;
        public string State { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
        public string Postcode { get; set; } = string.Empty;
        public Coordinates Coordinates { get; set; } = new Coordinates();
    }

    public class Street
    {
        public int Number { get; set; }
        public string Name { get; set; } = string.Empty;
    }

    public class Coordinates
    {
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
    }
}