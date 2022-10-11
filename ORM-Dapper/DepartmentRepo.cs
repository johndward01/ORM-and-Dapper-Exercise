using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ORM_Dapper;
internal class DepartmentRepo : IDepartmentRepo
{
    private readonly IDbConnection _connection;

    public DepartmentRepo(IDbConnection connection)
    {
        _connection = connection;
    }

    public IEnumerable<Department> GetAllDepartments()
    {
        return _connection.Query<Department>("SELECT * FROM departments;");
    }

    public void CreateDepartment(string departmentName)
    {
        _connection.Execute("INSERT INTO departments (Name) VALUES (@name);",
            new { name = departmentName });
    }

    public void UpdateDepartment(int departmentID, string updatedDepartmentName)
    {
        _connection.Execute("UPDATE departments SET Name = @name WHERE DepartmentID = @id;",
           new { name = updatedDepartmentName, id = departmentID });
    }
    public void DeleteDepartment(int id)
    {
        _connection.Execute("DELETE FROM departments WHERE DepartmentID = @departmentID;",
            new {departmentID = id});
    }
}
