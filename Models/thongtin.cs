using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Vietjet.com.Data;
using System;
using System.Linq;

namespace Vietjet.com.Models
{
    public static class thongtin
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new VietjetcomContext(
            serviceProvider.GetRequiredService<
            DbContextOptions<VietjetcomContext>>()))
            {
                // Kiểm tra thông tin cuốn sách đã tồn tại hay chưa
                if (context.bay.Any())
                {
                    return; // Không thêm nếu cuốn sách đã tồn tại trong DB
                }
                context.bay.AddRange(
                new bay
                {
                    Title = "2410",
                    ReleaseDate = DateTime.Parse("2022-2-7"),
                    Genre = "Vietjet Air",
                    Price = 50.00M,
                    Rating = " Thường"
                },
                new bay
                {
                    Title = "1805",
                    ReleaseDate = DateTime.Parse("2022-2-18"),
                    Genre = "Airlines",
                    Price = 1.000M,
                    Rating = "Thương Gia"
                },
                new bay
                {
                    Title = "1484",
                    ReleaseDate = DateTime.Parse("2022-5-12"),
                    Genre = "Bamboo Airways",
                    Price = 1.000M,
                    Rating = "Thương Gia"
                },
                new bay
                {
                    Title = "1304",
                    ReleaseDate = DateTime.Parse("2021-2-11"),
                    Genre = "Jetstar Pacific",
                    Price = 49.99M,
                    Rating = "Thường"
                }
                );
                context.SaveChanges();//lưu dữ liệu
            }
        }
    }
}