using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace SisConv.Domain.Helpers
{
	public class Conversor : IConversor
	{
		public  byte[] ImagemParaByte(Image imagem)
		{
			using (var stream = new MemoryStream())
			{
				imagem.Save(stream, ImageFormat.Png);
				return stream.ToArray();
			}
		}

		public  Image ByteParaImagem(byte[] bytes)
		{
			using (var stream = new MemoryStream(bytes))
			{
				return Image.FromStream(stream);
			}
		}
	}
}