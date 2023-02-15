using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Shopping_Cart_API.Data;
using Shopping_Cart_API.Repository;
using Shopping_Cart_API.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shopping_Cart_API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Shopping_Cart_API", Version = "v1" });
            });

            //configuring connection string services
            services.AddDbContext<ShoppingCartDbContext>(options =>
            {
            options.UseSqlServer(Configuration.GetConnectionString("SqlConnection"));
            });

            #region AddTransients

            //User
            services.AddTransient<IUser, UserRepo>();
            services.AddTransient<UserDetailsServices, UserDetailsServices>();    
            
            //Product
          //  services.AddTransient<IProduct, ProductRepo>();
           // services.AddTransient<ProductService, ProductService>(); 
            
            //Cart
         //   services.AddTransient<ICart, CartRepo>();
           // services.AddTransient<CartService, CartService>(); 
            
            //order
         //   services.AddTransient<IOrder, OrderRepo>();
         //   services.AddTransient<OrderService, OrderService>(); 
            
            //Payment
          //  services.AddTransient<IPayment, PaymentRepo>();
          //  services.AddTransient<PaymentService, PaymentService>(); 
            
            //Address
         //   services.AddTransient<IAddress, AddressRepo>();
          //  services.AddTransient<AddressService, AddressService>(); 
            
            //Feedback
         //   services.AddTransient<IFeedBack, FeedBackRepo>();
          //  services.AddTransient<FeedbackService, FeedbackService>();

            #endregion
        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Shopping_Cart_API v1"));
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
