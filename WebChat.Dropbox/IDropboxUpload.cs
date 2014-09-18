namespace WebChat.Dropbox
{
    public interface IDropboxUploader
    {
        string UploadFileToDropbox(byte[] fuleBytes, string fileName);
    }
}