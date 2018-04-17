namespace DatabaseEntities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("UserRanking")]
    public partial class UserRanking
    {
        public int UserRankingId { get; set; }

        public int MovieId { get; set; }

        public int RankingWeight { get; set; }

        public DateTime RankedTime { get; set; }

        public virtual Movie Movie { get; set; }
    }
}
