﻿using EF_Teste.Models;
using System.Security.Cryptography;

namespace EF_Teste.Repository
{
    public interface IStudentRepository
    {
        public Task Create(Student student);
        public Task Update(Student student);
        public Task Delete(Student student);

        public Task<Student>? GetById(int id);
        public Task<List<Student>> GetAll();
        public Task<List<Student>> GetByName(string name);

    }
}
