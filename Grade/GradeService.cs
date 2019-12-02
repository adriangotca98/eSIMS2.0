using eSims.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;
namespace eSims.Services
{
    public class GradeService
    {
        private readonly IMongoCollection<Grade> _grades;

        public GradeService(IeSimsDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _grades = database.GetCollection<Grade>(settings.GradesCollectionName);
        }

        public List<Grade> Get() =>
            _grades.Find(grade => true).ToList();

        public Grade Get(string idStudent, string idProfessor) =>
           _grades.Find<Grade>(grade => grade.Professor.Id == idProfessor && grade.Student.Id == idStudent).FirstOrDefault();

        public Grade Create(Grade grade)
        {
            _grades.InsertOne(grade);
            return grade;
        }

        public void Update(string idStudent, string idProfessor, Grade newGrade) =>
            _grades.ReplaceOne(grade => grade.Professor.Id == idProfessor && grade.Student.Id == idStudent, newGrade);

        public void Remove(Grade delGrade) =>
            _grades.DeleteOne(grade => grade.Professor.Id == delGrade.Professor.Id && grade.Student.Id == delGrade.Student.Id);

        public void Remove(string idStudent, string idProfessor) =>
            _grades.DeleteOne(grade => grade.Professor.Id == idProfessor && grade.Student.Id == idStudent);
    }
}
