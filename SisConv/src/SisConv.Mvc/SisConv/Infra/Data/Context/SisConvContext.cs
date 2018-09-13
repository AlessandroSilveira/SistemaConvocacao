using System.Data.Entity;
using SisConv.Application.ViewModels;

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

        public DbSet<ClienteViewModel> ClienteViewModels { get; set; }

        public DbSet<ProcessoViewModel> ConvocacaoViewModels { get; set; }

        public DbSet<CargoViewModel> CargoViewModels { get; set; }

        public DbSet<ConvocadoViewModel> ConvocadoViewModels { get; set; }

        public DbSet<DadosConvocadosViewModel> DadosConvocadosViewModels { get; set; }

        public DbSet<DocumentacaoViewModel> DocumentacaoViewModels { get; set; }

        public DbSet<PessoaViewModel> PessoaViewModels { get; set; }

		public System.Data.Entity.DbSet<SisConv.Application.ViewModels.TipoDocumentoViewModel> TipoDocumentoViewModels { get; set; }

		public System.Data.Entity.DbSet<SisConv.Application.ViewModels.DocumentoCandidatoViewModel> DocumentoCandidatoViewModels { get; set; }
	}
}