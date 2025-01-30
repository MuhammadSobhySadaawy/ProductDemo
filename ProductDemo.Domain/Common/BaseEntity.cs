using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductDemo.Domain.Common
{
    public abstract class BaseEntity
    {
        public int Id { get; set; }
        [DefaultValue(false)]
        public bool IsDeleted { get; set; } = false;
        [DefaultValue(true)]
        public bool IsActive { get; set; } = true;
        public DateTime CreateDate { get; set; }
        public DateTime? LastUpdateDate { get; set; }
        public int CreateUser{ get; set; }
        public int? LastUpdateUser{ get; set; }
    }
}
