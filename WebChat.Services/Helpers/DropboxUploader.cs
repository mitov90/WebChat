namespace WebChat.Services.Helpers
{
    using System.IO;
    using System.Net;

    using Spring.IO;
    using Spring.Social.Dropbox.Api;
    using Spring.Social.Dropbox.Connect;
    using Spring.Social.OAuth1;

    public class DropboxUploader : IDropboxUploader
    {
        private const string DropboxAppKey = "emkw9h68t3ozcg0";

        private const string DropboxAppSecret = "usy8k6vm870vqqu";

        private const string OauthAccessTokenValue = "5tnzwac5dpohdaui";

        private const string OauthAccessTokenSecret = "aavab3ng2408ell";

        private static IDropboxUploader dropboxDataProvider;

        private readonly WebClient client;

        private readonly IDropbox dropbox;

        private readonly DropboxServiceProvider dropboxServiceProvider;

        private OAuthToken oauthAccessToken;

        private DropboxUploader()
        {
            this.dropboxServiceProvider = new DropboxServiceProvider(DropboxAppKey, DropboxAppSecret, AccessLevel.Full);
            this.oauthAccessToken = new OAuthToken(OauthAccessTokenValue, OauthAccessTokenSecret);

            this.client = new WebClient();
            this.dropbox = this.dropboxServiceProvider.GetApi(this.oauthAccessToken.Value, this.oauthAccessToken.Secret);
        }

        public static IDropboxUploader Instance
        {
            get { return dropboxDataProvider ?? (dropboxDataProvider = new DropboxUploader()); }
        }

        /// <summary>
        ///     Uploads the file to dropbox and then gets the new url.
        /// </summary>
        /// <param name="url">Used to download the file.</param>
        /// <param name="fileName">Used as name for the image.</param>
        /// <returns>The link from dropbox</returns>
        public string UploadFile(string url, string fileName)
        {
            this.client.DownloadFile(url, fileName);
            Entry uploadFileEntry =
                this.dropbox.UploadFileAsync(new FileResource(fileName), string.Format("{0}", fileName)).Result;

            // TODO: check for file extensions?
            DropboxLink sharedUrl = this.dropbox.GetMediaLinkAsync(uploadFileEntry.Path).Result;
            File.Delete(fileName);

            return sharedUrl.Url;
        }
    }
}