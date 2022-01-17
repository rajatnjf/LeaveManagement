using HR.LeaveManagement.Application.Persistence.Contracts;
using HR.LeaveManagement.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Persistence.Repositories
{
    public class LeaveAllocationRepository : GenericRepository<LeaveAllocation>, ILeaveAllocationRepository
    {
        private readonly LeaveManagementDbContext _dbContext;
        private readonly DbSet<LeaveAllocation> _dbSet;

        public LeaveAllocationRepository(LeaveManagementDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<LeaveAllocation>();
        }

        public async Task<List<LeaveAllocation>> GetLeaveAllocationsWithDetailsAsync()
        {
            return await _dbSet.Include(e => e.LeaveType).ToListAsync();
        }

        public async Task<LeaveAllocation> GetLeaveAllocationWithDetailsAsync(int id)
        {
            return await _dbSet.Include(e => e.LeaveType).FirstOrDefaultAsync(e => e.Id == id);

        }
    }
}
