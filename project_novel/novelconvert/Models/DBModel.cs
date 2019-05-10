using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Data;
using System.Data.Entity;

namespace novelconvert.Models
{
    public class DBModel
    {
        
        public DbSet<NovelModel> Novels { get; set; }

        public void DBConnection(MySqlConnection conn, string database_name)
        {
            conn = new MySqlConnection("server=localhost;userid=root;password=123456;database=" + database_name);
            conn.Open();
            
        }

        public void DBCloseConnection(MySqlConnection conn)
        {
            conn.Close();
        }

        public NovelModel GetMaxVoting()
        {
            NovelModel lnm = new NovelModel();

            return lnm;
        }

        public List<NovelModel> AllNovel()
        {
            string query = "SELECT * FROM `novel_infor` WHERE 1";
            MySqlConnection conn = new MySqlConnection("server=localhost;userid=root;password=123456;database=novel");

            MySqlCommand cmd = new MySqlCommand(query, conn);
            conn.Open();

            var reader = cmd.ExecuteReader();

            List<NovelModel> lresult = new List<NovelModel>();
            int i = 0;
            while(reader.Read())
            {
                    NovelModel readNovel = new NovelModel();
                    readNovel.Id = reader.GetString(0);
                    readNovel.Name = reader.GetString(1);
                    readNovel.Link = reader.GetString(2);
                    readNovel.Author = reader.GetString(3);
                    readNovel.Chap_number = Int32.Parse(reader.GetString(4));
                    readNovel.Rating = Int32.Parse(reader.GetString(5));
                    readNovel.Viewer = Int32.Parse(reader.GetString(6));
                    readNovel.Voting = Int32.Parse(reader.GetString(7));
                    readNovel.Recommandation = Int32.Parse(reader.GetString(8));
                    //readNovel.Image_link = reader.GetString(9);

                    lresult.Add(readNovel);
                i++;
            }

            DBCloseConnection(conn);
         
            return lresult;
        }
    }
}