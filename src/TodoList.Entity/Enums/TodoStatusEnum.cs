using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TodoList.Entity.Enums
{
    /// <summary>
    /// -1-作废；0-新建；1-进行中；2-已完成；
    /// </summary>
    public enum TodoStatusEnum
    {
        Deleted = -1,

        New = 0,

        Processing = 1,

        Finished = 2,

    }
}
