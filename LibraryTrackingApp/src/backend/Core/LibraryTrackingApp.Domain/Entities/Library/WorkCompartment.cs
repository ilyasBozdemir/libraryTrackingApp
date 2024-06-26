﻿namespace LibraryTrackingApp.Domain.Entities.Library;

public class WorkCompartment : BaseEntity<Guid>, IAuditable<Guid>
{
    public Guid Id { get; set; }
    public Guid BookInventoryItemId { get; set; }

    public Guid ShelfId { get; set; }

    public string Name { get; set; }
    public ICollection<WorkInventory> BookInventoryItems { get; set; }

    public Shelf Shelf { get; set; }

}