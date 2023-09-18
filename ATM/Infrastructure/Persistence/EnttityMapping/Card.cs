using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Db.Persistence.EnttityMapping
{
    public class Card
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; protected set; }

        public string CardNumber { get; protected set; }

        public short Pin { get; protected set; }

        public int AccountId { get; protected set; }

        [ForeignKey("AccountId")]
        public virtual Account Account { get; protected set; }
    }
}
