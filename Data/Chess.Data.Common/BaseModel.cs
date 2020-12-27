namespace Chess.Data.Common
{
    using System;

    public class BaseModel<TKey>
    {
        public TKey Id { get; set; }

        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;
    }
}
