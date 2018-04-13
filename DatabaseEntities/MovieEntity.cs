using System;
using System.Data;
using System.Data.SqlClient;

namespace DatabaseEntities
{
    public class MovieEntity
    {
        private int id;

        public int? MovieId { get { return id; } }
        public int? RankingWeight { get; set; }
        public string Title { get; set; }
        public DateTime? ReleaseDate { get; set; }        
        public DateTime? LastRankedTime { get; set; }

        public MovieEntity(){}

        public MovieEntity(DataRow row)
        {
            id = (int)row[0];
            Title = (string)row[1];
            ReleaseDate = (DateTime)row[2];
            RankingWeight = (int)row[3];
            LastRankedTime = (DateTime)row[4];
        }
    }
}
