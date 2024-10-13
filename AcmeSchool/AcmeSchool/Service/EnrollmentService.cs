using AcmeSchool.Commands;
using AcmeSchool.DTOs;
using AcmeSchool.Model;
using AcmeSchool.Repositories;
using AutoMapper;

namespace AcmeSchool.Service
{
    public class EnrollmentService : IEnrollmentService
    {
        private readonly IMapper _mapper;
        private readonly IEnrollmentRepository _enrollmentRepository;
        public EnrollmentService(IMapper mapper, IEnrollmentRepository enrollmentRepository)
        {
            _mapper = mapper;
            _enrollmentRepository = enrollmentRepository;
        }


        public void Create(EnrollStudentCommand enrollment)
        {
            var entity = _mapper.Map<Enrollment>(enrollment);

            _enrollmentRepository.Add(entity);
            _enrollmentRepository.Commit();
        }
    }
}
