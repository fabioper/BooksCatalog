using System;
using BooksCatalog.Infra.Services.Messaging.Events;

namespace BooksCatalog.Api.Models.Events
{
    public record BookCreated(int BookId, DateTime CreatedAt) : BookCreatedMessage;
}