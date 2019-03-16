using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APP.Model.Sys
{
    public class UserModel
    {
        [Display(Name = "Id")]
        public int Id { get; set; }

        [Display(Name = "姓名")]
        public string Name { get; set; }

        [Display(Name = "年龄")]
        public int? Age { get; set; }

        [Display(Name = "出生日期")]
        public DateTime? Bir { get; set; }

        [Display(Name = "照片")]
        public string Photo { get; set; }

        [Display(Name = "备注")]
        public string Note { get; set; }

        [Display(Name = "添加时间")]
        public DateTime? CreateTime { get; set; }
    }
}
