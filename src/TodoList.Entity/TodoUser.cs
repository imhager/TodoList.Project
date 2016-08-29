using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace TodoList.Entity
{
    public class TodoUser
    {
        //[Key]
        public int Id { get; set; }

        public string UserName { get; set; }

        public string NickName { get; set; }

        public int Sex { get; set; }

        public DateTime Brithday { get; set; }

        /// <summary>
        /// 二维码
        /// </summary>
        public string QRUrl { get; set; }

        //private DateTime _createDateTime;

        //public DateTime CreateTime
        //{
        //    get { return _createDateTime; }
        //    set
        //    {
        //        if (_createDateTime == DateTime.MinValue)
        //        {
        //            _createDateTime = DateTime.Now;
        //        }
        //        else
        //        {
        //            _createDateTime = value;
        //        }
        //    }
        //}

        public DateTime CreateTime { get; set; }
    }
}
