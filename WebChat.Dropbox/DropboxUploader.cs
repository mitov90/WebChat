namespace WebChat.Dropbox
{
    using System.IO;
    using System.Net;

    using Spring.IO;
    using Spring.Social.Dropbox.Api;
    using Spring.Social.Dropbox.Connect;
    using Spring.Social.OAuth1;

    public class DropboxUploader : IDropboxUploader
    {
        /// <summary>
        ///     Used like
        ///     dropboxDataProvider = new DropboxUploader();
        ///     dropboxDataProvider.UploadFileToDropbox(url, file);
        /// </summary>
        private const string DropboxAppKey = "sz1naklm3twpmf7";

        private const string DropboxAppSecret = "7k6q0g0bmqjjwf0";

        private const string OauthAccessTokenValue = "5jkpgphv0lg8vqg3";

        private const string OauthAccessTokenSecret = "xgdf9jmxpak4dh7";

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

        public string UploadFileToDropbox(byte[] fileBytes, string fileName)
        {
            IResource fileResource = new ByteArrayResource(fileBytes);
            Entry uploadFileEntry =
                this.dropbox.UploadFileAsync(fileResource, string.Format("{0}", fileName))
                    .Result;
            DropboxLink sharedUrl = this.dropbox.GetMediaLinkAsync(uploadFileEntry.Path).Result;
            File.Delete(fileName);
            return sharedUrl.Url;
        }
    }
}