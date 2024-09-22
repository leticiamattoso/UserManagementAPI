using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using UM.Application.Users.Commands.AddUsers.Request;
using UM.Application.Users.Queries.GetAllUsers.Request;
using UM.Presentation.ViewModels;

namespace UM.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class UserController : BaseController
    {
        private static readonly HttpClient client = new();

        private static async Task<Result> GetRandomUserAsync()
        {
            var response = await client.GetStringAsync("https://randomuser.me/api/");
            var randomUserResponse = JsonConvert.DeserializeObject<RandomUserResponse>(response);
            return randomUserResponse.Results[0];
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

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Registration creation
        /// </summary>
        /// <param name="viewModel">Object representing an User</param>
        /// <returns></returns>
        [HttpPost("Create")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(object))]
        public async Task<ActionResult> Create([FromBody] AddUsersViewModel viewModel)
        {
            try
            {
                var response = await GetRandomUserAsync();

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
    }

    public class RandomUserResponse
    {
        public Result[] Results { get; set; }
    }

    public class Result
    {
        public Name Name { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }
        public Login Login { get; set; }
        public Dob Dob { get; set; }
        public string Phone { get; set; }
        public string Cell { get; set; }
        public Picture Picture { get; set; }
        public Location Location { get; set; }
    }

    public class Name
    {
        public string First { get; set; }
        public string Last { get; set; }
    }

    public class Login
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }

    public class Dob
    {
        public DateTime Date { get; set; }
        public int Age { get; set; }
    }

    public class Picture
    {
        public string Large { get; set; }
        public string Medium { get; set; }
        public string Thumbnail { get; set; }
    }

    public class Location
    {
        public Street Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string Postcode { get; set; }
        public Coordinates Coordinates { get; set; }
    }

    public class Street
    {
        public int Number { get; set; }
        public string Name { get; set; }
    }

    public class Coordinates
    {
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
    }
}