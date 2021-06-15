using System;
using System.IO;
using BooksCatalog.Shared.Guards;

namespace BooksCatalog.Infra.Services.Storage.Extensions
{
    public static class BlobStorageGuardExtensions
    {
        public static void FilenameWithoutExtension(this IGuardClause clause, string filename)
        {
            if (string.IsNullOrEmpty(Path.GetExtension(filename)))
                throw new ArgumentException("File extension must be given");
        }
        
        public static void InvalidContainerName(this IGuardClause clause, string containerName)
        {
            // TODO
        }
    }
}