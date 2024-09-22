namespace UM.Presentation.ViewModels
{
    public class AddUsersViewModel
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Gender { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public DateTime DateOfBirth { get; set; }
        public int Age { get; set; }
        public string Phone { get; set; } = string.Empty;
        public string Cell { get; set; } = string.Empty;
        public string? PictureLarge { get; set; }
        public string? PictureMedium { get; set; }
        public string? PictureThumbnail { get; set; }
        public string Street { get; set; } = string.Empty;
        public int Number { get; set; }
        public string PostCode { get; set; } = string.Empty;
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public string CityName { get; set; } = string.Empty;
        public string StateName { get; set; } = string.Empty;
        public string CountryName { get; set; } = string.Empty;
    }
}