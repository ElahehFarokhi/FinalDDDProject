using Framework.Domain.ValueObjects;
using System;

namespace Bazzar.Domain.Advertisements.ValueObjects
{
    public class PictureSize : BaseValueObject<PictureSize>
    {
        public int Height { get; set; }
        public int Width { get; set; }
        public PictureSize(int height, int width)
        {
            if (width<=0)
            {
                throw new ArgumentOutOfRangeException(nameof(width),"عرض تصویر باید بزرگتر از صفر باشد");
            }
            if (height <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(height),"ارتفاع تصویر باید بزرگتر از صفر باشد");
            }

            Width = width;
            Height = height;
        }
        public override int ObjectGetHashCode()
        {
            return (Width + Height).GetHashCode();
        }

        public override bool ObjectIsEqual(PictureSize otherObject)
        {
            return Height == otherObject.Height && Width == otherObject.Width;
        }
    }
}
