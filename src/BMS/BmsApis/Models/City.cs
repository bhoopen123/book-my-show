namespace BmsApis.Models
{
    public class City : BaseModel
    {
    }

    public class Theatre : BaseModel
    {

    }

    public class Audi : BaseModel { }
    public class Seat : BaseModel { }
    public class Show : BaseModel { }
    public class Ticket : BaseModel { }
    public class Payment : BaseModel { }
    public class User : BaseModel { }
    public class Bill : BaseModel { }
    public class SeatInShow : BaseModel { }
    public class SeatTypeInShow : BaseModel { }

    public class BaseModel
    {
        public int Id { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
