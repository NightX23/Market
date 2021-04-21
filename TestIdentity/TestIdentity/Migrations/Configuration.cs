namespace TestIdentity.Migrations
{
    using Microsoft.AspNet.Identity;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using TestIdentity.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<TestIdentity.Models.ApplicationDbContext>
    {
        //private ApplicationUserManager userManager;
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "TestIdentity.Models.ApplicationDbContext";
        }

        protected override void Seed(TestIdentity.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            ///*
            var departments = new List<Department>
            {
            new Department{Name="Contabilidad"},
            new Department{Name="Recursos Humanos"},
            new Department{Name="Ventas"},
            new Department{Name="Administración"},
            new Department{Name="Servicio al cliente"},
            new Department{Name="Contabilidad"}
            };

            departments.ForEach(d => context.Departments.Add(d));
            context.SaveChanges();

            var statuses = new List<Status>
            {
            new Status{Name="Activo"},
            new Status{Name="Inactivo"},
            };

            statuses.ForEach(s => context.Statuses.Add(s));
            context.SaveChanges();

            var positions = new List<Position>
            {
            new Position{Name="Gerente"},
            new Position{Name="Caja"},
            new Position{Name="Contable"}
            };

            positions.ForEach(p => context.Positions.Add(p));
            context.SaveChanges();

            var complainAndClaimStatuses = new List<ComplaintAndClaimStatus>
            {
                new ComplaintAndClaimStatus{Name = "Pendiente"},
                new ComplaintAndClaimStatus{Name = "En revisión"},
                new ComplaintAndClaimStatus{Name = "Resuelto"},
                new ComplaintAndClaimStatus{Name = "Cancelado"}
            };

            complainAndClaimStatuses.ForEach(c => context.ComplaintAndClaimStatuses.Add(c));
            context.SaveChanges();

            var complaintTypes = new List<ComplaintType>
            {
                new ComplaintType{Name = "Atención en el servicio"},
                new ComplaintType{Name = "Aplicación de pagos"},
                new ComplaintType{Name = "Artículos incautados"},
                new ComplaintType{Name = "Máquina de llamadas"},
                new ComplaintType{Name = "Cobros compulsivos"},
                new ComplaintType{Name = "Reporte en buró"},
                new ComplaintType{Name = "Eliminación de mora"},
                new ComplaintType{Name = "Aprobación pendiente"},
                new ComplaintType{Name = "Sucursal sin representante"}
                //new ComplaintType{Name = "Cobros a domicilio"}
            };
            complaintTypes.ForEach(c => context.ComplaintTypes.Add(c));
            context.SaveChanges();

            var rates = new List<Rate>
            {
                new Rate{Name = "Muy bueno"},
                new Rate{Name = "Bueno"},
                new Rate{Name = "Regular"},
                new Rate{Name = "Malo"}
            };
            rates.ForEach(r => context.Rates.Add(r));
            context.SaveChanges();

            var roles = new List<ApplicationRole>
            {
                new ApplicationRole{Name = "Customer"},
                new ApplicationRole{Name = "Employee"},
                new ApplicationRole{Name = "Admin"},
            };
            roles.ForEach(r => context.ApplicationRoles.Add(r));
            context.SaveChanges();

           /* var users = new List<ApplicationUser>
            {
                new ApplicationUser { UserName = String.Format("adm-{0}", "mpena"), Email = "mpena@domain.com", CreationDate = DateTime.Today },
                new ApplicationUser { UserName = String.Format("emp-{0}", "hramirez"), Email = "hramirez@domain.com", CreationDate = DateTime.Today },
                new ApplicationUser { UserName = String.Format("cus-{0}", "jdoe"), Email = "jdoe@gmail.com", CreationDate = DateTime.Today }
            };


            foreach (ApplicationUser user in users)
            {
                userManager.Create(user, "test123");
            }

            context.SaveChanges();

            var employees = new List<Employee>
            {
                new Employee{Id = users[0].UserName, IdentificationId = "402122654021", Name = "Marlon Peña", StatusId = 1, DepartmentId = 3, PositionId = 1},
                new Employee{Id = users[1].UserName, IdentificationId = "001534745201", Name = "Héctor Ramírez", StatusId = 1, DepartmentId = 1, PositionId = 1}
            };
            employees.ForEach(e => context.Employees.Add(e));
            context.SaveChanges();

            var customer = new Customer {
                Id = users[3].UserName,
                IdentificationId = "001298005512",
                Name = "John Doe",
                StatusId = 1
            };
            context.Customers.Add(customer);
            context.SaveChanges();
            
            userManager.AddToRole(users[0].Id, "Admin");
            userManager.AddToRole(users[1].Id, "Employee");
            userManager.AddToRole(users[2].Id, "Customer");
            context.SaveChanges();

            */
        }
    }
}
