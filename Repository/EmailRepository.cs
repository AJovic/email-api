using EmailApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmailApp.Repository
{
    public class EmailRepository : IEmailRepository
    {
        private readonly EmailDbContext _emailDbContext;

        public EmailRepository(EmailDbContext emailDbContext)
        {
            _emailDbContext = emailDbContext;
        }

        public async Task<List<Email>> GetAllEmailsAsync()
        {
            return await _emailDbContext.Emails.ToListAsync();
        }

        public Email CreateEmail(Email email)
        {
            _emailDbContext.Emails.Add(email);
            return email;
        }

        public async Task<bool> SaveAsync()
        {
            return (await _emailDbContext.SaveChangesAsync() > 0);
        }
    }
}
