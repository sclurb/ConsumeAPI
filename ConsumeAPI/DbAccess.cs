using ConsumeAPI.Data;
using ConsumeAPI.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsumeAPI
{

    public class DbAccess
    {
        private ConsumeApiContext _ctx = new ConsumeApiContext();

        public DbAccess()
        {

        }
        /// <summary>
        /// Gets a List from the local database by date range
        /// Very handy for updating the web server
        /// </summary>
        /// <param name="dates"></param>
        /// <returns></returns>
        public List<Stuff> GetReadingsByDateRangeFromLocalDb(DateRange dates)
        {
            var query = _ctx.Stuff.Where(f => f.Date > dates.From && f.Date < dates.To)
                .OrderBy(y => y.Date.Year)
                .ThenBy(m => m.Date.Month)
                .ThenBy(d => d.Date.Day)
                .ThenBy(h => h.Date.Hour)
                .ThenBy(m => m.Date.Minute).ToList();
            return query;
        }
    }
}
