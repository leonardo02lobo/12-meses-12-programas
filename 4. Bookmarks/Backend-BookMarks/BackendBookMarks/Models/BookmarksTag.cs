using System;
using System.Collections.Generic;

namespace BackendBookMarks.Models;

public partial class BookmarksTag
{
    public int BookmarkId { get; set; }

    public int TagId { get; set; }

    public virtual Bookmark Bookmark { get; set; } = null!;

    public virtual Tag Tag { get; set; } = null!;
}
