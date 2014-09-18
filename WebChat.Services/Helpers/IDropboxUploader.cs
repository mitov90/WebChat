namespace WebChat.Services.Helpers
{
    public interface IDropboxUploader
    {
        string UploadFile(string url, string fileName);
    }
}