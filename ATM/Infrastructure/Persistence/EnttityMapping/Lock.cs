using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Db.Persistence.EnttityMapping
{
    public class Lock
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; protected set; }

        public int CardId { get; protected set; }

        public int FailedAttempts { get; protected set; }

        public DateTime? LockDate { get; protected set; }

        [ForeignKey("CardId")]
        public virtual Card Card { get; protected set; }
    }
}
