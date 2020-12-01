using System;
using System.Collections.Generic;
using System.Text;

namespace Chess.Data.Common
{
    public interface IDeletableEntity
    {
        bool IsDeleted { get; set; }

        DateTime? DeletedOn { get; set; }
    }
}
