using PersonalExpenseTrackerAPI.Model;

namespace PersonalExpenseTrackerAPI.Repository
{
    public interface IUserRepository
    {
        Task<User> AddUser();

    }
}
