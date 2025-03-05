using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataConsulting.Inventory.Application.Abstractions.Email
{
    public interface IEmailService
    {
        Task SendAsync(Domain.Users.Email recipient, string subject, string body);
    }
}
