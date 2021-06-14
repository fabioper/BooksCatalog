using System;
using BooksCatalog.Infra.Services.Messaging.Events;

namespace BooksCatalog.Api.Models.Events
{
    public record AuthorCreated(int AuthorId, DateTime CreatedAt) : AuthorCreatedMessage;
}