using Common.Domain;
using Common.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.SiteEntities
{
    public class Slider : BaseEntity
    {
        public string Title { get; private set; }
        public string Link { get; private set; }
        public string ImageName { get; private set; }

        public Slider(string title, string link, string imageName)
        {
            Guard(title, link, imageName);

            Title = title;
            Link = link;
            ImageName = imageName;
        }

        public void Edit(string title, string link, string imageName)
        {
            Guard(title, link, imageName);
            Title = title;
            Link = link;
            ImageName = imageName;
        }

        public void Guard(string title, string link, string imageName)
        {
            NullOrEmptyDomainDataException.CheckString(link, nameof(link));
            NullOrEmptyDomainDataException.CheckString(imageName, nameof(imageName));
            NullOrEmptyDomainDataException.CheckString(title, nameof(title));
        }
    }
}