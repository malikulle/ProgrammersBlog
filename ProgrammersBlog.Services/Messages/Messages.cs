using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammersBlog.Services.Messages
{
    public static class Messages
    {
        public static class Comment
        {
            public static string NotFound(bool isPlural)
            {
                if (isPlural) return "Hiç bir yorum bulunamadı.";
                return "Böyle bir yorum bulunamadı.";
            }

            public static string Add(string createdByName)
            {
                return $"Sayın {createdByName}, yorumunuz başarıyla eklenmiştir.";
            }

            public static string Update(string createdByName)
            {
                return $"{createdByName} tarafından eklenen yorum başarıyla güncellenmiştir.";
            }
            public static string Delete(string createdByName)
            {
                return $"{createdByName} tarafından eklenen yorum başarıyla silinmiştir.";
            }
            public static string HardDelete(string createdByName)
            {
                return $"{createdByName} tarafından eklenen yorum başarıyla veritabanından silinmiştir.";
            }

            public static string UndoDelete(string deletedCommentCreatedByName)
            {
                return $"{deletedCommentCreatedByName} tarafından eklenen yorum başarıyla geri alındı.";
            }
        }

    }
}
