using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace Ejercicio_SOAP
{
    /// <summary>
    /// Descripción breve de WS_Personas
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class WS_Personas : System.Web.Services.WebService
    {


        [WebMethod]
        public string HelloWorld()
        {
            return "Hola a todos";
        }

        [WebMethod]
        public List<Personas> GetPersonasXML()
        {
            using (AdventureWorksLT2017Entities db = new AdventureWorksLT2017Entities())
            {
                return db.Personas.ToList();
            }
            /*Para ejecutar este método:
             * 
             * 
            WS_PersonasSoapClient personasSoapClient = new WS_PersonasSoapClient();
            List<Personas> p = new List<Personas>();
            p = personasSoapClient.GetPersonasXML().ToList();

            foreach (var a in p)
            {
                Console.WriteLine("Persona {0}:\nNombre: {1}, Apellidos: {2}, NIF: {3}, Dirección: {4}, Ciudad: {5}, Estado civil: {6}," +
                    "Sexo: {7}, Código postal: {8}, Provincia: {9}", a.ID, a.nombre, a.apellidos, a.NIF, a.direccion, a.ciudad, a.estadoCivil,
                    a.sexo, a.codigoPostal, a.provincia);
            }
            */
        }

        [WebMethod]
        public Personas AddPersonasXML(string nombre, string apellidos, string nif, string direccion, string ciudad, string estadoCivil,
            string sexo, string codigoPostal, string provincia)
        {
            using (AdventureWorksLT2017Entities db = new AdventureWorksLT2017Entities())
            {
                Personas p = new Personas();

                p.nombre = nombre;
                p.apellidos = apellidos;
                p.NIF = nif;
                p.direccion = direccion;
                p.ciudad = ciudad;
                p.estadoCivil = estadoCivil;
                p.sexo = sexo;
                p.codigoPostal = codigoPostal;
                p.provincia = provincia;

                db.Personas.Add(p);
                db.SaveChanges();
                return p;
            }

            /* Para ejecutar este método:
             * 
            WS_PersonasSoapClient personasSoapClient = new WS_PersonasSoapClient();
            Personas per = new Personas();

            per = personasSoapClient.AddPersonasXML("Pepe", "Gonzalez Perez", "12349H", "Fragoso 10", "Vigo", "Casado", "Masculino", "36204", "Pontevedra");
            Console.WriteLine(per.NIF + ", " + per.nombre + ", " + per.apellidos);
            */
        }

        [WebMethod]
        public Personas UpdatePersonasXML(int id, string nombre, string apellidos, string nif, string direccion, string ciudad, string estadoCivil,
        string sexo, string codigoPostal, string provincia)
        {
            using (AdventureWorksLT2017Entities db = new AdventureWorksLT2017Entities())
            {
               var persona = db.Personas.Find(id);

                persona.nombre = nombre;
                persona.apellidos = apellidos;
                persona.NIF = nif;
                persona.direccion = direccion;
                persona.ciudad = ciudad;
                persona.estadoCivil = estadoCivil;
                persona.sexo = sexo;
                persona.codigoPostal = codigoPostal;
                persona.provincia = provincia;

                db.SaveChanges();
                return persona;
            }
            /* Para ejecutar este método:
             * 
            WS_PersonasSoapClient personasSoapClient = new WS_PersonasSoapClient();
            Personas per = new Personas();

            per = personasSoapClient.UpdatePersonasXML(5, "Rosa", "Vallejo Perez", "5678G", "Teis 10", "Vigo", "Soltera", "Femenino", "36204", "Pontevedra");
            Console.WriteLine("Actualizada persona " + per.id + ":\n" + per.NIF + ", " + per.nombre + ", " + per.apellidos);
            */
        }

        [WebMethod]
        public string DeletePersonasXML(int id)
        {
            using (AdventureWorksLT2017Entities db = new AdventureWorksLT2017Entities())
            {
                db.Personas.Remove(db.Personas.Find(id));
                db.SaveChanges();
                return "Borrada persona con ID" + id;
            }

            /* Para ejecutar este método:
             * 
            WS_PersonasSoapClient personasSoapClient = new WS_PersonasSoapClient();
            Personas per = new Personas();

            Console.WriteLine(personasSoapClient.DeletePersonasXML(6));

            Console.ReadKey();
            */
        }
    }
}


