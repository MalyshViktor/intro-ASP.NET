using intro.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace intro.DAL.Context
{
    public class UsersConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            //начальная конфигурация при построении модели
            //(делигируется из контекста). Здесь
            //можно задать начальные значения полей,
            //поменять имя таблицы(по умолчанию - имя класса)
            //а также задать начальные данные для таблицы(seed)

            
            //Для пользователей традиционно задается корневой
            //администратор, с которого все начинается
            builder.HasData(new User
            {
                Id          = System.Guid.NewGuid(),
                RealName    = "Корневой администратор",
                Login       = "Admin",
                PassHash    = "",
                Email       = "",
                PassSalt    = "",
                RegMoment   = System.DateTime.Now,
                Avatar      = ""
            });
        }
    }
}
