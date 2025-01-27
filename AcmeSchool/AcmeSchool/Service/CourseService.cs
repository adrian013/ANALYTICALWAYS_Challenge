﻿using AcmeSchool.Commands;
using AcmeSchool.DTOs;
using AcmeSchool.Model;
using AcmeSchool.Repositories;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace AcmeSchool.Service
{
    public class CourseService : ICourseService
    {
        private readonly IMapper _mapper;
        private readonly ICourseRepository _courseRepository;
        public CourseService(IMapper mapper, ICourseRepository courseRepository)
        {
            _mapper = mapper;
            _courseRepository = courseRepository;
        }


        public Guid Create(CreateCourseCommand createCourseCommand)
        {
            var entity = _mapper.Map<Course>(createCourseCommand);

            _courseRepository.Add(entity);
            _courseRepository.SaveChanges();

            return entity.Id;
        }

        public IEnumerable<CourseDTO> GetAllWithStudents()
        {
            var courses = _courseRepository.GetAllWithStudents();

            var coursesDTO = new List<CourseDTO>();

            if (courses != null)
            {
                foreach (var course in courses)
                {
                    var courseDTO = _mapper.Map<CourseDTO>(course);

                    coursesDTO.Add(courseDTO);
                }
            }

            return coursesDTO;
        }

        public CourseDTO GetById(Guid courseId)
        {
            var course = _courseRepository.GetById(courseId);

            return _mapper.Map<CourseDTO>(course);
        }
    }
}
