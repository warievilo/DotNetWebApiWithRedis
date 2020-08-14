using System;

namespace DotNetWebApiWithRedis.Models
{
    public class Actor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public DateTime BirthDate { get; set; }

        public Actor(int id, string name, string gender, DateTime birthDate)
        {
            this.Id = id;
            this.Name = name;
            this.Gender = gender;
            this.BirthDate = birthDate;
        }
    }
}