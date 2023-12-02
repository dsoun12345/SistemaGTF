using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using Dropbox.Api;
using Dropbox.Api.Files;
using Xamarin.Essentials;
using Xamarin.Forms;
using System.Net.Http;
using System.Threading.Tasks;
using ZXing;
using ZXing.Mobile;
using ZXing.Net.Mobile.Forms;
using System.Collections.Generic; // Agregar esta directiva
using Newtonsoft.Json;

namespace proyectoconnect
{

    public partial class MainPage : ContentPage
    {
        private List<string> registros = new List<string>();

        private const string DropboxAppKey = "5dl2ukw5340uow1";
        private string DropboxAccessToken = "sl.Bq9SMtGarPdJlaTs3qnOzPtD7uW6ICUJ2gfcnLmdk_cX28saE-iDzMB6QQMl1RkZeTorl7YaNra_BU7wTm98QJmlf7iGT7-QFCzGcBAXthXum1fWssGru9MOiwvM8e0wq7CdDarin_VhtObMrOAQeSg";
        public MainPage()
        {
            InitializeComponent();


        }

        private async Task<string> RefrescarAccessToken(string refreshToken)
        {
            var httpClient = new HttpClient();
            var content = new FormUrlEncodedContent(new[]
            {
        new KeyValuePair<string, string>("refresh_token", refreshToken),
        new KeyValuePair<string, string>("grant_type", "refresh_token"),
        new KeyValuePair<string, string>("client_id", DropboxAppKey),
        new KeyValuePair<string, string>("client_secret", "5dl2ukw5340uow1"),
    });

            // Enviar la solicitud y obtener la respuesta
            var response = await httpClient.PostAsync("https://www.dropbox.com/1/oauth2/authorize_submit", content);

            // Verificar si la solicitud fue exitosa
            if (response.IsSuccessStatusCode)
            {
                // Leer y procesar el contenido de la respuesta
                var responseContent = await response.Content.ReadAsStringAsync();
                var responseDictionary = JsonConvert.DeserializeObject<Dictionary<string, string>>(responseContent);

                if (responseDictionary.ContainsKey("access_token"))
                {
                    DropboxAccessToken = responseDictionary["access_token"];
                    return DropboxAccessToken;
                }
                else
                {
                    // Maneja el caso en el que 'access_token' no está presente en la respuesta
                    // Puedes registrar un error o lanzar una excepción.
                    return null;
                }
            }
            else
            {
                // Manejar el caso en que la solicitud no fue exitosa
                // Puedes registrar un error o lanzar una excepción.
                return null;
            }
        }

        private async Task<bool> ValidarAccessToken()
        {
            using (var dbx = new DropboxClient(DropboxAccessToken))
            {
                try
                {
                    // Intenta hacer una llamada simple a la API para validar el token de acceso
                    await dbx.Files.ListFolderAsync(string.Empty);
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }

        private void ActualizarClienteDropbox(string accessToken)
        {
            DropboxAccessToken = accessToken;
        }

        private async void BuscarDatos_Clicked(object sender, EventArgs e)
        {
            // Verifica si el token de acceso aún es válido
            var esValido = await ValidarAccessToken();
            if (!esValido)
            {
                // El token de acceso ha expirado, refrescarlo
                var accessTokenRefrescado = await RefrescarAccessToken("YPEnzC35Tl4AAAAAAAACi219ZxdkcRsu6JsofUwFbUs");
                // Actualiza el cliente de Dropbox con el nuevo token de acceso
                ActualizarClienteDropbox(accessTokenRefrescado);
            }
            string textoBuscado = BusquedaEntry.Text;

            // Realiza la búsqueda en el contenido del archivo hola.txt
            string contenido = await DescargarContenidoDeDropbox();

            if (!string.IsNullOrWhiteSpace(contenido))
            {
                string[] lineas = contenido.Split(new string[] { ";" }, StringSplitOptions.RemoveEmptyEntries);

                // Busca todas las líneas que contienen el texto ingresado
                var lineasEncontradas = new List<string>();

                foreach (var linea in lineas)
                {
                    // Verifica si alguna parte de la línea contiene el texto buscado
                    string[] campos = linea.Split(',');
                    foreach (var campo in campos)
                    {
                        // Puedes ajustar la lógica de búsqueda según tus necesidades
                        if (campo.Contains(textoBuscado))
                        {
                            lineasEncontradas.Add(linea);
                            break; // Rompe el bucle para evitar agregar la misma línea más de una vez
                        }
                    }
                }

                // Elimina las filas anteriores del Grid
                ResultadoGrid.Children.Clear();

                if (lineasEncontradas.Any())
                {


                    // Agregar etiquetas y botones para cada resultado al Grid
                    for (int i = 0; i < lineasEncontradas.Count; i++)
                    {

                        // Etiqueta para mostrar el resultado
                        var etiqueta = new Label
                        {
                            Text = "",
                            TextColor = Color.White,
                            FontSize = 16,
                            FormattedText = new FormattedString()
                            {
                                Spans =
                        {
                               // Agregar el número de registro como parte del texto utilizando un Span
                            new Span { Text = $"Registro {i + 1}: "+ "\n"+ "\n", FontAttributes = FontAttributes.Bold, ForegroundColor = Color.White, FontSize = 20 },
                            new Span { Text = "ID: ", FontAttributes = FontAttributes.Bold },
                            new Span { Text = ObtenerValorCampo(lineasEncontradas[i], "ID") + "\n"+ "\n" },
                            new Span { Text = "Fecha de Entrega: ", FontAttributes = FontAttributes.Bold },
                            new Span { Text = ObtenerValorCampo(lineasEncontradas[i], "Fecha de Entrega") + "\n"+ "\n" },
                            new Span { Text = "Código de Tarjeta: ", FontAttributes = FontAttributes.Bold },
                            new Span { Text = ObtenerValorCampo(lineasEncontradas[i], "Código de Tarjeta") + "\n"+ "\n" },
                            new Span { Text = "DNI: ", FontAttributes = FontAttributes.Bold },
                            new Span { Text = ObtenerValorCampo(lineasEncontradas[i], "DNI") + "\n"+ "\n" },
                            new Span { Text = "Cantidad: ", FontAttributes = FontAttributes.Bold },
                            new Span { Text = ObtenerValorCampo(lineasEncontradas[i], "Cantidad") + "\n"+ "\n" },
                            new Span { Text = "Descripción: ", FontAttributes = FontAttributes.Bold },
                            new Span { Text = ObtenerValorCampo(lineasEncontradas[i], "Descripción") + "\n"+ "\n" },
                            new Span { Text = "Tamaño de Corte: ", FontAttributes = FontAttributes.Bold },
                            new Span { Text = ObtenerValorCampo(lineasEncontradas[i], "Tamaño de Corte") + "\n"+ "\n" },
                            new Span { Text = "Tipo de Corte: ", FontAttributes = FontAttributes.Bold },
                            new Span { Text = ObtenerValorCampo(lineasEncontradas[i], "Tipo de Corte") + "\n"+ "\n" },
                            new Span { Text = "Material: ", FontAttributes = FontAttributes.Bold },
                            new Span { Text = ObtenerValorCampo(lineasEncontradas[i], "Material") + "\n"+ "\n" },
                            new Span { Text = "Cliente: ", FontAttributes = FontAttributes.Bold },
                            new Span { Text = ObtenerValorCampo(lineasEncontradas[i], "Cliente") + "\n"+ "\n" },
                            new Span { Text = "Teléfono: ", FontAttributes = FontAttributes.Bold },
                            new Span { Text = ObtenerValorCampo(lineasEncontradas[i], "Teléfono") + "\n"+ "\n" },
                            new Span { Text = "Verificación: ", FontAttributes = FontAttributes.Bold },
                            new Span { Text = ObtenerValorCampo(lineasEncontradas[i], "Verificación") + "\n"+ "\n" }
                        }
                            }
                        };
                        ResultadoGrid.Children.Add(etiqueta, 0, i);

                        // Muestra la verificación después del campo "Material"
                        var botonVerificar = new ImageButton
                        {
                            Source = "verificar.png",
                            Style = (Style)Resources["ImageButtonStyle"],
                            CommandParameter = lineasEncontradas[i] // Pasa el registro como parámetro al botón
                        };
                        botonVerificar.Clicked += BotonVerificar_Clicked; // Asocia el manejador de eventos
                        ResultadoGrid.Children.Add(botonVerificar, 1, i); // Coloca el botón en la columna 1 y la fila i

                        // Crear botón "Anular" para el registro
                        var botonAnular = new ImageButton
                        {
                            Source = "anular.png",
                            Style = (Style)Resources["ImageButtonStyle"],
                            CommandParameter = lineasEncontradas[i] // Pasa el registro como parámetro al botón
                        };
                        botonAnular.Clicked += BotonAnular_Clicked; // Asocia el manejador de eventos
                        ResultadoGrid.Children.Add(botonAnular, 2, i); // Coloca el botón en la columna 2 y la fila i
                    }
                }
            }
        }



        private async void BotonVerificar_Clicked(object sender, EventArgs e)
        {
            var botonVerificar = (ImageButton)sender;

            // Verifica si el botón ya está deshabilitado (ya se hizo la verificación)
            if (!botonVerificar.IsEnabled)
            {
                return;
            }

            var registroVerificar = (string)botonVerificar.CommandParameter;

            // Verifica si el registro ya contiene "ok"
            if (registroVerificar.Contains("ok"))
            {
                // Si ya contiene "ok", no hagas nada
                return;
            }

            // Realiza la lógica de verificación aquí y agrega la verificación "ok" al registro
            registroVerificar += "ok";

            // Descarga el contenido actual del archivo desde Dropbox
            string contenido = await DescargarContenidoDeDropbox();

            // Encuentra el índice del registro original en el contenido
            int indice = -1;
            string[] lineas = contenido.Split(new string[] { ";" }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < lineas.Length; i++)
            {
                if (lineas[i] == (string)botonVerificar.CommandParameter)
                {
                    indice = i;
                    break;
                }
            }

            if (indice != -1)
            {
                // Reemplaza el registro original con el registro verificado
                lineas[indice] = registroVerificar;
                // Reconstruye el contenido con los cambios
                contenido = string.Join(";", lineas);
                // Sube el contenido actualizado a Dropbox
                await SubirContenidoADropbox(contenido);

                // Actualiza la etiqueta correspondiente en el Grid
                var etiqueta = ResultadoGrid.Children.LastOrDefault(c => Grid.GetColumn(c) == 0 && Grid.GetRow(c) == ResultadoGrid.Children.IndexOf(botonVerificar));
                if (etiqueta is Label label)
                {
                    label.Text = registroVerificar;
                }

                // Deshabilita el botón después de la verificación
                botonVerificar.IsEnabled = false;
            }
            BuscarDatos_Clicked(sender, e);
        }

        private async void BotonAnular_Clicked(object sender, EventArgs e)
        {
            var botonAnular = (ImageButton)sender;

            // Verifica si el botón ya está deshabilitado (ya se hizo la anulación)
            if (!botonAnular.IsEnabled)
            {
                return;
            }

            var registroAnular = (string)botonAnular.CommandParameter;

            // Realiza la lógica de anulación aquí y agrega la anulación "" al registro
            registroAnular = registroAnular.Replace("ok", "");

            // Descarga el contenido actual del archivo desde Dropbox
            string contenido = await DescargarContenidoDeDropbox();

            // Encuentra el índice del registro original en el contenido
            int indice = -1;
            string[] lineas = contenido.Split(new string[] { ";" }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < lineas.Length; i++)
            {
                if (lineas[i] == (string)botonAnular.CommandParameter)
                {
                    indice = i;
                    break;
                }
            }

            if (indice != -1)
            {
                // Reemplaza el registro original con el registro anulado
                lineas[indice] = registroAnular;
                // Reconstruye el contenido con los cambios
                contenido = string.Join(";", lineas);
                // Sube el contenido actualizado a Dropbox
                await SubirContenidoADropbox(contenido);

                // Actualiza la etiqueta correspondiente en el Grid
                var etiqueta = ResultadoGrid.Children.LastOrDefault(c => Grid.GetColumn(c) == 0 && Grid.GetRow(c) == ResultadoGrid.Children.IndexOf(botonAnular));
                if (etiqueta is Label label)
                {
                    label.Text = registroAnular;
                }

                // Habilita el botón de verificar después de la anulación
                var botonVerificar = ResultadoGrid.Children.LastOrDefault(c => Grid.GetColumn(c) == 1 && Grid.GetRow(c) == ResultadoGrid.Children.IndexOf(botonAnular));
                if (botonVerificar is ImageButton btnVerificar)
                {
                    btnVerificar.IsEnabled = true;
                }

                // Deshabilita el botón de anular después de la anulación
                botonAnular.IsEnabled = false;
            }
            BuscarDatos_Clicked(sender, e);
        }

        private async Task SubirContenidoADropbox(string contenido)
        {
            using (var dbx = new DropboxClient(DropboxAccessToken, new DropboxClientConfig()
            {
                HttpClient = new HttpClient(new HttpClientHandler())
            }))
            {
                using (var memStream = new MemoryStream(System.Text.Encoding.UTF8.GetBytes(contenido)))
                {
                    await dbx.Files.UploadAsync(
                        "/hola.txt",
                        WriteMode.Overwrite.Instance,
                        body: memStream);
                }
            }
        }
        private async Task<string> DescargarContenidoDeDropbox()
        {
            using (var dbx = new DropboxClient(DropboxAccessToken, new DropboxClientConfig()
            {
                HttpClient = new HttpClient(new HttpClientHandler())
            }))
            {
                try
                {
                    var fileMetadata = await dbx.Files.DownloadAsync("/hola.txt");
                    return await fileMetadata.GetContentAsStringAsync();
                }
                catch (Exception ex)
                {
                    Debug.WriteLine("Error al descargar el archivo: " + ex.Message);
                    return string.Empty;
                }
            }
        }

        private async void EscanearCodigo_Clicked(object sender, EventArgs e)
        {
            // Configuración del escáner
            var options = new MobileBarcodeScanningOptions
            {
                PossibleFormats = new List<BarcodeFormat>
        {
            BarcodeFormat.QR_CODE,
            BarcodeFormat.CODE_128,
            BarcodeFormat.EAN_13
        }
            };

            // Crear la página del escáner
            var scanPage = new ZXingScannerPage(options)
            {
                DefaultOverlayTopText = "Alinea el código de barras dentro del marco",
                DefaultOverlayBottomText = "El escaneo es automático",
            };

            scanPage.OnScanResult += (result) =>
            {
                scanPage.IsScanning = false;

                Device.BeginInvokeOnMainThread(async () =>
                {
                    await Navigation.PopAsync();
                    BusquedaEntry.Text = result.Text; // Mostrar el código en el Entry

                    // Realizar la búsqueda automáticamente
                    BuscarDatos_Clicked(sender, e);
                });
            };

            // Mostrar la página del escáner
            await Navigation.PushAsync(scanPage);
        }
        private string ObtenerValorCampo(string linea, string nombreCampo)
        {
            var campos = linea.Split(',');

            // Iterar sobre los campos y buscar el nombre del campo
            foreach (var campo in campos)
            {
                var keyValue = campo.Split(':');
                if (keyValue.Length == 2)
                {
                    var nombre = keyValue[0].Trim();
                    var valor = keyValue[1].Trim();

                    if (nombre.Equals(nombreCampo))
                    {
                        return valor;
                    }
                }
            }

            // Devuelve una cadena vacía si el campo no se encuentra
            return string.Empty;
        }

    }
}
