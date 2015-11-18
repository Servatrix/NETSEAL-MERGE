public static class LicenseTransfer
    {
        private static WebClient wc = new WebClient();
        private const string API_PAGE = "http://servatrix.pw/api/transfer.php";

        public static string Transfer(int toProduct)
        {
            return wc.DownloadString(string.Format("{0}?act=gen&exp={1}&points={2}&product={3}&pt={4}&user={5}",
                API_PAGE,
                Unix(LicenseGlobal.Seal.ExpirationDate),
                LicenseGlobal.Seal.Points,
                toProduct,
                LicenseGlobal.Seal.PublicToken,
                LicenseGlobal.Seal.Username));
        }
        private static long Unix(DateTime datetime)
        {
            DateTime sTime = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            return (long)(datetime - sTime).TotalSeconds;
        }
    }
