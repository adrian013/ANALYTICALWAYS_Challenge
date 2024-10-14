using AcmeSchool.Commands;
using AcmeSchool.DTOs;
using AcmeSchool.External;
using AcmeSchool.Model;
using AcmeSchool.Repositories;
using AutoMapper;

namespace AcmeSchool.Service
{
    public class EnrollmentService : IEnrollmentService
    {
        private readonly IMapper _mapper;
        private readonly IEnrollmentRepository _enrollmentRepository;
        private readonly IStudentRepository _studentRepository;
        private readonly ICourseRepository _courseRepository;
        private readonly IPaymentGateway _paymentGateway;
        public EnrollmentService(IMapper mapper, IEnrollmentRepository enrollmentRepository, IStudentRepository studentRepository, ICourseRepository courseRepository, IPaymentGateway paymentGateway)
        {
            _mapper = mapper;
            _enrollmentRepository = enrollmentRepository;
            _studentRepository = studentRepository;
            _courseRepository = courseRepository;
            _paymentGateway = paymentGateway;
        }


        public Guid Create(EnrollStudentCommand enrollment)
        {
            var course = _courseRepository.GetById(enrollment.CourseId);
            var student = _studentRepository.GetById(enrollment.StudentId);

            if (course == null)
            {
                throw new KeyNotFoundException($"CourseId: {enrollment.CourseId} not found");
            }

            if (student == null)
            {
                throw new KeyNotFoundException($"StudentId: {enrollment.StudentId} not found");
            }
            
            if(!_paymentGateway.ValidatePayment(enrollment.PaymentId))
            {
                throw new ArgumentException($"PaymentId: {enrollment.PaymentId} is not valid");
            }

            var entity = _mapper.Map<Enrollment>(enrollment);

            entity.EnrollmentDate = DateTime.Now;

            _enrollmentRepository.Add(entity);
            _enrollmentRepository.Commit();

            return entity.Id;
        }
    }
}
