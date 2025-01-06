using Dapper;
using Npgsql;
using exo_revisions.DAL.Entities;
using exo_revisions.DAL.Interfaces;

namespace exo_revisions.DAL.Repositories;

public class CategoryRepository : ICategoryRepository
{
    private readonly NpgsqlConnection _connection;

    public CategoryRepository(NpgsqlConnection connection)
    {
        _connection = connection;
    }

    public IEnumerable<Category> GetAll()
    {
        const string query = @"
            SELECT
                ""id"" AS ""Id"",
                ""name"" AS ""Name"",
                ""created_at"" AS ""CreatedAt""
            FROM
                ""categories"";
        ";
        return _connection.Query<Category>(query);
    }

    public Category? GetById(int id)
    {
        const string query = @"
            SELECT
                ""id"" AS ""Id"",
                ""name"" AS ""Name"",
                ""created_at"" AS ""CreatedAt""
            FROM
                ""categories""
            WHERE
                ""id"" = @Id;
        ";
        return _connection.QuerySingleOrDefault<Category>(query, new {Id = id});
    }

    public int Create(Category category)
    {
        const string query = @"
                INSERT INTO ""categories"" (
                   ""name""
                   )
                VALUES (
                    @Name
                    )
                RETURNING ""id"" AS ""Id"";
        ";
        int resultId = _connection.QuerySingle<int>(query, new
        {
            Name = category.Name,
        });

        return resultId;
    }

    public bool Update(Category category)
    {
        const string query = @"
            UPDATE ""categories"" SET
                ""name"" = @Name
            WHERE ""id"" = @Id;
            ";
        int affectedRows = _connection.Execute(query, new
        {
            Id = category.Id,
            Name = category.Name,
        });
        return affectedRows > 0;
    }

    public bool Delete(int id)
    {
        const string query = @"DELETE FROM ""categories"" WHERE ""id"" = @Id";
        int affectedRows = _connection.Execute(query, new {Id = id});
        return affectedRows > 0;
    }
}