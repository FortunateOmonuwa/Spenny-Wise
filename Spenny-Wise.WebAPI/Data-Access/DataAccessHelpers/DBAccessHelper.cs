using Microsoft.AspNetCore.Diagnostics;
using Microsoft.EntityFrameworkCore;
using Spenny_Wise.WebAPI.Domain.Models.UserEntity;

namespace Spenny_Wise.WebAPI.Data_Access.DataAccessHelpers
{
    public class DBAccessHelper
    {
        private readonly SpennyContext context;
        private readonly ILogger<DBAccessHelper> logger;

        public DBAccessHelper(ILogger<DBAccessHelper> logger, SpennyContext context)
        {
            this.context = context;
            this.logger = logger;
            
        }



        public async Task<User> GetUserWithProps(string user_id)
        {
            try
            {
                var user = await context.Users
                                .Include(x => x.Budgets)
                                .Include(x => x.Expenses)
                                .Include(x => x.BudgetCategories)
                                .Include(x => x.ExpenseCategories)
                                .FirstOrDefaultAsync(x => x.Id == int.Parse(user_id) || x.Name == user_id);

                if (user is not null)
                {
                    logger.LogInformation("User was successfully retrieved from the database");
                    return user;

                }
                else
                {
                    logger.LogError("User was not found on the database");
                    return null;
                }
            }
            catch(Exception ex)
            {
                throw new Exception($"{ex.GetType().Name} \n\n\n {ex.Message} \n\n\n {ex.Source}");
            }

        }

        public async Task<User> GetUser(string user_id)
        {
            try
            {
                var user = await context.Users.FirstOrDefaultAsync(x => x.Name == user_id || x.Id == int.Parse(user_id));

                if (user is not null)
                {
                    logger.LogInformation("User was successfully retrieved from the database");
                    return user;

                }
                else
                {
                    logger.LogError("User was not found on the database");
                    return null;
                }
            }
            catch (Exception ex)
            {
                logger.LogError($"{ex.GetType().Name} \n\n\n {ex.Message} \n\n\n {ex.Source}");
                throw new Exception($"{ex.GetType().Name} \n\n\n {ex.Message} \n\n\n {ex.Source}");
            }
        }
    }
}
