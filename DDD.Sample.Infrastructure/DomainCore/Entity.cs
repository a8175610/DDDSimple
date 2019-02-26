using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DDD.Sample.Infrastructure.Interface.DomainCore;

namespace DDD.Sample.Infrastructure.DomainCore
{
    /// <summary>
    /// 实体对象
    /// </summary>
    public class Entity : IEntity
    {
        public Guid Id { get; protected set; }
    }
}

