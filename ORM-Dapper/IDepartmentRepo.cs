namespace ORM_Dapper;

public interface IDepartmentRepo
{
    public void CreateDepartment(string departmentName);
    public void DeleteDepartment(int id);
    public IEnumerable<Department> GetAllDepartments();
    public void UpdateDepartment(int id, string updatedDepartmentName);
}