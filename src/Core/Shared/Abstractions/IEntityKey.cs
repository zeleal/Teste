namespace Shared.Abstractions;

/// <summary>
/// Interface marcadora para representar uma entidade.
/// </summary>
public interface IEntity
{
}

/// <summary>
/// Interface marcadora para representar uma entidade.
/// </summary>
/// <typeparam name="TKey">O tipo da chave.</typeparam>
public interface IEntityKey<out TKey> : IEntity where TKey : notnull
{
    TKey Id { get; }
}