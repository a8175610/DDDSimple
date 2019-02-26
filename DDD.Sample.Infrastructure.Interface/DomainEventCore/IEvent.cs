using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Sample.Infrastructure.Interface.DomainEventCore
{
    /// <summary>
    /// 事件源接口
    /// </summary>
    public interface IEvent
    {
        Guid Id { get; }
        /// <summary>
        /// 事件发生时间
        /// </summary>
        DateTime TimeSpan { get; set; }
    }
}
