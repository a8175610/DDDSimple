using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Sample.Infrastructure.Interface
{
    /// <summary>
    /// 工作单元模式接口
    /// </summary>
    public interface IUnitOfWork
    {
        /// <summary>
        /// 开启事务
        /// </summary>
        void BeginTransaction();
        /// <summary>
        /// 提交变更
        /// </summary>
        /// <returns></returns>
        bool Commit();
        /// <summary>
        /// 回滚事务
        /// </summary>
        void Rollback();
    }
}
