/*
* Codecofe.com
*
* Email: contact@codecofe.com
* Skype: jlrodriguez.codecofe
* 
*/

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;

namespace InteraccionJavascriptCodigoservidor
{
    // Se aplica herencia de ICallbackEventHandler a clase para aplicar comportamiento.
    public partial class WebEjemplo : System.Web.UI.Page, System.Web.UI.ICallbackEventHandler
    {
        // Variable de respuesta para javascript.
        private string _callbackResult = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            // - Arg - Argumento pasado desde el cliente al servidor.
            // - HandleEvent - Nombre del controlador de eventos del lado del cliente que recibe el resultado del evento de servidor.
            // - Contexto - script del lado del cliente que se evalúa en el cliente antes de la inicialización.
            string callbackReference = Page.ClientScript.GetCallbackEventReference(
                this, "arg", "HandleEvent", "context");

            // UsaCallback es el nombre del evento que se invocara del lado del cliente. 
            // El parametro arg envia valores al evento servidor.
            string callbackScript = "function UsaCallback(arg, context) {" + callbackReference + ";}";

            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "UsaCallback", callbackScript, true);
        }

        /// <summary>
        /// Evento de servidor.
        /// </summary>
        /// <param name="eventArg">Parametros enviados del lado de cliente.</param>
        public void RaiseCallbackEvent(string eventArg)
        {
            decimal vResultado = 0;

            // Convierte cadena de formato json a diccionario clave valor.
            Dictionary<string, string> vValores = JsonConvert.DeserializeObject<Dictionary<string, string>>(eventArg);

            if (vValores.Any())
            {
                // Obtiene valor de comando de lista de valores.
                string vComando = vValores["Comando"];

                decimal vNumero1;
                decimal vNumero2;

                decimal.TryParse(vValores["Valor1"], out vNumero1);
                decimal.TryParse(vValores["Valor2"], out vNumero2);

                // Selecciona el tipo de comando.
                switch (vComando)
                {
                    case "Sumar":
                        vResultado = vNumero1 + vNumero2;
                        break;
                    case "Multiplicar":
                        vResultado = vNumero1 * vNumero2;
                        break;
                    // Otros eventos ...
                    default:
                        break;
                }
            }

            // Asigna resultado de proceso.
            _callbackResult = vResultado.ToString();

        }

        /// <summary>
        /// Metodo heredado de ICallbackEventHandler.
        /// </summary>
        /// <returns>retona valor de callback.</returns>
        public string GetCallbackResult()
        {
            return _callbackResult;
        }
    }
}