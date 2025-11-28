namespace Blog.API.Models.DTOs
{
    public class PostResponseDTO
    {
        public string Title { get; init; } = string.Empty;

        public string Summary { get; init; } = string.Empty;

        public string Body { get; init; } = string.Empty;

        public string Slug { get; init; } = string.Empty;

        public DateTime CreateDate { get; init; } = new DateTime();

        public DateTime LastUpdateDate { get; init; } = new DateTime();

        public string UserName { get; init; } = string.Empty;

        public string CategoryName { get; init; } = string.Empty;

        public List<TagResponseDTO> TagNames { get; init; } = new List<TagResponseDTO>();
    }
}
