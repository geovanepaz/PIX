//using Core.ViewModels.Login;
//using FluentValidation;
//using Microsoft.Extensions.DependencyInjection;
//using Produto.Application.Services;
//using Produto.Application.ViewModels;
//using Produto.Application.ViewModels.Produto;
//using Produto.Domain;
//using Produto.Infra.Contexts;
//using Produto.Infra.Repositories;

//namespace Produto.Application.IoC
//{
//    public static class NativeInjectorBootStrapper
//    {
//        public static void ResolveDependencies(this IServiceCollection services)
//        {
//            //Validator 
//            services.AddTransient<IValidator<LoginRequest>, LoginValidator>();
//            services.AddTransient<IValidator<UsuarioRequest>, UsuarioValidator>();
//            services.AddTransient<IValidator<ProdutoRequest>, ProdutoValidator>();
//            services.AddTransient<IValidator<CategoriaRequest>, CategoriaValidator>();
//            services.AddTransient<IValidator<ProdutoUpdateRequest>, ProdutoUpdateValidator>();

//            services.AddScoped<IProdutoRepository, ProdutoRepository>();
//            services.AddScoped<IProdutoAppService, ProdutoAppService>();
//            services.AddScoped<IEstoqueService, EstoqueService>();
//            services.AddScoped<CatalogoContext>();
//        }
//    }
//}
