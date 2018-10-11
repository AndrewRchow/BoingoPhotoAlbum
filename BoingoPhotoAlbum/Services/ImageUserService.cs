using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BoingoPhotoAlbum.Domain;
using System.Data.SqlClient;
using System.Configuration;
using BoingoPhotoAlbum.Interfaces;

namespace BoingoPhotoAlbum.Services
{
    public class ImageUserService : IImageUserService
    {
        public int AddUser(AddUser model)
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                int modified=1;
                conn.Open();
                {
                    using (SqlCommand cmd = new SqlCommand("dbo.ImageUser_Add", conn))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Name", model.Name);
                        cmd.Parameters.AddWithValue("@Email", model.Email);
                        modified = Convert.ToInt32(cmd.ExecuteScalar());
                    }
                }
                conn.Close();
                return modified;
            }
        }

        public void AddImages(AddPhotos model)
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                conn.Open();
                {
                    using (SqlCommand cmd = new SqlCommand("dbo.Images_Add", conn))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Image", model.Image);
                        cmd.Parameters.AddWithValue("@Name", model.Name);
                        cmd.Parameters.AddWithValue("@Description", model.Description);
                        cmd.Parameters.AddWithValue("@UserId", model.UserId);
                        cmd.ExecuteNonQuery();
                    }
                }
                conn.Close();
            }
        }
        public List<GetImages> GetUserImages(Search searchModel)
        {
                List<GetImages> ImagesList = new List<GetImages>();
                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("dbo.Images_Get", conn))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@SearchCondition", searchModel.SearchCondition);
                        SqlDataReader reader = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
                        while (reader.Read())
                        {
                            GetImages model = Mapper(reader);
                            ImagesList.Add(model);
                        }
                    }
                    conn.Close();
                }
                return ImagesList;
        }
        private GetImages Mapper(SqlDataReader reader)
        {
            GetImages model = new GetImages();
            int index = 0;
            model.Image = (byte[])reader["Image"];
            model.Description = reader.GetString(index++);
            model.Name = reader.GetString(index++);
            model.Email = reader.GetString(index++);
            index++;
            return model;
        }
    }
}