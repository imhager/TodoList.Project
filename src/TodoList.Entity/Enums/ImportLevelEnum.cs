using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TodoList.Entity.Enums
{
    public enum ImportLevelEnum
    {
        /// <summary>
        /// 重要&紧急
        /// </summary>
        AA = 0,

        /// <summary>
        /// 重要&不紧急
        /// </summary>
        AB = 1,

        /// <summary>
        /// 紧急&不重要
        /// </summary>
        BC = 2,

        /// <summary>
        /// 不重要&不紧急
        /// </summary>
        CC = 3
    }
}
