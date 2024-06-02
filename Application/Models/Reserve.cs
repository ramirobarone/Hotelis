using System;

namespace Application.Models
{
    public class Reserve
    {
        public int Id { get; set; }
        public DateTime DateReserved { get; set; }
        public TimeOnly BeginTime { get; set; }
        public int IdRoom { get; set; }
        public int IdCost { get; set; }
        public int IdUser { get; set; }
    }
}