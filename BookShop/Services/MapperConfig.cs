using AutoMapper;
using BookShop.DataAccesLayer.Entities;
using BookShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookShop.Services
{
    public class MapperConfig
    {
        private readonly IMapper mMapper;

        public MapperConfig()
        {
            mMapper = new MapperConfiguration(options =>
            {
                options.CreateMap<User, UpdateUserViewModel>().ForMember(x => x.Role, y => y.MapFrom(z => z.Role.Name));
                options.CreateMap<UpdateUserViewModel, User>().ForMember(x => x.HashPassword, y => y.MapFrom(z => z.Password));
                options.CreateMap<User, UserViewModel>().ForMember(x => x.Role, y => y.MapFrom(z => z.Role.Name)).ReverseMap();
                options.CreateMap<RegisterUserViewModel, User>().ForMember(x => x.HashPassword, y => y.MapFrom(z => z.Password));
                
                options.CreateMap<Book, BookViewModel>()
                        .ForMember(x => x.Cover, y => y.MapFrom(z => z.Cover.Name))
                        .ForMember(x => x.TypeOfBook, y => y.MapFrom(z => z.TypeOfBook.Name))
                        .ForMember(x => x.PublishingHause, y => y.MapFrom(z => z.PublishingHause.Name));
                
                options.CreateMap<BookViewModel, Book>();
                options.CreateMap<BookCardViewModel, Book>().ReverseMap();

                options.CreateMap<PurchaseHistory, PurchaseHistoryViewModel>().ReverseMap();

                options.CreateMap<Cover, CoverViewModel>().ReverseMap();
                options.CreateMap<TypeOfBook, TypeOfBookViewModel>().ReverseMap();
                options.CreateMap<PublishingHause, PublishingHauseViewModel>().ReverseMap();

                options.CreateMap<Comment, CommentViewModel>().ReverseMap();
            }).CreateMapper();
        }

        #region User
        public User Map(UpdateUserViewModel user) => mMapper.Map<User>(user);
        public UpdateUserViewModel Map(User user) => mMapper.Map<UpdateUserViewModel>(user);
        public User Map(RegisterUserViewModel user) => mMapper.Map<User>(user);
        public UserViewModel Map_Author(User user) => mMapper.Map<UserViewModel>(user);
        public List<UserViewModel> Map(List<User> users) => mMapper.Map<List<UserViewModel>>(users);
        #endregion

        #region Book
        public List<Book> Map(List<BookViewModel> books) => mMapper.Map<List<Book>>(books);
        public Book Map(BookViewModel book) => mMapper.Map<Book>(book);

        public List<BookViewModel> Map(List<Book> books) => mMapper.Map<List<BookViewModel>>(books);
        public BookViewModel Map(Book book) => mMapper.Map<BookViewModel>(book);

        public BookCardViewModel Map_Card(Book book) => mMapper.Map<BookCardViewModel>(book);
        public ICollection<Book> Map(ICollection<BookCardViewModel> books) => mMapper.Map<ICollection<Book>>(books);
        public IEnumerable<BookViewModel> Map(IEnumerable<Book> books) => mMapper.Map<IEnumerable<BookViewModel>>(books);
        #endregion

        #region Cover
        public List<Cover> Map(List<CoverViewModel> covers) => mMapper.Map<List<Cover>>(covers);
        public Cover Map(CoverViewModel cover) => mMapper.Map<Cover>(cover);

        public List<CoverViewModel> Map(List<Cover> covers) => mMapper.Map<List<CoverViewModel>>(covers);
        public CoverViewModel Map(Cover cover) => mMapper.Map<CoverViewModel>(cover);
        #endregion

        #region TypeOfBook
        public List<TypeOfBook> Map(List<TypeOfBookViewModel> types) => mMapper.Map<List<TypeOfBook>>(types);
        public TypeOfBook Map(TypeOfBookViewModel type) => mMapper.Map<TypeOfBook>(type);

        public List<TypeOfBookViewModel> Map(List<TypeOfBook> types) => mMapper.Map<List<TypeOfBookViewModel>>(types);
        public TypeOfBookViewModel Map(TypeOfBook type) => mMapper.Map<TypeOfBookViewModel>(type);
        #endregion

        #region TypeOfBook
        public List<PublishingHause> Map(List<PublishingHauseViewModel> hauses) => mMapper.Map<List<PublishingHause>>(hauses);
        public PublishingHause Map(PublishingHauseViewModel hause) => mMapper.Map<PublishingHause>(hause);

        public List<PublishingHauseViewModel> Map(List<PublishingHause> hauses) => mMapper.Map<List<PublishingHauseViewModel>>(hauses);
        public PublishingHauseViewModel Map(PublishingHause hause) => mMapper.Map<PublishingHauseViewModel>(hause);
        #endregion

        #region PurchaseHistory
        public List<PurchaseHistoryViewModel> Map(List<PurchaseHistory> purchases) => mMapper.Map<List<PurchaseHistoryViewModel>>(purchases);
        public PurchaseHistory Map(PurchaseHistoryViewModel purchase) => mMapper.Map<PurchaseHistory>(purchase);
        #endregion

        #region Comment
        public List<CommentViewModel> Map(List<Comment> comments) => mMapper.Map<List<CommentViewModel>>(comments);
        public Comment Map(CommentViewModel comment) => mMapper.Map<Comment>(comment);
        #endregion
    }
}
