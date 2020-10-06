namespace Core.Domain.Administration.Models
{
    public class ModelConstants
    {
        public class Common
        {
            public const int MinNameLength = 2;
            public const int MaxNameLength = 20;
            public const int MinEmailLength = 3;
            public const int MaxEmailLength = 50;
            public const int MaxUrlLength = 2048;
            public const int Zero = 0;
        }

        public class SpecialOffer
        {
            public const int TitleMinLength = 5;
            public const int TitleMaxLength = 50;
            public const int ContentMinLength = 100;
            public const int ContentMaxLength = 1500;
            public const int ShortContentMinLength = 10;
            public const int ShortContentMaxLength = 50;
        }
        public class Payment
        {
            public const int Zero = 0;
        }

        public class Reservation
        {
            public const int MinNumberOfAdults = 1;
            public const int MaxNumberOfAdults = 20;

            public const int MinNumberOfKids = 0;
            public const int MaxNumberOfKids = 10;
        }

        public class Room
        {
            public const int MinRoomNumberLength = 2;
            public const int MaxRoomNumberLength = 10;

            public const int MinDescriptionLength = 5;
            public const int MaxDescriptionLength = 1000;
        }

    }
}
