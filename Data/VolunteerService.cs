using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace BlazorServerDatabaseTutorial.Data
{
    public class VolunteerService
    {
        private readonly IDbContextFactory<AppDBContext> ContextFactory;
        // ================================
        // Design: Inject IDbContextFactory
        // ================================
        public VolunteerService(IDbContextFactory<AppDBContext> iDbContextFactory)
        {
            ContextFactory = iDbContextFactory;
        }
        /// <summary>
        /// Get a list of all Volunteers
        /// </summary>
        public async Task<List<Volunteer>> GetAllVolunteersAsync()
        {
            using (var ctx = ContextFactory.CreateDbContext())
            {
                return await ctx.Volunteers.OrderBy(k => k.VolunteerName).ToListAsync();
            }
        }
        /// <summary>
        /// Add a Volunteer
        /// </summary>
        public async Task<bool> AddVolunteerAsync(Volunteer volunteer)
        {
            using (var ctx = ContextFactory.CreateDbContext())
            {
                ctx.Volunteers.Add(volunteer);
                await ctx.SaveChangesAsync();
                return true;
            }
        }
        /// <summary>
        /// Get Volunteer with specified Id
        /// </summary>
        public async Task<Volunteer> GetVolunteerAsync(int volunteerId)
        {
            Volunteer volunteer = null;
            using (var ctx = ContextFactory.CreateDbContext())
            {
                var query = ctx.Volunteers.Where(k => k.Id == volunteerId);
                if (query.Count() == 1)
                {
                    volunteer = await query.FirstAsync();
                }
                return volunteer;
            }
        }
        /// <summary>
        /// Delete a Volunteer (identified by VolunteerId)
        /// </summary>
        public async Task<bool> DeleteVolunteerAsync(int volunteerId)
        {
            bool successFlag = false;
            // TRICKY! We cannot simply use GetVolunteerAsync because it runs under a different dbContext!
            // Volunteer volunteer = await GetVolunteerAsync(volunteerId);  <--- cannot do this!
            using (var ctx = ContextFactory.CreateDbContext())
            {
                var query = ctx.Volunteers.Where(k => k.Id == volunteerId);
                if (query.Count() == 1)
                {
                    Volunteer volunteer = await query.FirstAsync();
                    ctx.Volunteers.Remove(volunteer);
                    await ctx.SaveChangesAsync();
                    successFlag = true;
                }
            }
            return successFlag;
        }
    }
}
