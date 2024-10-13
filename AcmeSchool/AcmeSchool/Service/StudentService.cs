using AcmeSchool.Commands;
using AcmeSchool.DTOs;
using AcmeSchool.Model;
using AcmeSchool.Repositories;
using AutoMapper;

namespace AcmeSchool.Service
{
    public class StudentService : IStudentService
    {
        private readonly IMapper _mapper;
        private readonly IStudentRepository _studentRepository;
        public StudentService(IMapper mapper, IStudentRepository studentRepository)
        {
            _mapper = mapper;
            _studentRepository = studentRepository;
        }

        public StudentDTO GetById(Guid studentId)
        {
            var student = _studentRepository.GetById(studentId);

            return _mapper.Map<StudentDTO>(student);
        }

        public Guid Create(CreateStudentCommand createStudentCommand)
        {
            var entity = _mapper.Map<Student>(createStudentCommand);

            _studentRepository.Add(entity);
            _studentRepository.Commit();

            return entity.Id;
        }
    }
}
