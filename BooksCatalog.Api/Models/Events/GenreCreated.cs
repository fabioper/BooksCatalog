﻿using System;
using BooksCatalog.Infra.Services.Messaging.Events;

namespace BooksCatalog.Api.Models.Events
{
    public record GenreCreated(int GenreId, DateTime CreatedAt) : GenreCreatedMessage;
}