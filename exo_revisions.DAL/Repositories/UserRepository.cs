using Dapper;
using Npgsql;
using exo_revisions.DAL.Entities;
using exo_revisions.DAL.Interfaces;

namespace exo_revisions.DAL.Repositories;

public class UserRepository : IUserRepository
{
    private readonly NpgsqlConnection _connection;

    public UserRepository(NpgsqlConnection connection)
    {
        _connection = connection;
    }

    public IEnumerable<User> GetAll()
    {
        const string query = @"
            SELECT
                ""id"" AS ""Id"",
                ""email"" AS ""Email"",
                ""password"" AS ""Password"",
                ""created_at"" AS ""CreatedAt"",
                ""fidelity_points"" AS ""FidelityPoints""
            FROM ""users""
        ";
        return _connection.Query<User>(query);
    }

    public User? GetById(int id)
    {
        const string query = @"
            SELECT
                ""id"" AS ""Id"",
                ""email"" AS ""Email"",
                ""password"" AS ""Password"",
                ""created_at"" AS ""CreatedAt"",
                ""fidelity_points"" AS ""FidelityPoints""
            FROM ""users""
            WHERE ""id"" = @Id
        ";
        return _connection.QuerySingleOrDefault<User>(query, new {Id = id});
    }

    public User? GetByEmail(string email)
    {
        const string query = @"
            SELECT
                ""id"" AS ""Id"",
                ""email"" AS ""Email"",
                ""password"" AS ""Password"",
                ""created_at"" AS ""CreatedAt"",
                ""fidelity_points"" AS ""FidelityPoints""
            FROM ""users""
            WHERE ""email"" = @Email
        ";
        return _connection.QuerySingleOrDefault<User>(query, new {Email = email});
    }

    public int Create(User user)
    {
        const string query = @"
                INSERT INTO ""users"" (
                    ""id"",
                    ""email"",
                    ""password"",
                    ""created_at"",
                    ""fidelity_points""
                )
                VALUES (
                    DEFAULT,
                    @Email,
                    @Password,
                    now(),
                    0
                )
                RETURNING ""id"" AS ""Id"";
            ";
        int resultId = _connection.QuerySingle<int>(query, new
        {
            user.Email,
            user.Password,
            user.CreatedAt,
            user.FidelityPoints,
        });
        return resultId;
    }

    public User? Login(string email)
    {
        const string query = @"
            SELECT
                ""id"" AS ""Id"",
                ""email"" AS ""Email"",
                ""password"" AS ""Password""
            FROM
                ""users""
            WHERE
                ""email"" = @Email
        ";
        return _connection.QueryFirstOrDefault<User>(query, new {Email = email});
    }

    public int GetFidelityPoints(int id)
    {
        const string query = @"
            SELECT
                ""fidelity_points"" AS ""FidelityPoints""
            FROM ""users""
            WHERE ""id"" = @Id
        ";
        return _connection.QuerySingle<int>(query, new {Id = id});
    }
    
    public void SetFidelityPoints(int id, int fidelityPoints)
    {
        const string query = @"
        UPDATE ""users""
        SET ""fidelity_points"" = @FidelityPoints
        WHERE ""id"" = @Id
    ";
        _connection.Execute(query, new { FidelityPoints = fidelityPoints, Id = id });
    }
}