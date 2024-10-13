using AcmeSchool.Commands;
using AcmeSchool.DTOs;
using AcmeSchool.Model;
using AutoMapper;

namespace AcmeSchool.Service
{
    public class StudentService : IStudentService
    {
        private readonly IMapper _mapper;
        public StudentService(IMapper mapper)
        {
            _mapper = mapper;
        }


        public void Create(CreateStudentCommand createStudentCommand)
        {
            var entity = _mapper.Map<Student>(createStudentCommand);


            throw new NotImplementedException();
        }
    }
}
