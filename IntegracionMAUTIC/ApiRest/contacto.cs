using System;
using System.Collections.Generic;
using System.Text;

namespace IntegracionCRM.ApiRest
{
    class contactoMautic
    {
        public dynamic contacto()
        {
            string json = @"
                        {
                        ""landing"":""landing2"",
                        ""crm"":""crm2"",
                        ""cedula"":""cedula2"",
                        ""afiliadafb"":""afiliadafb2"",
                        ""afiliadaweb"":""afiliadaweb2"",
                        ""tipocliente"":tipocliente2,
                        ""categoriasocia"":""categoriasocia2"",
                        ""ultimacompra"":""ultimacompra2"",
                        ""fpp"":""fpp2"",
                        ""tienda"":""tienda2"",
                        ""semana"":""semana2"",
                        ""firstname"":""firstname2"",
                        ""lastname"":""lastname2"",
                        ""email"":""email2"",
                        ""mobile"":""mobile2"",
                        ""phone"": ""phone2"",
                        ""address1"":""address12"",
                        ""city"": ""city2"",
                        ""provincia"":""provincia2"",
                        ""country"":""Ecuador"",
                        ""last_active"":""last_active2""
                        }
                        ";

            return json;
        }
    }
}
