﻿using SisConv.Domain.Entities;
using SisConv.Domain.Services;

namespace SisConv.Domain.Interfaces.Services
{
	public interface IEmailServices
	{
		EnviaEmailBuilder EnviarEmail(Convocado convocacao);
	}
}