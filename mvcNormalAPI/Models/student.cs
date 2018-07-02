using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace mvcNormalAPI.Models
{
	public class student
	{
		public int ID { get; set; }

		[Required]
		public string Name { get; set; }

		[Required]
		public int Age { get; set; }

		[Required]
		public string Address { get; set; }

		private SqlConnection con;
		private void connection()
		{
			string constring = ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString();
			con = new SqlConnection(constring);
		}


		// ********** VIEW STUDENTS********************
		public List<student> GetStudents()
		{
			connection();
			List<student> studentlist = new List<student>();

			SqlCommand cmd = new SqlCommand("GetStudents", con);
			cmd.CommandType = CommandType.StoredProcedure;
			SqlDataAdapter sd = new SqlDataAdapter(cmd);
			DataTable dt = new DataTable();

			con.Open();
			sd.Fill(dt);
			con.Close();

			foreach (DataRow dr in dt.Rows)
			{
				studentlist.Add(
					new student
					{
						ID = Convert.ToInt32(dr["Id"]),
						Name = Convert.ToString(dr["Name"]),
						Age = Convert.ToInt32(dr["Age"]),
						Address = Convert.ToString(dr["Address"])
					});
			}
			return studentlist;
		}


		// **************** ADD NEW STUDENT *********************
		public bool AddStudent(student smodel)
		{
			connection();
			SqlCommand cmd = new SqlCommand("AddNewStudent", con);
			cmd.CommandType = CommandType.StoredProcedure;

			cmd.Parameters.AddWithValue("@Name", smodel.Name);
			cmd.Parameters.AddWithValue("@Age", smodel.Age);
			cmd.Parameters.AddWithValue("@Address", smodel.Address);

			con.Open();
			int i = cmd.ExecuteNonQuery();
			con.Close();

			if (i >= 1)
				return true;
			else
				return false;
		}


        

		// ***************** UPDATE STUDENT DETAILS *********************
		public bool UpdateDetails(student smodel)
		{
			connection();
			SqlCommand cmd = new SqlCommand("UpdateStudentDetails", con);
			cmd.CommandType = CommandType.StoredProcedure;

			cmd.Parameters.AddWithValue("@ID", smodel.ID);
			cmd.Parameters.AddWithValue("@Name", smodel.Name);
			cmd.Parameters.AddWithValue("@Age", smodel.Age);
			cmd.Parameters.AddWithValue("@Address", smodel.Address);

			con.Open();
			int i = cmd.ExecuteNonQuery();
			con.Close();

			if (i >= 1)
				return true;
			else
				return false;
		}


		// ********************** DELETE STUDENT DETAILS *******************
		public bool DeleteStudent(int id)
		{
			connection();
			SqlCommand cmd = new SqlCommand("DeleteStudent", con);
			cmd.CommandType = CommandType.StoredProcedure;

			cmd.Parameters.AddWithValue("@ID", id);

			con.Open();
			int i = cmd.ExecuteNonQuery();
			con.Close();

			if (i >= 1)
				return true;
			else
				return false;
		}



		




	}
}