using Microsoft.AspNetCore.Mvc;

namespace NETCoreWebAPISQLServerAzure.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        [HttpGet("ConsultarSQLServer")]
        public JsonResult Consultar(int ID)
        {
            var Consulta = new StorageAzure();
            var Lista = Consulta.Consulta(ID);

            return new JsonResult(Lista);
        }

        [HttpGet("AlmacenarSQLServer")]
        public string Almacenar(string Nombre, string Sexo, int year_adopcion, string esterilizacion, string direccion)
        {
            var Almacena = new StorageAzure();
            bool resultado = Almacena.Almacenar(Nombre, Sexo, year_adopcion, esterilizacion, direccion);

            if (resultado == true)
                return "Alamacenado en SQL Server sobre Azure";
            else
                return "No almacenado";
        }

   
    }
}
