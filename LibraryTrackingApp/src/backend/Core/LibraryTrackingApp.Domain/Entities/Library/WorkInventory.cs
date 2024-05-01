﻿namespace LibraryTrackingApp.Domain.Entities.Library;


//bookstock tablosu kalkıcaktır. stokları teker teker aynı kitapta da verilen numaralar ile ayırarak burda da bunu girerek
// yapılcaktır stok adedi bu şekilde olucaktır.
public class WorkInventory : BaseEntity<Guid>, IAuditable<Guid>
{
    public Guid Id { get; set; }
    public Guid BookId { get; set; }
    public Guid BorrowLendId { get; set; }
    public Guid EditionId { get; set; } // Eserin türü
    public Guid? ShelfId { get; set; }
    public Guid? BookCompartmentId { get; set; }
    public string BookNumber { get; set; }
    public WorkStatus BookStatus { get; set; }
    public bool IsAvailable { get; set; }
    public string? Donor { get; set; } // Bağışçı


    public BookStockTransactionType BookStockTransactionType { get; set; }

    public string? Description { get; set; }
    public string? Notes { get; set; } 

    public Shelf Shelf { get; set; }
    public WorkCatalog WorkCatalog { get; set; }

    public ICollection<Edition> Editions { get; set; } // Baskılar

    public virtual ICollection<BorrowLend> BorrowLends { get; set; }

    public virtual WorkCompartment BookCompartment { get; set; }
}
