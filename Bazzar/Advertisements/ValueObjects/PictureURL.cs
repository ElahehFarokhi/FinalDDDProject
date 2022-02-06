using Framework.Domain.ValueObjects;
using System;

namespace Bazzar.Domain.Advertisements.ValueObjects
{
    public class PictureURL : BaseValueObject<PictureURL>
    {
        public string URL { get; set; }
        public static PictureURL FromString(string value) => new PictureURL(value);
        public PictureURL(string url)
        {
            if (string.IsNullOrEmpty(url))
            {
                throw new ArgumentOutOfRangeException("برای آدرس تصویر مقدار لازم است");
            }
            URL = url;
        }
        public override int ObjectGetHashCode()
        {
            return URL.GetHashCode();
        }

        public override bool ObjectIsEqual(PictureURL otherObject)
        {
            return URL == otherObject.URL;
        }
        public static implicit operator string(PictureURL pictureURL) => pictureURL.URL;
    }
}
