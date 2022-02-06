using Bazzar.Domain.Advertisements.Entities;
using Bazzar.Domain.Advertisements.Events;
using Bazzar.Domain.Advertisements.ValueObjects;
using Framework.Domain.Entities;
using Framework.Domain.Events;
using Framework.Domain.Exceptions;
using Framework.Tools.Enums;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Bazzar.Domain.Advertisements.Entities
{

    public class Advertisement : BaseAggregateRoot<Guid>
    {
        public UserId OwnerId { get; private set; }
        public UserId ApprovedBy { get; private set; }
        public AdvertisementTitle Title { get; private set; }
        public AdvertisementText Text { get; private set; }
        public Price Price { get; private set; }
        public AdvertisementState Status { get; private set; }
        public List<Picture> Pictures { get; private set; }
        public Advertisement(Guid id, UserId ownerId)
        {
            Pictures = new(0);
            HandleEvent(new AdvertisementCreated()
            {
                Id = id,
                OwnerId = ownerId.Value
            });
        }


        public void SetTitle(AdvertisementTitle title)
        {
            HandleEvent(new AdvertisementTitleChanged()
            {
                Id = Id,
                AdvertisementTitle = title.Value
            }
            );
        }

        public void UpdateText(AdvertisementText text)
        {
            HandleEvent(new AdvertisementTextUpdated()
            {
                Id = Id,
                Text = text.Value
            }
            );
        }

        public void UpdatePrice(Price price)
        {
            HandleEvent(new AdvertisementPriceUpdated()
            {
                Id = Id,
                Price = price.Value.Value
            }
            );
        }

        public void RequestToPublish()
        {
            HandleEvent(new AdvertisementSendForReview()
            {
                Id = Id
            }
           );
        }

        protected override void ValidateInvariants()
        {
            var isValid =
                Id != default &&
                OwnerId != default &&
                (Status switch
                {
                    AdvertisementState.ReviewPending => Title != null && Text != null && Price != null,
                    AdvertisementState.Active => Title != null && Text != null && Price != null && ApprovedBy != null,
                    _ => true
                }
                );
            if (!isValid)
            {
                throw new InvalidEntityStateException(this, $"مقدار تنظیم شده برای آگهی در وضعیت {Status.GetDescription()} صحیح نمی باشد");
            }
        }

        protected override void SetStateByEvent(IEvents @event)
        {
            switch (@event)
            {
                case AdvertisementCreated e:
                    Id = e.Id;
                    OwnerId = new UserId(e.OwnerId);
                    Status = AdvertisementState.Inactive;
                    break;
                case AdvertisementPriceUpdated e:
                    Price = new Price(Rial.FromLong(e.Price));
                    break;
                case AdvertisementSendForReview e:
                    Status = AdvertisementState.ReviewPending;
                    break;
                case AdvertisementTextUpdated e:
                    Text = new AdvertisementText(e.Text);
                    break;
                case AdvertisementTitleChanged e:
                    Title = new AdvertisementTitle(e.AdvertisementTitle);
                    break;
                case AdvertisementPictureResized e:
                    break;
                case PictureAddedToAdvertisement e:
                    break;

                default:
                    throw new InvalidOperationException("امکان اجرای عملیات درخواستی وجود ندارد");
            }
            
        }

        public void AddPicture(Uri pictureUri, PictureSize size)
        {
            var newPic = new Picture(HandleEvent);
            newPic.HandleEvent(new PictureAddedToAdvertisement()
            {
                PictureId = new Guid(),
                ClassifiedAdId = Id,
                Url = pictureUri.ToString(),
                Height = size.Height,
                Width = size.Width
            }
            );

            Pictures.Add(newPic);
        }

        public void ResizePicture(Guid pictureId, PictureSize newSize)
        {
            var picture = FindPicture(pictureId);
            if (picture == null)
            {
                throw new InvalidOperationException($"تصویری با شناسه {pictureId} وجود ندارد");
            }
            picture.Resize(newSize);
        }

        private Picture FindPicture(Guid id) => Pictures.FirstOrDefault(_ => _.Id == id);


        // with lots of repeat
        //public class Advertisement : BaseEntity<Guid>
        //{
        //    public UserId OwnerId { get; private set; }
        //    public UserId ApprovedBy { get; private set; }
        //    public AdvertisementTitle Title { get; private set; }
        //    public AdvertisementText Text { get; private set; }
        //    public Price Price { get; private set; }
        //    public AdvertisementState Status { get; private set; }

        //    public Advertisement(Guid id, UserId ownerId)
        //    {
        //        Id = id;
        //        OwnerId = ownerId;
        //        Raise(new AdvertisementCreated()
        //        {
        //            Id = id, 
        //            OwnerId = ownerId.Value
        //        });
        //    }


        //    public void SetTitle(AdvertisementTitle title)
        //    {
        //        Title = title;
        //        ValidateInvariants();
        //        Raise(new AdvertisementTitleChanged()
        //        {
        //            Id = Id,
        //            AdvertisementTitle = Title.Value
        //        }
        //        );
        //    }

        //    public void UpdateText(AdvertisementText text)
        //    {
        //        Text = text;
        //        ValidateInvariants();
        //        Raise(new AdvertisementTextUpdated()
        //        {
        //            Id = Id,
        //            AdvertisementText = Text.Value
        //        }
        //        );
        //    }

        //    public void UpdatePrice(Price price)
        //    {
        //        Price = price;
        //        ValidateInvariants();
        //        Raise(new AdvertisementPriceUpdated()
        //        {
        //            Id = Id,
        //            AdvertisementPrice = Price.Value.Value
        //        }
        //        );
        //    }

        //    public void RequestToPublish()
        //    {
        //        Status = AdvertisementState.ReviewPending;
        //        ValidateInvariants();
        //        Raise(new AdvertisementSendForReview()
        //        {
        //            Id = Id
        //        }
        //       );
        //    }

        //    protected override void ValidateInvariants()
        //    {
        //        var isValid =
        //            Id != default &&
        //            OwnerId != default &&
        //            (Status switch
        //                {
        //                    AdvertisementState.ReviewPending => Title != null && Text != null && Price != null,
        //                    AdvertisementState.Active => Title != null && Text != null && Price != null && ApprovedBy != null,
        //                    _ => true
        //                }
        //            );
        //        if (!isValid)
        //        {
        //            throw new InvalidEntityStateException(this, "آگهی تنظیم شده در وضعیت صحیحی قرار ندارد");
        //        }
        //    }
        //}


        // without value object
        //public class Advertisement : BaseEntity<Guid>
        //{
        //    public Guid OwnerId { get; private set; }
        //    public string Title { get; private set; }
        //    public string Text { get; private set; }
        //    public long Price { get; private set; }
        //    public AdvertisementStatus Status { get; private set; }

        //    public Advertisement(Guid id, Guid ownerId)
        //    {
        //        if (id == default)
        //            throw new Exception();

        //        if (ownerId == default)
        //            throw new Exception();
        //        Id = id;
        //        OwnerId = ownerId;
        //        CheckInvariants();
        //    }

        //    public void setTitle(string title)
        //    {
        //        if (string.IsNullOrEmpty(title))
        //        {
        //            throw new Exception();
        //        }

        //        Title = title;
        //        CheckInvariants();
        //    }

        //    public void setText(string text)
        //    {
        //        if (string.IsNullOrEmpty(text))
        //        {
        //            throw new Exception();
        //        }

        //        Text = text;
        //        CheckInvariants();
        //    }

        //    public void setPrice(long price)
        //    {
        //        Price = price;
        //        CheckInvariants();
        //    }

        //    public void SendForReview()
        //    {
        //        Status = AdvertisementStatus.WaitingForReview;
        //        CheckInvariants();
        //    }

        //    public void CheckInvariants()
        //    { 

        //    }

        //}
    }
}