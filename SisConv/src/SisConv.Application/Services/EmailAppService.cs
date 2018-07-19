using AutoMapper;
using SisConv.Application.Interfaces.Repository;
using SisConv.Application.ViewModels;
using SisConv.Domain.Entities;
using SisConv.Domain.Interfaces.Services;
using SisConv.Domain.Services;

namespace SisConv.Application.Services
{
	public class EmailAppService :  IEmailAppService
	{
		private readonly IEmailServices _emailServices;
		
		public EmailAppService(IEmailServices emailServices) 
		{
			_emailServices = emailServices;
			
		}

		public void EnviarEmail(ConvocadoViewModel convocacao)
		{
			var admin = Mapper.Map<ConvocadoViewModel, Convocado>(convocacao);
			_emailServices.EnviarEmail(admin);
		}
	}
}