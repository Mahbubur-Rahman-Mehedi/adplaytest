using ChinookTest.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ChinookTest.Data
{
    public class TrackAPIDb 
    {
        public static void DeleteTrack(int trackId)
        {
            var conn = new SqlConnection(Config.ChinookConnection);
            conn.Open();
            var cmd = new SqlCommand("DeleteTrack", conn)
            {
                CommandType = CommandType.StoredProcedure
            };
            cmd.Parameters.AddWithValue("@Id", trackId);
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public static List Tracks(int trackId)
        {
            var trackList = new List();
            var conn = new SqlConnection(Config.ChinookConnection);
            conn.Open();
            var cmd = new SqlCommand("GetTracks", conn)
            {
                CommandType = CommandType.StoredProcedure
            };
            cmd.Parameters.AddWithValue("@Id", trackId);
            var dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                trackList.Add(new Tracks
                {
                    TrackId = Convert.ToInt32(dr["TrackId"]),
                    Name = dr["Name"].ToString(),
                    AlbumId = Convert.ToInt32(dr["AlbumId"]),
                    GenreId = Convert.ToInt32(dr["GenreId"]),
                   
                });
            }
            dr.Close();
            conn.Close();

            return trackList;
        }


        private class Config
        {
            static public String ChinookConnection { get { return WebConfigurationManager.ConnectionStrings["ChinookConnection"].ConnectionString; } }
        }
    }
}
