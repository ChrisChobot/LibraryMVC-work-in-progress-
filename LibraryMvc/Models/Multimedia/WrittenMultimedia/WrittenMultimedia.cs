namespace LibraryMvc.Models
{
    public abstract class WrittenMultimedia : Multimedia
    {
        public string TableOfContents { get; set; }
        public int PagesCount { get; set; }
    }
}