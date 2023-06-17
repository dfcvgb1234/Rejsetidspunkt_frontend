using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Rejsetidspunkt.Services
{
    internal class XMLService<T>
    {
        public static T DeserializeResponse(string responseContent)
        {
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(T));

                using (StringReader reader = new StringReader(responseContent))
                {
                    T response = (T)serializer.Deserialize(reader);
                    return response;
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
                if (ex.InnerException != null)
                {
                    Console.WriteLine(ex.InnerException.ToString());

                    if (ex.InnerException.InnerException != null)
                    {
                        Console.WriteLine(ex.InnerException.InnerException.ToString());
                    }
                }

                return default(T);
            }

        }
    }
}
