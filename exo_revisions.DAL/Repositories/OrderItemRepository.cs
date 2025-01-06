using Dapper;
using Npgsql;
using exo_revisions.DAL.Entities;
using exo_revisions.DAL.Interfaces;

namespace exo_revisions.DAL.Repositories;

public class OrderItemRepository : IOrderItemRepository
{
    private readonly NpgsqlConnection _connection;

    public OrderItemRepository(NpgsqlConnection connection)
    {
        _connection = connection;
    }

    public IEnumerable<OrderItem> GetAll()
    {
        const string query = @"
            SELECT
                ""id"" AS ""Id"",
                ""order_id"" AS ""OrderId"",
                ""product_id"" AS ""ProductId"",
                ""quantity"" AS ""Quantity"",
                ""unit_price"" AS ""UnitPrice"",
                ""created_at"" AS ""CreatedAt""
            FROM
                ""order_items"";
        ";
        return _connection.Query<OrderItem>(query);
    }

    public OrderItem? GetById(int id)
    {
        const string query = @"
            SELECT
                ""id"" AS ""Id"",
                ""order_id"" AS ""OrderId"",
                ""product_id"" AS ""ProductId"",
                ""quantity"" AS ""Quantity"",
                ""unit_price"" AS ""UnitPrice"",
                ""created_at"" AS ""CreatedAt""
            FROM
                ""order_items""
            WHERE
                ""id"" = @Id;
        ";
        return _connection.QuerySingleOrDefault<OrderItem>(query, new {Id = id});
    }

    public IEnumerable<OrderItem> GetByOrderId(int orderId)
    {
        const string query = @"
            SELECT
                ""id"" AS ""Id"",
                ""order_id"" AS ""OrderId"",
                ""product_id"" AS ""ProductId"",
                ""quantity"" AS ""Quantity"",
                ""unit_price"" AS ""UnitPrice"",
                ""created_at"" AS ""CreatedAt""
            FROM
                ""order_items""
            WHERE
                ""order_id"" = @OrderId;
        ";
        return _connection.Query<OrderItem>(query, new { OrderId = orderId });
    }

    public IEnumerable<OrderItem> GetByProductId(int productId)
    {
        const string query = @"
            SELECT
                ""id"" AS ""Id"",
                ""order_id"" AS ""OrderId"",
                ""product_id"" AS ""ProductId"",
                ""quantity"" AS ""Quantity"",
                ""unit_price"" AS ""UnitPrice"",
                ""created_at"" AS ""CreatedAt""
            FROM
                ""order_items""
            WHERE
                ""product_id"" = @ProductId;
        ";
        return _connection.Query<OrderItem>(query, new { ProductId = productId });
    }

    public int Create(OrderItem orderItem)
    {
        const string query = @"
                INSERT INTO ""order_items"" (
                   ""order_id"",
                   ""product_id"",
                   ""quantity"",
                   ""unit_price""
                   )
                VALUES (
                    @OrderId,
                    @ProductId,
                    @Quantity,
                    @UnitPrice
                    )
                RETURNING ""id"" AS ""Id"";
        ";
        int resultId = _connection.QuerySingle<int>(query, new
        {
            OrderId = orderItem.OrderId,
            ProductId = orderItem.ProductId,
            Quantity = orderItem.Quantity,
            UnitPrice = orderItem.UnitPrice,
        });

        return resultId;
    }

    public bool Update(OrderItem orderItem)
    {
        const string query = @"
            UPDATE ""order_items"" SET
                ""quantity"" = @Quantity,
                ""unit_price"" = @UnitPrice
            WHERE ""id"" = @Id;
            ";
        int affectedRows = _connection.Execute(query, new
        {
            Id = orderItem.Id,
            Quantity = orderItem.Quantity,
            UnitPrice = orderItem.UnitPrice,
        });
        return affectedRows > 0;
    }

    public bool Delete(int id)
    {
        const string query = @"DELETE FROM ""order_items"" WHERE ""id"" = @Id";
        int affectedRows = _connection.Execute(query, new {Id = id});
        return affectedRows > 0;
    }
}