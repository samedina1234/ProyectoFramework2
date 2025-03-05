using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace ProyectoFramework2.Shared.Entities
{
    public partial class ContraseñaHash
    {
        public string HashPassword(string Contraseña)
        {
            using (var sha256 = SHA256.Create())
            {
                byte[] hashBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(Contraseña));
                return Convert.ToBase64String(hashBytes);
            }
        }

        public bool VerifyPassword(string Contraseña, string hash)
        {
            return HashPassword(Contraseña) == hash;
        }
    }
}
