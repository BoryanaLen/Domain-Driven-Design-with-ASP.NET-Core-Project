namespace Common.Application
{
    public class EmailAttachment
    {
        public byte[] Content { get; set; } = default!;

        public string FileName { get; set; } = default!;

        public string MimeType { get; set; } = default!;
    }
}
