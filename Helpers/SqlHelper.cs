using Dapper;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace SeleniumGameShopQA.Helpers
{
    class SqlHelper
    {
        /// <summary>
        /// Metoda do pobierania wielu wierszy z bazy danych dla podanych parametrów
        /// i mapowanie na liste obiektów
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="queryString"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public List<T> sqlSelectList<T>(string queryString, object parameters)
        {
            using (var connection = new SqlConnection(AppSettings.DefaultConnection))
            {
                connection.Open();
                var sqlCommand = connection.Query<T>(queryString, parameters).ToList();

                connection.Close();
                return sqlCommand;
            }
        }

        /// <summary>
        /// Metoda do pobierania pojedyńczego wiersza odpowiedzi z bazy danych
        /// dla wskazanych parametrów i mapowania na obiekt
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="queryString"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public T sqlSelect<T>(string queryString, object parameters)
        {
            using (var connection = new SqlConnection(AppSettings.DefaultConnection))
            {
                connection.Open();
                var sqlCommand = connection.Query<T>(queryString, parameters).FirstOrDefault();

                connection.Close();
                return sqlCommand;
            }
        }

        /// <summary>
        /// Wykonanie skryptu sql bez zwracania odpowiedzi np. do insert/update
        /// </summary>
        /// <param name="queryString"></param>
        /// <param name="parameters"></param>
        public void executeSqlString(string queryString, object parameters)
        {
            using (var connection = new SqlConnection(AppSettings.DefaultConnection))
            {
                connection.Open();
                connection.Execute(queryString, parameters);

                connection.Close();
            }
        }
    }
}
