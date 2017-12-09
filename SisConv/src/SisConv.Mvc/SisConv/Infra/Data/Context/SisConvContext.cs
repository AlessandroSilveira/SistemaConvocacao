using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SisConv.Infra.Data.Context
{
    public class SisConvContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public SisConvContext() : base("name=SisConvContext")
        {
        }

        public System.Data.Entity.DbSet<SisConv.Application.ViewModels.ClienteViewModel> ClienteViewModels { get; set; }

        public System.Data.Entity.DbSet<SisConv.Application.ViewModels.ProcessoViewModel> ConvocacaoViewModels { get; set; }

        public System.Data.Entity.DbSet<SisConv.Application.ViewModels.CargoViewModel> CargoViewModels { get; set; }

        public System.Data.Entity.DbSet<SisConv.Application.ViewModels.ConvocadoViewModel> ConvocadoViewModels { get; set; }

		public System.Data.Entity.DbSet<SisConv.Application.ViewModels.DadosConvocadosViewModel> DadosConvocadosViewModels { get; set; }

        public System.Data.Entity.DbSet<SisConv.Application.ViewModels.DocumentacaoViewModel> DocumentacaoViewModels { get; set; }
    }
}
