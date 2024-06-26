﻿using System.Text.Json.Serialization;
using LibraryTrackingApp.Application.Features.WorkInventories.Commands.Responses;

namespace LibraryTrackingApp.Application.Features.WorkInventories.Commands.Requests;

public class CreateBookCommandRequest : IRequest<CreateBookCommandResponse>
{
    public string Title { get; init; } // Kitap Başlığı
    public Guid AuthorId { get; init; } // Yazar ID
    public string ISBN { get; init; } // ISBN
    public int PageCount { get; init; } // Sayfa Sayısı
    public DateTime PublicationDate { get; init; } // Yayın Tarihi

    public string? AudioFilePath { get; set; }
    public string? FilePath { get; set; }


    [JsonConverter(typeof(JsonStringEnumConverter))]
    public WorkStatus Status { get; init; } = WorkStatus.Active; // Kitap Durumu
    public Guid GenreId { get; init; } // Tür Id'si
    public Guid PublisherId { get; init; } // Yayıncı Id'si
    public Guid LibraryBranchId { get; init; } // Kütüphane Şube Id'si
    public string Description { get; init; } // Açıklama
    public string CoverImageUrl { get; init; } // Kapak Resmi URL'i
    public DateTime OriginalPublicationDate { get; init; } // Orijinal Yayın Tarihi

    [JsonConverter(typeof(JsonStringEnumConverter))]
    public WorkFormat Format { get; init; } // Kitap Formatı


    public string WorkLanguage { get; init; } // Kitap Dili
    public bool IsFeatured { get; init; } // Öne Çıkarılmış mı?
}