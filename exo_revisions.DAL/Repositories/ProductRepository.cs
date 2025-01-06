using Dapper;
using Npgsql;
using exo_revisions.DAL.Entities;
using exo_revisions.DAL.Interfaces;

namespace exo_revisions.DAL.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly NpgsqlConnection _connection;

    public ProductRepository(NpgsqlConnection connection)
    {
        _connection = connection;
    }

    public IEnumerable<Product> GetAll()
    {
        const string query = @"
            SELECT
                ""id"" AS ""Id"",
                ""name"" AS ""Name"",
                ""description"" AS ""Description"",
                ""price"" AS ""Price"",
                ""stock"" AS ""Stock"",
                ""image_url"" AS ""ImageUrl"",
                ""created_at"" AS ""CreatedAt"",
                ""deleted_at"" AS ""DeletedAt"",
                ""status"" AS ""Status"",
                ""category_id"" AS ""CategoryId""
            FROM
                ""products"";
        ";
        return _connection.Query<Product>(query);
    }

    public IEnumerable<Product> GetAllActive()
    {
        const string query = @"
        SELECT
            ""id"" AS ""Id"",
            ""name"" AS ""Name"",
            ""description"" AS ""Description"",
            ""price"" AS ""Price"",
            ""stock"" AS ""Stock"",
            ""image_url"" AS ""ImageUrl"",
            ""created_at"" AS ""CreatedAt"",
            ""deleted_at"" AS ""DeletedAt"",
            ""status"" AS ""Status"",
            ""category_id"" AS ""CategoryId""
        FROM
            ""products""
        WHERE
            ""status"" = 'active' AND ""deleted_at"" IS NULL;";
        return _connection.Query<Product>(query);
    }

    public Product? GetById(int id)
    {
        const string query = @"
            SELECT
                ""id"" AS ""Id"",
                ""name"" AS ""Name"",
                ""description"" AS ""Description"",
                ""price"" AS ""Price"",
                ""stock"" AS ""Stock"",
                ""image_url"" AS ""ImageUrl"",
                ""created_at"" AS ""CreatedAt"",
                ""deleted_at"" AS ""DeletedAt"",
                ""status"" AS ""Status"",
                ""category_id"" AS ""CategoryId""
            FROM
                ""products""
            WHERE
                ""id"" = @Id;
        ";
        return _connection.QuerySingleOrDefault<Product>(query, new {Id = id});
    }

    public int Create(Product product)
    {
        const string query = @"
                INSERT INTO ""products"" (
                ""name"", 
                ""description"", 
                ""price"",
                ""stock"",
                ""image_url"",
                ""status"",
                ""category_id""
                   )
                VALUES (
                    @Name,
                    @Description,
                    @Price,
                    @Stock,
                    @ImageUrl,
                    @Status,
                    @CategoryId
                    )
                RETURNING ""id"" AS ""Id"";
        ";
        int resultId = _connection.QuerySingle<int>(query, new
        {
            Name = product.Name,
            Description = product.Description,
            Price = product.Price,
            Stock = product.Stock,
            ImageUrl = product.ImageUrl,
            Status = product.Status,
            CategoryId = product.CategoryId,
        });

        return resultId;
    }

    public bool Update(Product product)
    {
        const string query = @"
            UPDATE ""products"" SET
                ""name"" = @Name,
                ""description"" = @Description,
                ""price"" = @Price,
                ""stock"" = @Stock,
                ""image_url"" = @ImageUrl,
                ""status"" = @Status,
                ""category_id"" = @CategoryId
            WHERE ""id"" = @Id;
            ";
        int affectedRows = _connection.Execute(query, new
        {
            Id = product.Id,
            Name = product.Name,
            Description = product.Description,
            Price = product.Price,
            Stock = product.Stock,
            ImageUrl = product.ImageUrl,
            Status = product.Status,
            CategoryId = product.CategoryId,
        });
        return affectedRows > 0;
    }

    public bool Delete(int id)
    {
        const string query = @"
            UPDATE ""products"" SET 
                ""deleted_at"" = now(), ""status"" = 'inactive'
            WHERE ""id"" = @Id";
        int affectedRows = _connection.Execute(query, new {Id = id});
        return affectedRows > 0;
    }
}