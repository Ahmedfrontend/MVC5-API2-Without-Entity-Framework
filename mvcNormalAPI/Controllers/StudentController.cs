using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using mvcNormalAPI.Models;

namespace mvcNormalAPI.Controllers
{
    public class StudentController : ApiController
    {


		[HttpGet]
		public IHttpActionResult Index()
		{
			student A = new student();

			return Ok(A.GetStudents());
		}

		[HttpPost]
		public IHttpActionResult Create(student smodel)
		{
			try
			{
				if (ModelState.IsValid)
				{
					student sdb = new student();
					if (sdb.AddStudent(smodel))
					{

					}
					return Ok(smodel);
				}
				else {
					return BadRequest("this student not Valid");
				}
				
			}
			catch
			{
				return BadRequest("this student not Valid");				
			}
		}


		// 3. ************* EDIT STUDENT DETAILS ******************
		// GET: Student/Edit/5

		[HttpGet]
		public IHttpActionResult Edit(int id)
		{
			student sdb = new student();
			return Ok(sdb.GetStudents().Find(smodel => smodel.ID == id));
		}

		// POST: Student/Edit/5
		[HttpPost]
		public IHttpActionResult Edit(int id, student smodel)
		{
			try
			{
				student sdb = new student();
				sdb.UpdateDetails(smodel);
				return Ok(smodel);
			}
			catch
			{
				return BadRequest("this student not Valid");
			}
		}


		// 4. ************* DELETE STUDENT DETAILS ******************
		// GET: Student/Delete/5

		[HttpDelete]
		public IHttpActionResult Delete(int id)
		{
			try
			{
				student sdb = new student();
				if (sdb.DeleteStudent(id))
				{
					
				}
				return Ok("student Deleted");
			}
			catch
			{
				return BadRequest("this student not Valid");
			}
		}

	}
}
