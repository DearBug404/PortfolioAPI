using Microsoft.Extensions.DependencyInjection;
using Portfolio.Application.Interfaces;
using Portfolio.Domain.Entities;
using Portfolio.Persistence.Context;
using Portfolio.Persistence.Repositories;

namespace Portfolio.Persistence.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        private IServiceProvider _serviceProvider;
        #region Eager Initialization
        //public UnitOfWork(ApplicationDbContext context)
        //{
        //    _context = context;
        //    HeaderRepository = new GenericRepository<Header>(_context);
        //    IntroRepository = new GenericRepository<Intro>(_context);
        //    AboutRepository = new GenericRepository<About>(_context);
        //    UserRepository = new GenericRepository<User>(_context);
        //    ServiceRepository = new GenericRepository<Services>(_context);
        //    SkillSectionRepository = new GenericRepository<SkillSection>(_context);
        //    SkillDetailRepository = new GenericRepository<SkillDetail>(_context);
        //    ExperienceRepository = new GenericRepository<Experience>(_context);
        //    EducationRepository = new GenericRepository<Education>(_context);
        //    ReviewRepository = new GenericRepository<Review>(_context);
        //    ContactInfoRepository = new GenericRepository<ContactInfo>(_context);
        //    ClientMessageRepository = new GenericRepository<ClientMessage>(_context);
        //    AuditLogRepository = new GenericRepository<AuditLog>(_context);
        //    SocialLinksRepository = new GenericRepository<SocialLinks>(_context);
        //}

        //public IGenericRepository<Header> HeaderRepository { get; }
        //public IGenericRepository<About> AboutRepository { get; }
        //public IGenericRepository<User> UserRepository { get; }
        //public IGenericRepository<Intro> IntroRepository { get; }
        //public IGenericRepository<Services> ServiceRepository { get; }
        //public IGenericRepository<SkillSection> SkillSectionRepository { get; }
        //public IGenericRepository<SkillDetail> SkillDetailRepository { get; }
        //public IGenericRepository<Experience> ExperienceRepository { get; }
        //public IGenericRepository<Education> EducationRepository { get; }
        //public IGenericRepository<Review> ReviewRepository { get; }
        //public IGenericRepository<ContactInfo> ContactInfoRepository { get; }
        //public IGenericRepository<ClientMessage> ClientMessageRepository { get; }
        //public IGenericRepository<AuditLog> AuditLogRepository { get; }
        //public IGenericRepository<SocialLinks> SocialLinksRepository { get; }
        #endregion

        #region Lazy Initialization
        private IGenericRepository<Header>? _headerRepository;
        private IGenericRepository<Intro>? _introRepository;
        private IGenericRepository<About>? _aboutRepository;
        private IGenericRepository<User>? _userRepository;
        private IGenericRepository<Services>? _servicesRepository;
        private IGenericRepository<SkillSection>? _skillSectionRepository;
        private IGenericRepository<SkillDetail>? _skillDetailRepository;
        private IGenericRepository<Experience>? _experienceRepository;
        private IGenericRepository<Education>? _educationRepository;
        private IGenericRepository<Review>? _reviewRepository;
        private IGenericRepository<ContactInfo>? _contactInfoRepository;
        private IGenericRepository<ClientMessage>? _clientMessageRepository;
        private IGenericRepository<AuditLog>? _auditLogRepository;
        private IGenericRepository<SocialLinks>? _socialLinksRepository;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }

        public IGenericRepository<Header> HeaderRepository =>
            _headerRepository ?? new GenericRepository<Header>(_context);

        public IGenericRepository<Intro> IntroRepository =>
           _introRepository ?? new GenericRepository<Intro>(_context);

        public IGenericRepository<About> AboutRepository =>
            _aboutRepository ?? new GenericRepository<About>(_context);

        public IGenericRepository<User> UserRepository =>
            _userRepository ?? new GenericRepository<User>(_context);

        public IGenericRepository<Services> ServiceRepository =>
            _servicesRepository ?? new GenericRepository<Services>(_context);

        public IGenericRepository<SkillSection> SkillSectionRepository =>
            _skillSectionRepository ?? new GenericRepository<SkillSection>(_context);

        public IGenericRepository<SkillDetail> SkillDetailRepository =>
            _skillDetailRepository ?? new GenericRepository<SkillDetail>(_context);

        public IGenericRepository<Experience> ExperienceRepository =>
            _experienceRepository ?? new GenericRepository<Experience>(_context);

        public IGenericRepository<Education> EducationRepository =>
            _educationRepository ?? new GenericRepository<Education>(_context);

        public IGenericRepository<Review> ReviewRepository =>
            _reviewRepository ?? new GenericRepository<Review>(_context);

        public IGenericRepository<ContactInfo> ContactInfoRepository =>
            _contactInfoRepository ?? new GenericRepository<ContactInfo>(_context);

        public IGenericRepository<ClientMessage> ClientMessageRepository =>
            _clientMessageRepository ?? new GenericRepository<ClientMessage>(_context);

        public IGenericRepository<AuditLog> AuditLogRepository =>
            _auditLogRepository ?? new GenericRepository<AuditLog>(_context);

        public IGenericRepository<SocialLinks> SocialLinksRepository =>
            _socialLinksRepository ?? new GenericRepository<SocialLinks>(_context);
        #endregion

        #region second approach - Lazy Initialization
        //    public UnitOfWork(ApplicationDbContext context, IServiceProvider serviceProvider)
        //    {
        //        _context = context;
        //        _serviceProvider = serviceProvider;
        //    }

        //    // Lazy property that asks DI for the repository when first accessed
        //    public IGenericRepository<Header> HeaderRepository =>
        //_serviceProvider.GetRequiredService<IGenericRepository<Header>>();

        //    public IGenericRepository<Intro> IntroRepository =>
        //        _serviceProvider.GetRequiredService<IGenericRepository<Intro>>();

        //    public IGenericRepository<About> AboutRepository =>
        //        _serviceProvider.GetRequiredService<IGenericRepository<About>>();

        //    public IGenericRepository<User> UserRepository =>
        //        _serviceProvider.GetRequiredService<IGenericRepository<User>>();

        //    public IGenericRepository<Services> ServiceRepository =>
        //        _serviceProvider.GetRequiredService<IGenericRepository<Services>>();

        //    public IGenericRepository<SkillSection> SkillSectionRepository =>
        //        _serviceProvider.GetRequiredService<IGenericRepository<SkillSection>>();

        //    public IGenericRepository<SkillDetail> SkillDetailRepository =>
        //        _serviceProvider.GetRequiredService<IGenericRepository<SkillDetail>>();

        //    public IGenericRepository<Experience> ExperienceRepository =>
        //        _serviceProvider.GetRequiredService<IGenericRepository<Experience>>();

        //    public IGenericRepository<Education> EducationRepository =>
        //        _serviceProvider.GetRequiredService<IGenericRepository<Education>>();

        //    public IGenericRepository<Review> ReviewRepository =>
        //        _serviceProvider.GetRequiredService<IGenericRepository<Review>>();

        //    public IGenericRepository<ContactInfo> ContactInfoRepository =>
        //        _serviceProvider.GetRequiredService<IGenericRepository<ContactInfo>>();

        //    public IGenericRepository<ClientMessage> ClientMessageRepository =>
        //        _serviceProvider.GetRequiredService<IGenericRepository<ClientMessage>>();

        //    public IGenericRepository<AuditLog> AuditLogRepository =>
        //        _serviceProvider.GetRequiredService<IGenericRepository<AuditLog>>();

        //    public IGenericRepository<SocialLinks> SocialLinksRepository =>
        //        _serviceProvider.GetRequiredService<IGenericRepository<SocialLinks>>();

        #endregion
        public async Task<int> SaveChangesAsync() => await _context.SaveChangesAsync();

        public void Dispose() => _context.Dispose();
    }
}
