namespace LibraryApi.Entities
{
    public partial class BookItem
    {
        public string? Id { get; set; }
        public string? Author { get; set; }
        public string? ImageLink { get; set; }
        public string? Language { get; set; }
        public string? Link { get; set; }
        public string? Title { get; set; }
        public string? ReleaseDate { get; set; }
        public string? Format { get; set; }
        public string? ISBN { get; set; }
        public string? Description { get; set; }
        public int? Pages { get; set; }
        public int? Year { get; set; }
    }
}
