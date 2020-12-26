namespace Chess.Data.Models
{
    using Chess.Data.Common;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Move : BaseModel<string>
    {
        public string Title { get; set; }

        [ForeignKey("ApplicationUser")]
        public string ApplicationUserId { get; set; }
        public virtual ApplicationUser Player { get; set; }

        [ForeignKey("Game")]
        public string GameId { get; set; }
        public virtual Game Game { get; set; }
    }
}
