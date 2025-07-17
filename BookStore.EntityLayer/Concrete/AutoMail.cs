using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.EntityLayer.Concrete
{
    [NotMapped]
    public class AutoMail
    {
        public string ToEmail { get; set; }
        public string Subject = "📚 Booksaw’a Hoş Geldiniz! Okuma Yolculuğunuz Başlıyor! 🎉";
        public string Body = @"
        <p>Merhaba,</p>

        <p>Booksaw ailesine katıldığınız için çok mutluyuz!</p>
        <p>Binlerce kitap arasında dilediğiniz türde eseri keşfetmeniz için buradayız.</p>
        <p><strong>Üyeliğinizle birlikte sizi bekleyen ayrıcalıklardan bazıları:</strong></p>
        <ul>
        <li> ✨ Kişiselleştirilmiş kitap önerileri </li>
        <li> 📦 Hızlı ve güvenli teslimat </li>
        <li> 💬 Okur yorumları ve puanlamalar </li>
        <li> 🎁 Özel kampanya ve indirimler </li>
        </ul>
        <p><strong>Hemen okumaya başlamak için sizi sitemize bekliyoruz:</strong></p>        
        <p>👉 www.booksaw.com</p>        
        <p>Sorularınız veya önerileriniz için bize her zaman ulaşabilirsiniz.</p>
        <p>☕ Keyifli okumalar! 📖</p>
        <p>Sevgilerle,</p>
        <p>Booksaw Ekibi 🤎</p>
        <p> 📧 info@booksaw.com </p>
        <p> 📞 0987 654 32 10 </p>";
    }
}
