using System.Collections.Generic;

namespace Common.Domain.ValueObjects
{
    public class SeoData : ValueObject
    {
        private SeoData()
        {
        }

        public static SeoData CreateEmpty()
        {
            return new SeoData();
        }

        public SeoData(string? metaKeyWords, string? metaDescription, string? metaTitle, bool indexPage, string? canonical)
        {
            MetaKeyWords = metaKeyWords;
            MetaDescription = metaDescription;
            MetaTitle = metaTitle;
            IndexPage = indexPage;
            Canonical = canonical;
        }

        public string? MetaTitle { get; private set; }
        public string? MetaDescription { get; private set; }
        public string? MetaKeyWords { get; private set; }
        public bool IndexPage { get; private set; } = true;
        public string? Canonical { get; private set; }
    }
}