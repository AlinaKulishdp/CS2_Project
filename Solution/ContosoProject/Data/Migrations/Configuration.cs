namespace Data.Migrations
{
    using Domain.Entities;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Data.EFData.ProjectContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Data.EFData.ProjectContext context)
        {
            var permissions = new List<Permission>
            {
                new Permission{Name = "Список клиентов", Type = Domain.PermissionType.ListClient},
                new Permission{Name = "Добавление клиента", Type = Domain.PermissionType.NewClient},
                new Permission{Name = "Редактирование клиента", Type = Domain.PermissionType.EditClient},
                new Permission{Name = "Список заказов", Type = Domain.PermissionType.ListOrder},
                new Permission{Name = "Новый заказ", Type = Domain.PermissionType.NewOrder},
                new Permission{Name = "Редактирование заказа", Type = Domain.PermissionType.EditOrder},
                new Permission{Name = "Список товаров", Type = Domain.PermissionType.ListGoods},
                new Permission{Name = "Новый товар", Type = Domain.PermissionType.NewGoods},
                new Permission{Name = "Редактирование товара", Type = Domain.PermissionType.EditGoods},
                new Permission{Name = "Список пользователей", Type = Domain.PermissionType.ListUser},
                new Permission{Name = "Новый пользователь", Type = Domain.PermissionType.NewUser},
                new Permission{Name = "Редактирование пользователя", Type = Domain.PermissionType.EditUser},
                new Permission{Name = "Сохранить список клиентов", Type = Domain.PermissionType.SaveListClients},
                new Permission{Name = "Сохранить список заказов", Type = Domain.PermissionType.SaveListOrders},
                new Permission{Name = "Сохранить список товаров", Type = Domain.PermissionType.SaveListGoods},
                new Permission{Name = "Сохранить список пользователей", Type = Domain.PermissionType.SaveListUsers},
                new Permission{Name = "Печатать отчет по клиентам", Type = Domain.PermissionType.PrintReportClients},
                new Permission{Name = "Печатать отчет по заказам", Type = Domain.PermissionType.PrintReportOrders},
                new Permission{Name = "Печатать отчет по товарам", Type = Domain.PermissionType.PrintReportGoods},
                new Permission{Name = "Печатать отчет по пользователям", Type = Domain.PermissionType.PrintReportUsers},

                new Permission{Name = "Список ролей", Type = Domain.PermissionType.ListRoles},
                new Permission{Name = "Добавление роли", Type = Domain.PermissionType.NewRole},
                new Permission{Name = "Редактирование роли", Type = Domain.PermissionType.EditRole},
                new Permission{Name = "Редактирование категории товаров", Type = Domain.PermissionType.EditProductCategory}
            };

            var role = new Role { Name = "Administrator", Permissions = permissions };
            context.Roles.AddOrUpdate(x => x.Name, new Role[] { role });
            var info = new PersonalInfo { FirstName = "admin", LastName = "admin", MiddleName = "admin" };
            context.PersonalInfoes.AddOrUpdate(info);
            var admin = new User { Login = "admin", Password = "21232f297a57a5a743894a0e4a801fc3", Role = role, PersonalInfo = info };
            context.Users.AddOrUpdate(x => x.Login, new User[] { admin });


            context.SaveChanges();

        }
    }
}
