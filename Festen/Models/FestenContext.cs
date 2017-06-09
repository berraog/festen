using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace Festen.Models
{
    public class FestenContext : DbContext
    {
        public DbSet<Participant> Participant { get; set; }
        public FestenContext(DbContextOptions<FestenContext> options) : base(options)
        {
        }

        public async Task<bool> AddParticipant(Participant p)
        {
            await Participant.AddAsync(p);

            return await SaveChangesAsync() > 0;
        }

        internal IEnumerable<Participant> GetAllParticipants()
        {
            if (Participant.Count() > 0)
            {
                return Participant.OrderByDescending(p => p.CompletedMissions).ToList();
            }
            //Participant p = new Participant { Id = 0, Firstname = "förnamn", Lastname = "efternamn", CompletedMissions = 0 };
            return new Participant[] { new Participant { Id = 0, Firstname = "förnamn", Lastname = "efternamn", CompletedMissions = 0 } };

        }
    }
}
