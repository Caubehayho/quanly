using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using Quanlydovat.Models;
using System.Data.SqlClient;

namespace Quanlydovat.DAL
{
    public class DALDo
    {
        public SqlConnection GetConnection()
        {
            string sql = ConfigurationManager.ConnectionStrings["DBconnect"].ConnectionString;
            SqlConnection con = new SqlConnection(sql);
            return con;
        }
        public List<Do> getAll(string id)
        {
            List<Do> dos = new List<Do>();
            SqlConnection con = GetConnection();
            con.Open();
            string sql;
            if (string.IsNullOrEmpty(id))
            {
                sql = "select * from Do";
            }
            else
            {
                sql = " select * from do where ID=" + id;
            }
            SqlCommand cm = new SqlCommand(sql, con);
            SqlDataReader dt = cm.ExecuteReader();
            while(dt.Read())
            {
                Do d = new Do();
                d.ID = int.Parse(dt["ID"].ToString());
                d.Ten = dt["Ten"].ToString();
                d.NguonG = dt["NguonG"].ToString();
                d.Gia = dt["Gia"].ToString();
                d.DanhGia = dt["DanhGia"].ToString();
                dos.Add(d);
            }
            con.Close();
            return dos;
        }

        public void Create(Do dovat)
        {
            SqlConnection con = GetConnection();
            con.Open();
            string sql = "INSERT INTO Do VALUES(@td, @ng, @gia, @dg)";
            SqlCommand cm = new SqlCommand(sql, con);
            cm.Parameters.AddWithValue("td", dovat.Ten);
            cm.Parameters.AddWithValue("ng", dovat.NguonG);
            cm.Parameters.AddWithValue("gia", dovat.Gia);
            cm.Parameters.AddWithValue("dg", dovat.DanhGia);
            cm.ExecuteNonQuery();
            con.Close();
        }

        public void Update(Do dovat)
        {
            SqlConnection con = GetConnection();
            con.Open();
            string sql ="update Do set Ten=@td, NguonG=@ng, Gia=@gia, DanhGia=@dg where ID=@id";
            SqlCommand cm = new SqlCommand(sql, con);
            cm.Parameters.AddWithValue("id", dovat.ID);
            cm.Parameters.AddWithValue("td", dovat.Ten);
            cm.Parameters.AddWithValue("ng", dovat.NguonG);
            cm.Parameters.AddWithValue("gia", dovat.Gia);
            cm.Parameters.AddWithValue("dg", dovat.DanhGia);
            cm.ExecuteNonQuery();
            con.Close();
        }
        public void Delete(Do dovat)
        {
            SqlConnection con = GetConnection();
            con.Open();
            string sql = "delete from Do where ID= " +dovat.ID;
            SqlCommand cm = new SqlCommand(sql, con);
            cm.ExecuteNonQuery();
            con.Close();
        }
    }
}