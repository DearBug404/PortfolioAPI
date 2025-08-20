
using Portfolio.Domain.Common;

namespace Portfolio.Domain.Entities
{
    public class SkillSection : AddUpdateAuditEntities
    {
        public Guid Id { get; set; }
        public string? SkillSectionTitle { get; set; }
        public string? SkillSectionDescription { get; set; }

        public static SkillSection Create(
            string? skillSectionTitle,
            string? skillSectionDescription)
        {
            return new SkillSection
            {
                SkillSectionTitle = skillSectionTitle,
                SkillSectionDescription = skillSectionDescription
            };
        }

        public void Update(
            string? skillSectionTitle = null,
            string? skillSectionDescription = null)
        {
            if (!string.IsNullOrWhiteSpace(skillSectionTitle)) SkillSectionTitle = skillSectionTitle;
            if (!string.IsNullOrWhiteSpace(skillSectionDescription)) SkillSectionDescription = skillSectionDescription;
        }
    }

}
