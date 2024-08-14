using LaManada_API_KeirynSandi.Models;

namespace LaManada_API_KeirynSandi.ModelsDTO
{
    public class UsuarioDTO
    {
        public int UsersId { get; set; }

        public int? UserRoleId { get; set; }

        public string? Correo { get; set; }

        public string? Nombre { get; set; }

        public string? Telefono { get; set; }

        public string? Contrasennia { get; set; }

        public int RolID { get; set; }

        public virtual UserRole? UserRole { get; set; }

        public string? RolDescripcion { get; set; }

    }
}
