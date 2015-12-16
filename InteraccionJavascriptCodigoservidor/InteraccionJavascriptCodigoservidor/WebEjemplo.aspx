<%--

Codecofe.com

Email: contact@codecofe.com
Skype: jlrodriguez.codecofe

--%>

<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebEjemplo.aspx.cs" Inherits="InteraccionJavascriptCodigoservidor.WebEjemplo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Ejemplo Interacci&oacute;n JavaScript y C&oacute;digo Servidor</title>

    <%--referencia jquery--%>
    <script src="http://code.jquery.com/jquery-2.1.4.min.js" type="text/javascript"></script>


    <script type="text/javascript">
        // Variables globales.
        var Numero1, Numero2;

        function Sumar() {
            ProcesarDatos('Sumar');
        }

        function Multiplicar() {
            ProcesarDatos('Multiplicar');
        }

        // Función obtiene datos de controles y asigna parametros.
        function ProcesarDatos(comando) {

            Numero1 = $('#txtPrimerNumero').val();
            Numero2 = $('#txtSegundoNumero').val();

            var parametros = { Comando: comando, Valor1: Numero1, Valor2: Numero2 };

            // Convierte json a cadena.
            // Envia parametros al método RaiseCallbackEvent de C#.
            UsaCallback(JSON.stringify(parametros));
        }

        // Función que obtiene respuesta del método RaiseCallbackEvent por medio del parametro _callbackResult.
        function HandleEvent(result, context) {

            $('#dvResultado').html('');

            // Verifica si resultado no es vacio.
            if (result != '') {
                $('#dvResultado').html('<span><strong> EL RESULTADO ES ' + result + ' </strong></span>')
            }
        }

    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Ejemplo javascript y c&oacute;digo servidor</h1>
            <br />
            <br />
            Primer N&uacute;mero:
           <input type="text" id="txtPrimerNumero" />
            <br />
            <br />
            Segundo N&uacute;mero:
            <input type="text" id="txtSegundoNumero" />
            <br />
            <br />
            <div id="dvResultado"></div>
            <br />
            <br />
            <input type="button" value="Sumar" onclick="Sumar()" />&nbsp;&nbsp;
            <input type="button" value="Multiplicar" onclick="Multiplicar()" />
        </div>
    </form>
</body>
</html>
