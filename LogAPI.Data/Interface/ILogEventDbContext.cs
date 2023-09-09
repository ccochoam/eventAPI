using LogAPI.Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace LogAPI.Data.Interface
{
    public interface ILogEventDbContext: IDisposable
    {
        DbSet<Event> Event { get; set; }
    }
}
