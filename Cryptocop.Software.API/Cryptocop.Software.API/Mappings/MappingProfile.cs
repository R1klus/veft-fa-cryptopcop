using System.IdentityModel.Tokens.Jwt;
using AutoMapper;
using Cryptocop.Software.API.Models.DTOs;
using Cryptocop.Software.API.Models.Entities;
using Cryptocop.Software.API.Models.InputModels;
using Cryptocop.Software.API.Models.ResponseModels;
using Cryptocop.Software.API.Repositories.Helpers;
using Microsoft.IdentityModel.Tokens;

namespace Cryptocop.Software.API.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // DTOs
            CreateMap<Address, AddressDto>();
            CreateMap<ShoppingCartItem, ShoppingCartItemDto>()
                .ForMember(src => src.TotalPrice, 
                    opt => opt.
                        MapFrom(src => src.Quantity*src.UnitPrice));
            CreateMap<Order, OrderDto>();
            CreateMap<OrderItem, OrderItemDto>();
            CreateMap<PaymentCard, PaymentCardDto>();
            CreateMap<User, UserDto>();

            // InputModels
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
            
            // Entities
            CreateMap<AddressDto, Address>();
            CreateMap<OrderDto, Order>();
            CreateMap<OrderItemDto, OrderItem>();
            CreateMap<PaymentCardDto, PaymentCard>();
            CreateMap<UserDto, User>();

            CreateMap<CryptoCurrencyResponse, CryptoCurrencyDto>();
            CreateMap<ExchangeResponse, ExchangeDto>();
        }
    }
}