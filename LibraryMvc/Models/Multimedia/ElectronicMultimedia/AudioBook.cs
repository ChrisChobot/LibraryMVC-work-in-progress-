namespace LibraryMvc.Models
{
    public class AudioBook : ElectronicMultimedia
    {
        public string Lector { get; set; }
        public string Isbn { get; set; }
        public float Lenght { get; set; }
    }
}