using System.Drawing;

namespace SisConv.Domain.Helpers
{
    public interface IConversor
    {
        byte[] ImagemParaByte(Image imagem);
        Image ByteParaImagem(byte[] bytes);
    }
}