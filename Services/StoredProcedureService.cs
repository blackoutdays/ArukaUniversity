using System;

namespace arusha.Services
{
    public class StoredProcedureService
    {
        // Метод для вызова вашей хранимой процедуры
        public string ExecuteStoredProcedure(int parameter)
        {
            // Здесь должна быть логика вызова вашей процедуры с переданным параметром
            // Возвращаем строку с результатом
            return $"Result for parameter {parameter}";
        }
    }
}
