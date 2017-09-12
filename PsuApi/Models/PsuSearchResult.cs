using System;
using System.Collections.Generic;

namespace PsuApi.Models
{
    public class PsuSearchResult : IEquatable<PsuSearchResult>
    {
        public PsuSearchEnum Search { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string MailId { get; set; }
        public string Title { get; set; }
        public string AdminArea { get; set; }
        public string Campus { get; set; }
        public string Curriculum { get; set; }
        public string Url { get; set; }
        public string TelephoneNumber { get; set; }
        public string Countries { get; set; }
        public string Languages { get; set; }
        public string CommonName { get; set; }
        public string LastName { get; set; }
        public string GivenName { get; set; }
        public string Mailbox { get; set; }
        public string EduPersonPrincipalName { get; set; }
        public string EduPersonPrimaryAffiliation { get; set; }

        public override bool Equals(object obj)
        {
            return Equals(obj as PsuSearchResult);
        }

        public bool Equals(PsuSearchResult other)
        {
            return other != null &&
                   Search == other.Search &&
                   Name == other.Name &&
                   Email == other.Email &&
                   MailId == other.MailId &&
                   Title == other.Title &&
                   AdminArea == other.AdminArea &&
                   Campus == other.Campus &&
                   Curriculum == other.Curriculum &&
                   Url == other.Url &&
                   TelephoneNumber == other.TelephoneNumber &&
                   Countries == other.Countries &&
                   Languages == other.Languages &&
                   CommonName == other.CommonName &&
                   LastName == other.LastName &&
                   GivenName == other.GivenName &&
                   Mailbox == other.Mailbox &&
                   EduPersonPrincipalName == other.EduPersonPrincipalName &&
                   EduPersonPrimaryAffiliation == other.EduPersonPrimaryAffiliation;
        }

        public override int GetHashCode()
        {
            var hashCode = 735720604;
            hashCode = hashCode * -1521134295 + Search.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Email);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(MailId);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Title);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(AdminArea);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Campus);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Curriculum);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Url);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(TelephoneNumber);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Countries);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Languages);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(CommonName);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(LastName);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(GivenName);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Mailbox);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(EduPersonPrincipalName);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(EduPersonPrimaryAffiliation);
            return hashCode;
        }

        public IEnumerable<string> ToEnumerableString() => new List<string> {nameof(Name), nameof(Email), nameof(MailId),
                nameof(Title), nameof(AdminArea), nameof(Campus), nameof(Curriculum), nameof(Url),
                nameof(TelephoneNumber), nameof(Countries), nameof(Languages), nameof(CommonName),
                nameof(LastName),nameof(GivenName),nameof(Mailbox),nameof(EduPersonPrincipalName),nameof(EduPersonPrimaryAffiliation) };


    }
}