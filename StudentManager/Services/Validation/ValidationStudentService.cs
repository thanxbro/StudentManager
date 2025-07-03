using StudentManager.DataBase;
using StudentManager.DataBase.Data;


namespace StudentManager.Services.Validation
{
    public class ValidationStudentService : IValidation<Student>
    {
        private const int MAX_LENGTH_NAME = 40;
        private const int MAX_LENGTH_LASTNAME = 40;
        private const int MAX_LENGTH_MIDLENAME = 60;

        private DataBaseContext  _db;
        public ValidationStudentService(DataBaseContext db)
        {
            _db = db;
        }
        public (bool,string) Validate(Student student)
        {
            if (CheckUniqueFIO(student))
            {
                return (false, "Данный пользователь уже существует в базе данных");
            }

            switch (student.Name.Length)
            {
                case > MAX_LENGTH_NAME: return (false, $"Имя пользователя не может превышать более {MAX_LENGTH_NAME} символов");
                case <= 0: return (false, "Имя пользователя не может быть мустым");
            }

            switch (student.LastName.Length)
            {
                case > MAX_LENGTH_LASTNAME: return (false, $"Фамилия пользователя не может превышать более {MAX_LENGTH_LASTNAME} символов");
                case <= 0: return (false, "Фамилия пользователя не может быть мустым");
            }

            switch (student.Middlename?.Length)
            {
                case > MAX_LENGTH_MIDLENAME: return (false, $"Отчество пользователя не может превышать более {MAX_LENGTH_MIDLENAME} символов");
            }

            return (true, "Допуск");
        }

        private bool CheckUniqueFIO(Student student)
        {
            return _db.Students.Any(s =>
                                                s.Name == student.Name &&
                                                s.LastName == student.LastName &&
                                                s.Middlename == student.Middlename);

        }
    }
}
