using AcmeSchool.Commands;
using AcmeSchool.DTOs;
using AcmeSchool.Model;
using AutoMapper;

namespace AcmeSchool.Service
{
    public class EnrollmentService : IEnrollmentService
    {
        private readonly IMapper _mapper;
        public EnrollmentService(IMapper mapper)
        {
            _mapper = mapper;
        }


        public void Create(EnrollStudentCommand enrollment)
        {
            //var entity = _mapper.Map<Student>(student);


            throw new NotImplementedException();
        }
    }
}
