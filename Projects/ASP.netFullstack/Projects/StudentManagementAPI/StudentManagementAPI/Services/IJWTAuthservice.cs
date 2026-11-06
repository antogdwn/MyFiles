namespace StudentManagementAPI.Services
{
    public interface IJWTAuthservice
    {
        public string GenerateToken(string username);
        public bool ValidateUser(string username, string password);

    }
}
