namespace TaskManager.Persistence.Database.Queries;

public static class TaskQueries
{
	public const string GetAll = @"
        SELECT
            Id,
            Title,
            Description,
            IsCompleted,
            CreatedAt
        FROM Tasks
        ORDER BY CreatedAt DESC";

	public const string GetById = @"
        SELECT
            Id,
            Title,
            Description,
            IsCompleted,
            CreatedAt
        FROM Tasks
        WHERE Id = @Id";

	public const string Create = @"
        INSERT INTO Tasks
        (
            Title,
            Description,
            IsCompleted,
            CreatedAt
        )
        VALUES
        (
            @Title,
            @Description,
            @IsCompleted,
            @CreatedAt
        );

        SELECT CAST(SCOPE_IDENTITY() AS INT);";

	public const string Update = @"
        UPDATE Tasks
        SET
            Title = @Title,
            Description = @Description,
            IsCompleted = @IsCompleted
        WHERE Id = @Id";

	public const string Delete = @"
        DELETE FROM Tasks
        WHERE Id = @Id";
}