namespace Core.Web.Common
{
    public class GlobalConstants
    {
        public const string SystemName = "Hotel Boryana";

        public const string SystemEmail = "b.arizanova@gmail.com";

        public const string AdministratorRoleName = "Administrator";

        public const string UserRoleName = "User";

        public const int DefaultPageNumber = 1;

        public const int PageSize = 3;

        public const string JpgFormat = "jpg";

        public const string JpegFormat = "jpeg";

        public const string PngFormat = "png";

        public const string ReservationInfoPlaceholder = "@reservationInfo";

        public const string GuestInfoPlaceholder = "@guestInfo";

        public const string PaymentInfoPlaceholder = "@paymentInfo";

        public const string RoomsInfoPlaceholder = " @roomsInfo";

        public const string ReservationReceiptEmailHtmlPath = "Views/Emails/reservation-confirmation.html";

        public const string PaymentReceiptEmailHtmlPath = "Views/Emails/payment-confirmation.html";

        public const string ReservationHtmlInfo =
            @"<td align=""left"" style=""padding: 6px 12px;font-family: 'Source Sans Pro', Helvetica, Arial, sans-serif; font-size: 14px; line-height: 20px;"">{0}</td>
              <td align = ""left"" style=""padding: 6px 12px;font-family: 'Source Sans Pro', Helvetica, Arial, sans-serif; font-size: 14px; line-height: 20px;"">{1}</td>
              <td align = ""left"" style=""padding: 6px 12px;font-family: 'Source Sans Pro', Helvetica, Arial, sans-serif; font-size: 14px; line-height: 20px;"">{2}</td>
              <td align = ""left"" style=""padding: 6px 12px;font-family: 'Source Sans Pro', Helvetica, Arial, sans-serif; font-size: 14px; line-height: 20px;"">{3}</td>
              <td align = ""left"" style=""padding: 6px 12px;font-family: 'Source Sans Pro', Helvetica, Arial, sans-serif; font-size: 14px; line-height: 20px;"">{4}</td>";

        public const string GuestHtmlInfo =
            @"<td align=""left"" style=""padding: 6px 12px;font-family: 'Source Sans Pro', Helvetica, Arial, sans-serif; font-size: 14px; line-height: 20px;"">{0}</td>
              <td align = ""left"" style=""padding: 6px 12px;font-family: 'Source Sans Pro', Helvetica, Arial, sans-serif; font-size: 14px; line-height: 20px;"">{1}</td>
              <td align = ""left"" style=""padding: 6px 12px;font-family: 'Source Sans Pro', Helvetica, Arial, sans-serif; font-size: 14px; line-height: 20px;"">{2}</td>";

        public const string PaymentHtmlInfo =
           @" <td align = ""left"" style=""padding: 6px 12px;font-family: 'Source Sans Pro', Helvetica, Arial, sans-serif; font-size: 14px; line-height: 20px;"">{0}</td>
              <td align = ""left"" style=""padding: 6px 12px;font-family: 'Source Sans Pro', Helvetica, Arial, sans-serif; font-size: 14px; line-height: 20px;"">{1}</td>
              <td align = ""left"" style=""padding: 6px 12px;font-family: 'Source Sans Pro', Helvetica, Arial, sans-serif; font-size: 14px; line-height: 20px;"">{2}</td>";

        public const string RoomsHtmlInfo =
           @"
           <tr>
              <td align = ""left"" style=""padding: 6px 12px;font-family: 'Source Sans Pro', Helvetica, Arial, sans-serif; font-size: 14px; line-height: 20px;"">{0}</td>
              <td align = ""left"" style=""padding: 6px 12px;font-family: 'Source Sans Pro', Helvetica, Arial, sans-serif; font-size: 14px; line-height: 20px;"">{1}</td>            
              <td align = ""left"" style=""padding: 6px 12px;font-family: 'Source Sans Pro', Helvetica, Arial, sans-serif; font-size: 14px; line-height: 20px;"">{2}</td>
              <td align = ""left"" style=""padding: 6px 12px;font-family: 'Source Sans Pro', Helvetica, Arial, sans-serif; font-size: 14px; line-height: 20px;"">{3}</td>
              <td align = ""left"" style=""padding: 6px 12px;font-family: 'Source Sans Pro', Helvetica, Arial, sans-serif; font-size: 14px; line-height: 20px;"">{4}</td>
           </tr>";

        public const string PaymentConfitmationHtmlInfo =
          @"
           <tr>
              <td align = ""left"" style=""padding: 6px 12px;font-family: 'Source Sans Pro', Helvetica, Arial, sans-serif; font-size: 14px; line-height: 20px;"">{0}</td>
              <td align = ""left"" style=""padding: 6px 12px;font-family: 'Source Sans Pro', Helvetica, Arial, sans-serif; font-size: 14px; line-height: 20px;"">{1}</td>            
              <td align = ""left"" style=""padding: 6px 12px;font-family: 'Source Sans Pro', Helvetica, Arial, sans-serif; font-size: 14px; line-height: 20px;"">{2}</td>
           </tr>";
    }
}
