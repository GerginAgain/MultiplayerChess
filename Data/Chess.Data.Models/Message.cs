namespace Chess.Data.Models
{
    using System.ComponentModel.DataAnnotations.Schema;
    using Chess.Data.Common;

    public class Message : BaseModel<string>
    {
        public string Content { get; set; }

        [ForeignKey("ApplicationUser")]
        public string ApplicationUserId { get; set; }
        public virtual ApplicationUser Player { get; set; }

        [ForeignKey("Game")]
        public string GameId { get; set; }
        public virtual Game Game { get; set; }
    }
}
