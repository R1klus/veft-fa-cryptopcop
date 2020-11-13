using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using AutoMapper;
using Cryptocop.Software.API.Models.DTOs;
using Cryptocop.Software.API.Models.Entities;
using Cryptocop.Software.API.Models.InputModels;
using Cryptocop.Software.API.Models.ResponseModels;
using Cryptocop.Software.API.Repositories.Helpers;
using Cryptocop.Software.API.Repositories.Resolvers;
using Microsoft.AspNetCore.Routing.Constraints;
using Microsoft.IdentityModel.Tokens;

namespace Cryptocop.Software.API.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Entities => Entities
            CreateMap<ShoppingCartItem, OrderItem>()
                .ForMember(src => src.TotalPrice,
                    opt => opt
                        .MapFrom(src => src.Quantity * src.UnitPrice));
            
            // Entities => DTOs
            CreateMap<Address, AddressDto>();
            CreateMap<ShoppingCartItem, ShoppingCartItemDto>()
                .ForMember(src => src.TotalPrice, 
                    opt => opt.
                        MapFrom(src => src.Quantity*src.UnitPrice));
            CreateMap<Order, OrderDto>()
                .ForMember(src => src.OrderDate,
                    opt => opt
                        .MapFrom(src => src.OrderDate.ToString("d")))
                .ForMember(src => src.CreditCard,
                    opt => opt.MapFrom(src => src.MaskedCreditCard));
                
            CreateMap<OrderItem, OrderItemDto>();
            CreateMap<PaymentCard, PaymentCardDto>();
            CreateMap<User, UserDto>();

            // InputModels => Entities
            CreateMap<AddressInputModel, Address>();
            CreateMap<LoginInputModel, User>()
                .ForMember(src => src.HashedPassword,
                    opt => opt.
                        MapFrom(src => HashingHelper
                            .HashPassword(src.Password)));
            CreateMap<RegisterInputModel, User>()
                .ForMember(src => src.HashedPassword,
                    opt => opt.
                        MapFrom(src => HashingHelper
                            .HashPassword(src.Password)));
            CreateMap<ShoppingCartItemInputModel, ShoppingCartItem>();
            CreateMap<PaymentCardInputModel, PaymentCard>();
            
            // DTOs => Entities
            CreateMap<AddressDto, Address>();
            CreateMap<OrderDto, Order>();
            CreateMap<OrderItemDto, OrderItem>();
            CreateMap<PaymentCardDto, PaymentCard>();
            CreateMap<UserDto, User>();
            
            // ExternalResponses => DTOs
            CreateMap<CryptoCurrencyResponse, CryptoCurrencyDto>();
            CreateMap<ExchangeResponse, ExchangeDto>();
        }
    }
}