using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITPWorkshop.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Adresa { get; set; }
        public string BrojTelefona { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
    }
}