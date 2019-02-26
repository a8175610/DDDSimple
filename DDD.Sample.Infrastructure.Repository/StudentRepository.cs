using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DDD.Sample.Domain;
using DDD.Sample.Domain.Aggregate;
using DDD.Sample.Domain.Repository.Interface;
using DDD.Sample.Infrastructure.Interface;

namespace DDD.Sample.Infrastructure.Repository
{
    public class StudentRepository : BaseRepository<Student>, IStudentRepository
    {
        public StudentRepository(IDbContext dbContext) : base(dbContext)
        {
        }


    }
}
