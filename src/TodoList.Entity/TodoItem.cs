using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TodoList.Entity
{
    public class TodoItem
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public string UserName { get; set; }
        
        /// <summary>
        /// 公共、私有
        /// </summary>
        public int Type { get; set; }

        public string Title { get; set; }

        public string Descript { get; set; }

        /// <summary>
        /// -1-作废；0-新建；1-进行中；2-已完成；
        /// </summary>
        public int Status { get; set; }

        /// <summary>
        /// 重要性和紧急性级别，对应枚举ImportLevelEnum
        /// </summary>
        public int Level { get; set; }

        /// <summary>
        /// 更新时间，比如作废时间、完成时间
        /// </summary>
        public DateTime UpdateTime { get; set; }

        public DateTime CreateTime { get; set; }
    }
}
