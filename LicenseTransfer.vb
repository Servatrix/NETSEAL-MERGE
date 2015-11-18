Public NotInheritable Class LicenseTransfer
 Private Sub New()
 End Sub
 Private Shared wc As New WebClient()
 Private Const API_PAGE As String = "http://servatrix.pw/api/transfer.php"

 Public Shared Function Transfer(toProduct As Integer) As String
  Return wc.DownloadString(String.Format("{0}?act=gen&exp={1}&points={2}&product={3}&pt={4}&user={5}", API_PAGE, Unix(LicenseGlobal.Seal.ExpirationDate), LicenseGlobal.Seal.Points, toProduct, LicenseGlobal.Seal.PublicToken, _
   LicenseGlobal.Seal.Username))
 End Function
 Private Shared Function Unix(datetime As DateTime) As Long
  Dim sTime As New DateTime(1970, 1, 1, 0, 0, 0, _
   DateTimeKind.Utc)
  Return CLng((datetime - sTime).TotalSeconds)
 End Function
End Class
