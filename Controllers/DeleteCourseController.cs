using BigSchool.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BigSchool.Controllers
{
    public class DeleteCourseController : ApiController
    {
        BigSchoolContext context = new BigSchoolContext();

        [HttpGet]
        [Route("api/DeteleCourse")]
        public IHttpActionResult DeteleCourse(int id)
        {
            var userId = User.Identity.GetUserId();
            var course = context.Courses.Single(c => c.Id == id && c.LectureId == userId);

            try
            {
                var Attend = context.Attendances.Single(p => p.Attende == userId && p.CourseId == id);
                context.Attendances.Remove(Attend);
                context.Courses.Remove(course);
                context.SaveChanges();
                return Json(new
                {
                    check = "Ok"
                });
            }
            catch (Exception e)
            {
                e.Message.ToString();
                return Json(new
                {
                    check = "Null"
                });
            }
        }
    }
}
