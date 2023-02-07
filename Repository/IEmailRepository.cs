using EmailApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmailApp.Repository
{
    public interface IEmailRepository
    {
        Task<List<Email>> GetAllEmailsAsync();

        Email CreateEmail(Email email);

        Task<bool> SaveAsync();
    }
}
