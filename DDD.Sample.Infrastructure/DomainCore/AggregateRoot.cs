using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DDD.Sample.Infrastructure.Interface.DomainCore;

namespace DDD.Sample.Infrastructure.DomainCore
{
    /// <summary>
    /// 聚合根
    /// </summary>
    public class AggregateRoot : Entity, IAggregateRoot
    {
    }
}
