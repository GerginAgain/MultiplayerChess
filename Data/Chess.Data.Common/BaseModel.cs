using System;
using System.Collections.Generic;
using System.Text;

namespace Chess.Data.Common
{
    public class BaseModel<TKey>
    {
        public TKey Id { get; set; }

        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;
    }
}
