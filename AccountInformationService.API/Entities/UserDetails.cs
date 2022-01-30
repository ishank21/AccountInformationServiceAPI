namespace AccountInformationService.API.Entities
{
    public class UserDetails
    {
        public string? UserName { get; set; }
        public string? UserGuid { get; set; }
        public string? RoleName { get; set; }
        public int RoleID { get; set; }
        public string? AplId { get; set; }
        public bool HasActiveRole { get; set; }
    }
}
