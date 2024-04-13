﻿using LibraryTrackingApp.Domain.Entities.Library;
using LibraryTrackingApp.Domain.Enums;

namespace LibraryTrackingApp.Persistence.Data;

public static class SeedData
{
    public static void Seed(ModelBuilder modelBuilder)
    {
        var systemRole = new AppRole
        {
            Id = Guid.NewGuid(),
            Name = "system",
            NormalizedName = "SYSTEM",
            ConcurrencyStamp = Guid.NewGuid().ToString()
        };

        var adminRole = new AppRole
        {
            Id = Guid.NewGuid(),
            Name = "Admin",
            NormalizedName = "ADMIN",
            ConcurrencyStamp = Guid.NewGuid().ToString()
        };

        var staffRole = new AppRole
        {
            Id = Guid.NewGuid(),
            Name = "Staff",
            NormalizedName = "STAFF",
            ConcurrencyStamp = Guid.NewGuid().ToString()
        };

        var memberRole = new AppRole
        {
            Id = Guid.NewGuid(),
            Name = "Member",
            NormalizedName = "MEMBER",
            ConcurrencyStamp = Guid.NewGuid().ToString()
        };

        var hasher = new PasswordHasher<AppUser>();

        var systemUser = new AppUser
        {
            Id = Guid.NewGuid(),
            UserName = "system",
            NormalizedUserName = "SYSTEM",
            Name = "system",
            Surname = "system",
            Email = "system@domain.com",
            NormalizedEmail = "SYSTEM@DOMAIN.COM",
            EmailConfirmed = true,
            PasswordHash = hasher.HashPassword(null, "SYSTEM@DOMAIN.COM"),
            SecurityStamp = string.Empty,
            ConcurrencyStamp = Guid.NewGuid().ToString(),
            CreatedBy = "SYSTEM",
            LastModifiedBy = "SYSTEM",
        };

        var adminUser = new AppUser
        {
            Id = Guid.NewGuid(),
            UserName = "admin@example.com",
            NormalizedUserName = "ADMIN@EXAMPLE.COM",
            Email = "admin@example.com",
            NormalizedEmail = "ADMIN@EXAMPLE.COM",
            Name = "admin",
            Surname = "admin",
            EmailConfirmed = true,
            PasswordHash = hasher.HashPassword(null, "YourPassword"),
            SecurityStamp = string.Empty,
            ConcurrencyStamp = Guid.NewGuid().ToString(),
            CreatedBy = systemUser.Name,
            CreatedById = systemUser.Id,
            LastModifiedBy = systemUser.LastModifiedBy,
        };

        var staffUser = new AppUser
        {
            Id = Guid.NewGuid(),
            UserName = "employee1@example.com",
            NormalizedUserName = "EMPLOYEE2@EXAMPLE.COM",
            Email = "employee1@example.com",
            NormalizedEmail = "EMPLOYEE2@EXAMPLE.COM",
            Name = "admin",
            Surname = "admin",
            EmailConfirmed = true,
            PasswordHash = hasher.HashPassword(null, "YourPassword2"),
            SecurityStamp = string.Empty,
            ConcurrencyStamp = Guid.NewGuid().ToString(),
            CreatedBy = systemUser.Name,
            CreatedById = systemUser.Id,
            LastModifiedBy = systemUser.LastModifiedBy,
        };

        var appUserRole = new AppUserRole() { UserId = adminUser.Id, RoleId = adminRole.Id };
        var appUserRole2 = new AppUserRole() { UserId = staffUser.Id, RoleId = staffRole.Id };

        var jKRowlingAuthor = new Author
        {
            Id = Guid.NewGuid(),
            Name = "J.K.",
            Surname = "Rowling",
            BirthDate = new DateTime(1965, 7, 31),
            Country = "United Kingdom",
            Biography =
                "Joanne Rowling, better known by her pen name J.K. Rowling, is a British author, philanthropist, film producer, television producer, and screenwriter. She is best known for writing the Harry Potter fantasy series.",
            CreatedById = systemUser.Id,
            CreatedBy = systemUser.Name,
            CreatedDate = DateTime.Now,
            LastModifiedBy = systemUser.LastModifiedBy,
        };

        var fantasyGenre = new Genre
        {
            Id = Guid.NewGuid(),
            Name = "Fantasy",
            IsActive = true,
            CreatedById = systemUser.Id,
            CreatedDate = DateTime.Now,
            CreatedBy = systemUser.Name,
            LastModifiedBy = systemUser.LastModifiedBy,
        };

        var adventureGenre = new Genre
        {
            Id = Guid.NewGuid(),
            Name = "Adventure",
            IsActive = true,
            CreatedById = systemUser.Id,
            CreatedDate = DateTime.Now,
            CreatedBy = systemUser.Name,
            LastModifiedBy = systemUser.LastModifiedBy,
        };

        var mainBranchId = Guid.NewGuid();

        var mainBranch = new LibraryBranch
        {
            Id = Guid.NewGuid(),
            Name = "Örnek Kütüphane Şubesi",
            Address = "123 Ana Cadde",
            PhoneNumber = "123-456-7890",
            OpeningDate = new DateTime(2020, 2, 20),
            Description = "Bu bir örnek kütüphane şubesidir.",
            CreatedBy = systemUser.Name,
            CreatedById = systemUser.Id,
            LastModifiedBy = systemUser.LastModifiedBy,
        };

        var bloomsburyPublishingPublisher = new Publisher
        {
            Id = Guid.NewGuid(),
            Name = "Bloomsbury Publishing",
            Website = "https://www.bloomsbury.com/",
            Address = "50 Bedford Square, London, England",
            PhoneNumber = "+44 (0)20 7631 5600",
            Email = "info@bloomsbury.com",
            CreatedById = systemUser.Id,
            CreatedBy = systemUser.Name,
            CreatedDate = DateTime.Now,
            LastModifiedBy = systemUser.LastModifiedBy,
        };

        var harryPotterBook = new Book
        {
            Id = Guid.NewGuid(),
            GenreId = fantasyGenre.Id,
            LibraryBranchId = mainBranch.Id,
            PublisherId = bloomsburyPublishingPublisher.Id,
            AuthorId = jKRowlingAuthor.Id,
            Title = "Harry Potter and the Philosopher's Stone",
            ISBN = "9781408855652",
            Description =
                "Harry Potter has never even heard of Hogwarts when the letters start dropping on the doormat at number four, Privet Drive. Addressed in green ink on yellowish parchment with a purple seal, they are swiftly confiscated by his grisly aunt and uncle. Then, on Harry's eleventh birthday, a great beetle-eyed giant of a man called Rubeus Hagrid bursts in with some astonishing news: Harry Potter is a wizard, and he has a place at Hogwarts School of Witchcraft and Wizardry. An incredible adventure is about to begin!",
            CoverImageUrl = "https://m.media-amazon.com/images/I/81q77Q39nEL._SY385_.jpg",
            PageCount = 352,
            PublicationDate = new DateTime(1997, 6, 26),
            OriginalPublicationDate = new DateTime(1997, 6, 26),
            Status = BookStatus.Available,
            Format = BookFormat.PrintedBook,
            BookLanguage = BookLanguage.English,
            IsFeatured = true,
            CreatedById = systemUser.Id,
            CreatedBy = systemUser.Name,
            CreatedDate = DateTime.Now,
            LastModifiedBy = systemUser.LastModifiedBy
        };

        var harryPotterTag1 = new Tag
        {
            Id = Guid.NewGuid(),
            Name = "Hogwarts",
            BookId = harryPotterBook.Id,
            CreatedById = systemUser.Id,
            CreatedBy = systemUser.Name,
            CreatedDate = DateTime.Now,
            LastModifiedBy = systemUser.LastModifiedBy
        };

        var harryPotterTag2 = new Tag
        {
            Id = Guid.NewGuid(),
            Name = "Harry Potter",
            BookId = harryPotterBook.Id,
            CreatedById = systemUser.Id,
            CreatedBy = systemUser.Name,
            CreatedDate = DateTime.Now,
            LastModifiedBy = systemUser.LastModifiedBy
        };

        var harryPotterTag3 = new Tag
        {
            Id = Guid.NewGuid(),
            Name = "Quidditch",
            BookId = harryPotterBook.Id,
            CreatedById = systemUser.Id,
            CreatedBy = systemUser.Name,
            CreatedDate = DateTime.Now,
            LastModifiedBy = systemUser.LastModifiedBy
        };


        var member1 = new Member
        {
            Id = Guid.NewGuid(),
            Name = "John Doe",
            Email = "john.doe@example.com",
            Address = "123 Main Street",
            PhoneNumber = "+1234567890",
            MembershipDate = DateTime.Now,
            BirthDate = new DateTime(1990, 5, 15),
            Gender = true,
            Occupation = "Software Engineer",
            NumberOfLateReturns = 0,
            MaxLateReturnsAllowed = 3,
            HasPenalty = false,
            PenaltyDurationInDays = 0,
            IsExtensionAllowed = true,
            ExtensionDurationInDays = 7, 
            LibraryBranchId= mainBranchId,
            CreatedById = systemUser.Id,
            CreatedBy = systemUser.Name,
            CreatedDate = DateTime.Now,
            LastModifiedBy = systemUser.LastModifiedBy,
            LastModifiedDate = null
        };

        var member2 = new Member
        {
            Id = Guid.NewGuid(),
            Name = "Jane Smith",
            Email = "jane.smith@example.com",
            Address = "456 Oak Street",
            PhoneNumber = "+1987654321",
            MembershipDate = DateTime.Now,
            BirthDate = new DateTime(1985, 8, 20),
            Gender = false,
            LibraryBranchId = mainBranchId,
            Occupation = "Teacher",
            NumberOfLateReturns = 2,
            MaxLateReturnsAllowed = 3,
            HasPenalty = true,
            PenaltyDurationInDays = 7,
            IsExtensionAllowed = false,
            ExtensionDurationInDays = 0,
            CreatedById = systemUser.Id,
            CreatedBy = systemUser.Name,
            CreatedDate = DateTime.Now,
            LastModifiedBy = systemUser.LastModifiedBy,
            LastModifiedDate = null
        };

        var mondaybranchHour = new BranchHour
        {
            Id = Guid.NewGuid(),
            LibraryBranchId = mainBranchId,
            OpeningTime = new TimeSpan(8, 0, 0), 
            ClosingTime = new TimeSpan(17, 30, 0),
            CreatedById = systemUser.Id,
            CreatedBy = systemUser.Name,
            CreatedDate = DateTime.Now
        };

        var tuesdaybranchHour = new BranchHour
        {
            Id = Guid.NewGuid(),
            LibraryBranchId = mainBranchId,
            OpeningTime = new TimeSpan(8, 0, 0),
            ClosingTime = new TimeSpan(17, 30, 0),
            CreatedById = systemUser.Id,
            CreatedBy = systemUser.Name,
            CreatedDate = DateTime.Now
        };

        var wednesdaybranchHour = new BranchHour
        {
            Id = Guid.NewGuid(),
            LibraryBranchId = mainBranchId,
            OpeningTime = new TimeSpan(8, 0, 0),
            ClosingTime = new TimeSpan(17, 30, 0),
            CreatedById = systemUser.Id,
            CreatedBy = systemUser.Name,
            CreatedDate = DateTime.Now
        };

        var thursdaybranchHour = new BranchHour
        {
            Id = Guid.NewGuid(),
            LibraryBranchId = mainBranchId,
            OpeningTime = new TimeSpan(8, 0, 0),
            ClosingTime = new TimeSpan(17, 30, 0),
            CreatedById = systemUser.Id,
            CreatedBy = systemUser.Name,
            CreatedDate = DateTime.Now
        };

        var fridaybranchHour = new BranchHour
        {
            Id = Guid.NewGuid(),
            LibraryBranchId = mainBranchId,
            OpeningTime = new TimeSpan(8, 0, 0),
            ClosingTime = new TimeSpan(17, 30, 0),
            CreatedById = systemUser.Id,
            CreatedBy = systemUser.Name,
            CreatedDate = DateTime.Now
        };

        var saturdaybranchHour = new BranchHour
        {
            Id = Guid.NewGuid(),
            LibraryBranchId = mainBranchId,
            OpeningTime = new TimeSpan(8, 0, 0),
            ClosingTime = new TimeSpan(17, 30, 0),
            CreatedById = systemUser.Id,
            CreatedBy = systemUser.Name,
            CreatedDate = DateTime.Now
        };

        var sundaybranchHour = new BranchHour
        {
            Id = Guid.NewGuid(),
            LibraryBranchId = mainBranchId,
            OpeningTime = new TimeSpan(0, 0, 0),
            ClosingTime = new TimeSpan(0, 0, 0),
            CreatedById = systemUser.Id,
            CreatedBy = systemUser.Name,
            CreatedDate = DateTime.Now
        };

        SeedEntities<AppRole>(modelBuilder, systemRole, adminRole, staffRole, memberRole);
        SeedEntities<AppUser>(modelBuilder, systemUser, adminUser, staffUser);
        SeedEntities<AppUserRole>(modelBuilder, appUserRole, appUserRole2);
        SeedEntities<Author>(modelBuilder, jKRowlingAuthor);
        SeedEntities<Genre>(modelBuilder, fantasyGenre, adventureGenre);
        SeedEntities<LibraryBranch>(modelBuilder, mainBranch);
        //SeedEntities<BranchHour>(modelBuilder, mondaybranchHour, tuesdaybranchHour, wednesdaybranchHour, thursdaybranchHour, fridaybranchHour, saturdaybranchHour, sundaybranchHour);
        SeedEntities<Publisher>(modelBuilder, bloomsburyPublishingPublisher);
        SeedEntities<Book>(modelBuilder, harryPotterBook);
        SeedEntities<Tag>(modelBuilder, harryPotterTag1, harryPotterTag2, harryPotterTag3);
        SeedEntities<Member>(modelBuilder, member1, member2);

    }

    private static void SeedEntities<T>(ModelBuilder modelBuilder, params T[] entities)
        where T : class
    {
        modelBuilder.Entity<T>().HasData(entities);
    }
}
