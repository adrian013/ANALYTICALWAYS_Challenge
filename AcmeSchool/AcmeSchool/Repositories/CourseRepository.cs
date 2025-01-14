﻿using AcmeSchool.Model;
using AcmeSchool.Persistence.InMemory;

namespace AcmeSchool.Repositories
{
    public class CourseRepository : Repository<Course, ApiContext>, ICourseRepository
    {
        private readonly ApiContext _context;

        public CourseRepository(ApiContext context) : base(context)
        {
            _context = context;
        }

        public IEnumerable<Course> GetAllWithStudents()
        {
            //As in-memory database doesn't support relationships, I resolve the relation in the repository, for future implementations should re write the repositories

            var courses = _context.Courses.ToList();

            foreach(var course in courses)
            {
                var enrollments = _context.Enrollments.Where(x => x.CourseId == course.Id).ToList();

                foreach(var enrollment in enrollments)
                {
                    enrollment.Student = _context.Students.First(x => x.Id == enrollment.StudentId);
                }

                course.Enrollments = enrollments;
            }

            return _context.Courses.ToList();
        }
    }
}
