﻿namespace LibraryTrackingApp.Domain.Entities.Library;

public class WorkTag : BaseEntity<Guid>, IAuditable<Guid>
{
    public Guid Id { get; set; }
    public Guid WorkCatalogId { get; set; }
    public string Name { get; set; }

    public virtual ICollection<WorkCatalog> WorkCatalogs { get; set; }
}
