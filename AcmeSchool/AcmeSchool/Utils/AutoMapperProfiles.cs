using AcmeSchool.Commands;
using AcmeSchool.DTOs;
using AcmeSchool.Model;
using AutoMapper;

namespace AcmeSchool.Utils
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<CreateCourseCommand, Course>();
            CreateMap<CreateStudentCommand, Student>();
            CreateMap<EnrollStudentCommand, Enrollment>();

            CreateMap<Course, CourseDTO>();
            CreateMap<Enrollment, EnrollmentDTO>();
            CreateMap<Student, StudentDTO>();

        }
    }
}
