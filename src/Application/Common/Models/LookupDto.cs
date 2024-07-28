using BasicShop.Application.Common.Mappings;
using BasicShop.Domain.Entities;

namespace BasicShop.Application.Common.Models;

// Note: This is currently just used to demonstrate applying multiple IMapFrom attributes.
public class LookupDto
{
    public Guid Id { get; init; }

    public string? Title { get; init; }
}
